namespace Forpost.Business.Abstract.Services;

/// <summary>
/// Как будто бы редактирование и не надо, либо новая тех карта, либо ничего
/// </summary>
public interface ITechnologicalCardService : IBusinessService
{
    /// <summary>
    /// Получаем модель тех.карты с её составом.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Task GetTechnologicalCardByIdAsync(int id);

    /// <summary>
    /// Получаем все тех.карты с их составом.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Task GetTechnologicalCardsAsync();

    /// <summary>
    /// Создаем тех.карту, добавляем в нее состав и задачи
    /// </summary>
    /// <returns></returns>
    public Task CreateTechnologicalCardAsync();

    /// <summary>
    /// Добавление этапа в тех.карту
    /// </summary>
    /// <returns></returns>
    public Task AddStep();

    /// <summary>
    /// Удаление этапа из тех.карты
    /// </summary>
    /// <returns></returns>
    public Task DeleteStep();

    /// <summary>
    /// Добавление компонента в тех.карту
    /// </summary>
    /// <returns></returns>
    public Task AddComponent();

    /// <summary>
    /// Удаление компонента из тех.карты
    /// </summary>
    /// <returns></returns>
    public Task DeleteComponent();

    /// <summary>
    /// Удаление тех карты навсегда.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Task DeleteTechnologicalCardAsync(int id);

    /// <summary>
    /// Архивация тех карты
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Task ArchiveTechnologicalCardAsync(int id);
}