using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using CapstoneBlog.DLL;
using CapstoneBlog.BLL;
using CapstoneBlog.Domain;

namespace CapstoneBlog.Tests
{
    [TestFixture]
    public class BlogManagerTests
    {
        [Test]
        public void GetAllApprovedPostsTest()
        {
            Mock<IBlogManager> mockManager = new Mock<IBlogManager>();

            mockManager.Setup(x => x.GetAllApprovedPosts()).Returns(new Response<List<Post>>()
                 {
                     Data = new List<Post>()
                {
                   new Post() {
                    Title = "Mock Posts",
                    Categories = new List<Category>() { new Category() { category =  "Test" } },
                    Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nulla finibus, risus id sagittis tristique, felis nulla sodales nulla, nec pretium mi lacus in urna. Fusce scelerisque orci purus. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Vestibulum at massa fringilla, scelerisque justo non, vestibulum ex. Quisque eu nulla felis. Cras gravida lacus id sem tincidunt, vitae mattis est consectetur. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. In vestibulum porttitor arcu vel pharetra. In hac habitasse platea dictumst.",
                    DatePosted = DateTime.Now,
                    IsApproved = true },

                    new Post() {
                     Title = "Different Category",
                     Categories = new List<Category>() { new Category { category = "Category Test" } },
                     Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nulla finibus, risus id sagittis tristique, felis nulla sodales nulla, nec pretium mi lacus in urna. Fusce scelerisque orci purus. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Vestibulum at massa fringilla, scelerisque justo non, vestibulum ex. Quisque eu nulla felis. Cras gravida lacus id sem tincidunt, vitae mattis est consectetur. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. In vestibulum porttitor arcu vel pharetra. In hac habitasse platea dictumst.",
                     DatePosted = DateTime.Now,
                     IsApproved = true }
                },

                     Success = true,
                 });

            Assert.AreEqual(2, mockManager.Object.GetAllApprovedPosts().Data.Count());
            Assert.IsTrue(mockManager.Object.GetAllApprovedPosts().Success);
        }

        [Test]
        public void GetAllUnapprovedPostsTest()
        {
            Mock<IBlogManager> mockManager = new Mock<IBlogManager>();

            mockManager.Setup(x => x.GetAllUnapprovedPosts()).Returns(new Response<List<Post>>()
            {
                Data = new List<Post>()
            {
                 new Post() {
                     Title = "Not Approved Post",
                     Categories = new List<Category>() { new Category { category =  "Category Test" } },
                     Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nulla finibus, risus id sagittis tristique, felis nulla sodales nulla, nec pretium mi lacus in urna. Fusce scelerisque orci purus. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Vestibulum at massa fringilla, scelerisque justo non, vestibulum ex. Quisque eu nulla felis. Cras gravida lacus id sem tincidunt, vitae mattis est consectetur. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. In vestibulum porttitor arcu vel pharetra. In hac habitasse platea dictumst.",
                     DatePosted = DateTime.Now,
                     IsApproved = false },
          
             },
                Success = true,
            });

            Assert.AreEqual(1, mockManager.Object.GetAllUnapprovedPosts().Data.Count());
            Assert.IsTrue(mockManager.Object.GetAllUnapprovedPosts().Success);
        }

        [Test]
        public void AddPostTest()
        {
            Mock<IBlogManager> mockManager = new Mock<IBlogManager>();

            mockManager.Setup(x => x.AddPost(It.IsAny<Post>())).Returns(new Response<Post>()
            {
                Success = true
            });

            Assert.IsTrue(mockManager.Object.AddPost(It.IsAny<Post>()).Success);
        }



    }
}
