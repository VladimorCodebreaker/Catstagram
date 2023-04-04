using System;
using Catstagram.Data.Base;
using Catstagram.Data.IServices;
using Catstagram.Data.ViewModels;
using Catstagram.Models;
using Microsoft.EntityFrameworkCore;

namespace Catstagram.Data.Services
{
	public class PostService : EntityBaseRepository<Post>, IPostService
	{
        private readonly DatabaseContext _context;

        public PostService(DatabaseContext context) : base(context)
        {
            _context = context;
        }

        public async Task AddNewPostAsync(PostVM data)
        {
            var post = new Post()
            {
                Image = data.Image,
                Name = data.Name,
                Email = data.Email,
                DateAdded = data.DateAdded,
                Comment = data.Comment
            };
            await _context.Posts.AddAsync(post);
            await _context.SaveChangesAsync();
        }

        public async Task UpdatePostAsync(PostVM data)
        {
            var post = await _context.Posts.FirstOrDefaultAsync(n => n.Id == data.Id);

            if (post != null)
            {
                post.Image = data.Image;
                post.Name = data.Name;
                post.Email = data.Email;
                post.DateAdded = data.DateAdded;
                post.Comment = data.Comment;

                await _context.SaveChangesAsync();
            }
        }
    }
}

