using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PromVesClientPlatform.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromVesClientPlatform.Service.DirectoryService
{
    public class DirectoryService
    {
        private readonly ILogger<DirectoryService> _logger;
        private readonly IDbContextFactory<ApplicationDbContext> _dbContextFactory;

        public DirectoryService(
            ILogger<DirectoryService> logger,
            IDbContextFactory<ApplicationDbContext> dbContextFactory)
        {
            _logger = logger;
            _dbContextFactory = dbContextFactory;
        }
        // методы для работы с сотрудниками
        public async Task<List<Employee>> GetEmployeesAsync()
        {
            await using var db = await _dbContextFactory.CreateDbContextAsync();

            return await db.Employees
                .AsNoTracking()
                .OrderBy(x => x.FullName)
                .ToListAsync();
        }
        //метод для добавления сотрудника
        public async Task AddEmployeeAsync(string fullName)
        {
            if (string.IsNullOrWhiteSpace(fullName))
                return;

            await using var db = await _dbContextFactory.CreateDbContextAsync();

            var employee = new Employee
            {
                FullName = fullName.Trim()
            };

            db.Employees.Add(employee);

            await db.SaveChangesAsync();

            _logger.LogInformation(
                "Добавлен сотрудник: {FullName}",
                employee.FullName);
        }
        //метод для обновления сотрудника
        public async Task UpdateEmployeeAsync(int id, string fullName)
        {
            if (string.IsNullOrWhiteSpace(fullName))
                return;

            await using var db = await _dbContextFactory.CreateDbContextAsync();

            var employee = await db.Employees.FindAsync(id);

            if (employee == null)
                return;

            employee.FullName = fullName.Trim();

            await db.SaveChangesAsync();

            _logger.LogInformation(
                "Изменён сотрудник: {FullName}",
                employee.FullName);
        }
        //метод для удаления сотрудника
        public async Task DeleteEmployeeAsync(int id)
        {
            await using var db = await _dbContextFactory.CreateDbContextAsync();

            var employee = await db.Employees.FindAsync(id);

            if (employee == null)
                return;

            db.Employees.Remove(employee);

            await db.SaveChangesAsync();

            _logger.LogInformation(
                "Удалён сотрудник: {FullName}",
                employee.FullName);
        }
        // методы для работы с группами животных
        public async Task<List<AnimalGroup>> GetAnimalGroupsAsync()
        {
            await using var db = await _dbContextFactory.CreateDbContextAsync();

            return await db.AnimalGroups
                .AsNoTracking()
                .OrderBy(x => x.Name)
                .ToListAsync();
        }
        //метод для добавления группы животных
        public async Task AddAnimalGroupAsync(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return;

            await using var db = await _dbContextFactory.CreateDbContextAsync();

            var group = new AnimalGroup
            {
                Name = name.Trim()
            };

            db.AnimalGroups.Add(group);

            await db.SaveChangesAsync();

            _logger.LogInformation(
                "Добавлена группа животных: {Name}",
                group.Name);
        }
        //метод для обновления группы животных
        public async Task UpdateAnimalGroupAsync(int id, string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return;

            await using var db = await _dbContextFactory.CreateDbContextAsync();

            var group = await db.AnimalGroups.FindAsync(id);

            if (group == null)
                return;

            group.Name = name.Trim();

            await db.SaveChangesAsync();

            _logger.LogInformation(
                "Изменена группа животных: {Name}",
                group.Name);
        }
        //метод для удаления группы животных
        public async Task DeleteAnimalGroupAsync(int id)
        {
            await using var db = await _dbContextFactory.CreateDbContextAsync();

            var group = await db.AnimalGroups.FindAsync(id);

            if (group == null)
                return;

            db.AnimalGroups.Remove(group);

            await db.SaveChangesAsync();

            _logger.LogInformation(
                "Удалена группа животных: {Name}",
                group.Name);
        }
    }
}
