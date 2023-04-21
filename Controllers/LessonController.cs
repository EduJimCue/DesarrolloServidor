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
//Introducir una nueva leccion
[HttpPost]
public ActionResult CreateLesson(Leccion lessonItem)
{
    var existingLesson =_context.Lessons.Find(lessonItem.Id);
    if (existingLesson != null)
    {
        return Conflict("Ya existe una lección con ese id");
    }else
    {
        // Buscar el usuario correspondiente en la base de datos utilizando el ID enviado
        var teacher = _context.Users.Find(lessonItem.TeacherId);
        
        if (teacher == null)
        {
            return NotFound("No se encontró el profesor con el ID proporcionado");
        }
        if (!teacher.Role)
        {
            return Conflict("El usuario seleccionado no es un profesor");
        }
        // Asignar el usuario encontrado como profesor de la lección
        lessonItem.Teacher = teacher;
        
        _context.Lessons.Add(lessonItem);
        _context.SaveChanges();
        var resourceUrl = Request.Path.ToString() + "/"+ lessonItem.Id;
        return Created(resourceUrl,lessonItem);
    }
}
//Modificar una leccion
[HttpPut]
public ActionResult UpdateLesson(Leccion lessonItem)
{
    var existingLesson = _context.Lessons.Find(lessonItem.Id);
    var teacher = _context.Users.Find(lessonItem.TeacherId);
    if (teacher == null)
    {
        return NotFound("No se encontró el profesor con el ID proporcionado");
    }
    if (existingLesson == null)
    {
        return NotFound("No se ha encontrado ninguna leccion con ese id");
    }
    else
    {
        existingLesson.TeacherId=lessonItem.TeacherId;
        existingLesson.Minute=lessonItem.Minute;
         if (!teacher.Role)
        {
            return Conflict("El usuario seleccionado no es un profesor");
        }
         if (lessonItem.Name!="string")
        {
            existingLesson.Name = lessonItem.Name;
        }
          if (lessonItem.Capacity!=0)
        {
            existingLesson.Capacity=lessonItem.Capacity;
        }
         if (lessonItem.Description!="string")
        {
            existingLesson.Description=lessonItem.Description;
        }
        if (lessonItem.Hour!=0)
        {
            existingLesson.Hour=lessonItem.Hour;
        }
        _context.SaveChanges();
        return Ok();
    }
}
//Eliminar una leccon
[HttpDelete]
[Route("{Id}")]
public ActionResult DeleteLesson(int Id)
{
    var lesson = _context.Lessons.Find(Id);
    if (lesson == null)
    {
        return NotFound("No hay ninguna leccion con ese Id");
    }
    _context.Lessons.Remove(lesson);
    _context.SaveChanges();
    return NoContent();
}
}