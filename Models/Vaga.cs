using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CatalogoEmprego.Models;

public class Vaga
{
    [Required]
    public int Id { get; set; }
    
    [Required]
    [Column(TypeName ="varchar(50)")]
    public string TipoVaga { get; set; }  

    [Required]
    [Column(TypeName ="varchar(4)")]
    public int NumeroVagas { get; set; }  

    [Required]
    [Column(TypeName ="varchar(25)")]
    public double Salario { get; set; } 

    [Required]
    [Column(TypeName ="varchar(255)")]
    public String Especificacoes { get; set; }    

    //Propriedade de navegação
    public Empresa Empresa { get; set; }   

    //Chave estrangeira
    public int Empresaid { get; set; }

}