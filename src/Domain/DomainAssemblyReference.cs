using System.Reflection;

namespace Forpost.Domain;

/// <summary>
/// Класс предоставляющий ссылку на сборку, в которой он находится
/// </summary>
public static class DomainAssemblyReference
{
    /// <summary>
    /// Получить сборку
    /// </summary>
    public static Assembly Assembly => typeof(DomainAssemblyReference).Assembly;
}