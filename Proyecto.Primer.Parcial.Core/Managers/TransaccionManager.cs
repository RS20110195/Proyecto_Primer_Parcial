using Proyecto.Primer.Parcial.Core.Entities;
using Proyecto.Primer.Parcial.Core.Managers.Interfaces;
using Proyecto.Primer.Parcial.Core.Services.Interfaces;

namespace Proyecto.Primer.Parcial.Core.Managers;

public class TransaccionManager : ITransaccionManager
{
    private readonly ITransaccionService _service;
    
        public TransaccionManager(ITransaccionService service){
            _service = service;
        }
    
        public Transacciones GetTransacciones(Registros registros)
        {
            return _service.ProcessTransacciones(registros);
        }
}

