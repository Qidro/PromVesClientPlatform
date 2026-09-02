using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Npgsql;
using PromVesClientPlatform.DTO;
using PromVesClientPlatform.Model;
using PromVesClientPlatform.Service.UserService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PromVesClientPlatform.Service.AuthorizationService
{
    public class UserService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ILogger<UserService> _logger;
        private readonly HashPasswordService _hashPasswordService;
        //private List<UserDto> _usersDto;
        public UserService(ApplicationDbContext dbContext, ILogger<UserService> logger, HashPasswordService hashPasswordService)
        {
            _dbContext = dbContext;
            _logger = logger;
            _hashPasswordService = hashPasswordService;
        }
        //метод авторизации пользователя
        public async Task<ServiceResult<User>> AuthorizationUserAsync(string Login, string Password)
        {
            try 
            {
                //поиск пользователя
                var userData = await _dbContext.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Name == Login);
                if (userData == null)
                {
                    return ServiceResult<User>.Fail("Пользователя не существует");
                }
                //провервка на активность пользователя
                if(userData.Active == false)
                {
                    return ServiceResult<User>.Fail("Пользователя неактивен");
                }
                //string HashPassword = _hashPasswordService.getHashPasswordUser(Password);
                //сравнием хэш пороля
                bool resultCheckPassword = _hashPasswordService.passwordСheck(Password, userData.Password);
                if (resultCheckPassword == true)
                {
                    return ServiceResult<User>.Ok(userData);
                }
                else 
                {
                    return ServiceResult<User>.Fail("Ошибка авторизации");
                }
                //return ServiceResult.Ok();
            }
            catch (TimeoutException ex)
            {
                _logger.LogError(ex, "Превышено время ожидания при создании пользователя {Login}.", Login);

                return ServiceResult<User>.Fail("Превышено время ожидания при создании пользователя.");
            }
            catch (NpgsqlException ex)
            {
                _logger.LogError(ex, "Ошибка базы данных при создании пользователя {Login}.", Login);

                return ServiceResult<User>.Fail("Ошибка базы данных.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Неизвестная ошибка при создании пользователя {Login}.", Login);

                return ServiceResult<User>.Fail("Не удалось создать пользователя.");
            }
           
        }
        //метот создания пользователя в БД
        public async Task<ServiceResult> CreateUserAsync(string Login, string Role, bool Active, string Password)
        {
           // string Role = "admin";
            string HashPassword = _hashPasswordService.getHashPasswordUser(Password);
            var user = new User
            {
                Id = Guid.NewGuid(),
                Name = Login,
                Password = HashPassword,
                Role = Role,
                Active = Active
            };
            try
            {
                //поиск сущестует ли пользователь
                var userData = await _dbContext.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Name == user.Name);
                //проверка данныъ
                if (userData != null)
                {
                    return ServiceResult.Fail("Пользователь уже существует");
                }
                //создание данных и сохранений
                await _dbContext.Users.AddAsync(user);
                await _dbContext.SaveChangesAsync();
                return ServiceResult.Ok();
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError(ex, "Ошибка сохранения пользователя {Login}.", Login);

                return ServiceResult.Fail($"{ex.Message}");
            }
            catch (TimeoutException ex)
            {
                _logger.LogError(ex, "Превышено время ожидания при создании пользователя {Login}.", Login);

                return ServiceResult.Fail("Превышено время ожидания при создании пользователя.");
            }
            catch (NpgsqlException ex)
            {
                _logger.LogError(ex, "Ошибка базы данных при создании пользователя {Login}.", Login);

                return ServiceResult.Fail("Ошибка базы данных.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Неизвестная ошибка при создании пользователя {Login}.", Login);

                return ServiceResult.Fail("Не удалось создать пользователя.");
            }
            
        }

        //метод по получению всего списка пользователей
        public async Task<ServiceResult<List<UserDto>>> GetUsersListAsync()
        {
            try
            {
                //получаем список пользователей
                var users = await _dbContext.Users
                    .Select(u => new UserDto
                    {
                        Id = u.Id,
                        Name = u.Name,
                        Role = u.Role,
                        Active = u.Active
                    })
                    .ToListAsync();
                //проверка на пустой список
                if (users.Count == 0)
                {
                    return ServiceResult<List<UserDto>>.Fail("Список пользователей пуст");
                }
                return ServiceResult<List<UserDto>>.Ok(users);
                //return ServiceResult<List<UserDto>>.Fail("Тяжело");
            }
            catch (TimeoutException ex)
            {
                _logger.LogError( ex, "Ошибка ожидания ответа от БД");
                return ServiceResult<List<UserDto>>.Fail("Ошибка ожидания ответа от БД: " + ex.Message);
            }
            catch (NpgsqlException ex)
            {
                _logger.LogError(ex, "Ошибка бд");
                return ServiceResult<List<UserDto>>.Fail("Ошибка БД: " + ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка получения списка пользователей");

                return ServiceResult<List<UserDto>>.Fail("Не удалось получить список пользователей" + ex.Message);
            }
            //return ServiceResult<UserDto>.Fail("Тяжело");
        }
        //Метод улаения пользователя
        public async Task<ServiceResult> DeleateUserAsync(Guid Id)
        {
            try 
            {
                //поиск пользователя
                var user = await _dbContext.Users.FindAsync(Id);
                //проверка есть ли запись в бд с заданным параметром
                if (user == null)
                {
                    return ServiceResult.Fail("Пользователь не найден");
                }
                else
                {
                    //удаление пользователя
                    _dbContext.Users.Remove(user);
                    await _dbContext.SaveChangesAsync();

                    return ServiceResult.Ok();
                }
            }
            catch (TimeoutException ex)
            {
                _logger.LogError(ex, "Превышено время ожидания при удалении пользователя.");

                return ServiceResult.Fail("Превышено время ожидания при удалении пользователя.");
            }
            catch (NpgsqlException ex)
            {
                _logger.LogError(ex, "Ошибка базы данных при удалении пользователя.");

                return ServiceResult.Fail("Ошибка базы данных.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Неизвестная ошибка при удалении пользователя.");

                return ServiceResult.Fail("Не удалось удалить пользователя.");
            }
        }
        //метод получения данных пользователя
        public async Task<ServiceResult<UserDto>> GetUserAsync(Guid Id)
        {
            try 
            {
                //получаем пользовтеля по Id
                var user = await _dbContext.Users
                .Where(x => x.Id == Id)
                .Select(u => new UserDto
                {
                    Id = u.Id,
                    Name = u.Name,
                    Role = u.Role,
                    Active = u.Active
                }).FirstOrDefaultAsync();
                //проверка на поиск пользователя
                if (user == null)
                {
                    return ServiceResult<UserDto>.Fail("Пользователь не найден");
                }
                return ServiceResult<UserDto>.Ok(user);
                
            }
            catch (TimeoutException ex)
            {
                _logger.LogError(ex, "Превышено время ожидания при получении данных пользователя.");

                return ServiceResult<UserDto>.Fail("превышено время ожидания при получении данных пользователя.");
            }
            catch (NpgsqlException ex)
            {
                _logger.LogError(ex, "Ошибка базы данных при получении данных пользователя.");

                return ServiceResult<UserDto>.Fail("ошибка базы данных.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Неизвестная ошибка при получении данных пользователя.");

                return ServiceResult<UserDto>.Fail("не удалось получить данных пользователя.");
            }

        }
        //метод по изменению данных пользователя
        public async Task<ServiceResult> ChangeUserAsync(Guid id, string login, string role, bool active, string? password = null)
        {
            try 
            {
                //поиск пользователя по Id
                var user = await _dbContext.Users.FindAsync(id);
                if (user == null)
                {
                    return ServiceResult.Fail("пользователь не найден");
                }
                user.Name = login;
                user.Role = role;
                user.Active = active;
                //проверка на пустой пароль
                if (!string.IsNullOrWhiteSpace(password))
                {
                    user.Password = _hashPasswordService.getHashPasswordUser(password);
                }
                await _dbContext.SaveChangesAsync();
                return ServiceResult.Ok();
            }
            catch (TimeoutException ex)
            {
                _logger.LogError(ex, "Ошибка ожидания ответа от БД");
                return ServiceResult.Fail("Ошибка ожидания ответа от БД: " + ex.Message);
            }
            catch (NpgsqlException ex)
            {
                _logger.LogError(ex, "Ошибка бд");
                return ServiceResult.Fail("Ошибка БД: " + ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка получения списка пользователей");

                return ServiceResult.Fail("Не удалось получить список пользователей" + ex.Message);
            }

        }
    }
}
