using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryManagementSystem.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Data.Handlers
{
    public class AuthorHandler
    {
        public List<Author> GetAlAuthorsWithBooks()
        {
            var builder = new DbContextOptionsBuilder<LibraryContext>();
            var db = new LibraryContext(builder.Options);
            using (db)
            {
                return (from c in db.Authors.Include(m => m.Books) select c).ToList();
            }
        }

        public Author GetAuthorById(int id)
        {
            var builder = new DbContextOptionsBuilder<LibraryContext>();
            var db = new LibraryContext(builder.Options);
            using (db)
            {
                return (from c in db.Authors where c.AuthorId == id select c).FirstOrDefault();
            }
        }

        public Author GetAuthorwithBooksById(int id)
        {
            var builder = new DbContextOptionsBuilder<LibraryContext>();
            var db = new LibraryContext(builder.Options);
            using (db)
            {
                return (from c in db.Authors.Include(m => m.Books) where c.AuthorId == id select c).FirstOrDefault();
            }
        }

        public List<Author> GetAllAuthors()
        {
            var builder = new DbContextOptionsBuilder<LibraryContext>();
            var db = new LibraryContext(builder.Options);
            using (db)
            {
                return (from c in db.Authors select c).ToList();
            }
        }
        public int GetAuthorCount()
        {
            var builder = new DbContextOptionsBuilder<LibraryContext>();
            var db = new LibraryContext(builder.Options);
            using (db)
            {
                return (from o in db.Authors select o).Count();
            }
        }


    }
}
