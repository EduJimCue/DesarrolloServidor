using Microsoft.AspNetCore.Mvc;
using Prueba.Data;
using Prueba.Models;

namespace Prueba.Controllers;

[ApiController]
[Route("[controller]")]
public class GymController : ControllerBase
{
  private readonly DataContext _context;
  private static List<Gimnasio>Gyms=new List<Gimnasio>{};
  public GymController (DataContext context){
    _context = context;
}
//Obtengo todos los gimnasios
[HttpGet]
public ActionResult<List<Gimnasio>>Get(){
    return Ok(_context.Gyms);
}
//Obtengo gimnasio por id
[HttpGet]
[Route("{Id}")]
public ActionResult<List<Gimnasio>>GetById(int Id){
    var Gimnasio = _context.Gyms.Find(Id);
    return Gimnasio==null ? NotFound(): Ok(Gimnasio);
}
//Obtener un gimnasio con un nombre parcial
[HttpGet]
[Route("/Gyms/{PartialName}")]
public ActionResult<List<Gimnasio>>GetByName(string PartialName){
    var Gimnasio = _context.Gyms.Where(x => x.Name.Contains(PartialName));
    return Gimnasio==null ? NotFound(): Ok(Gimnasio);
}
//Introducir un nuevo gimnasio
[HttpPost]
public ActionResult CreateGym(Gimnasio gymItem)
{
    var existingGym =_context.Gyms.Find(gymItem.Id);
    if (existingGym != null)
    {
        return Conflict("Ya existe un gimnasio con ese id");
    }else
    {
        _context.Gyms.Add(gymItem);
        _context.SaveChanges();
        var resourceUrl = Request.Path.ToString() + "/"+ gymItem.Id;
        return Created(resourceUrl,gymItem);
    }
   
}
//Modificar un gimnasio
[HttpPut]
public ActionResult UpdateGym(Gimnasio gymItem)
{
    var existingGym = _context.Gyms.Find(gymItem.Id);
    if (existingGym == null)
    {
        return NotFound("No se ha encontrado un gimnasio con ese id");
    }
    else
    {
        existingGym.Name = gymItem.Name;
        existingGym.Address = gymItem.Address;
        existingGym.MonthPrice = gymItem.MonthPrice;
        _context.SaveChanges();
        return Ok();
    }
}
//Eliminar un gimnasio
[HttpDelete]
[Route("{Id}")]
public ActionResult DeleteGym(int Id)
{
    var gym = _context.Gyms.Find(Id);
    if (gym == null)
    {
        return NotFound("No hay ningun gimnasio con ese Id");
    }
    _context.Gyms.Remove(gym);
    _context.SaveChanges();
    return NoContent();
}
}