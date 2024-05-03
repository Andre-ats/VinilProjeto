namespace VinilProjeto.Entity.VinilVenda;

public class VinilImagem : IEntity
{
    public string fileName { get; private set; }
    public Guid vinilId { get; private set; }

    public VinilImagem()
    {
    }

    public static VinilImagem createVinilEntity(string fileName, Guid vinilId)
    {

        VinilImagem vinilImagem = new VinilImagem()
        {
            fileName = fileName,
            vinilId = vinilId
        };

        return vinilImagem;
    }
    
    
}