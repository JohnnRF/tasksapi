using Microsoft.AspNetCore.Mvc;

namespace tasksapi.Controllers;

[ApiController]
[Route("api/[controller]")]

public class HelloWorldController : ControllerBase
{
    IHelloWorldService helloWorldService;

    public HelloWorldController(IHelloWorldService helloWorld)
    {
        this.helloWorldService = helloWorld;
    }


    [HttpGet]
    public IActionResult Get(){
        return Ok(helloWorldService.GetHelloWorld());
    }
}