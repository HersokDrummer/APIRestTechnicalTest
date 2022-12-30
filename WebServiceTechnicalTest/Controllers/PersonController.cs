using Microsoft.AspNetCore.Mvc;
using WebServiceTechnicalTest.Logic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebServiceTechnicalTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        //global list of persons Singleton Pattern desing
        private readonly IPersonBssLogic _person;

        //Constructor
        public PersonController(IPersonBssLogic person) {
            //injeccion singleton: con Singleton, siempre va a ser el mismo objeto para todas las solicitudes.
            _person = person;
        }

        //POST
        [HttpPost]
        public IActionResult AddPerson([FromBody] PersonModel person) {
            _person.AddPerson(person);
            var lstPersons = _person.GetAllPersonModels();
            return Ok(lstPersons);
        }

        //PUT
        [HttpPut]
        public IActionResult UpdatePerson([FromBody] PersonModel person) {
            _person.UpdatePerson(person);
            var lstPersons = _person.GetAllPersonModels();
            return Ok(lstPersons);
        }

        // GET: api/<PersonController>
        [HttpGet]
        public IActionResult Get()
        {
            var lstPersons = _person.GetAllPersonModels();
            return Ok(lstPersons);
        }
        
        // DELETE api/<PersonController>/id
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _person.DeletePerson(id);
        }
    }
}
