using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Prueba_Técnica___Mini_App.Services;

namespace Prueba_Técnica___Mini_App.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController(IBookServices request) : ControllerBase
    {
        [HttpPost("create-book")]
        public async Task<ActionResult> CreateBook([FromBody] string title, CancellationToken cancellationToken)
        {
            var result = await request.CreateBook(title, cancellationToken);
            if (result)
            {
                return Ok("Book created successfully.");
            }
            else
            {
                return BadRequest("Failed to create book.");
            }
        }

        [HttpGet]
        public async Task<ActionResult> GetBooks(CancellationToken cancellationToken)
        {
            var books = await request.GetBooks(cancellationToken);
            return Ok(books);
        }
    }
}
