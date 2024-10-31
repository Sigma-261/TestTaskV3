using Microsoft.AspNetCore.Mvc;
using TestTask.Models;
using TestTaskV3.Data;
using TestTaskV3.Data.Interfaces;

namespace TestTaskV3.API.v1.PackController;

[ApiController]
[Route("api/[controller]")]
public class PackController : CrudController<Pack>
{
    private readonly TubeContext _context;
    private readonly IEntityRepository<Pack> _packRepository;
    private ILogger<Pack> _logger;
    public PackController(IEntityRepository<Pack> packRepository,
        ILogger<Pack> logger,
        TubeContext tubeContext) : base(packRepository, logger)
    {
        _packRepository = packRepository;
        _logger = logger;
        _context = tubeContext;
    }

    /// <summary>
    /// Создание пакета
    /// </summary>
    /// <param name="model">Запись</param>
    /// <returns>Добавленная запись</returns>
    [HttpPost]
    public IActionResult CreatePack(List<Guid> tubes, int packNumber, DateTime date)
    {
        var test = _packRepository.GetListQuery()
            .DistinctBy(x => x.Number)
            .ToList();

        if (test.Any(x => x.Number == packNumber))
            return StatusCode(500, "пакет уже существует");

        List<Pack> pack = new List<Pack>();

        foreach (var tube in tubes)
        {
            var tubeq = _context.Tube.FirstOrDefault(x => x.Guid == tube);

            tubeq.IsPacked = true;

            pack.Add(new Pack()
            {
                Number = packNumber,
                IdTube = tube,
                DateCreate = date,
                DateUpdate = date
            });
        }

        _context.SaveChanges();
        _repository.AddRange(pack);

        return Ok(pack);
    }

    /// <summary>
    /// Добавление трубы в пакет
    /// </summary>
    /// <returns></returns>
    public IActionResult AddTube(List<Guid> tubes, int packNumber, DateTime date)
    {
        return Ok();
    }

    /// <summary>
    /// Удаление трубы из пакет
    /// </summary>
    /// <returns></returns>
    public IActionResult RemoveTube(List<Guid> tubes, int packNumber, DateTime date)
    {
        return Ok();
    }
}
