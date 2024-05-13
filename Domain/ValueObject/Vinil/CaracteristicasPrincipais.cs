namespace VinilProjeto.ValueObject.Vinil;

public enum TipoAlbum
{
    Vinil,
    CD,
    Vazio
}

public enum TipoDeEmbalagem
{
    Lacrado,
    Deslacrado,
    Vazio
}

[Serializable]
public class CaracteristicasPrincipais
{
    public string nomeArtista { get; protected set; }
    public string gravadora { get; protected set; }
    public TipoAlbum tipoDeAlbum { get; protected set; }
    public string anoLancamento { get; protected set; }
    public TipoDeEmbalagem tipoDeEmbalagem { get; protected set; }
    
    public CaracteristicasPrincipais(){}

    public static CaracteristicasPrincipais createVinilEntity(string nomeArtista, string gravadora,
        TipoAlbum tipoAlbum, string anoLancamento, TipoDeEmbalagem tipoDeEmbalagem)
    {
        CaracteristicasPrincipais caracteristicasPrincipais = new CaracteristicasPrincipais()
        {
            nomeArtista = nomeArtista,
            gravadora = gravadora,
            tipoDeAlbum = tipoAlbum,
            anoLancamento = anoLancamento,
            tipoDeEmbalagem = tipoDeEmbalagem

        };
        return caracteristicasPrincipais;
    }
}