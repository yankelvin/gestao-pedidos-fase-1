using Domain.Models.ItensPedido;
using Microsoft.EntityFrameworkCore;
using Service.DrivenAdapters.DataBaseAdapters.Entities.ItensPedido;
using Service.DrivenAdapters.DatabaseAdapters.MapContext.EntitiesMap;

namespace Service.DrivenAdapters.DatabaseAdapters.MapContext;

public static class ConfigureMap
{
    public static void Config(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ItensPedidoEntity>(new ItensPedidoMap().Configure);
    }
}