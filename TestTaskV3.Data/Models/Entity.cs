using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTaskV3.Data.Interfaces;

namespace TestTaskV3.Data.Models;

public class Entity : IEntity
{
    public Entity()
    {
        DateCreate = DateTime.UtcNow;
        DateUpdate = DateCreate;
    }

    /// <summary>
    /// Уникальный идентификатор
    /// </summary>
    [Column("ID")]
    [Key]
    public Guid Guid { get; set; }

    /// <summary>
    /// Дата создания записи
    /// </summary>
    [Column("CREATE_AT")]
    [ReadOnly(true)]
    public virtual DateTime DateCreate { get; set; }

    /// <summary>
    /// Дата обновления записи
    /// </summary>
    [Column("UPDATE_AT")]
    [ReadOnly(true)]
    public virtual DateTime DateUpdate { get; set; }

    /// <summary>
    /// Обновление дат перед сохранением в БД
    /// </summary>
    /// <param name="now"></param>
    public void UpdateBeforeSave(DateTime now)
    {
        DateUpdate = now;
    }
}
