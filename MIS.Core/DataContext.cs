using Microsoft.EntityFrameworkCore;
using MIS.Core.Dtos;
using MIS.Core.TestSeedData;

namespace MIS.Core
{
    // ОО-представление БД
    public class DataContext : DbContext
    {
        // Подключаем DbSet's
        public DbSet<UserDto> Users { get; set; }
        public DbSet<MedicalServiceDto> MedicalServices { get; set; }
        public DbSet<OrderDto> Orders { get; set; }



        // Переопределяем провайдер БД
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = Options.ConnectionString;
            optionsBuilder.UseNpgsql(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Инициализируем тестовые начальные данные
            InitData data = new();
            data.SeedData(modelBuilder);
        }
    }
}

