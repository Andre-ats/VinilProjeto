using VinilProjeto.ValueObject.Vinil;

namespace VinilProjeto.Entity.VinilVenda;


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
    public string listaMusica { get; protected set; }
    public string precoVinil { get; protected set; }
    public string quantiaVinil { get; protected set; }
    public string UPC { get; protected set; }
    public CaracteristicasPrincipais caracteristicasPrincipais { get; protected set; }
    public OutrasCaracteristicas outrasCaracteristicas { get; protected set; }
    public StatusVinil StatusVinil { get; protected set; }
    public ICollection<VinilImagem> VinilImagem { get; protected set; } = new List<VinilImagem>();
    public Vinil(){}

    public static Vinil createVinilEntity(string nome, string descricao, string preco, string quantiavinil, string UPC, string listaMusica,
        CaracteristicasPrincipais caracteristicasPrincipais, OutrasCaracteristicas outrasCaracteristicas, 
        StatusVinil status, ICollection<VinilImagem> vinilImagem)
    {
        
        Vinil vinil = new Vinil()
        {
            nomeVinil = nome,
            descricaoVinil = descricao,
            precoVinil = preco,
            quantiaVinil = quantiavinil,
            UPC = UPC,
            listaMusica = listaMusica,
            caracteristicasPrincipais = caracteristicasPrincipais,
            outrasCaracteristicas = outrasCaracteristicas,
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