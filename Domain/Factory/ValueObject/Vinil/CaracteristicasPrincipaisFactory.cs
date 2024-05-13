using VinilProjeto.ValueObject.Vinil;

namespace VinilProjeto.Factory.ValueObject.Vinil;

public class CaracteristicasPrincipaisFactory
{
    public string _nomeArtista { get; set; }
    public string _gravadora { get; set; }
    public TipoAlbum _tipoAlbum { get; set; }
    public string _anoLancamento { get; set; }
    public TipoDeEmbalagem _tipoDeEmbalagem { get; set; }

    private void init()
    {
        _nomeArtista = null;
        _gravadora = null;
        _tipoAlbum = TipoAlbum.Vazio;
        _anoLancamento = null;
        _tipoDeEmbalagem = TipoDeEmbalagem.Vazio;
    }

    public CaracteristicasPrincipaisFactory setNomeArtista(string nomeArtista)
    {
        this._nomeArtista = nomeArtista;
        return this;
    }
    
    public CaracteristicasPrincipaisFactory setGravadora(string gravadora)
    {
        this._gravadora = gravadora;
        return this;
    }
    
    public CaracteristicasPrincipaisFactory setTipoAlbum(TipoAlbum tipoAlgum)
    {
        this._tipoAlbum = tipoAlgum;
        return this;
    }
    
    public CaracteristicasPrincipaisFactory setAnoLancamento(string anoLancamento)
    {
        this._anoLancamento = anoLancamento;
        return this;
    }
    
    public CaracteristicasPrincipaisFactory setTipoDeEmbalagem(TipoDeEmbalagem tipoDeEmbalagem)
    {
        this._tipoDeEmbalagem = tipoDeEmbalagem;
        return this;
    }

    public bool validar()
    {
        _ = _nomeArtista == null ? throw new Exception() : true;
        _ = _gravadora == null ? throw new Exception() : true;
        _ = _tipoAlbum.Equals(TipoAlbum.Vazio) ? throw new Exception() : true;
        _ = _anoLancamento == null ? throw new Exception() : true;
        _ = _tipoDeEmbalagem.Equals(TipoDeEmbalagem.Vazio) ? throw new Exception() : true;

        return true;
    }

    public CaracteristicasPrincipais build()
    {
        _ = this.validar() ? true : throw new Exception();
        CaracteristicasPrincipais caracteristicasPrincipais = CaracteristicasPrincipais.createVinilEntity(
            _nomeArtista, 
            _gravadora, 
            _tipoAlbum, 
            _anoLancamento, 
            _tipoDeEmbalagem
        );
        
        this.init();

        return caracteristicasPrincipais;

    }
}