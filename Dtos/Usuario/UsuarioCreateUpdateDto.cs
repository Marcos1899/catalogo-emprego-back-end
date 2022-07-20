using System.ComponentModel.DataAnnotations;

namespace CatalogoEmpregoBack.Dtos.Usuario;

public class UsuarioCreateUpdateDto
{
    [Required]
    [StringLength(150, MinimumLength =8)]
    public string NomeCompleto { get; set; }  

    [Required]
    [StringLength(255)]
    public string EnderecoCompleto { get; set; }  

    [Required]
    [StringLength(15)]
    public string Login { get; set; }  

    [Required]
    [StringLength(100)]
    [EmailAddress] //faz validação de email
    public string Email { get; set; }  

    [Required]
    [StringLength(10)]
    public string Senha { get; set; }  

    [Required]
    [StringLength(15)]
    public string Cpf { get; set; }  

    [Required]
    [StringLength(25)]
    public string Telefone { get; set; }  

    [Required]
    [StringLength(50)]
    public string Cidade { get; set; }  

    [Required]
    [StringLength(15)]
    public string TipoUsuario { get; set; }  

    [Required]
    [StringLength(25)]
    public string Rg { get; set; }  

    //Propriedade de navegação
    public CurriculoCreateDto Curriculo { get; set; }
}

public class CurriculoCreateDto
{ 
    [Required]
    [StringLength(100)]
    public string Formacao { get; set; }  

    [Required]
    [StringLength(255)]
    public string CursosComplementares { get; set; }  

    [Required]
    [StringLength(255)]
    public string ExperienciaProfissional { get; set; }  
}
