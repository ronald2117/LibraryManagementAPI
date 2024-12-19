namespace LibraryManagementAPI.Models
{
    public class PhysicalBook : Book
    {
        public string? ISBN { get; set; }
        public int? CopiesAvailable { get; set; }
    }
}
