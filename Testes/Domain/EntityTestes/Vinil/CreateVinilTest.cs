using VinilProjeto.Entity.VinilVenda;
using VinilProjeto.Factory.Entity.VinilVenda;

namespace Testes.Domain.EntityTestes.Vinil;

public class CreateVinilTest
{
    [Test]
    public void construcaoObjVinil()
    {
        var vinil = new VinilVendaFactory()
            .setNomeVinil("Dua Lipa teste")
            .setDescricaoVinil("Dua lipa teste descricao")
            .setEstiloMusical(EstiloMusical.POP)
            .setPrecoVinil("333")
            .setQuantiaVinil("1")
            .setStatusVinil(StatusVinil.Ativo)
            .build();
        
        var vinil2 = new VinilVendaFactory()
            .setNomeVinil("Post malone teste")
            .setDescricaoVinil("Post malone teste descricao")
            .setEstiloMusical(EstiloMusical.HipHop)
            .setPrecoVinil("414")
            .setQuantiaVinil("3")
            .setStatusVinil(StatusVinil.Ativo)
            .build();
    }
}