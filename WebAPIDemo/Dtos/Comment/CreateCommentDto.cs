using System.ComponentModel.DataAnnotations;

namespace WebAPIDemo.Dtos.Comment
{
    public class CreateCommentDto
    {
        [Required]
        [MinLength(5, ErrorMessage ="Title must have atleast 5 characters")]
        [MaxLength(150, ErrorMessage ="Title cannot be over 150 characters")]
        public string Title { get; set; } = string.Empty;

        [Required]
        [MinLength(5, ErrorMessage = "Content must have atleast 5 characters")]
        [MaxLength(150, ErrorMessage = "Content cannot be over 150 characters")]
        public string Content { get; set; } = string.Empty;
    }
}
