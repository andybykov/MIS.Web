using Microsoft.EntityFrameworkCore;
using MIS.Core.Dtos;

namespace MIS.Core.TestSeedData
{
    public class InitData
    {
        // Тестовые данные
        public void SeedData(ModelBuilder modelBuilder)
        {
            SeedUsers(modelBuilder);
            SeedMedicalServices(modelBuilder);
            SeedOrders(modelBuilder);
        }

        private void SeedUsers(ModelBuilder modelBuilder)
        {
            var registrationDate = DateTime.UtcNow.AddMonths(-1);

            modelBuilder.Entity<UserDto>().HasData(
                // Пациенты
                new UserDto
                {
                    Id = 1,
                    FirstName = "Иван",
                    LastName = "Петров",
                    Email = "ivan.petrov@email.com",
                    Password = "hashed_password_1",
                    PhoneNumber = "79990001101",
                    Role = UserRole.Client,
                    RegistrationDate = registrationDate,
                    DateOfBirth = new DateTime(1985, 5, 15, 0, 0, 0, DateTimeKind.Utc),
                    Gender = Gender.Male,
                    IsRemoved = false
                },
                new UserDto
                {
                    Id = 2,
                    FirstName = "Мария",
                    LastName = "Сидорова",
                    Email = "maria.sidorova@email.com",
                    Password = "hashed_password_2",
                    PhoneNumber = "79990001102",
                    Role = UserRole.Client,
                    RegistrationDate = registrationDate.AddDays(2),
                    DateOfBirth = new DateTime(1990, 8, 22, 0, 0, 0, DateTimeKind.Utc),
                    Gender = Gender.Female,
                    IsRemoved = false
                },
                new UserDto
                {
                    Id = 3,
                    FirstName = "Алексей",
                    LastName = "Козлов",
                    Email = "alexey.kozlov@email.com",
                    Password = "hashed_password_3",
                    PhoneNumber = "79990001103",
                    Role = UserRole.Client,
                    RegistrationDate = registrationDate.AddDays(5),
                    DateOfBirth = new DateTime(1978, 12, 10, 0, 0, 0, DateTimeKind.Utc),
                    Gender = Gender.Male,
                    IsRemoved = false
                },

                // Врачи
                new UserDto
                {
                    Id = 4,
                    FirstName = "Дмитрий",
                    LastName = "Смирнов",
                    Email = "dmitry.smirnov@email.com",
                    Password = "hashed_password_4",
                    PhoneNumber = "79990001104",
                    Role = UserRole.Doctor,
                    RegistrationDate = registrationDate.AddDays(-10),
                    DateOfBirth = new DateTime(1975, 3, 18, 0, 0, 0, DateTimeKind.Utc),
                    Gender = Gender.Male,
                    IsRemoved = true
                },
                new UserDto
                {
                    Id = 5,
                    FirstName = "Ольга",
                    LastName = "Иванова",
                    Email = "olga.ivanova@email.com",
                    Password = "hashed_password_5",
                    PhoneNumber = "79990001105",
                    Role = UserRole.Doctor,
                    RegistrationDate = registrationDate.AddDays(-8),
                    DateOfBirth = new DateTime(1982, 7, 12, 0, 0, 0, DateTimeKind.Utc),
                    Gender = Gender.Female,
                    IsRemoved = false
                },

                // Администратор
                new UserDto
                {
                    Id = 99,
                    FirstName = "Админ",
                    LastName = "Системный",
                    Email = "admin@admin.com",
                    Password = "123",
                    PhoneNumber = "79990001100",
                    Role = UserRole.Admin,
                    RegistrationDate = registrationDate.AddMonths(-2),
                    DateOfBirth = new DateTime(1980, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                    Gender = Gender.Male,
                    IsRemoved = false
                }
            );
        }

        private void SeedMedicalServices(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MedicalServiceDto>().HasData(
                new MedicalServiceDto
                {
                    Id = 1,
                    Name = "Первичная консультация терапевта",
                    Price = 1500.00m,
                    Description = "Осмотр и консультация врача-терапевта, постановка предварительного диагноза"
                },
                new MedicalServiceDto
                {
                    Id = 2,
                    Name = "Повторная консультация терапевта",
                    Price = 1200.00m,
                    Description = "Повторный осмотр и коррекция лечения"
                },
                new MedicalServiceDto
                {
                    Id = 3,
                    Name = "ЭКГ (электрокардиография)",
                    Price = 800.00m,
                    Description = "Запись и расшифровка электрокардиограммы"
                },
                new MedicalServiceDto
                {
                    Id = 4,
                    Name = "УЗИ брюшной полости",
                    Price = 2500.00m,
                    Description = "Ультразвуковое исследование органов брюшной полости"
                },
                new MedicalServiceDto
                {
                    Id = 5,
                    Name = "Общий анализ крови",
                    Price = 600.00m,
                    Description = "Лабораторное исследование общего анализа крови"
                },
                new MedicalServiceDto
                {
                    Id = 6,
                    Name = "Консультация кардиолога",
                    Price = 2000.00m,
                    Description = "Осмотр и консультация врача-кардиолога"
                },
                new MedicalServiceDto
                {
                    Id = 7,
                    Name = "Массаж спины (1 сеанс)",
                    Price = 1800.00m,
                    Description = "Лечебный массаж спины продолжительностью 45 минут"
                },
                new MedicalServiceDto
                {
                    Id = 8,
                    Name = "Рентген грудной клетки",
                    Price = 1100.00m,
                    Description = "Рентгенологическое исследование органов грудной клетки"
                }
            );
        }

        private void SeedOrders(ModelBuilder modelBuilder)
        {
            var orderDate = DateTime.UtcNow.AddDays(-10);

            modelBuilder.Entity<OrderDto>().HasData(
                new OrderDto
                {
                    Id = 1,
                    Date = orderDate,
                    OrderStatus = OrderStatus.Completed,
                    TotalAmount = 1500.00m,
                    UserId = 1, // Иван Петров
                    MedicalServiceId = 1 // Консультация терапевта
                },
                new OrderDto
                {
                    Id = 2,
                    Date = orderDate.AddDays(1),
                    OrderStatus = OrderStatus.Completed,
                    TotalAmount = 2300.00m,
                    UserId = 1, // Иван Петров
                    MedicalServiceId = 5 // Анализ крови
                },
                new OrderDto
                {
                    Id = 3,
                    Date = orderDate.AddDays(2),
                    OrderStatus = OrderStatus.New,
                    TotalAmount = 2000.00m,
                    UserId = 2, // Мария Сидорова
                    MedicalServiceId = 6 // Консультация кардиолога
                },
                new OrderDto
                {
                    Id = 4,
                    Date = orderDate.AddDays(3),
                    OrderStatus = OrderStatus.New,
                    TotalAmount = 1800.00m,
                    UserId = 2, // Мария Сидорова  
                    MedicalServiceId = 7 // Массаж спины
                },
                new OrderDto
                {
                    Id = 5,
                    Date = orderDate.AddDays(1),
                    OrderStatus = OrderStatus.Completed,
                    TotalAmount = 3300.00m,
                    UserId = 3, // Алексей Козлов
                    MedicalServiceId = 4 // УЗИ брюшной полости
                },
                new OrderDto
                {
                    Id = 6,
                    Date = orderDate.AddDays(4),
                    OrderStatus = OrderStatus.Cancelled,
                    TotalAmount = 1100.00m,
                    UserId = 3, // Алексей Козлов
                    MedicalServiceId = 8 // Рентген грудной клетки
                },
                new OrderDto
                {
                    Id = 7,
                    Date = orderDate.AddDays(5),
                    OrderStatus = OrderStatus.Cancelled,
                    TotalAmount = 1200.00m,
                    UserId = 1, // Иван Петров
                    MedicalServiceId = 2 // Повторная консультация
                },
                new OrderDto
                {
                    Id = 8,
                    Date = DateTime.UtcNow.AddHours(-2),
                    OrderStatus = OrderStatus.New,
                    TotalAmount = 800.00m,
                    UserId = 2, // Мария Сидорова
                    MedicalServiceId = 3 // ЭКГ
                }
            );
        }
    }
}