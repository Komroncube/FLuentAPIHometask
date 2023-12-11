using FLuentAPI.DataContext;
using FLuentAPI.DTOs;
using FLuentAPI.Helpers;
using FLuentAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;
using System.Text.Json.Serialization.Metadata;

namespace FLuentAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly BookstoreDBContext _dbContext;
        private readonly IDistributedCache _distributedCache;

        public AuthorController(BookstoreDBContext dbContext, IDistributedCache distributedCache)
        {
            _dbContext = dbContext;
            _distributedCache = distributedCache;
        }

        //[Authorize(Roles = CustomRoles.AdminRoles)]
        [HttpGet]
        public async ValueTask<IActionResult> GetAllAuthors()
        {
            var jsonInCache = await _distributedCache.GetStringAsync(DateTime.Now.Date.ToString());
            if (jsonInCache is null)
            {
                var res = _dbContext.Authors.ToList();
                jsonInCache = JsonSerializer.Serialize(res);
                await _distributedCache.SetStringAsync(DateTime.Now.Date.ToString(), jsonInCache, new DistributedCacheEntryOptions()
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(30)
                });
                

            }

            var result = JsonSerializer.Deserialize<Author[]>(jsonInCache);


            return Ok(jsonInCache);
        }

        [Authorize(Roles = CustomRoles.MentorRoles)]
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
