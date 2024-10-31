using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTaskV3.Data.Interfaces;

/// <summary>
/// Базовый интерфейс
/// </summary>
public interface IEntity
{
    /// <summary>
    /// Уникальный идентификатор
    /// </summary>
    [Column("ID")]
    [Key]
    Guid Guid { get; set; }

    /// <summary>
    /// Дата создания записи
    /// </summary>
    [Column("CREATE_AT")]
    public DateTime DateCreate { get; set; }

    /// <summary>
    /// Дата обновления записи
    /// </summary>
    [Column("UPDATE_AT")]
    public DateTime DateUpdate { get; set; }

    /// <summary>
    /// Обновление дат перед сохранением в БД
    /// </summary>
    /// <param name="now"></param>
    public void UpdateBeforeSave(DateTime now);
}
