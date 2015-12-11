using System.Collections.Generic;
using CapstoneBlog.Domain;

namespace CapstoneBlog.DLL
{
    public interface IBlogRepository
    {
        void AddPost(Post newPost);
        void DeletePost(List<int> postID);
        List<Post> GetAllPostByCategory(string category);
        List<Domain.Post> GetAllPosts();
        //void UpdatePost(Post toUpdate);
        void AddWebpage(Models.Webpage page);
        Models.Webpage GetWebpageByTitle(string Title);
        void ApprovePost(List<int> postID);
    }
}