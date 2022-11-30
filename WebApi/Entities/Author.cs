namespace WebApi.Entities
{
     public class Author
     {
        public int id { get; set; }   
        
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; } 
     }
}