using Microsoft.AspNetCore.Mvc;
using TestTask.Models;
using TestTaskV3.Data.Interfaces;
using TestTaskV3.Data;
using System.ComponentModel;
using TestTaskV3.Data.Models;

namespace TestTaskV3.API.v1.TubeController;

[ApiController]
[Route("api/[controller]")]
public class TubeController : CrudController<Tube>
{
    private readonly IEntityRepository<Tube> _tubeRepository;
    private ILogger<Tube> _logger;
    public TubeController(IEntityRepository<Tube> tubeRepository,
        ILogger<Tube> logger) : base(tubeRepository, logger)
    {
        _tubeRepository = tubeRepository;
        _logger = logger;
    }

    /// <summary>
    /// Обновление записи
    /// </summary>
    /// <param name="model">Обновленная запись</param>
    /// <returns></returns>
    [HttpPut]
    public override IActionResult Update(Tube model)
    {
        var fromDb = _tubeRepository.Get(model.Guid);
        if (fromDb == null) 
            return NotFound("Запись с заданным идентификатором не найдена");

        if(fromDb.IsPacked == true)
            return StatusCode(500, "Труба является частью пакета!");

        if (_tubeRepository.Update(model))
            return Ok(model);

        return StatusCode(500, "Не удалось обновить данные трубы");
    }

    /// <summary>
    /// Удаление записи
    /// </summary>
    /// <param name="guid">Идентификатор записи</param>
    /// <returns></returns>
    [HttpDelete("{guid}")]
    [HttpDelete("delete/{guid}")]
    public override IActionResult DeleteByGuid(Guid guid)
    {
        var entity = _tubeRepository.Get(guid);
        if (entity == null) 
            return NotFound("Запись с заданным идентификатором не найдена");

        if (entity.IsPacked == true)
            return StatusCode(500, "Труба является частью пакета!");

        if (_tubeRepository.Delete(guid))
        {
            return Ok();
        }

        return StatusCode(500, "Произошла ошибка при удалении записи");
    }

    /// <summary>
    /// Получение статистики по товарам
    /// </summary>
    /// <returns>Статистика по трубам</returns>
    [HttpGet("statistics")]
    public virtual IActionResult GetStatistics(Guid guid)
    {
        var models = _tubeRepository.GetListQuery().ToArray();

        if (models.Length == 0)
            return NotFound("Труб нет!");

        return Ok(new TubeStatistics
        {
            TotalCount = models.Length,
            DefectCount = models.Where(x => x.IsDefect == true).Count(),
            QualityCount = models.Where(x => x.IsDefect == false).Count(),
            TotalWeight = models.Sum(x => x.Weight)
        });
    }

}
