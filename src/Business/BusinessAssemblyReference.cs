using System.Reflection;

namespace Forpost.Business;

/// <summary>
/// Класс предоставляющий ссылку на сборку, в которой он находится
/// </summary>
public static class BusinessAssemblyReference
{
    /// <summary>
    /// Получить сборку
    /// </summary>
    public static Assembly Assembly => typeof(BusinessAssemblyReference).Assembly;
}