namespace ForumApp.Models
{
    using System.ComponentModel.DataAnnotations;
    using static ForumApp.Infrastructure.Constants.PostConstants;

    public class PostViewModel
    {
        public int Id { get; set; }

        [StringLength(PostTitleMaxLength, 
            MinimumLength = PostTitleMinLength)]
        public string Title { get; set; } = string.Empty;

        [StringLength(PostContentMaxLength, 
            MinimumLength = PostContentMinLength)]
        public string Content { get; set; } = string.Empty;
    }
}
