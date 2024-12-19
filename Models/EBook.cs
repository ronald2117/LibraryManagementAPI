namespace LibraryManagementAPI.Models
{
    public class Ebook : Book
    {
        public string? FilePath { get; set; }
        public string? Format { get; set; } // e.g., PDF, ePub
    }
}
