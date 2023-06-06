using FluentMigrator.Runner;
using Microsoft.OpenApi.Models;
using RoomyTestTask.Context;
using RoomyTestTask.Interfaces.Context;
using RoomyTestTask.Interfaces.Repositories;
using RoomyTestTask.Interfaces.Services;
using RoomyTestTask.Interfaces.Utils;
using RoomyTestTask.Migrations;
using RoomyTestTask.Repositories;
using RoomyTestTask.Services;
using RoomyTestTask.Utils;
using System.Reflection;

namespace RoomyTestTask.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IDocumentRepository, DocumentRepository>();
            services.AddScoped<IPaymentRepository, PaymentRepository>();
            services.AddScoped<IDocumentService, DocumentService>();
            services.AddScoped<IPaymentService, PaymentService>();
            services.AddScoped<IFileReader, FileReader>();
            services.AddScoped<IPaymentParser, PaymentParser>();
            services.AddScoped<ICookiesHelper, CookiesHelper>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            return services;
        }

        public static IServiceCollection AddDatabase(this IServiceCollection services, string? connectionString)
        {
            services.AddSingleton<IDatabaseConnectionFactory, DatabaseConnectionFactory>();
            services.AddSingleton<Database>();
            services.AddLogging(c => c.AddFluentMigratorConsole())
                .AddFluentMigratorCore()
                .ConfigureRunner(c => c.AddSqlServer2012()
                    .WithGlobalConnectionString(connectionString)
                    .ScanIn(Assembly.GetExecutingAssembly()).For.Migrations());

            return services;
        }

        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "RoomyTestTask API",
                    Description = "An ASP.NET Core Web API for managing documents and payment data",
                    TermsOfService = new Uri("https://example.com/terms"),
                    Contact = new OpenApiContact
                    {
                        Name = "Iskander Shakirov",
                        Url = new Uri("https://t.me/kekes_kekes")
                    }
                });

                // using System.Reflection;
                string xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
            });

            return services;
        }
    }
}
