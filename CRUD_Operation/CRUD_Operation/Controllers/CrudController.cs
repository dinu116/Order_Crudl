using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_Operation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CrudController : ControllerBase
    {
        private static List<Crud> operation = new List<Crud>
        {
                new Crud { Id = 1, Name= "Dinesh Agrawal",  FirstName="Dinesh", LastName="Agrawal", Place="Banaglore" },
                new Crud { Id = 2, Name= "Deepak Agrawal",  FirstName="Deepak", LastName="Agrawal", Place="Banaglore" }
        };
        private readonly DataContext _context;

        public CrudController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Crud>>> Get()
        {

            return Ok(await _context.Cruds.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Crud>> Get(int id)
        {
            var crud = operation.Find(x=> x.Id == id);
            if (crud == null) {
                return BadRequest("opration not found");
            }
            return Ok(crud);
        }

        [HttpPost]
        public async Task<ActionResult<List<Crud>>> Add(Crud crud)
        {
            operation.Add(crud);
            return Ok(operation);
        }

        [HttpPut]
        public async Task<ActionResult<List<Crud>>> Update(Crud request)
        {
            var crud = operation.Find(x => x.Id == request.Id);
            if (crud == null)
            {
                return BadRequest("opration not found");
            }

            crud.Id = request.Id;
            crud.FirstName = request.FirstName; 
            crud.LastName = request.LastName;
            crud.Place = request.Place;

            return Ok(operation);
        }

        [HttpDelete]
        public async Task<ActionResult<List<Crud>>> Delete(int id)
        {
            var crud = operation.Find(x => x.Id == id);
            if (crud == null)
            {
                return BadRequest("opration not found");
            }


            operation.Remove(crud);
            return Ok(crud);
        }
    }
}
