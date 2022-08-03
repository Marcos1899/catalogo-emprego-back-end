
using CatalogoEmprego.Dtos.Empresa;

namespace CatalogoEmpregoBack.Dtos.Vaga;

public class VagaResponseDto
{
    public int Id { get; set; }
    public string TipoVaga { get; set; }  
    public int NumeroVagas { get; set; }  
    public string Salario { get; set; } 
    public String Especificacoes { get; set; }  
    
    public EmpresaResponseDto Empresa { get; set; }

}




