using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TestTaskV3.Data.Interfaces;

/// <summary>
/// Интерфейс базового репозитория
/// </summary>
/// <typeparam name="T"></typeparam>
public interface IEntityRepository<T> where T : IEntity
{
    T Add(T model);
    bool Update(T models);
    bool Delete(T model);
    IQueryable<T> GetListQuery();
    List<T> GetList();
    bool Any(Expression<Func<T, bool>> func);
    T FirstOrDefault(Expression<Func<T, bool>> func);
}
