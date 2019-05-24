using System.Collections.Generic;

namespace lab4.model
{
    public class Worker
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        
        public string Patronimic { get; set; }
        
        public int Age { get; set; }
        
        
        //navigation property //auto-connection
        public ICollection<Project> Projects { get; set; } //ссылка 
    }
}