using System.Reflection;

namespace Forpost.Web.Host.Settings;

/// <summary>
/// Класс предоставляющий ссылку на сборку, в которой он находится
/// </summary>
public static class WebAssemblyReference
{
    /// <summary>
    /// Получить сборку
    /// </summary>
    public static Assembly Assembly => typeof(WebAssemblyReference).Assembly;
}
