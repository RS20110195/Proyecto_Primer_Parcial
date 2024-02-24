using Proyecto.Primer.Parcial.Core.Entities;

namespace Proyecto.Primer.Parcial.Core.Services.Interfaces;

public interface ITransaccionService
{
    Transacciones ProcessTransacciones(Registros registros);
}