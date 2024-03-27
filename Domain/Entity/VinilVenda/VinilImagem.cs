namespace VinilProjeto.Entity.VinilVenda;

public class VinilImagem : IEntity
{
    public string fileName { get; private set; }
    public string hashName { get; private set; }
    public Guid vinilId { get; private set; }

    public VinilImagem()
    {
    }

    public static VinilImagem createVinilEntity(string fileName, string hashName, Guid vinilId)
    {

        VinilImagem vinilImagem = new VinilImagem()
        {
            fileName = fileName,
            hashName = hashName,
            vinilId = vinilId
        };

        return vinilImagem;
    }

    
}