using APIRestfulEntity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIRestfulEntity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrugereController : ControllerBase
    {
        private BrugereDbContext? _dbContext;

        public BrugereController(BrugereDbContext dbcontext)
        {
            _dbContext = dbcontext;
        }
        // GET: api/<BrugereController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var bruger = _dbContext.brugeres.ToList();



                if (bruger.Count == 0)
                {
                    return NotFound();
                }

                return Ok(from brugeren in bruger
                          select brugeren.Name);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // GET api/<BrugereController>/5
        [HttpGet("{id}")]
        public IActionResult Get([FromRoute]int id)
        {
            try
            {
                var bruger = _dbContext.brugeres.Find(id);

                if (bruger == null)
                {
                    return NotFound();
                }

                return Ok(bruger);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // POST api/<BrugereController>
        [HttpPost]
        public IActionResult Post([FromBody] string value)
        {
            Brugeres b1 = new Brugeres();
            b1.Name = value;

            try
            {
                _dbContext.Add(b1);
                _dbContext.SaveChanges();
            }
            catch(Exception ex)
            {
                return StatusCode(500,ex.Message);
            }

            var brugere = _dbContext.brugeres;
            return Ok(brugere);
        }

        // PUT api/<BrugereController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] string value)
        {
            try
            {
                var bruger = _dbContext.brugeres.Find(id);
                if (bruger == null)
                {
                    return StatusCode(404, "Bruger ikke fundet");
                }
                bruger.Name = value;

                _dbContext.Entry(bruger).State = EntityState.Modified;
                _dbContext.SaveChanges();
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            var brugere = _dbContext.brugeres.ToList();
            return Ok(brugere);
        }

        // DELETE api/<BrugereController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var bruger = _dbContext.brugeres.Find(id);

                _dbContext.Entry(bruger).State = EntityState.Deleted;
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
            var brugere = _dbContext.brugeres.ToList();
            return Ok(brugere);
        }
    }
}
