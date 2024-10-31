using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using TestTaskV3.Data.Models;

namespace TestTask.Models;

/// <summary>
/// Пакет с трубами
/// </summary>
[Table("PACK")]
public class Pack : Entity
{
    /// <summary>
    /// Номер пакета
    /// </summary>
    [Column("NUMBER")]
    public int Number {  get; set; }

    /// <summary>
    /// Идентификатор трубы
    /// </summary>
    [Column("ID_TUBE")]
    public Guid IdTube { get; set; }

    /// <summary>
    /// Труба
    /// </summary>
    [ForeignKey("IdTube")]
    public Tube Tube { get; set; }
}
