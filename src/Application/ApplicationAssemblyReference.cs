using System.Reflection;

namespace Forpost.Application;

/// <summary>
/// Класс предоставляющий ссылку на сборку, в которой он находится
/// </summary>
public class ApplicationAssemblyReference
{
    /// <summary>
    /// Получить сборку
    /// </summary>
    public static Assembly Assembly => typeof(ApplicationAssemblyReference).Assembly;
}