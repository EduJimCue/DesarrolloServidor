using Microsoft.AspNetCore.Mvc;
using Prueba.Data;
using Prueba.Models;

namespace Prueba.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
  private readonly DataContext _context;
  private static List<Gimnasio>Users=new List<Gimnasio>{};
  public UserController (DataContext context){
    _context = context;
}
//Obtengo todos los usuarios
[HttpGet]
public ActionResult<List<Gimnasio>>Get(){
    return Ok(_context.Users);
}
//Obtener usuario por id
[HttpGet]
[Route("{Id}")]
public ActionResult<List<User>>GetById(int Id){
    var User = _context.Users.Find(Id);
    return User==null ? NotFound(): Ok(User);
}
//Obtener usuario por nombre
[HttpGet]
[Route("/Users/{PartialName}")]
public ActionResult<List<User>>GetByName(string PartialName){
    var User = _context.Users.Where(x => x.Name.Contains(PartialName));
    return User==null ? NotFound(): Ok(User);
}
//Loguear a un usuario
[HttpGet]
[Route("/{UserName}/{PassWord}")]
public ActionResult<User> GetByLogin(string UserName, string PassWord)
{
    User user = _context.Users.SingleOrDefault(u => u.Username == UserName && u.Password == PassWord);
    return user == null ? NotFound() : Ok(user);
}
//Nuevo usuario
[HttpPost]
public ActionResult CreateUser(User userItem)
{
    var existingUser =_context.Users.Find(userItem.Id);
    var existingUsername = _context.Users.FirstOrDefault(u => u.Username == userItem.Username);
    if (existingUser != null)
    {
        return Conflict("Ya existe una usuario con ese id");
    }else
    {
        if (existingUsername!=null)
        {
            return Conflict("Ya existe una usuario con ese username");
        }else
        {
            _context.Users.Add(userItem);
        _context.SaveChanges();
        var resourceUrl = Request.Path.ToString() + "/"+ userItem.Id;
        return Created(resourceUrl,userItem);
    }
        }
        
}
//Modificar un usuario
[HttpPut]
public ActionResult UpdateUser(User userItem)
{
    var existingUser = _context.Users.Find(userItem.Id);
    if (existingUser == null)
    {
        return NotFound("No se ha encontrado un gimnasio con ese id");
    }
    else
    {
        if (userItem.Name!="string")
        {
            existingUser.Name = userItem.Name;
        }
        if (userItem.Username!="string")
        {
            existingUser.Username = userItem.Username;
        }
        if (userItem.Password!="string")
        {
            existingUser.Password = userItem.Password;
        }
        _context.SaveChanges();
        return Ok();
    }
}
//Eliminar usuario
[HttpDelete]
[Route("{Id}")]
public ActionResult DeleteUser(int Id)
{
    var userItem = _context.Users.Find(Id);
    if (userItem == null)
    {
        return NotFound("No hay ningun usuario con ese Id");
    }
    _context.Users.Remove(userItem);
    _context.SaveChanges();
    return NoContent();
}
}