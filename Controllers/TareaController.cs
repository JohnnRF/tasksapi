using Microsoft.AspNetCore.Mvc;
using proyectoef.Models;
using tasksapi.Services;

namespace tasksapi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TareaController : ControllerBase
{
    ITareasService tareasService;

    public TareaController(ITareasService service)
    {
        this.tareasService = service;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(tareasService.Get());
    }
}
