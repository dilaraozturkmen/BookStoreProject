namespace WebApi.Entities
{
     public class Genre 
     {
   
        public int id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; } = true;
     }
}