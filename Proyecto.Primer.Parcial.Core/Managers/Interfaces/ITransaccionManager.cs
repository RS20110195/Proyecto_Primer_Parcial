using Proyecto.Primer.Parcial.Core.Entities;

namespace Proyecto.Primer.Parcial.Core.Managers.Interfaces;

public interface ITransaccionManager
{
    Transacciones GetTransacciones(Registros registros);

    (List<Transacciones>, SaldoActual) GetTransaccionesListAndSaldoActual(List<Transacciones> lista_actual_transacciones, SaldoActual saldoactual, bool tipo);

    int GetMeta(float MoneyMeta, SaldoActual saldoActual);

    double GetSaldoFinal(
        double ingresos_totales, 
        double gastos_fijos, 
        double gastos_variables,
        double ahorros
        );

    Transacciones searchTransacciones(List<Transacciones> lista_transacciones, string query);    
}