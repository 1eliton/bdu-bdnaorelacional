using Atividade04.Domain;
using Atividade4.Infra;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atividade04.Application
{
    public class PostApplication
    {
        public (string message, bool result) New(ObjectId blogId, Post post)
        {
            var blog = Helper.GetFiltered<Blog>(b => b.Id.Equals(blogId)).FirstOrDefault();
            if (blog != null)
            {
                if (blog.Posts.Any(p => p.Title == post.Title) )
                {
                    return ("there's already a post with the same title", false);
                }
                 else
                {
                    try
                    {
                        Console.WriteLine("qwdqwd");
                        blog.Posts.Add(post);
                        Task.Run(async () => await Helper.ReplaceOneAsync(b => b.Id.Equals(blog.Id), blog));
                        return ("", true);
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }

            return ("error occurred", false);
        }
    }
}
