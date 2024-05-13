namespace VinilProjeto.ValueObject.Vinil;
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
public class OutrasCaracteristicas
{
    public string quantiaCancoes { get; protected set; }
    public EstiloMusical estiloMusical { get; protected set; }

    public static OutrasCaracteristicas createOutrasCaracteristicas(string quantiaCancoes, EstiloMusical estiloMusical)
    {
        OutrasCaracteristicas outrasCaracteristicas = new OutrasCaracteristicas()
        {
            quantiaCancoes = quantiaCancoes,
            estiloMusical = estiloMusical
        };

        return outrasCaracteristicas;
    }
}