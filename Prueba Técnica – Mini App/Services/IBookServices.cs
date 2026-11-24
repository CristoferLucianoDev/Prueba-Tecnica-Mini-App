using Prueba_Técnica___Mini_App.Entities;
using Prueba_Técnica___Mini_App.DTOs;

namespace Prueba_Técnica___Mini_App.Services
{
    public interface IBookServices
    {
        Task<List<BookRequest>> GetBooks(CancellationToken cancellationToken);
        Task<bool> CreateBook(string title, CancellationToken cancellationToken);
    }
}
