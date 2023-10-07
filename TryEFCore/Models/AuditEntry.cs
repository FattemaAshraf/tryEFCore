namespace TryEFCore.Models
{
    public class AuditEntry
    {
        public int Id { get; set; }
        public string userName { get; set; }
        public string Action { get; set; }
    }
}
