using AutoMapper;
using CarWorkshops.Data;
using CarWorkshops.Data.Repositories;
using CarWorkshops.Data.Repositories.Abstracts;
using CarWorkshops.WebApplication.Models.Abstracts;
using CarWorkshops.WebApplication.Models.Mappers.Resolvers;
using DataAccess;
using DataAccess.Abstracts;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.IO;

namespace CarWorkshops.WebApplication.Extensions
{
    public static class ServicesExtensions
    {
        public static void ConfigureMapping(this IServiceCollection services)
        {
            services.AddScoped<IAddressResolver, AddressResolver>();
            services.AddScoped<ICarWorkshopCarTrademarksResolver, CarWorkshopCarTrademarksResolver>();
            services.AddAutoMapper(typeof(Startup));
        }

        public static void ConfigureRepositories(this IServiceCollection services)
        {
            services.AddSingleton<IDataContext, MemoryDataContext>();
            services.AddScoped<IAddressesRepository, AddressesRepository>();
            services.AddScoped<IAppointmentsRepository, AppointmentsRepository>();
            services.AddScoped<ICarTrademarksRepository, CarTrademarksRepository>();
            services.AddScoped<ICarWorkshopsRepository, CarWorkshopsRepository>();
            services.AddScoped<ICountriesRepository, CountriesRepository>();
            services.AddScoped<IUsersRepository, UsersRepository>();
            services.AddScoped<IRepository, Repository>();
        }

        public static void ConfigureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = $"{nameof(CarWorkshops)} API", Version = "v1" });
                c.CustomSchemaIds(SchemaIdStrategy);
                var xmlFile = Path.ChangeExtension(typeof(Startup).Assembly.Location, ".xml");
                c.IncludeXmlComments(xmlFile);
            });
        }

        private static string SchemaIdStrategy(Type currentClass)
        {
            string returnedValue = currentClass.Name;
            if (returnedValue.EndsWith("Dto"))
            {
                returnedValue = returnedValue.Replace("Dto", string.Empty);
            }
            return returnedValue;
        }
    }
}
