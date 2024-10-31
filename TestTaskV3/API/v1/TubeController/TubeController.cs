using Microsoft.AspNetCore.Mvc;
using TestTask.Models;
using TestTaskV3.Data.Interfaces;
using TestTaskV3.Data;
using System.ComponentModel;

namespace TestTaskV3.API.v1.TubeController;

[ApiController]
[Route("api/[controller]")]
public class TubeController : ControllerBase
{
    private readonly TubeContext _context;
    private readonly IEntityRepository<Tube> _tubeRepository;

    public TubeController(TubeContext context,
        IEntityRepository<Tube> tubeRepository)
    {
        _context = context;
        _tubeRepository = tubeRepository;
    }

    /// <summary>
    /// Синхронизация всех сигналов
    /// </summary>
    [HttpGet("test")]
    public IActionResult Test(int i)
    {
        Console.WriteLine(i);
        return Ok("urs");
    }
}
