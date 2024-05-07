namespace VinilProjeto.Entity.VinilVenda;

public class VinilImagem
{
    public string fileName { get; private set; }
    public Guid vinilId { get; private set; }
    public string rotaImagemVinil { get; set; }

    public VinilImagem()
    {
    }

    public static VinilImagem createVinilEntity(string fileName, Guid vinilId, string rotaImagemVinil)
    {

        VinilImagem vinilImagem = new VinilImagem()
        {
            fileName = fileName,
            vinilId = vinilId,
            rotaImagemVinil = rotaImagemVinil
        };

        return vinilImagem;
    }
    
    
}