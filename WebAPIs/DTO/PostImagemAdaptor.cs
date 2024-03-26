using System.ComponentModel.DataAnnotations;

namespace WebAPIs.DTO;

public class PostImagemAdaptor
{
    [Required] public Guid vinilID;
    [Required] public IFormFile file;
    [Required] public string nome;
}