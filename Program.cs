using System;
using System.Collections.Generic;
using System.Linq;

namespace efcore
{
    class Program
    {

        static void Main(string[] args)
        {
           List<Post> lp=  new List<Post>();
           lp.Add(new Post(){Title="Hello I am posting", Content="This is the content of the post"});
           lp.Add(new Post(){Title="Hello I am posting again", Content="I am fed up with posting"});

           using (var db = new BloggingContext())
           {
                // db.Blogs.Add(new Blog { Url = "http://blogs.msdn.com/adonet", Posts = lp,Description="This is the new special Diego's blog" });
                // var count = db.SaveChanges();
                // Console.WriteLine("{0} records saved to database", count);

                // Console.WriteLine();
                // Console.WriteLine("All blogs in database:");
                // foreach (var blog in db.Blogs)
                // {
                //     Console.WriteLine(" - {0}", blog.Url);
                // }
            var newBlog= db.Blogs.Add(new Blog { Url = "http://blogs.msdn.com/adonet", Description="This is the new special Diego's blog" });
            db.Posts.Add(new Post(){Title="Hello I am a solitary post", Content="I am good",BlogId = newBlog.Entity.BlogId});
            db.SaveChanges();



            }
        }
    }
}
