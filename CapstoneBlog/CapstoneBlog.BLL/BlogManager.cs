using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapstoneBlog.Domain;
using CapstoneBlog.DLL;
using System.Text.RegularExpressions;


namespace CapstoneBlog.BLL
{
    public class BlogManager : IBlogManager
    {
        private IBlogRepository _repo;
        public BlogManager()
        {
            _repo = new BlogRepository();
        }
        public BlogManager(IBlogRepository repo)
        {
            repo = _repo;
        }
        
        public Response<List<Post>> GetAllUnapprovedPosts()
        {
            var response = new Response<List<Post>>();
            try
            {
                var posts = _repo.GetAllPosts();

                response.Data = posts.Where(x => x.IsApproved == false).ToList();
                response.Success = true;
                response.Message = "Loaded all unapproved posts.";
            }
            catch(Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public Response<List<Post>> GetAllApprovedPosts()
        {
            var response = new Response<List<Post>>();
            try
            {
                var posts = _repo.GetAllPosts();

                response.Data = posts.Where(x => x.IsApproved == true).ToList();
                response.Success = true;
                response.Message = "Loaded all approved posts.";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public Response<List<Post>> GetPostsByCategory(string category)
        {
            var response = new Response<List<Post>>();

            try
            {
                response.Data = _repo.GetAllPostByCategory(category).Where(x => x.IsApproved == true).ToList();
                response.Success = true;
                response.Message = "Successfully retrieved posts.";
            }
            catch(Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public Response<Post> AddPost(Post newPost)
        {
            Regex pattern = new Regex(@"#\w+", RegexOptions.IgnoreCase);
            var cats = new List<string>();
            List<Category> catList = new List<Category>();

            foreach (Match match in pattern.Matches(newPost.Content))
            {
                string cat = match.Value;
                cats.Add(cat.Substring(1, cat.Length - 1) + " ");

                foreach (var c in cats)
                {
                    catList.Add(new Category() { category = c });
                }
            }

            newPost.Categories = catList;
            var response = new Response<Post>();

            try
            {

                _repo.AddPost(newPost);
                response.Success = true;
                response.Message = "Successfully added post.";
            }
            catch(Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public Response<Post> DeletePost(List<int> postID)
        {
            var response = new Response<Post>();
            try
            {
                _repo.DeletePost(postID);
                response.Success = true;
                response.Message = "successfully deleted post.";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        //public Response<Post> UpdatePost(Post toUpdate)
        //{
        //    var response = new Response<Post>();
        //    try
        //    {
        //        _repo.UpdatePost(toUpdate);
        //        response.Success = true;
        //        response.Message = "Successfully updated post.";
        //    }
        //    catch(Exception ex)
        //    {
        //        response.Success = false;
        //        response.Message = ex.Message;
        //    }
        //    return response;
        //}

        public Response<Post> ApprovePost(List<int> postID)
        {
            var response = new Response<Post>();
            try
            {
                _repo.ApprovePost(postID);
                response.Message = "Successfully Approved.";
                response.Success = true;        
            }
            catch(Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public Response<Models.Webpage> AddWebpage(Models.Webpage page)
        {
            var response = new Response<Models.Webpage>();

            try
            {
                _repo.AddWebpage(page);
                response.Success = true;
                response.Message = "Added Webpage.";
            }
            catch(Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public Response<Models.Webpage> GetWebpageByTitle(string Title)
        {
            var response = new Response<Models.Webpage>();
            try
            {
                response.Data = _repo.GetWebpageByTitle(Title);
                response.Success = true;
                response.Message = "Success.";
            }
            catch(Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }
    }
}
