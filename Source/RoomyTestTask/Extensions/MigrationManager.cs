using FluentMigrator.Runner;
using RoomyTestTask.Migrations;

namespace RoomyTestTask.Extensions
{
    public static class MigrationManager
    {
        public static IApplicationBuilder MigrateDatabase(this IApplicationBuilder applicationBuilder)
        {
            using (IServiceScope scope = applicationBuilder.ApplicationServices.CreateScope())
            {
                Database databaseService = scope.ServiceProvider.GetRequiredService<Database>();
                IMigrationRunner migrationService = scope.ServiceProvider.GetRequiredService<IMigrationRunner>();

                try
                {
                    databaseService.CreateDatabase("RoomyTestTaskDatabase");

                    migrationService.ListMigrations();
                    migrationService.MigrateUp();
                }
                catch
                {
                    //log errors or ...
                    throw;
                }
            }

            return applicationBuilder;
        }
    }
}
