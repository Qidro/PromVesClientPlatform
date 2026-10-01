using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;

namespace PromVesClient.Service.TcpService
{
    public class TcpService
    {
        private TcpClient? _client;
        private NetworkStream? _stream;
        private CancellationTokenSource? _cts;

        private readonly ILogger<TcpService> _logger;

        public CancellationToken Token =>
            _cts?.Token ?? CancellationToken.None;

        public TcpService(ILogger<TcpService> logger)
        {
            _logger = logger;
        }

        // ============================================================
        // ПОДКЛЮЧЕНИЕ К СЕРВЕРУ
        // ============================================================

        public async Task ConnectAsync()
        {
            _client = new TcpClient();

            // Получаем локальный IPv4-адрес компьютера
            IPAddress ipAddress = await GetLocalIPAddressAsync();

            // Подключаемся к серверу весов
            await _client
                .ConnectAsync(ipAddress, 5002)
                .WaitAsync(TimeSpan.FromSeconds(5));

            _stream = _client.GetStream();

            _cts = new CancellationTokenSource();

            // Начинаем получать данные от сервера
            _ = ReceiveMessagesAsync(_cts.Token);
        }

        // ============================================================
        // ПОЛУЧЕНИЕ ЛОКАЛЬНОГО IP
        // ============================================================

        public async Task<IPAddress> GetLocalIPAddressAsync()
        {
            var host = await Dns.GetHostEntryAsync(
                Dns.GetHostName());

            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip;
                }
            }

            throw new Exception(
                "Локальный IPv4 адрес не найден.");
        }

        // ============================================================
        // ОТКЛЮЧЕНИЕ ОТ СЕРВЕРА
        // ============================================================

        public async Task DisconnectAsync()
        {
            try
            {
                _cts?.Cancel();

                _stream?.Dispose();

                _client?.Close();
                _client?.Dispose();
            }
            catch (Exception ex)
            {
                _logger.LogWarning(
                    ex,
                    "Ошибка при отключении от сервера");
            }
            finally
            {
                _cts?.Dispose();

                _cts = null;
                _stream = null;
                _client = null;
            }

            await Task.CompletedTask;
        }

        // ============================================================
        // ПОЛУЧЕНИЕ ДАННЫХ ОТ СЕРВЕРА
        // ============================================================

        public async Task ReceiveMessagesAsync(
            CancellationToken token)
        {
            try
            {
                byte[] buffer = new byte[4096];

                while (!token.IsCancellationRequested)
                {
                    if (_stream == null)
                        break;

                    // Таймаут ожидания данных — 10 секунд
                    using var timeoutCts =
                        CancellationTokenSource
                            .CreateLinkedTokenSource(token);

                    timeoutCts.CancelAfter(
                        TimeSpan.FromSeconds(10));

                    int count = await _stream.ReadAsync(
                        buffer,
                        timeoutCts.Token);

                    // Сервер закрыл соединение
                    if (count == 0)
                        break;

                    string message =
                        Encoding.UTF8.GetString(
                            buffer,
                            0,
                            count);

                    // Передаём полученное значение форме
                    MessageReceived?.Invoke(message);
                }
            }
            catch (IOException ex)
            {
                _logger.LogError(
                    ex,
                    "Ошибка ввода-вывода. " +
                    "Сервер разорвал соединение");

                ConnectionError?.Invoke(
                    new Exception(
                        "Сервер разорвал соединение",
                        ex));
            }
            catch (ObjectDisposedException ex)
            {
                _logger.LogError(
                    ex,
                    "Попытка считывания закрытого потока");

                ConnectionError?.Invoke(
                    new Exception(
                        "Сервер разорвал соединение",
                        ex));
            }
            catch (SocketException ex)
            {
                _logger.LogError(
                    ex,
                    "Ошибка сокета: {SocketErrorCode}",
                    ex.SocketErrorCode);

                ConnectionError?.Invoke(
                    new Exception(
                        "Сервер разорвал соединение",
                        ex));
            }
            catch (OperationCanceledException)
            {
                // Нормальное завершение при DisconnectAsync()
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    ex,
                    "Ошибка получения данных от сервера");

                ConnectionError?.Invoke(
                    new Exception(
                        "Сервер разорвал соединение",
                        ex));
            }
        }

        // ============================================================
        // СОБЫТИЯ
        // ============================================================

        public event Action<string>? MessageReceived;

        public event Action<Exception>? ConnectionError;
    }
}
