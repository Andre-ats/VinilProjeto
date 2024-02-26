namespace VinilProjeto.Factory.ValueObject.Telefone;

using VinilProjeto.ValueObject.Telefone;

public class TelefoneFactory
{
    private string _codigo { get; set; }
    private string _ddd { get; set; }
    private string _numero { get; set; }

    private void init()
    {
        _codigo = null;
        _ddd = null;
        _numero = null;
    }

    public TelefoneFactory setCodigo(string codigo)
    {
        this._codigo = codigo;
        return this;
    }
    public TelefoneFactory setDDD(string ddd)
    {
        this._ddd = ddd;
        return this;
    }
    public TelefoneFactory setNumero(string numero)
    {
        this._numero = numero;
        return this;
    }

    public bool validar()
    {
        _ = _codigo == null ? throw new Exception() : true;
        _ = _ddd == null ? throw new Exception() : true;
        _ = _numero == null ? throw new Exception() : true;

        return true;
    }

    public Telefone build()
    {
        _ = this.validar() ? true : throw new Exception();

        Telefone telefone = Telefone.createTelefone(
            _codigo,
            _ddd,
            _numero
        );
        this.init();

        return telefone;
    }
}