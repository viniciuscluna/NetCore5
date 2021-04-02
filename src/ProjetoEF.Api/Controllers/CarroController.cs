using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ProjetoEF.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarroController : ControllerBase
    {
        private readonly ICarroRepository _repository;
       
        public CarroController(ICarroRepository repository)
        {
            _repository = repository;
        }

  
       [HttpGet("{id}")]
        public async Task<ActionResult<Carro>> Get(int id)
        {
            return Ok(await _repository.GetById(id));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Carro>>> Get()
        {
            var cars = await _repository.GetCars();
            return Ok(cars);
        }

        [HttpPost]
        public async Task<IActionResult> Post(){
            await _repository.InsertCars();
            return Ok(new {
                Sucesso=true,
                Mensagem= "Inseridos"
            });
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(){
            await _repository.ClearCars();
            return Ok(new {
                Sucesso=true,
                Mensagem= "Removidos"
            });
        }
    }
}
