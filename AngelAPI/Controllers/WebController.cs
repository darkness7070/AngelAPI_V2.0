using AngelAPI.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace AngelAPI.Controllers;
/// <summary>
/// Контроллер для Веб-сервиса
/// </summary>
public class WebController : Controller
{
    private PostgresContext db = new();
    /// <summary>
    /// Возвращает список целей посещения
    /// </summary>
    [HttpGet]
    [Route("/web/purposes")]
    public IActionResult Purposes()
    {
        return Ok(JsonConvert.SerializeObject(db.Purposes.ToList()));
    }

    /// <summary>
    /// Возвращает список подразделений
    /// </summary>
    [HttpGet]
    [Route("/web/subdivisions")]
    public IActionResult Subdivisions()
    {
        return Ok(JsonConvert.SerializeObject(
            db.Subdivisions
                .ToList()
            ));
    }
    /// <summary>
    /// Получаем список рабочих по id подразделения
    /// </summary>
    [HttpGet]
    [Route("/web/workers")]
    public IActionResult Workers([FromQuery]int id)
    {
        return Ok(JsonConvert.SerializeObject(
            db.WorkerSubdivisions
                .Include(x=>x.IdWorkerNavigation)
                .Where(x=>x.IdSubdivision == id)
                .Select(x=>x.IdWorkerNavigation)
                .ToList()
        ));
    }
}