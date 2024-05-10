using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RestAPIDemo.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BooksController : ControllerBase
	{
		private static List<Book> books = new List<Book>
		{
			new Book { Id = 1,Name="Harry Porter1"},
			new Book{Id =2, Name="Animal Farm"}
		};
		// GET: api/<BooksController>
		[HttpGet]
		public IActionResult Get()
		{
			return Ok(books);
		}

		// GET api/<BooksController>/5
		[HttpGet("{id}")]
		public IActionResult Get(int id)
		{
			var book =  books.Find(x => x.Id == id);
			if(book == null)
			{
				return NotFound();
			}
			return Ok(book);
		}

		// POST api/<BooksController>
		[HttpPost]
		public IActionResult Post([FromBody] Book book)
		{
			book.Id = GetNextId();
			books.Add(book);
			return Ok(book);
		}

		// PUT api/<BooksController>/5
		[HttpPut("{id}")]
		public IActionResult Put(int id, [FromBody] Book book)
		{
			var index = books.FindIndex(x => x.Id == id);
			if(index == -1)
			{
				return NotFound();
			}
			books[index].Name = book.Name;
			return Ok(book);
		}

		// DELETE api/<BooksController>/5
		[HttpDelete("{id}")]
		public IActionResult Delete(int id)
		{
			var book = books.Find(book => book.Id == id);
			if(book == null )
			{
				return NotFound();
			}
			books.Remove(book);
			return NoContent();
		}

		private int GetNextId()
		{
			return books.Count + 1;
		}
	}

	public class Book
	{
		public int Id { get; set; }
		public string Name { get; set; }
	}
}
