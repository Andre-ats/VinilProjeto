using VinilProjeto.ValueObject.Vinil;

namespace VinilProjeto.Repository.DTO.ValueObject.Vinil;

public class CaracteristicasPrincipaisDTO
{
    public string nomeArtista { get; set; }
    public string gravadora { get; set; }
    public TipoAlbum tipoDeAlbum { get; set; }
    public string anoLancamento { get; set; }
    public TipoDeEmbalagem tipoDeEmbalagem { get; set; }
}