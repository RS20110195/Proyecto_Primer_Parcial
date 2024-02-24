


using Proyecto.Primer.Parcial.Core.Entities;
using Proyecto.Primer.Parcial.Core.Services.Interfaces;

namespace Proyecto.Primer.Parcial.Core.Services;

public class TransaccionService : ITransaccionService
{
    public Transacciones ProcessTransacciones(Registros registros)
    {
        var transacciones = new Transacciones();
        
        transacciones.Descripcion = registros.Descripcion;
        transacciones.Monto = registros.Monto;
        transacciones.Tipo = registros.Tipo;
        
        return transacciones;
    }
    
}

