using Microsoft.EntityFrameworkCore;
using Prueba_Técnica___Mini_App.Datos;
using Prueba_Técnica___Mini_App.DTOs;
using Prueba_Técnica___Mini_App.Entities;

namespace Prueba_Técnica___Mini_App.Services
{
    public class BookServices(AppDbContext context) : IBookServices
    {
        public async Task<bool> CreateBook(string title, CancellationToken cancellationToken)
        {
            var book = new Books
            {
                Title = title
            };

            context.Books.Add(book);

            return await context.SaveChangesAsync(cancellationToken) > 0;
        }

        public async Task<List<BookRequest>> GetBooks(CancellationToken cancellationToken)
        {
            var books = context.Books
                .AsNoTracking()
                .Select(book => new BookRequest
                {
                    Title = book.Title
                })
                .ToListAsync(cancellationToken);

            return await books;
        }
    }
}
