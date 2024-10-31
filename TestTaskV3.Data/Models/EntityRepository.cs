using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TestTaskV3.Data.Interfaces;

namespace TestTaskV3.Data.Models;

/// <summary>
/// Базовый репозиторий
/// </summary>
public class EntityRepository<T> : IEntityRepository<T> where T : class, IEntity
{
    private readonly TubeContext _db;
    private readonly ILogger<IEntityRepository<T>> _logger;

    public EntityRepository(TubeContext db,
        ILogger<IEntityRepository<T>> logger)
    {
        _db = db;
        _logger = logger;
    }

    /// <summary>
    /// Обновление модели перед записью в БД
    /// </summary>
    /// <param name="model">Модель</param>
    /// <param name="nowUtc">Текущее время</param>
    /// <returns>Обновленная запись</returns>
    private T UpdateEntityBeforeSave(T model)
    {
        model.UpdateBeforeSave(DateTime.UtcNow);
        return model;
    }

    /// <summary>
    /// Добавление объекта
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    public virtual T Add(T model)
    {
        try
        {
            _db.Add(model);
            _db.SaveChanges();
        }
        catch (Exception ex)
        {
            model.Guid = Guid.Empty;
            _logger.LogError($"Ошибка при добавлении сущности: {ex}");
        }

        return model;
    }

    /// <summary>
    /// Добавляет элементы указанной коллекции
    /// </summary>
    /// <param name="models"></param>
    /// <returns></returns>
    public virtual IEnumerable<T> AddRange(IEnumerable<T> models)
    {
        try
        {
            _db.AddRange(models);
            _db.SaveChanges();
        }
        catch (Exception ex)
        {
            _logger.LogError($"Ошибка при добавлении сущностей: {ex}");
        }

        return models;
    }

    /// <summary>
    /// Получение записи по идентификатору
    /// </summary>
    /// <param name="guid">Guid</param>
    /// <returns></returns>
    public T Get(Guid guid)
    {
        return GetListQuery().FirstOrDefault(p => p.Guid == guid);
    }

    /// <summary>
    /// Обновление объекта
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    public virtual bool Update(T model)
    {
        try
        {
            _db.Update(UpdateEntityBeforeSave(model));
            _db.SaveChanges();

            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError($"Ошибка при обновлении сущности: {ex}");
            return false;
        }
    }

    /// <summary>
    /// Удаление объекта
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    public virtual bool Delete(T model)
    {
        try
        {
            _db.Remove(model);
            _db.SaveChanges();

            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError($"Ошибка при удалении сущности: {ex}");
            return false;
        }
    }

    /// <summary>
    /// Удаление объекта по Guid
    /// </summary>
    /// <param name="guid"></param>
    /// <param name="userGuid"></param>
    /// <returns></returns>
    public virtual bool Delete(Guid guid)
    {
        try
        {
            var model = _db.Set<T>().AsNoTracking().FirstOrDefault(p => p.Guid == guid);
            return Delete(model);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Ошибка при удалении сущности: {ex}");
            return false;
        }
    }


    /// <summary>
    /// Получить коллекцию
    /// </summary>
    /// <returns></returns>
    public virtual IQueryable<T> GetListQuery()
    {
        return _db.Set<T>().AsNoTracking().AsQueryable();
    }

    /// <summary>
    /// Получить коллекцию
    /// </summary>
    /// <returns></returns>
    public virtual List<T> GetList()
    {
        return _db.Set<T>().AsNoTracking().ToList();
    }

    /// <summary>
    /// Проверяет существование хотя бы одного элемента в последовательности 
    /// </summary>
    /// <param name="func"></param>
    /// <returns></returns>
    public virtual bool Any(Expression<Func<T, bool>> func)
    {
        return GetListQuery().Any(func);
    }

    /// <summary>
    /// Возвращает первый элемент последовательности или значение по умолчанию, если ни одного элемента не найдено
    /// </summary>
    /// <param name="func"></param>
    /// <returns></returns>
    public virtual T FirstOrDefault(Expression<Func<T, bool>> func)
    {
        return GetListQuery().FirstOrDefault(func);
    }
}
