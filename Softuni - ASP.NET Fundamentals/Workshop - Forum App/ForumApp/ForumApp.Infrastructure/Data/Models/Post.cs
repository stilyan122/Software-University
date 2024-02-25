namespace ForumApp.Infrastructure.Data.Models
{
    using Microsoft.EntityFrameworkCore;
    using System.ComponentModel.DataAnnotations;
    using static ForumApp.Infrastructure.Constants.PostConstants;
    /// <summary>
    /// Post entity class
    /// </summary>
    [Comment("Post Entity Class")]
    public class Post
    {
        /// <summary>
        /// Post Identificator => Primary Key
        /// </summary>
        [Key]
        [Comment("Post Id")]
        public int Id { get; init; }

        /// <summary>
        /// Post Title
        /// </summary>
        [Comment("Post Title")]
        [Required]
        [StringLength(PostTitleMaxLength, 
            MinimumLength = PostTitleMinLength)]
        public string Title { get; set; } = string.Empty;

        /// <summary>
        /// Post Content
        /// </summary>
        [Comment("Post Content")]
        [StringLength(PostContentMaxLength, 
            MinimumLength = PostContentMinLength)]
        public string Content { get; set; } = string.Empty;
    }
}
