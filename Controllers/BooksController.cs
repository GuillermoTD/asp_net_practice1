using ASP.NET_Practice.Services;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NET_Practice.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : Controller{
        private readonly IServiceBook bookservice;
        private readonly ILogger<BooksController> _logger;

       public BooksController(IServiceBook service, ILogger<BooksController> logger)
        {
            bookservice = service;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult> GetBooks(){
            try
            {
                  Console.WriteLine("Toma tu libroo");
                  return Ok(await bookservice.GetBooks());
            }
            catch (System.Exception error)
            {
                
                _logger.LogError(error, "Hubo un error al obtener los libros");
                return StatusCode(500);
            }
        }

         [HttpGet("{id}")]
        public async Task<ActionResult> GetBookITem(string id){
             try
            {
                  Console.WriteLine("Toma tu libro");
                  return Ok(await bookservice.GetBookById(id));
            }
            catch (System.Exception error)
            {
                
                _logger.LogError(error, "Hubo un error al obtener los libros");
                return StatusCode(500);
            }
        }

    }
}