using Npgsql;

namespace Discount.Grpc.Extentions
{
    public static class HostExtention
    {
        public static WebApplication MigrateDatabase<TContext>(this WebApplication webApplication, int? retry = 0)
        {
            int retryForAvailability = retry.Value;

            using (var scope = webApplication.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var configuration = services.GetRequiredService<IConfiguration>();
                var logger = services.GetRequiredService<ILogger<TContext>>();

                try
                {
                    logger.LogInformation("migration postgresql database");
                    using var connection = new NpgsqlConnection(
                        configuration.GetValue<string>("PostgresSettings:ConnectionStrings"));
                    connection.Open();

                    using var command = new NpgsqlCommand
                    {
                        Connection = connection,
                    };

                    command.CommandText = "DROP TABLE IF EXISTS Coupons";                        
                    command.ExecuteNonQuery();

                    command.CommandText = @"CREATE TABLE Coupons(Id SERIAL PRIMARY KEY,
                                                                 ProductId VARCHAR(100) NOT NULL,
                                                                 Description TEXT,
                                                                 Amount INT NOT NULL)";
                    command.ExecuteNonQuery();

                    command.CommandText = "INSERT INTO Coupons(ProductId, Description, Amount) VALUES ('dd99gg', 'test', 5000)";
                    command.ExecuteNonQuery();

                    command.CommandText = "INSERT INTO Coupons(ProductId, Description, Amount) VALUES ('ff66ww', 'desc', 3000)";
                    command.ExecuteNonQuery();

                    logger.LogInformation("migration has been completed!");
                }
                catch (NpgsqlException ex)
                {
                    logger?.LogInformation("an error has been occured and I'm retrying");

                    if (retryForAvailability < 10)
                    {
                        retryForAvailability++;
                        Thread.Sleep(2000);
                        MigrateDatabase<TContext>(webApplication, retryForAvailability);
                    }
                }
            }

            return webApplication;
        }
    }
}
