namespace Forpost.Common.Utils;

/// <summary>
/// Поставщик авторизованного пользователя
/// </summary>
public interface IIdentityProvider
{
    /// <summary>
    /// Получить идентификатор авторизованного пользователя
    /// </summary>
    /// <value>Null - пользователь не авторизован</value>
    public Guid? GetUserId();

    /// <summary>
    /// Получить роль авторизованного пользователя
    /// </summary>
    public Guid? GetRoleId();
}