namespace lab4.model
{
    public class Project
    {
        public int Id { get; set; }
        public string ProjectName { get; set; }
        public int Premium { get; set; }
      
        public int WorkerId { get; set; } // внешний ключ //ссылка
        public Worker Worker { get; set; }  //navigation property  //ссылка
    }
}