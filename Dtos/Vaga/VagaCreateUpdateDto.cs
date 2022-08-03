using System.ComponentModel.DataAnnotations;
using CatalogoEmprego.Dtos.Empresa;

namespace CatalogoEmpregoBack.Dtos.Vaga;

public class VagaCreateUpdateDto
{    
    [Required]
    [StringLength(50, MinimumLength = 5)]
    public string TipoVaga { get; set; }  

    [Required]

    public int NumeroVagas { get; set; }  

    [Required]
    [StringLength(50)]
    public String Salario { get; set; } 

    [Required]
    [StringLength(255)]
    public String Especificacoes { get; set; }   

    public int Empresaid { get; set; } = 1;

    //Propriedade de navegação
    public EmpresaCreateUpdateDto Empresa { get; set; }   
}
