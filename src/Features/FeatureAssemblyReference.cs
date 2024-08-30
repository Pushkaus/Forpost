using System.Reflection;

namespace Forpost.Features;

/// <summary>
/// Сборка с фичами приложения
/// </summary>
public class FeatureAssemblyReference
{
    public static Assembly Assembly => typeof(FeatureAssemblyReference).Assembly;

    public const string ArchitectureLayer = "Application";
}