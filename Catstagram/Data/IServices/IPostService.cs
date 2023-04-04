using System;
using Catstagram.Data.Base;
using Catstagram.Data.ViewModels;
using Catstagram.Models;

namespace Catstagram.Data.IServices
{
	public interface IPostService : IEntityBaseRepository<Post>
    {
        Task AddNewPostAsync(PostVM entity);
        Task UpdatePostAsync(PostVM entity);
    }
}

