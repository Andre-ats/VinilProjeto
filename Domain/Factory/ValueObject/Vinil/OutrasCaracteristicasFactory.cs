using VinilProjeto.ValueObject.Vinil;

namespace VinilProjeto.Factory.ValueObject.Vinil;

public class OutrasCaracteristicasFactory
{
    public string _quantiaCancoes { get; set; }
    public EstiloMusical _estiloMusical { get; set; }

    private void init()
    {
        _quantiaCancoes = null;
        _estiloMusical = EstiloMusical.Vazio;
    }

    public OutrasCaracteristicasFactory setQuantiaCancoes(string quantiaCancoes)
    {
        this._quantiaCancoes = quantiaCancoes;
        return this;
    }

    public OutrasCaracteristicasFactory setEstiloMusical(EstiloMusical estiloMusical)
    {
        this._estiloMusical = estiloMusical;
        return this;
    }

    public bool validar()
    {
        _ = _quantiaCancoes == null ? throw new Exception() : true;
        _ = _estiloMusical.Equals(EstiloMusical.Vazio) ? throw new Exception() : true;

        return true;
    }

    public OutrasCaracteristicas build()
    {
        _ = this.validar() ? true : throw new Exception();

        OutrasCaracteristicas outrasCaracteristicas = OutrasCaracteristicas.createOutrasCaracteristicas(
            _quantiaCancoes, 
            _estiloMusical
        );
        this.init();

        return outrasCaracteristicas;
    }
}