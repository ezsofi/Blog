using Blog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Database.Repository
{
    public class PostService : IPostService
    {
        private readonly BlogDbContext dbContext;
        public PostService(BlogDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void AddPost(Post post)
        {
            dbContext.Posts.Add(post);
        }

        public List<Post> GetAllPost()
        {
            return dbContext.Posts.ToList();
        }

        public Post GetPost(int id)
        {
            return dbContext.Posts.FirstOrDefault(p => p.Id ==id);
        }

        public void RemovePost(int id)
        {
            dbContext.Remove(GetPost(id));
        }

        public void UpdatePost(Post post)
        {
            dbContext.Posts.Update(post);
        }
        public async Task<bool> SaveChangesAsync()
        {
            if (await dbContext.SaveChangesAsync() > 0)
            {
                return true;
            }
            return false;
        }
    }
}
