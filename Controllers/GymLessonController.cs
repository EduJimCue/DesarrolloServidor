using Microsoft.AspNetCore.Mvc;
using Prueba.Data;
using Prueba.Models;

namespace Prueba.Controllers;

[ApiController]
[Route("[controller]")]
public class GymLessonController : ControllerBase
{
  private readonly DataContext _context;
  private static List<GimnasioLesson>GymLesson=new List<GimnasioLesson>{};
  public GymLessonController (DataContext context){
    _context = context;
}
//Obtengo todas las relaciones gimnasio-leccion
[HttpGet]
public ActionResult<List<GimnasioLesson>>Get(){
    return Ok(_context.GymLesson);
}
//Obtengo todas las leccion de un gimnasio por su id
[HttpGet("{gymId}")]
public ActionResult<List<Leccion>> GetById(int gymId)
{
    var gymLessons = _context.GymLesson.Where(item => item.GimnasioId == gymId).ToList();
    var lessons = new List<Leccion>();
    foreach (var item in gymLessons)
    {
        var lesson = _context.Lessons.Find(item.LeccionId);
        if (lesson != null)
        {
            lessons.Add(lesson);
        }
    }
    return lessons.Count == 0 ? NotFound("No existe un gimnasio con ese id") : Ok(lessons);
}
}