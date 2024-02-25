namespace ForumApp.Core.Services
{
    using ForumApp.Core.Contracts;
    using ForumApp.Core.Models;
    using ForumApp.Infrastructure.Data;
    using ForumApp.Infrastructure.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using System.Runtime.CompilerServices;
    using System.Threading.Tasks;

    public class PostService : IPostService
    {
        private readonly ForumAppDbContext context;

        public PostService(ForumAppDbContext context)
        {
            this.context = context;
        }

        public async Task SaveChangesAsync()
        {
            await context.SaveChangesAsync();
        }

        public async Task AddAsync(PostFormModel model)
        {
            var entity = new Post()
            {
                Title = model.Title,
                Content = model.Content
            };

            await context.Posts.AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Post>> GetAllAsync()
        {
            return await 
                this.context
                .Posts
                .ToListAsync();
        }

        public async Task<Post?> GetByIdAsync(int id)
        {
            return await this.context
                .Posts
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task DeleteAsync(int id)
        {
            var post = await this.context
                .Posts.FirstOrDefaultAsync(p => p.Id == id);

            if (post != null)
            {
                this.context.Posts.Remove(post);
                await this.context.SaveChangesAsync();
            }
        }
    }
}
