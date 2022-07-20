using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CatalogoEmprego.Models;

public class Usuario
{
    [Required]
    public int Id { get; set; } 

    [Required]
    [Column(TypeName ="varchar(150)")]
    public string NomeCompleto { get; set; }  

    [Required]
    [Column(TypeName ="varchar(255)")]
    public string EnderecoCompleto { get; set; }  

    [Required]
    [Column(TypeName ="varchar(15)")]
    public string Login { get; set; }  
  
    [Required]
    [Column(TypeName ="varchar(100)")]  
    public string Email { get; set; }  

    [Required]
    [Column(TypeName ="varchar(10)")]
    public string Senha { get; set; }  

    [Required]
    [Column(TypeName ="varchar(15)")]
    public string Cpf { get; set; }  

    [Required]
    [Column(TypeName ="varchar(25)")]
    public string Telefone { get; set; }  

    [Required]
    [Column(TypeName ="varchar(50)")]
    public string Cidade { get; set; }  

    [Required]
    [Column(TypeName ="varchar(15)")]
    public string TipoUsuario { get; set; }  

    [Required]
    [Column(TypeName ="varchar(25)")]
    public string Rg { get; set; }  

    //Propriedade de navegação
    public Curriculo Curriculo { get; set; }

    public List<Empresa> Empresas { get; set; }


}
