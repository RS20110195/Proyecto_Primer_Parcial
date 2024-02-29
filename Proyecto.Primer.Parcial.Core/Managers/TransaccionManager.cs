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

        public (List<Transacciones>, SaldoActual) GetTransaccionesListAndSaldoActual(List<Transacciones> lista_actual_transacciones, SaldoActual saldoactual, bool tipo)
        {
            return _service.ProcessTransaccionesListAndSaldoActual(lista_actual_transacciones, saldoactual, tipo);
        }

        public int GetMeta(float MoneyMeta, SaldoActual saldoActual)
        {
            return _service.ProcessMeta(MoneyMeta, saldoActual);
        }

        public double GetSaldoFinal(
            double ingresos_totales, 
            double gastos_fijos, 
            double gastos_variables,
            double ahorros
            )
        {
            return _service.ProcessSaldoFinal(ingresos_totales, gastos_fijos, gastos_variables, ahorros);
        }

        public Transacciones searchTransacciones(List<Transacciones> lista_transacciones, string query)
        {
            return _service.searchTransacciones(lista_transacciones, query);
        }
}

