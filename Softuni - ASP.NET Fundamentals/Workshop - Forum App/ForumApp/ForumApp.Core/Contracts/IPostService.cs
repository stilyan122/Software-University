namespace ForumApp.Core.Contracts
{
    using ForumApp.Core.Models;
    using ForumApp.Infrastructure.Data.Models;

    public interface IPostService
    {
        public Task SaveChangesAsync();

        public Task<IEnumerable<Post>> GetAllAsync();

        public Task AddAsync(PostFormModel model);

        public Task<Post?> GetByIdAsync(int id);

        public Task DeleteAsync(int id);
    }
}
