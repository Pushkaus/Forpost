using System.Reflection;

namespace Forpost.Store.Repositories;

public static class RepositoryAssemblyReference
{
    public static Assembly Assembly => typeof(RepositoryAssemblyReference).Assembly;
}