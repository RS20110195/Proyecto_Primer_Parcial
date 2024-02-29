


using System.ComponentModel;
using Proyecto.Primer.Parcial.Core.Entities;
using Proyecto.Primer.Parcial.Core.Services.Interfaces;

namespace Proyecto.Primer.Parcial.Core.Services;

public class TransaccionService : ITransaccionService
{
    public Transacciones ProcessTransacciones(Registros registros)
    {
        var transacciones = new Transacciones();
        
        transacciones.Categoria = registros.Categoria;
        transacciones.Descripcion = registros.Descripcion;
        transacciones.Monto = registros.Monto;
        transacciones.Tipo = registros.Tipo;
        
        return transacciones;
    }


    //I need return a list of transacciones and SaldoActual


    public (List<Transacciones>, SaldoActual) ProcessTransaccionesListAndSaldoActual(List<Transacciones> lista_actual_transacciones, SaldoActual saldoactual, bool tipo)
    {

        float MoneyAux;
        String descripcion;
        System.Console.Write("Ingrese la cantidad: ");
        Single.TryParse(System.Console.ReadLine(), out MoneyAux);
        double Money = (double)MoneyAux;

        SaldoActual SA = saldoactual;
        List<Transacciones> listTransacciones = lista_actual_transacciones;

        if (tipo)
        {
            if (Money > 0)
            {    

                System.Console.Write("Ingrese la Categoria : \n");
                System.Console.WriteLine("1. Comida");
                System.Console.WriteLine("2. Ropa");
                System.Console.WriteLine("3. Escuela");
                System.Console.WriteLine("4. Salud");
                System.Console.WriteLine("5. Entretenimiento");
                System.Console.WriteLine("6. Otros");
                System.Console.Write("Ingrese la Categoria : ");
                int categoria_num;
                Int32.TryParse(System.Console.ReadLine(), out categoria_num);

                String categoria;
                switch (categoria_num)
                {
                    case 1:
                        categoria = "Comida";
                        break;
                    case 2:
                        categoria = "Ropa";
                        break;
                    case 3:
                        categoria = "Escuela";
                        break;
                    case 4:
                        categoria = "Salud";
                        break;
                    case 5:
                        categoria = "Entretenimiento";
                        break;
                    case 6:
                        categoria = "Otros";
                        break;
                    default:
                        categoria = "Otros";
                        break;
                }

                System.Console.Write("Ingrese la Descripcion : ");
                descripcion = System.Console.ReadLine() ?? "";
                var registros = new Registros{
                    Categoria=categoria,
                    Descripcion=descripcion, 
                    Monto=Money, 
                    Tipo = tipo};
                Transacciones transacciones = ProcessTransacciones(registros);
                listTransacciones.Add(transacciones);
                SA.saldoactual += Money;
            }
            else
            {
                System.Console.WriteLine("Debe Ingresar Una Cantidad Mayor a Cero");
            }
        }
        else
        {
            if (Money <= SA.saldoactual)
            {

                System.Console.Write("Ingrese la Categoria : \n");
                System.Console.WriteLine("1. Comida");
                System.Console.WriteLine("2. Ropa");
                System.Console.WriteLine("3. Escuela");
                System.Console.WriteLine("4. Salud");
                System.Console.WriteLine("5. Entretenimiento");
                System.Console.WriteLine("6. Otros");
                System.Console.Write("Ingrese la Categoria : ");
                int categoria_num;
                Int32.TryParse(System.Console.ReadLine(), out categoria_num);

                String categoria;
                switch (categoria_num)
                {
                    case 1:
                        categoria = "Comida";
                        break;
                    case 2:
                        categoria = "Ropa";
                        break;
                    case 3:
                        categoria = "Escuela";
                        break;
                    case 4:
                        categoria = "Salud";
                        break;
                    case 5:
                        categoria = "Entretenimiento";
                        break;
                    case 6:
                        categoria = "Otros";
                        break;
                    default:
                        categoria = "Otros";
                        break;
                }

                System.Console.Write("Ingrese la Descripcion : ");
                descripcion = System.Console.ReadLine() ?? "";
                var registros = new Registros{
                    Categoria=categoria,
                    Descripcion=descripcion, 
                    Monto=Money, 
                    Tipo = tipo
                    };
                Transacciones transacciones = ProcessTransacciones(registros);
                listTransacciones.Add(transacciones);
                SA.saldoactual -= Money;
            }
            else
            {
                System.Console.WriteLine("-------------------------------------------------------------------");
                System.Console.WriteLine($"No puede Retirar más del Saldo Actual: ${SA.saldoactual} mxn");
                System.Console.WriteLine("-------------------------------------------------------------------");
            }
        }   
        
    
        return (listTransacciones, SA);
    }


    public (List<Transacciones>, SaldoActual) ProcessTransaccionesListAndSaldoActualTest(List<Transacciones> lista_actual_transacciones, SaldoActual saldoactual, bool tipo, Registros registros)
    {
        SaldoActual SA = saldoactual;
        List<Transacciones> listTransacciones = lista_actual_transacciones;

        if (tipo)
        {
            if (registros.Monto > 0)
            {    

                Transacciones transacciones = ProcessTransacciones(registros);
                listTransacciones.Add(transacciones);
                SA.saldoactual += registros.Monto;
            }
            else
            {
                System.Console.WriteLine("Debe Ingresar Una Cantidad Mayor a Cero");
            }
        }
        else
        {
            if (registros.Monto <= SA.saldoactual)
            {

                Transacciones transacciones = ProcessTransacciones(registros);
                listTransacciones.Add(transacciones);
                SA.saldoactual -= registros.Monto;
            }
        }   
        
        return (listTransacciones, SA);
    }


        
    


    public int ProcessMeta(float MoneyMeta, SaldoActual sa)
    {

        int Limite;
        
        if (MoneyMeta > sa.saldoactual)
        { 
            double LimiteAux = 100 / MoneyMeta * sa.saldoactual;
            Limite = (int)LimiteAux;
        }
        else
        {
            Limite = 100;
        }
        
        return Limite;
    }


    public double ProcessSaldoFinal(
        double ingresos_totales, 
        double gastos_fijos, 
        double gastos_variables,
        double ahorros
        )
    {
        double saldo_final;
        saldo_final = ingresos_totales - gastos_fijos - gastos_variables - ahorros;
        return saldo_final;
    }


    public Transacciones searchTransacciones(List<Transacciones> lista_transacciones, string query)
    {
        Transacciones transaccion;
        return transaccion = lista_transacciones.Find(x => x.Descripcion == query);
    }

}

