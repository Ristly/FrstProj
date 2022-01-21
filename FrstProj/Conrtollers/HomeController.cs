using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore.Internal;

namespace FrstProj.Conrtollers
{

    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {

        TestContext db;
        private readonly ILogger<UsersController> _logger;


        public UsersController(IDbContextDependencies context, ILogger<UsersController> logger)
        {
            _logger = logger;

            db = (TestContext)context;
            if (!db.Users.Any())
            {
                db.Users.Add(new User { UserName = "Tom", UserAge = 26 });
                db.Users.Add(new User { UserName = "Alice", UserAge = 31 });
                db.SaveChanges();
            }
        }

        [HttpGet("General_Get")]
        public async Task<ActionResult<IEnumerable<User>>> Get()
        {
            return await db.Users.ToListAsync();
        }

        // GET api/users/5
        [HttpGet("Get_{id}")]
        public async Task<ActionResult<User>> Get(int id)
        {
            User user = await db.Users.FirstOrDefaultAsync(x => x.UserId == id);
            if (user == null)
                return NotFound();
            return new ObjectResult(user);
        }

        // POST api/users
        [HttpPost("Post")]
        public async Task<ActionResult<User>> Post(User user)
        {
            if (user == null)
            {
                return BadRequest();
            }

            db.Users.Add(user);
            await db.SaveChangesAsync();
            return Ok(user);
        }

        // PUT api/users/
        [HttpPut("Post")]
        public async Task<ActionResult<User>> Put(User user)
        {
            if (user == null)
            {
                return BadRequest();
            }
            if (!db.Users.Any(x => x.UserId == user.UserId))
            {
                return NotFound();
            }

            db.Update(user);
            await db.SaveChangesAsync();
            return Ok(user);
        }

        // DELETE api/users/5
        [HttpDelete("Del_{id}")]
        public async Task<ActionResult<User>> Delete(int id)
        {
            User user = db.Users.FirstOrDefault(x => x.UserId == id);
            if (user == null)
            {
                return NotFound();
            }
            db.Users.Remove(user);
            await db.SaveChangesAsync();
            return Ok(user);
        }
    }


    [ApiController]
    [Route("api/[controller]")]
    public class CitiesController : ControllerBase
    {

        TestContext db;
        private readonly ILogger<CitiesController> _logger;


        public CitiesController(IDbContextDependencies context, ILogger<CitiesController> logger)
        {
            _logger = logger;

            db = (TestContext)context;
            if (!db.Cities.Any())
            {
                db.Cities.Add(new City { NameCity = "Baikonur"});
                db.Cities.Add(new City { NameCity = "Saint Petersburg"});
                db.SaveChanges();
            }
        }

        [HttpGet]
        [Route("Get_general")]
        public async Task<ActionResult<IEnumerable<City>>> Get()
        {
            return await db.Cities.ToListAsync();
        }

        // GET api/users/5
        [HttpGet("Get_{id}")]
        public async Task<ActionResult<City>> Get(int id)
        {
            City city = await db.Cities.FirstOrDefaultAsync(x => x.IdCity == id);
            if (city == null)
                return NotFound();
            return new ObjectResult(city);
        }

        // POST api/users
        [HttpPost]
        [Route("Post")]
        public async Task<ActionResult<City>> Post(City city)
        {
            if (city == null)
            {
                return BadRequest();
            }

            db.Cities.Add(city);
            await db.SaveChangesAsync();
            return Ok(city);
        }

        // PUT api/users/
        [HttpPut]
        [Route("Put")]
        public async Task<ActionResult<City>> Put(City city)
        {
            if (city == null)
            {
                return BadRequest();
            }
            if (!db.Cities.Any(x => x.IdCity == city.IdCity))
            {
                return NotFound();
            }

            db.Update(city);
            await db.SaveChangesAsync();
            return Ok(city);
        }

        // DELETE api/users/5
        [HttpDelete("Del_{id}")]
        public async Task<ActionResult<City>> Delete(int id)
        {
            City city = db.Cities.FirstOrDefault(x => x.IdCity == id);
            if (city == null)
            {
                return NotFound();
            }
            db.Cities.Remove(city);
            await db.SaveChangesAsync();
            return Ok(city);
        }
    }


}
