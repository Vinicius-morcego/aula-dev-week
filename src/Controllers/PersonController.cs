using Microsoft.AspNetCore.Mvc;
using src.Models;
using Microsoft.EntityFrameworkCore;
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
    public List<Pessoa> Get(){
        // var pessoa = new Pessoa("vinicius", 38, "00000000000");
        // var contrato = new Contrato("abc123", 50.20);

        //pessoa.contratos.Add(contrato);

        return _repository.Pessoas.Include(p => p.contratos).ToList();

        //return pessoa;
    }

    [HttpPost]
    public Pessoa Post([FromBody] Pessoa pessoa)
    {
        _repository.Pessoas.Add(pessoa);
        _repository.SaveChanges();
        return pessoa;
    }

    [HttpPut("{id}")]
    public string Update([FromRoute]int id, [FromBody] Pessoa pessoa)
    {
        _repository.Pessoas.Update(pessoa);
        _repository.SaveChanges();
        Console.WriteLine(id);
        Console.WriteLine(pessoa);
        return "Dados do id " + id + " atualizados";
    }

    [HttpDelete("{id}")]
    public string Delete([FromRoute] int id)
    {
        var result = _repository.Pessoas.SingleOrDefault(e => e.Id == id);
        _repository.Pessoas.Remove(result);
        _repository.SaveChanges();
        return "deletado pessoa de Id "+id;
    }
}