using System.Collections.Generic;
using CapstoneBlog.Domain;
using CapstoneBlog.Models;

namespace CapstoneBlog.BLL
{
    public interface IBlogManager
    {
        Domain.Response<Domain.Post> AddPost(Domain.Post newPost);
        Domain.Response<Webpage> AddWebpage(Webpage page);
        Domain.Response<Domain.Post> ApprovePost(List<int> postID);
        Domain.Response<Domain.Post> DeletePost(List<int> postID);
        Domain.Response<List<Domain.Post>> GetAllApprovedPosts();
        Domain.Response<List<Domain.Post>> GetAllUnapprovedPosts();
        Domain.Response<List<Domain.Post>> GetPostsByCategory(string category);
        Domain.Response<Webpage> GetWebpageByTitle(string Title);
    }
}