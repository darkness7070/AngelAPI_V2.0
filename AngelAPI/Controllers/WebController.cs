using Microsoft.AspNetCore.Mvc;

namespace AngelAPI.Controllers;
/// <summary>
/// Контроллер для Веб-сервиса
/// </summary>
public class WebController : Controller
{
    /// <summary>
    /// Возвращает список целей посещения
    /// </summary>
    [HttpGet]
    [Route("/web/purposes")]
    public IActionResult Purposes()
    {
        return Ok("OK");
    }
    /// <summary>
    /// Возвращает список подразделений
    /// </summary>
    [HttpGet]
    [Route("/web/subdivisions")]
    public IActionResult Subdivisions()
    {
        return Ok("OK");
    }
    
}