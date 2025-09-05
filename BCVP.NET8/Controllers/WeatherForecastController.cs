using AutoMapper;
using BCVP.NET8.IService;
using BCVP.NET8.Model;
using BCVP.NET8.Service;
using Microsoft.AspNetCore.Mvc;

namespace BCVP.NET8.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;
    private readonly IBaseService<Role, RoleVo> _roleService;

    public IBaseService<Role,RoleVo> _roleServiceObj { get; set; }

    public WeatherForecastController(ILogger<WeatherForecastController> logger,
        IBaseService<Role,RoleVo> roleService)
    {
        _logger = logger;
        _roleService = roleService;
    }

    [HttpGet(Name = "GetUserVo")]
    public async Task<object> Get()
    {
        //var userService = new UserService();
        //var users = userService.Query();
        //return users;

        //var baseService = new BaseService<Role, RoleVo>(_mapper);
        //var roleList = await baseService.Query();

        //var roleList = await _roleService.Query();

        var roleList = await _roleServiceObj.Query();
        return roleList;
    }
}
