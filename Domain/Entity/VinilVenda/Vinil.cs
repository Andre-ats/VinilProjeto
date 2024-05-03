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

public enum StatusVinil
{
    Ativo,
    Inativo,
    Vazio
}

[Serializable]
public class Vinil : IEntity
{
    public string nomeVinil { get; protected set; }
    public string descricaoVinil { get; protected set; }
    public string precoVinil { get; protected set; }
    public string quantiaVinil { get; protected set; }
    public EstiloMusical estiloMusical { get; protected set; }
    public StatusVinil StatusVinil { get; protected set; }
    public ICollection<VinilImagem> VinilImagem { get; protected set; } = new List<VinilImagem>();
    public Vinil(){}

    public static Vinil createVinilEntity(string nome, string descricao, string preco, string quantia,
        EstiloMusical estiloMusical, StatusVinil status, ICollection<VinilImagem> vinilImagem)
    {
        
        Vinil vinil = new Vinil()
        {
            nomeVinil = nome,
            descricaoVinil = descricao,
            precoVinil = preco,
            quantiaVinil = quantia,
            estiloMusical = estiloMusical,
            StatusVinil = status,
            VinilImagem = vinilImagem
        };
        
        return vinil;
        
    }

    public Vinil adicionarVinilImagem(VinilImagem vinilImagem)
    {
        this.VinilImagem.Add(vinilImagem);
        return this;
    }
    
}