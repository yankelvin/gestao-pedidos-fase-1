namespace Service.DrivingAdapters.RestAdapters.DTOs.Cliente;

public class CadastroClienteDto
{
    public string Nome { get; set; }
    public string CPF { get; set; }
    public string Email { get; set; }
    public string Telefone { get; set; }
    public DateTime Aniversario { get; set; }
}