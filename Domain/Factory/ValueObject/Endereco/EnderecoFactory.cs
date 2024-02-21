namespace VinilProjeto.Factory.ValueObject.Endereco;

using VinilProjeto.Entity.Usuario.Endereco;

public class EnderecoFactory
{
    private string _cep { get; set; }
    private string _logradouro { get; set; }
    private string _numero { get; set; }
    private string _complemento { get; set; }
    private string _referencia { get; set; }
    private string _bairro { get; set; }
    private string _cidade { get; set; }
    private string _estado { get; set; }

    private void init()
    {
        _cep = null;
        _logradouro = null;
        _numero = null;
        _complemento = null;
        _referencia = null;
        _bairro = null;
        _cidade = null;
        _estado = null;
    }

    public EnderecoFactory setCep(string cep)
    {
        this._cep = cep;
        return this;
    }
    public EnderecoFactory setLogradouro(string Logradouro)
    {
        this._logradouro = Logradouro;
        return this;
    }
    public EnderecoFactory setNumero(string numero)
    {
        this._numero = numero;
        return this;
    }

    public EnderecoFactory setComplemento(string complemento)
    {
        this._complemento = complemento;
        return this;
    }
    public EnderecoFactory setReferencia(string referencia)
    {
        this._referencia = referencia;
        return this;
    }
    public EnderecoFactory setBairro(string bairro)
    {
        this._bairro = bairro;
        return this;
    }
    public EnderecoFactory setCidade(string cidade)
    {
        this._cidade = cidade;
        return this;
    }
    public EnderecoFactory setEstado(string estado)
    {
        this._estado = estado;
        return this;
    }

    public bool validar()
    {
        _ = _cep == null ? throw new Exception() : true;
        _ = _logradouro == null ? throw new Exception() : true;
        _ = _numero == null ? throw new Exception() : true;
        _ = _complemento == null ? throw new Exception() : true;
        _ = _referencia == null ? throw new Exception() : true;
        _ = _bairro == null ? throw new Exception() : true;
        _ = _cidade == null ? throw new Exception() : true;
        _ = _estado == null ? throw new Exception() : true;

        return true;
    }

    public Endereco build()
    {
        _=this.validar() ? true : throw new Exception();
        Endereco endereco = Endereco.createEndereco(
            _cep,
            _logradouro,
            _numero,
            _complemento,
            _referencia,
            _bairro,
            _cidade,
            _estado
        );
        
        this.init();

        return endereco;
    }
    
}