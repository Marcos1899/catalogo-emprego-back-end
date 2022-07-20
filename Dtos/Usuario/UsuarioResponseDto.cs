namespace CatalogoEmpregoBack.Dtos.Usuario;

public class UsuarioResponseDto
{

    public int Id { get; set; } 

    public string NomeCompleto { get; set; }  

    public string EnderecoCompleto { get; set; }  

    public string Login { get; set; }  
    public string Email { get; set; }  
    public string Cpf { get; set; }  
    public string Telefone { get; set; }    
    public string Cidade { get; set; }  
    public string TipoUsuario { get; set; }  
    public string Rg { get; set; }   
    public CurriculoResponseDto Curriculo { get; set; }

}

//Posso criar o dto fora 
public class  CurriculoResponseDto{
    
    public int Id { get; set; }
    public string Formacao { get; set; }  
    public string CursosComplementares { get; set; }  
    public string ExperienciaProfissional { get; set; }  

}
