

namespace TryEFCore.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [Required,MaxLength(50)]
        public string FirstName { get; set; }
        [Required, MaxLength(50)]
        public string LastName { get; set; }
        public string DisplayName { get; set; }

    }
}
