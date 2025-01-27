using ASP.NET_Practice.Models;
using ASP.NET_Practice.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

namespace ASP.NET_Practice.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : Controller
    {
        private readonly IServiceBook bookservice;
        private readonly ILogger<BooksController> _logger;

        public BooksController(IServiceBook service, ILogger<BooksController> logger)
        {
            bookservice = service;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult> GetBooks()
        {
            try
            {
                Console.WriteLine("Toma tu libroo ");
                return Ok(await bookservice.GetBooks());
            }
            catch (System.Exception error)
            {

                _logger.LogError(error, "Hubo un error al obtener los libros");
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetBookITem(string id)
        {
            try
            {
                Console.WriteLine("Toma tu libro");
                var result = await bookservice.GetBookById(id);

                return Ok(result);
            }
            catch (System.Exception error)
            {

                _logger.LogError(error, "Hubo un error al obtener los libros");
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<ActionResult> CreateBook(Book book)
        {
            if (book is null)
            {
                return BadRequest();
            }
            //aqui hacemos uso de la funcion insertbook ubicada en el servicebook
            await bookservice.InsertBook(book);
            //La funcion created crea una respuesta http de codigo 201
            return Created("Insertado", true);
        }


        [HttpPut("id")]
        public async Task<ActionResult> UpdateBook(Book book, string id)
        {
            if (book is null)
            {
                return BadRequest();
            }

            book.Id = new ObjectId(id);
            await bookservice.UpdateBook(book);

            return Created("Insertado", true);
        }


        [HttpDelete("id")]        
        public async Task<ActionResult> DeleteBook(string id)
        {
            var book = await bookservice.GetBookById(id);
            
            if (book is null)
            {
                return BadRequest();
            }

            book.Id = new ObjectId(id);
            
            await bookservice.DeleteBook(book);

            return NoContent();
        }
    }
}