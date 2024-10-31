using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TestTaskV3.Data;

/// <summary>
/// Реализация атрибута для задания маршрута до методов контроллера
/// </summary>
public class SetRouteAttribute : RouteAttribute
{
    /// <inheritdoc />
    public SetRouteAttribute() : base(GetTemplate("v{version:ApiVersion}/[controller]"))
    {
    }

    /// <inheritdoc />
    public SetRouteAttribute(string name) : base(GetTemplate("v{version:ApiVersion}/" + name))
    {
    }

    public SetRouteAttribute(string name, int version) : base(GetTemplate($"v{version}/" + name))
    {
    }

    /// <summary>
    /// Получение полного пути к методу API
    /// </summary>
    /// <param name="template"></param>
    /// <returns></returns>
    private static string GetTemplate(string template)
    {
        var templateReplace = new Regex(@"^/?api/").Replace(template, "");

        var a = $"/api/{Assembly.GetEntryAssembly()?.GetName()?.Name?.ToLower().Replace(".", "-")}/{templateReplace}";

        return $"/api/{Assembly.GetEntryAssembly()?.GetName()?.Name?.ToLower().Replace(".", "-")}/{templateReplace}";
    }
}
