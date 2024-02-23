namespace VinilProjeto.Entity.VinilVenda;

public enum EstiloMusical
{
    Rock,
    POP,
    Jazz,
    Rap,
    Trap,
    HipHop,
    Eletronica,
    Reggae,
    RB,
    Blues,
    Vazio
}
[Serializable]
public class VinilEntity : IEntity
{
    public string nomeVinil { get; protected set; }
    public string descricaoVinil { get; protected set; }
    public string precoVinil { get; protected set; }
    public string quantiaVinil { get; protected set; }
    public EstiloMusical estiloMusical { get; protected set; }
    
    public VinilEntity(){}

    public static VinilEntity createVinilEntity(string nome, string descricao, string preco, string quantia,
        EstiloMusical estiloMusical)
    {
        
        VinilEntity vinilEntity = new VinilEntity()
        {
            nomeVinil = nome,
            descricaoVinil = descricao,
            precoVinil = preco,
            quantiaVinil = quantia,
            estiloMusical = estiloMusical
        };
        
        return vinilEntity;
        
    }
}