using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapstoneBlog.Domain;


namespace CapstoneBlog.DLL
{
    public class BlogRepository : IBlogRepository
    {
        public void AddPost(Post newPost)
        {
            using (var context = new Models.PostContext())
            {
                Models.Post post = new Models.Post();

                post.Title = newPost.Title;
                post.IsApproved = newPost.IsApproved;
                post.DatePosted = newPost.DatePosted;
                post.Content = newPost.Content;
                post.CatID = newPost.CatID;
                post.Categories = newPost.Categories.Select(x => new Models.Category() { category = x.category }).ToList();

                context.Posts.Add(post);
                context.SaveChanges();
            }           
        }

        public void DeletePost(List<int> postID)
        {
            foreach (var ID in postID)
            {
                using (var context = new Models.PostContext())
                {
                    var post = context.Posts.Where(x => x.PostID == ID);

                    foreach (var p in post)
                    {
                        context.Posts.Remove(p);
                    }
                    context.SaveChanges();
                }
            }

        }

        public List<Post> GetAllPosts()
        {
            var list = new List<Post>();
            using (var context = new Models.PostContext())
            {


                var posts = context.Posts;
                foreach(var post in posts)
                {
                    list.Add(MapPost(post));
                }

               
                return list;
            }            
        }

        public List<Post> GetAllPostByCategory(string category)
        {
            var list = GetAllPosts();
            var query = new List<Post>();

            foreach(var post in list)
            {
                foreach(var cat in post.Categories)
                {
                    if (cat.category.Contains(category) && post.IsApproved == true)
                        query.Add(post);
                }
            }

            return query;
        }

        //public void UpdatePost(Post toUpdate)
        //{
        //    using (var context = new Models.PostContext())
        //    {
        //        var post = context.Posts.FirstOrDefault(x => x.PostID == toUpdate.PostID);

        //        post = toUpdate;
        //        context.SaveChanges();               
        //    }
        //}

        public void ApprovePost(List<int> postID)
        {
            using (var context = new Models.PostContext())
            {
                foreach (var p in postID)
                {
                    var post = context.Posts.FirstOrDefault(x => x.PostID == p);

                    post.IsApproved = true;
                    context.SaveChanges();
                }
            }
            
        }

        public void AddWebpage(Models.Webpage page)
        {
            using (var context = new Models.PostContext())
            {
                context.Webpages.Add(page);
                context.SaveChanges();
            }
        }
        
        public Models.Webpage GetWebpageByTitle(string Title)
        {
            var pages = new List<Models.Webpage>();

            using (var context = new Models.PostContext())
            {
                foreach(var page in context.Webpages)
                {
                    pages.Add(page);
                }

                return pages.FirstOrDefault(x => x.Title == Title);               
            }
        }

        private Post MapPost(Models.Post from)
        {
            var to = new Post();

            to.PostID = from.PostID;
            to.Title = from.Title;
            to.IsApproved = from.IsApproved;
            to.DatePosted = from.DatePosted;
            to.Content = from.Content;
            to.CatID = from.CatID;
            to.Categories = from.Categories.Select(x => MapCategory(x)).ToList();

            return to;
        }

        private Category MapCategory(Models.Category from)
        {
            var to = new Category();
            to.category = from.category;
            return to;
        }
    }
}
