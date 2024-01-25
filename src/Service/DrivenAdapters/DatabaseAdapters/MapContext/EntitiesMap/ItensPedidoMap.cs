using Domain.Models.ItensPedido;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Service.DrivenAdapters.DataBaseAdapters.Entities.ItensPedido;

namespace Service.DrivenAdapters.DatabaseAdapters.MapContext.EntitiesMap;

public class ItensPedidoMap : IEntityTypeConfiguration<ItensPedidoEntity>
{
    public void Configure(EntityTypeBuilder<ItensPedidoEntity> builder)
    {
        builder.HasOne(itens => itens.Pedido)
            .WithMany(pedido => pedido.ItensPedidos)
            .HasForeignKey(itensPedido => itensPedido.IdPedido);
    }
}