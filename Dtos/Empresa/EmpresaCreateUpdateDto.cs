using System.ComponentModel.DataAnnotations;

namespace CatalogoEmprego.Dtos.Empresa;

public class EmpresaCreateUpdateDto
{
   [Required]
   [StringLength(100, MinimumLength = 10)]
   public  string RazaoSocial { get; set; }
   
   [Required]
   [StringLength(100, MinimumLength = 10)]
   public  string NomeFantasia { get; set; }
   
   [Required]
   [MinLength(14)]
   public  string Cnpj { get; set; }
   
   [Required]
   [MinLength(5)]
   public  string Cidade { get; set; }
   
   [Required]
   [MinLength(4)]
   public  string Estado { get; set; }
   
   [Required]
   [StringLength(100, MinimumLength =6)]
   public  string Endereco { get; set; }
   
   [Required]
   [MinLength(9)]
   public  string Telefone { get; set; }
   
   [Required]
   [StringLength(100, MinimumLength =10)]
   public  string Email { get; set; }

   public int UsuarioId { get; set; }

   [Required]
   [MinLength(6)]
   public string Senha { get; set; }
}
