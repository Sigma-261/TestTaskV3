using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System.ComponentModel;
using System.Text.RegularExpressions;

namespace TestTaskV3.Data;

public static class ServiceCollection
{
    /// <summary>
    /// Базовая инициализация сервисов для модулей
    /// </summary>
    /// <param name="services"></param>
    /// <param name="connectionString">Строка подключения к БД</param>
    public static void AddBaseModuleDI(this IServiceCollection services, string connectionString,
        IConfiguration configuration)
    {
        // CORS
        services.AddCors();

        // Routes
        services.AddControllersWithNewtonsoft();
    }


    /// <summary>
    /// Внедрение контроллеров и сериализацию Newtonsoft
    /// </summary>
    /// <param name="services"></param>
    private static void AddControllersWithNewtonsoft(this IServiceCollection services)
    {
        services.AddControllers(o =>
        {
            o.Conventions.Add(new ControllerDocumentationConvention());
            o.Conventions.Add(new RouteTokenTransformerConvention(new SlugifyParameterTransformer()));
            // o.Filters.Add(typeof(AccessControlFilter));
        })
            .AddNewtonsoftJson(o =>
            {
                o.SerializerSettings.Converters.Add(new StringEnumConverter
                {
                    NamingStrategy = new CamelCaseNamingStrategy(),
                });
                o.SerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Utc;
            });
    }

    /// <summary>
    /// Название Controller
    /// </summary>
    private class ControllerDocumentationConvention : IControllerModelConvention
    {
        /// <inheritdoc />
        void IControllerModelConvention.Apply(ControllerModel controller)
        {
            if (controller == null)
                return;

            foreach (var attribute in controller.Attributes)
            {
                if (attribute.GetType() == typeof(DisplayNameAttribute))
                {
                    var routeAttribute = (DisplayNameAttribute)attribute;
                    if (!string.IsNullOrWhiteSpace(routeAttribute.DisplayName))
                        controller.ControllerName = routeAttribute.DisplayName;
                }
            }
        }
    }

    /// <summary>
    /// Трансформатор пути запрос, пример: AccountSettings -> account-settings
    /// </summary>
    private class SlugifyParameterTransformer : IOutboundParameterTransformer
    {
        /// <inheritdoc />
        public string TransformOutbound(object value)
        {
            // Slugify value
            return value == null ? null : Regex.Replace(value.ToString(), "([a-z])([A-Z])", "$1-$2").ToLower();
        }
    }
}

