using CaseStudyApi.Models;
using CaseStudyApi.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CaseStudyApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class RecruitsController : ControllerBase
    {
        private readonly ITokenRepository _tokenRepository;

        public RecruitsController(ITokenRepository tokenRepository)
        {
            _tokenRepository = tokenRepository;
        }


        // GET: api/<UsersController>
        [HttpGet]
        public List<string> Get()
        {
            var recruits = new List<string>
        {
            "Ramesh",
            "Satvik",
            "Hari"
        };

            return recruits;
        }


        [AllowAnonymous]
        [HttpPost]
        [Route("authenticate")]
        public IActionResult Authenticate(Users usersdata)
        {
            var token = _tokenRepository.Authenticate(usersdata);

            if (token == null)
            {
                return Unauthorized();
            }

            return Ok(token);
        }
    }
}