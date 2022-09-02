using Microsoft.AspNetCore.Mvc;
using src.Models;

namespace src.Controllers;
[ApiController]
[Route("[controller]")]
public class PersonController : ControllerBase{
    [HttpGet]
    public Pessoa Get(){
        var pessoa = new Pessoa("vinicius", 38, "05644635660");
        var contrato = new Contrato("abc123", 50.20);

        pessoa.contratos.Add(contrato);

        return pessoa;
    }

    [HttpPost]
    public Pessoa Post([FromBody] Pessoa pessoa){
                
        return pessoa;
    }

    [HttpPut("{id}")]
    public string Update([FromRoute]int id, [FromBody] Pessoa pessoa)
    {
        Console.WriteLine(id);
        Console.WriteLine(pessoa);
        return "Dados do id " + id + " atualizados";
    }

    [HttpDelete("{id}")]
    public string Delete([FromRoute] int id)
    {
        return "deletado pessoa de Id "+id;
    }
}