namespace Prueba.Models;

    public class Gimnasio
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int MonthPrice { get; set; }
        public DateTime SignUpDate { get; set; }
     

        private static int Number = 12345678;

        public Gimnasio()
        {
        }

        public Gimnasio(string name, string address, int monthPrice)
        {
            Name = name;
            Address = address;
            MonthPrice = monthPrice;
            SignUpDate = DateTime.Now;
            Id = Number;
            Number++;
        }
    }