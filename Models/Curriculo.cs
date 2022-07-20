using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CatalogoEmprego.Models;

public class Curriculo
{
    [Required]
    public int Id { get; set; }

    [Required]
    [Column(TypeName ="varchar(100)")]
    public string Formacao { get; set; }  

    [Required]
    [Column(TypeName ="varchar(255)")]
    public string CursosComplementares { get; set; }  

    [Required]
    [Column(TypeName ="varchar(255)")]
    public string ExperienciaProfissional { get; set; }  

    //Propriedade de Navegação
    public Usuario Usuario { get; set; }

    //Chave Estrangeira
    public int UsuarioId { get; set; }
 

}
