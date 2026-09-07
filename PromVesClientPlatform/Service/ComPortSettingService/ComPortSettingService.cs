using Microsoft.Extensions.Logging;
using PromVesClientPlatform.DTO;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO.Ports;
namespace PromVesClientPlatform.Service.ComPortSettingService
{
    public class ComPortSettingService
    {
        private readonly ILogger<ComPortSettingService> _logger;
        // Путь к рабочему файлу на сервере
        private readonly string _serverSettingsPath = @"C:\PromVesNew\PromVesServer\ConfigPort.json";
        //конвертирует в файле json в формат enwy
        private readonly JsonSerializerOptions _jsonOptions = new()
        {
            WriteIndented = true,
            Converters =
    {
        new JsonStringEnumConverter()
    }
        };
        public ComPortSettingService(ILogger<ComPortSettingService> logger)
        { 
            _logger = logger;
        }
        //получение сохраненный настроек ком порта
        public async Task<ServiceResult<ConfigurationSetting>> GetSavedSettingComPort()
        {
            //проверка на поиск файла настроек
            if (!File.Exists(_serverSettingsPath))
            {
                _logger.LogWarning(
                    "Файл настроек {Path} не найден. Загружаются настройки по умолчанию.",
                    _serverSettingsPath);

                return ServiceResult<ConfigurationSetting>.Fail("не удалось найти файл конфигурации");
            }
            //читаем файл
            string json = File.ReadAllText(_serverSettingsPath);
            //проверка по пустоту данных
            if (string.IsNullOrWhiteSpace(json))
            {
                _logger.LogWarning(
                    $"Файл настроек {_serverSettingsPath} пустой.");
                return ServiceResult<ConfigurationSetting>.Fail($"файл настроек {_serverSettingsPath} пустой. Загружаются настройки по умолчанию.");

            }
            //десериализуем
            var configuration = JsonSerializer.Deserialize<ConfigurationSetting>(json, _jsonOptions);
            //проверка на удачную десериализацию
            if (configuration == null)
            {
                _logger.LogWarning(
                    "Не удалось десериализовать файл настроек.");
                return ServiceResult<ConfigurationSetting>.Fail("не удалось десериализовать файл настроек. Загружаются настройки по умолчанию.");
            }
            return ServiceResult<ConfigurationSetting>.Ok(configuration);
        }
        //получение всех com портов
        public async Task<string[]> GetNameComPort()
        {
            //получаем список com портов
            string[] ports = SerialPort.GetPortNames();
            return (ports);
        }
        // Сохраняет настройки.
        public async Task<ServiceResult> SaveAsync(SerialPortSettings configuration)
        {
            try
            {
                string json = JsonSerializer.Serialize(
                    configuration,
                    _jsonOptions);

                File.WriteAllTextAsync(_serverSettingsPath, json);

                return ServiceResult.Ok();
            }
            catch (JsonException ex)
            {
                _logger.LogError(ex,
                    "Ошибка сериализации настроек COM-портов.");

                return ServiceResult.Fail(
                    "Не удалось подготовить настройки к сохранению.");
            }
            catch (IOException ex)
            {
                _logger.LogError(ex,
                    "Ошибка записи файла настроек {Path}.",
                    _serverSettingsPath);

                return ServiceResult.Fail(
                    "Не удалось сохранить настройки.");
            }
            catch (UnauthorizedAccessException ex)
            {
                _logger.LogError(ex,
                    "Нет доступа к файлу настроек {Path}.",
                    _serverSettingsPath);

                return ServiceResult.Fail(
                    "Нет доступа к файлу настроек.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,
                    "Неизвестная ошибка при сохранении настроек.");

                return ServiceResult.Fail(
                    "Не удалось сохранить настройки.");
            }
        }
    }
}
