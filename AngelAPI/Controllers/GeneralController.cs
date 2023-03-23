using System.Net.Mime;
using AngelAPI.Entities;
using AngelAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace AngelAPI.Controllers;
/// <summary>
/// Главный контроллер, отвечает на общие запросы разных приложений
/// </summary>
public class GeneralController : Controller
{
    PostgresContext _db = new();
    /// <summary>
    /// Аутентификация по коду
    /// </summary>
    [HttpGet]
    [Route("general/auth")]
    public IActionResult Code([FromQuery]string code)
    {
        var employee = _db.Employees
            .Where(x => x.Code.ToLower() == code.ToLower())
            .FirstOrDefault();
        return employee == null ? Unauthorized() : Ok(JsonConvert.SerializeObject(employee));
    }
    /// <summary>
    /// Аутентификация для пользователей с логином и паролем
    /// </summary>
    [HttpPost]
    [Route("general/auth")]
    public IActionResult Auth([FromBody]RequestGeneral.Authentication request)
    {
        var User = _db.Users
            .Where(x => x.Login == request.Login)
            .Where(x => x.Password == request.Password)
            .FirstOrDefault();
        return User == null ? Unauthorized() : Ok(JsonConvert.SerializeObject(User));
    }
    /// <summary>
    /// По id заявки получаем информацию о ней (Low-Security)
    /// </summary>
    [HttpGet]
    [Route("general/application")]
    public IActionResult Application([FromQuery] int id)
    {
        return _db.Applications.FirstOrDefault(x => x.Id == id) == null
            ? NotFound()
            : Ok(JsonConvert.SerializeObject(
                    new ResponseGeneral.InfoApplication(
                        _db.Applications
                            .Include(x => x.IdPurposeNavigation)
                            .Include(x => x.IdSubdivisionNavigation)
                            .Include(x => x.IdSubdivisionNavigation.IdSubdivisionNavigation)
                            .Include(x => x.IdSubdivisionNavigation.IdWorkerNavigation)
                            .FirstOrDefault(x => x.Id == id),
                        _db.AppVisitors
                            .Where(x => x.IdApp == id)
                            .Select(x => x.IdVisitorNavigation)
                            .ToList()
                    ),
                    new JsonSerializerSettings
                    {
                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                    }
                )
            );
    }
    /// <summary>
    /// По token`у получаем список заявок пользователя
    /// </summary>
    [HttpPost]
    [Route("general/applications")]
    public IActionResult Applications([FromBody]RequestGeneral.Applications request)
    {
        List<ResponseGeneral.InfoApplications> apps = new();
        if (request.isAdmin)
        {
            foreach (var item in _db.Applications.ToList())
            {
                apps.Add(new ResponseGeneral.InfoApplications(item,
                    _db.WorkerSubdivisions.Where(x=>x.Id == item.IdSubdivision).Select(x=>x.IdWorkerNavigation).ToList(),
                    _db.WorkerSubdivisions.Where(x=>x.Id == item.IdSubdivision).Select(x=>x.IdSubdivisionNavigation).ToList()
                ));
            }
        }
        else
        {
            foreach (var item in _db.AppUsers.Where(x => x.IdUserNavigation.Token == request.Token).Select(x => x.IdAppNavigation).ToList())
            {
                apps.Add(new ResponseGeneral.InfoApplications(item,
                    _db.WorkerSubdivisions.Where(x=>x.Id == item.IdSubdivision).Select(x=>x.IdWorkerNavigation).ToList(),
                    _db.WorkerSubdivisions.Where(x=>x.Id == item.IdSubdivision).Select(x=>x.IdSubdivisionNavigation).ToList()
                ));
            }
        }
        return Ok(JsonConvert.SerializeObject(apps,
                    new JsonSerializerSettings
                    {
                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                    }
                )
            );
    }
}