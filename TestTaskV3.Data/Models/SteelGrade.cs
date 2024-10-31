using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using TestTaskV3.Data.Models;

namespace TestTask.Models;

/// <summary>
/// Марка стали
/// </summary>
[Table("STEEL_GRADE")]
public class SteelGrade : Entity
{
    /// <summary>
    /// Вес трубы
    /// </summary>
    [Column("WEIGHT")]
    public required string Name { get; set; }
}
