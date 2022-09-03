using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

using src.Models;
using src.Persistence;

namespace src.Controllers;

[ApiController]
[Route("[controller]")]
public class PersonController : ControllerBase{
    private DatabaseContext _repository { get; set; }
    
    public PersonController(DatabaseContext context)
    {
        this._repository = context;
    }
    
    [HttpGet]
    public ActionResult<List<Pessoa>> Get(){
        // var pessoa = new Pessoa("vinicius", 38, "00000000000");
        // var contrato = new Contrato("abc123", 50.20);

        //pessoa.contratos.Add(contrato);
        var result = _repository.Pessoas.Include(p => p.contratos).ToList();

        if(!result.Any()) return NoContent();        

        return Ok(result);
        //return pessoa;
    }

    [HttpPost]
    public ActionResult<Pessoa> Post([FromBody] Pessoa pessoa)
    {
        try
        {
            _repository.Pessoas.Add(pessoa);
            _repository.SaveChanges();            
        }
        catch (System.Exception)
        {
            return BadRequest(new {
                msg = "Houve erro ao enviar solicitação",
                status = HttpStatusCode.BadRequest
            });
        }
        return Created("criado", pessoa);
    }

    [HttpPut("{id}")]
    public ActionResult<Object> Update(
        [FromRoute]int id, 
        [FromBody] Pessoa pessoa)
    {

        var result = _repository.Pessoas.SingleOrDefault(e => e.Id == id);
        if(result is null)
        {
            return NotFound(new 
            {
                msg = "Não encontrado!",
                status = HttpStatusCode.NotFound
            });
        }
        try
        {
        _repository.Pessoas.Update(pessoa);
        _repository.SaveChanges();            
        }
        catch (System.Exception)
        {
            
            return BadRequest(new{
                msg = "Houve erro ao enviar solicitação de atualização do "
                + id + "atualizados",
                status = HttpStatusCode.BadRequest
            });
        }
        return Ok(new{
           msg = $"Dados do id {id} atualizados",
           status = HttpStatusCode.OK
        });

        
    }

    [HttpDelete("{id}")]
    public ActionResult<Object> Delete([FromRoute] int id)
    {
        var result = _repository.Pessoas.SingleOrDefault(e => e.Id == id);
        if(result is null) return BadRequest(new {
            msg = "Conteúdo inexistente, solicitação inválida",
            status = HttpStatusCode.BadRequest
        });
        
        _repository.Pessoas.Remove(result);
        _repository.SaveChanges();
        return Ok(new {
            msg = "deletado pessoa de Id "+id,
            status = HttpStatusCode.OK
    });
    }
  
 }

