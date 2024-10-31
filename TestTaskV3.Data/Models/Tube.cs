using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using TestTaskV3.Data.Models;
using System.Xml.Serialization;
using System.Text.Json.Serialization;

namespace TestTask.Models;

/// <summary>
/// Труба
/// </summary>
[Table("TUBE")]
public class Tube : Entity
{
    /// <summary>
    /// Номер трубы
    /// </summary>
    [Column("NUMBER")]
    public int Number {  get; set; }

    /// <summary>
    /// Является ли труба бракованной
    /// </summary>
    [Column("IS_DEFECT")]
    public bool IsDefect { get; set; }

    /// <summary>
    /// Является ли труба упакованной
    /// </summary>
    [Column("IS_PACKED")]
    public bool IsPacked { get; set; }

    /// <summary>
    /// Идентификатор марки стали
    /// </summary>
    [Column("ID_GRADE")]
    public Guid IdGrade { get; set; }

    /// <summary>
    /// Марка стали
    /// </summary>
    [ForeignKey("IdGrade")]
    [JsonIgnore]
    [XmlIgnore]
    public SteelGrade Grade { get; set; }

    /// <summary>
    /// Вес трубы
    /// </summary>
    [Column("WEIGHT")]
    public decimal Weight { get; set; }
}
