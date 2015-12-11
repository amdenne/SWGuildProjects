namespace CapstoneBlog.Models.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CapstoneBlog.Models.PostContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CapstoneBlog.Models.PostContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            context.Posts.AddOrUpdate(
                 new Post {
                     Title = "Mock Posts",
                     Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nulla finibus, risus id sagittis tristique, felis nulla sodales nulla, nec pretium mi lacus in urna. Fusce scelerisque orci purus. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Vestibulum at massa fringilla, scelerisque justo non, vestibulum ex. Quisque eu nulla felis. Cras gravida lacus id sem tincidunt, vitae mattis est consectetur. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. In vestibulum porttitor arcu vel pharetra. In hac habitasse platea dictumst.",
                     DatePosted = DateTime.Now,
                     IsApproved = true,
                    Categories = new List<Category>()
                     {
                         new Category() { category = "Category " },
                     }
                 },
                 
                 new Post {
                     Title = "Not Approved Post",
                     Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nulla finibus, risus id sagittis tristique, felis nulla sodales nulla, nec pretium mi lacus in urna. Fusce scelerisque orci purus. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Vestibulum at massa fringilla, scelerisque justo non, vestibulum ex. Quisque eu nulla felis. Cras gravida lacus id sem tincidunt, vitae mattis est consectetur. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. In vestibulum porttitor arcu vel pharetra. In hac habitasse platea dictumst.",
                     DatePosted = DateTime.Now,
                     IsApproved = false,
                     Categories = new List<Category>()
                     {
                         new Category() { category = "Category " },
                         new Category() { category = "Another Category " }
                     }
                 },
                 
                 new Post
                 {
                     Title = "Different Category",
                     Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nulla finibus, risus id sagittis tristique, felis nulla sodales nulla, nec pretium mi lacus in urna. Fusce scelerisque orci purus. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Vestibulum at massa fringilla, scelerisque justo non, vestibulum ex. Quisque eu nulla felis. Cras gravida lacus id sem tincidunt, vitae mattis est consectetur. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. In vestibulum porttitor arcu vel pharetra. In hac habitasse platea dictumst.",
                     DatePosted = DateTime.Now,
                     IsApproved = true,
                     Categories = new List<Category>()
                     {
                         new Category() { category = "Category " },
                         new Category() { category = "Another Category " }
                     }
                 }
                );

                     //
        }
    }
}
