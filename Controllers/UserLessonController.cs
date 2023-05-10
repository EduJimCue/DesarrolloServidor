using Microsoft.AspNetCore.Mvc;
using Prueba.Data;
using Prueba.Models;

namespace Prueba.Controllers;

[ApiController]
[Route("UserLesson")]
public class UserLessonController : ControllerBase
{
  private readonly DataContext _context;
  private static List<UserLesson>UserLesson=new List<UserLesson>{};
  public UserLessonController (DataContext context){
    _context = context;
}
//Obtengo todas las relaciones gimnasio-leccion
[HttpGet]
[Route("GetAllUserLesson")]
public ActionResult<List<UserLesson>>Get(){
    return Ok(_context.UsuarioLesson);
}
//Obtengo todas las lecciones que tiene un usuario
[HttpGet("/GetUserLessonUser/{userId}")]
public ActionResult<List<UserLesson>> GetByUserId(int userId)
{
    var userLessons = _context.UsuarioLesson.Where(item => item.UsuarioId == userId).ToList();
    var lessons = new List<Leccion>();
    foreach (var item in userLessons)
    {
        var lesson = _context.Lessons.Find(item.LeccionId);
        if (lesson != null)
        {
            lessons.Add(lesson);
        }
    }
    return lessons.Count == 0 ? NotFound("No existe un usuario con ese id") : Ok(lessons);
}
//Obtengo todos los usuarios que estan en una leccion
[HttpGet("/GetLessonUser/{lessonId}")]
public ActionResult<List<UserLesson>> GetByLessonId(int lessonId)
{
    var userLessons = _context.UsuarioLesson.Where(item => item.LeccionId == lessonId).ToList();
    return userLessons.Count == 0 ? NotFound(userLessons) : Ok(userLessons);
}
//Apuntar a un usuario en una leccion
[HttpPost]
[Route("PostUserLesson")]
public ActionResult CreateUserLesson(UserLesson userLesson)
{
    var existingUserLesson = _context.UsuarioLesson
        .FirstOrDefault(ul => ul.UsuarioId == userLesson.UsuarioId && ul.LeccionId == userLesson.LeccionId);
    if (existingUserLesson != null)
    {
        return Conflict("Ya existe una relación con este usuario y esta lección");
    }
    else
    {
        _context.UsuarioLesson.Add(userLesson);
        _context.SaveChanges();
        var resourceUrl = Request.Path.ToString() + "/" + userLesson.Id;
        return Created(resourceUrl, userLesson);
    }  
}
//Eliminar relacion usuario leccion
[HttpDelete]
[Route("DeleteUserLesson/{userId}/{lessonId}")]
public ActionResult DeleteUserLesson(int userId, int lessonId)
{
    var userLesson = _context.UsuarioLesson.SingleOrDefault(ul => ul.UsuarioId == userId && ul.LeccionId == lessonId);
    if (userLesson == null)
    {
        return NotFound("No hay ninguna relación con esos Ids");
    }
    
    _context.UsuarioLesson.Remove(userLesson);
    _context.SaveChanges();
    
    return NoContent();
}
}