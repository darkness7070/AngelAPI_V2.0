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
    PostgresContext db = new();
    /// <summary>
    /// Аутентификация по коду
    /// </summary>
    [HttpGet]
    [Route("general/auth")]
    public IActionResult Code([FromQuery]string code)
    {
        var Employeer = db.Employees
            .Where(x => x.Code.ToLower() == code.ToLower())
            .FirstOrDefault();
        return Employeer == null ? Unauthorized() : Ok(JsonConvert.SerializeObject(Employeer));
    }
    /// <summary>
    /// Аутентификация для пользователей с логином и паролем
    /// </summary>
    [HttpPost]
    [Route("general/auth")]
    public IActionResult Auth([FromBody]RequestGeneral.Authentication request)
    {
        var User = db.Users
            .Where(x => x.Login == request.Login)
            .Where(x => x.Password == request.Password)
            .FirstOrDefault();
        return User == null ? Unauthorized() : Ok(JsonConvert.SerializeObject(User));
    }
    /// <summary>
    /// По id заявки получаем информацию о ней (Low-Security)
    /// </summary>
    [HttpPost]
    [Route("general/application")]
    public IActionResult Application([FromQuery] int Id)
    {
        return db.Applications.FirstOrDefault(x => x.Id == Id) == null
            ? NotFound()
            : Ok(JsonConvert.SerializeObject(
                    new ResponseGeneral.InfoApplication(
                        db.Applications
                            .Include(x => x.IdPurposeNavigation)
                            .Include(x => x.IdSubdivisionNavigation)
                            .Include(x => x.IdSubdivisionNavigation.IdSubdivisionNavigation)
                            .Include(x => x.IdSubdivisionNavigation.IdWorkerNavigation)
                            .FirstOrDefault(x => x.Id == Id),
                        db.AppVisitors
                            .Where(x => x.IdApp == Id)
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
        return request.isAdmin ? Ok(JsonConvert.SerializeObject(db.Applications.ToList())) :
            db.Users.FirstOrDefault(x => x.Token == request.Token) == null ? Unauthorized() :
            Ok(JsonConvert.SerializeObject(
                db.AppUsers
                        .Where(x => x.IdUserNavigation.Token == request.Token)
                        .Select(x => x.IdAppNavigation)
                        .ToList(),
                    new JsonSerializerSettings
                    {
                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                    }
                )
            );
    }
}