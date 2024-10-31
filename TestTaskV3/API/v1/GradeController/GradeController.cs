using Microsoft.AspNetCore.Mvc;
using TestTask.Models;
using TestTaskV3.Data;
using TestTaskV3.Data.Interfaces;

namespace TestTaskV3.API.v1.GradeController;

[ApiController]
[Route("api/[controller]")]
public class GradeController : CrudController<SteelGrade>
{
    private readonly IEntityRepository<SteelGrade> _gradeRepository;
    private ILogger<SteelGrade> _logger;

    public GradeController(IEntityRepository<SteelGrade> gradeRepository,
        ILogger<SteelGrade> logger) : base(gradeRepository, logger)
    {
        _gradeRepository = gradeRepository;
        _logger = logger;
    }
}
