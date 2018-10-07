using System.Threading.Tasks;
using be_master_with_core2.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace be_master_with_core2.Features.Users
{
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private readonly EcommerceContext _db;

        public UsersController(EcommerceContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _db.Users.ToListAsync());
        }
    }
}