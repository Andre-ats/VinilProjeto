using VinilProjeto.Entity.VinilVenda;

namespace VinilProjeto.Factory.Entity.VinilVenda;

public class VinilVendaFactory
{
    public string _nomeVinil { get; set; }
    public string _descricaoVinil { get; set; }
    public string _precoVinil { get; set; }
    public string _quantiaVinil { get; set; }
    public EstiloMusical _estiloMusical { get; set; }

    private void init()
    {
        _nomeVinil = null;
        _descricaoVinil = null;
        _precoVinil = null;
        _quantiaVinil = null;
        _estiloMusical = EstiloMusical.Vazio;
    }

    public VinilVendaFactory setNomeVinil(string nomeVinil)
    {
        this._nomeVinil = nomeVinil;
        return this;
    }

    public VinilVendaFactory setDescricaoVinil(string descricaoVinil)
    {
        this._descricaoVinil = descricaoVinil;
        return this;
    }

    public VinilVendaFactory setPrecoVinil(string precoVinil)
    {
        this._precoVinil = precoVinil;
        return this;
    }

    public VinilVendaFactory setQuantiaVinil(string quantiaVinil)
    {
        this._quantiaVinil = quantiaVinil;
        return this;
    }
    public VinilVendaFactory setEstiloMusical(EstiloMusical estiloMusical)
    {
        this._estiloMusical = estiloMusical;
        return this;
    }

    public bool validar()
    {
        _ = _nomeVinil == null ? throw new Exception() : true;
        _ = _descricaoVinil == null ? throw new Exception() : true;
        _ = _precoVinil == null ? throw new Exception() : true;
        _ = _quantiaVinil == null ? throw new Exception() : true;
        _ = _estiloMusical == EstiloMusical.Vazio ? throw new Exception() : true;

        return true;
    }

    public Vinil build()
    {
        _ = this.validar() ? true : throw new Exception();
        
        Vinil vinil = Vinil.createVinilEntity(
            _nomeVinil,
            _descricaoVinil,
            _precoVinil,
            _quantiaVinil,
            _estiloMusical
        );
        
        this.init();
        
        return vinil;
    }
}