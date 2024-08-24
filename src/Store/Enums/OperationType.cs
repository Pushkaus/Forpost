namespace Forpost.Store.Enums;

public enum OperationType
{
    /// <summary>
    /// Подготовительный тип операции (Неважно учитывать количество сделанного продукта, готовится сразу партия)
    /// </summary>
    Preparatory  = 100,
    /// <summary>
    /// Основной тип операции (Важно учесть количество сделанного продукта)
    /// </summary>
    Basic = 200
}