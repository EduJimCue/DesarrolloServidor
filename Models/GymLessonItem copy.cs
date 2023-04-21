namespace Prueba.Models;
    public class GimnasioLesson
{
public int Id {get; set;}
public int GimnasioId { get; set; }
 public Gimnasio Gimnasio { get; set; }
public int LeccionId { get; set; }
public Leccion Leccion { get; set; }
}