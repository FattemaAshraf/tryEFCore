namespace TryEFCore.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int NationalityId { get; set; }

        public Nationality Nationality { get; set; }
    }
}