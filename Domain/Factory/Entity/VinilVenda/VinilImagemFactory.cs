using VinilProjeto.Entity.VinilVenda;

namespace VinilProjeto.Factory.Entity.VinilVenda;

public class VinilImagemFactory
{
    public string _fileName { get; set; }
    public Guid _vinilId { get; set; }

    private void init()
    {
        _fileName = null;
        _vinilId = Guid.Empty;
    }

    public VinilImagemFactory setFileName(string fileName)
    {
        this._fileName = fileName;
        return this;
    }
    

    public VinilImagemFactory setVinilId(Guid vinilId)
    {
        this._vinilId = vinilId;
        return this;
    }

    public bool validar()
    {
        _ = _fileName == null ? throw new Exception() : true;
        _ = _vinilId.Equals(Guid.Empty) ? throw new Exception() : true;

        return true;
    }

    public VinilImagem build()
    {
        _ = this.validar() ? true : throw new Exception();

        VinilImagem vinilImagem = VinilImagem.createVinilEntity(
            _fileName,
            _vinilId
        );

        this.init();

        return vinilImagem;
    }
}