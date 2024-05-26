using Forpost.Store.Postgres;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Xunit;

namespace Forpost.Store.Postgres.Tests
{
    public class OrderBlockContextTests
    {
        private readonly IConfiguration _configuration;

        public OrderBlockContextTests()
        {
            // Загрузите конфигурацию из appsettings.json для тестирования
            _configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build();
        }

        [Fact]
        public async Task ConnectToDatabase_ShouldSuccess()
        {
            // Создайте экземпляр OrderBlockContext
            using (var context = new OrderBlockContext(
                new DbContextOptionsBuilder<OrderBlockContext>()
                    .UseNpgsql(_configuration.GetConnectionString("DBContext"))
                    .Options))
            {
                // Проверьте, что подключение к базе данных было установлено
                var count = await context.OrderBlocks.CountAsync();

                // Убедитесь, что count - это не 0 (т.е. подключение к базе данных успешно)
                Assert.NotEqual(0, count);
            }
        }
    }
}
