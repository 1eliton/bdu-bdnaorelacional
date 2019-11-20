using Atividade04.Domain;
using Atividade4.Infra;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atividade04.Application
{
    public class BlogApplication
    {
        public List<Blog> Get()
        {
            var result =
            Helper.GetCollection<Blog>()
                .Aggregate();
                //.Match(k => k.Posts.Any());
            return result.ToList();
        }

        /// <summary>
        /// return true if is a valid <see cref="Blog"/>
        /// </summary>
        /// <returns></returns>
        private (string message, bool result) validate(Blog blog)
        {
            return Get(blog) != null 
                ? ("", true)
                : ("Blog does not exists!", false);
        }

        public (string message, bool result) New(Blog blog)
        {
            var isValid = validate(blog);
            if (isValid.result)
            {
                try
                {
                    Task.Run(async () => await Helper.InsertOneAsync(blog));
                    return ("Blog added successfully!", true);
                }
                catch (Exception e)
                {
                    throw;
                }
            }
            else
            {
                return isValid;
            }
        }

        public Blog Get(Blog blog)
        {
            return Helper
               .GetFiltered<Blog>(b => b.Title == blog.Title && b.User.Login == blog.User.Login)
               .FirstOrDefault();
        }
    }
}
