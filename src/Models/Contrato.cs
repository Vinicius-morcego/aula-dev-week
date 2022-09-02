namespace src.Models;

public class Contrato
{
    public Contrato()
    {
        this.DataCriacao = DateTime.Now;
        this.Valor = 0;
        this.TokenId = "000000";
        this.Pago = false;
    }

    public Contrato(string TokenId, double Valor)
    {
        this.DataCriacao = DateTime.Now;
        this.Valor = Valor;
        this.TokenId = TokenId;
        this.Pago = false;
    }
    public DateTime DataCriacao { get; set; }
    public string TokenId { get; set; }
    public double Valor { get; set; }
    public Boolean Pago { get; set; }
    
    
    
    
    
    
    
    
}