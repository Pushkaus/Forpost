using System.Reflection;

namespace Forpost.Web.Contracts;

/// <summary>
/// Класс предоставляющий ссылку на сборку, в которой он находится
/// </summary>
public static class WebContractsAssemblyReference
{
    /// <summary>
    /// Получить сборку
    /// </summary>
    public static Assembly Assembly => typeof(WebContractsAssemblyReference).Assembly;
}