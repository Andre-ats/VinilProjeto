using System.ComponentModel.DataAnnotations;

namespace WebAPIs.DTO;

public class PostImagemAdaptor
{
    [Required] public Guid vinilID{ get; set; }
    [Required] public IFormFile file { get; set; }
    [Required] public string nome{ get; set; }
}