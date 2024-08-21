namespace Forpost.Common.Utils;

public interface IIdentityProvider
{
    /// <summary>
    /// Получить идентификатор авторизованного пользователя
    /// </summary>
    /// <value>Null - пользователь не авторизован</value>
    public Guid? GetUserId();
}