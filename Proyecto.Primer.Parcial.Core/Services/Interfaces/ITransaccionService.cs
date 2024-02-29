using Proyecto.Primer.Parcial.Core.Entities;

namespace Proyecto.Primer.Parcial.Core.Services.Interfaces;

public interface ITransaccionService
{
    Transacciones ProcessTransacciones(Registros registros);

    (List<Transacciones>, SaldoActual) ProcessTransaccionesListAndSaldoActual(List<Transacciones> lista_actual_transacciones, SaldoActual saldoactual, bool tipo);
    
    int ProcessMeta(float MoneyMeta, SaldoActual saldoActual);

    double ProcessSaldoFinal(
        double ingresos_totales, 
        double gastos_fijos, 
        double gastos_variables,
        double ahorros
        );

    Transacciones searchTransacciones(List<Transacciones> lista_transacciones, string query);    
}