using Proyecto.Primer.Parcial.Core.Entities;

namespace Proyecto.Primer.Parcial.Core.Managers.Interfaces;

public interface ITransaccionManager
{
    Transacciones GetTransacciones(Registros registros);

}