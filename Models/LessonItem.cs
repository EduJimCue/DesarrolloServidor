namespace Prueba.Models;

    public class Leccion
{
    public string Name { get; set;}
    public int TeacherId{ get; set;}
    public List<User> students = new List<User>();
    public string Description { get; set; }
    public int Hour{ get; set; } 
    public int Minute{ get; set; } 
    public int Capacity{ get; set; } 
    public int Id{ get; set; } 

    public Leccion(){}
    
    //Creador con datos
    public Leccion(string Name,int TeacherId,string Description,int Hour, int Minute, int Capacity)
    { 
       
        {
            this.Name=Name;
            this.TeacherId=TeacherId;
            this.Description=Description;
            this.Hour=Hour;
            this.Minute=Minute;
            this.Capacity=Capacity;
        }
    }
}


