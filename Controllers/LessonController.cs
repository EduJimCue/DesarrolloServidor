using Microsoft.AspNetCore.Mvc;
using Prueba.Data;
using Prueba.Models;

namespace Prueba.Controllers;

[ApiController]
[Route("[controller]")]
public class LessonController : ControllerBase
{
  private readonly DataContext _context;
  private static List<Leccion>Lesson=new List<Leccion>{};
  public LessonController (DataContext context){
    _context = context;
}
//Obtengo todas las lecciones
[HttpGet]
public ActionResult<List<Leccion>>Get(){
    return Ok(_context.Lessons);
}
//Obtengo leccion por id
[HttpGet]
[Route("{Id}")]
public ActionResult<List<Leccion>>GetById(int Id){
    var Lesson = _context.Lessons.Find(Id);
    return Lesson==null ? NotFound(): Ok(Lesson);
}
//Obtener una leccion por nombre parcial
[HttpGet]
[Route("/Lessons/{PartialName}")]
public ActionResult<List<Leccion>>GetByName(string PartialName){
    var Lesson = _context.Lessons.Where(x => x.Name.Contains(PartialName));
    return Lesson==null ? NotFound(): Ok(Lesson);
}

}