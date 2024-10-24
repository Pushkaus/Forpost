namespace Forpost.Application.Contracts.ProductCreating.ProductsDevelopments;

/// <summary>
/// Перечисление, определяющее варианты настройки продукта.
/// </summary>
//TODO: Убрать сокращения и перевести на английский
public enum SettingOptionRead
{
    /// <summary>
    /// ЗВУ
    /// </summary>
    ЗВУ = 100,

    /// <summary>
    /// Параметр R.
    /// </summary>
    R = 200,

    /// <summary>
    /// Вариант ВДК.
    /// </summary>
    ВДК = 300,

    /// <summary>
    /// Настройка Триада.
    /// </summary>
    Триада = 400,

    /// <summary>
    /// DC/DC преобразователь.
    /// </summary>
    DC_DC = 500
}