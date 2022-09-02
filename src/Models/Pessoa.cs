namespace src.Models;

using System.Collections.Generic;

public class Pessoa
{
    public Pessoa()
    {
        this.Nome = "template";
        this.Idade = 0;
        this.contratos = new List<Contrato>();
        this.Ativado = true;
        
    }

    public Pessoa(string Nome, int Idade, string Cpf)
    {
        this.Nome = Nome;
        this.Idade = Idade;
        this.Cpf = Cpf;
         this.contratos = new List<Contrato>();
         this.Ativado = true;

    }

    /*nome, idade, cpf, ativa*/
    public int Id { get; set; }   
    public string Nome { get; set; }
    public int Idade { get; set; }
    public string? Cpf { get; set; }
    public Boolean Ativado { get; set; } 

    public List<Contrato> contratos { get; set; }
    
    

}

