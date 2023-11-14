using FLuentAPI.DataContext;
using FLuentAPI.DTOs;
using FLuentAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FLuentAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly BookstoreDBContext _dbContext;

        public AuthorController(BookstoreDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        [Authorize]
        [HttpGet]
        public IActionResult GetAllAuthors()
        {
            var res = _dbContext.Authors.ToList();
            return Ok(res);

        }
        [Authorize]
        [HttpGet]
        public IActionResult GetAuthorById(int id)
        {
            var author = _dbContext.Authors.FirstOrDefault(x => x.Id == id);
            return Ok(author.Books);
        }
        [HttpPost]
        public IActionResult CreateAuthor(AuthorDto authordto)
        {
            var author = new Author 
            { 
                FullName = authordto.FullName,
                Salary = authordto.Salary,
            };

            _dbContext.Authors.Add(author);
            _dbContext.SaveChanges();
            return Ok(author);
        }
        [HttpPut]
        public IActionResult UpdateAuthor(AuthorDto authordto)
        {
            var author = new Author(authordto.Id, authordto.FullName, authordto.Salary);
            _dbContext.Authors.Update(author);
            _dbContext.SaveChanges();
            return Ok(author);
        }
        [HttpDelete]
        public IActionResult DeleteAuthor(int id)
        {
            var author = _dbContext.Authors.FirstOrDefault(x=>x.Id == id);
            if (author is null)
                return Ok();

            _dbContext.Authors.Remove(author);
            _dbContext.SaveChanges();
            return Ok(author);
        }
    }
}
