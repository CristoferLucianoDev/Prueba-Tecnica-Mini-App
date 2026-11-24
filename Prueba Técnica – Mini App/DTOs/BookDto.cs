using System.ComponentModel.DataAnnotations;

namespace Prueba_Técnica___Mini_App.DTOs
{
    public class BookDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
    }

    public class BookRequest
    {
        [Required, MaxLength(100, ErrorMessage = "The title cannot exceed 100 characters.")]
        public string Title { get; set; } = string.Empty;
    }
}
