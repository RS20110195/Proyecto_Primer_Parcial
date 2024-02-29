
using System;
using System.Threading;
using System.Collections.Generic;
using Proyecto.Primer.Parcial.Core.Entities;
using Proyecto.Primer.Parcial.Core.Managers;
using Proyecto.Primer.Parcial.Core.Services;

namespace Proyecto.Primer.Parcial.App;


public static class MainProgram
{
    public static List<Transacciones> listTransacciones = new List<Transacciones>();
    public static Ingresos IN = new Ingresos();
    public static Retiros RE = new Retiros();
    public static SaldoActual SA = new SaldoActual();
    public static List<String> DescripcionDistinta = new List<String>();

    public static TransaccionService service = new TransaccionService();
    
    public static TransaccionManager managers = new TransaccionManager(service);
    
public static void Main(string[] args){
    float Option;
    do
    {
        System.Console.WriteLine("---------- SISTEMA PRINCIPAL ----------");
        System.Console.WriteLine("1. Registro de Transacciones ");
        System.Console.WriteLine("2. Seguimiento de Saldo y Estado Financiero ");
        System.Console.WriteLine("3. Meta Y Presupuesto Mensual ");
        System.Console.WriteLine("0. Salir del Sistema");
        System.Console.Write("Ingresa Opcion -->: ");
        //Option = Console.Read();
        Single.TryParse(System.Console.ReadLine(), out Option);
        switch(Option){
            case 1:
                Opcion1();
            break;
            case 2:
                Opcion2();
            break;
            case 3:
                Opcion3();
            break;
            case 0:
            System.Console.WriteLine("Haz salido del Sistema Vuelva Pronto");
            break;
            default:
            System.Console.WriteLine("No es Una Opcione del Sistema");
            break;
        }
        
    } while (Option != 0);
}


static void Opcion1()
{
    
    float option;
    do
    {
        System.Console.WriteLine("---------- REGISTRO DE TRANSACCIONES ----------");
        System.Console.WriteLine($"Saldo Actual: ${SA.saldoactual} mxn");
        System.Console.WriteLine("1. Ingresar ");
        System.Console.WriteLine("2. Retirar ");
        System.Console.WriteLine("0. Regresar al Menu Principal");
        System.Console.Write("Ingresa Una Opcion -->: ");
        Single.TryParse(System.Console.ReadLine(), out option);

        switch (option)
        {
            case 1:
                Registro(true);
                break;
            case 2:
                Registro(false);
                break;
                case 0:
                System.Console.WriteLine();
                System.Console.WriteLine();
                break;
                default:
                    System.Console.WriteLine("No es una opcion del Sistema");
                break;
        }
    } while (option != 0);
}


public static void Registro(bool tipo)
{
    var service = new TransaccionService();
    var managers = new TransaccionManager(service);


    var result = managers.GetTransaccionesListAndSaldoActual(listTransacciones, SA, tipo);

    listTransacciones = result.Item1;
    SA = result.Item2;

    
    
}


static void Opcion2()
{
    float option;
    do
    {
        System.Console.WriteLine("---------- SEGUIMIENTO DE SALDO Y ESTADO FINANCIERO ----------");
        System.Console.WriteLine("1. Saldo Actual ");
        System.Console.WriteLine("2. Estado Financiero ");
        System.Console.WriteLine("3. Informes de las Finanzas ");
        System.Console.WriteLine("0. Regresar al Menu Principal");
        System.Console.Write("Ingresa Una Opcion -->: ");
        Single.TryParse(System.Console.ReadLine(), out option);

        switch (option)
        {
            case 1:
                System.Console.WriteLine("----------------------------------");
                System.Console.WriteLine($"Saldo Actual ${SA.saldoactual} mxn");
                System.Console.WriteLine("----------------------------------");
                break;
            case 2:
                estadoFinanciero();
                break;
            case 3:
                informeFinanzas();
                break;
            case 0:
                System.Console.WriteLine();
                System.Console.WriteLine();
                break;
            default:
                System.Console.WriteLine("No es una opcion del Sistema");
                break;
        }
    } while (option != 0);
}

static void estadoFinanciero(){
    IN.IngresosTotales = 0;
    RE.RetirosTotales = 0;
    foreach (var VARIABLE in listTransacciones)
    {
        if (VARIABLE.Tipo)
        {
            IN.IngresosTotales += VARIABLE.Monto;
        }else
        {
            RE.RetirosTotales += VARIABLE.Monto;
        }
    }
    System.Console.WriteLine("----------------------------------");
    foreach (var VARIABLE in listTransacciones)
    { if (VARIABLE.Tipo)
        { System.Console.WriteLine("----------------------------------");
            System.Console.WriteLine(VARIABLE.Categoria);
            System.Console.WriteLine(VARIABLE.Descripcion);
            System.Console.WriteLine($"${VARIABLE.Monto} mxn");
            System.Console.WriteLine("----------------------------------");
        }
    }
    System.Console.WriteLine($"Ingresos Totales: ${IN.IngresosTotales} mxn");
    
    foreach (var VARIABLE in listTransacciones)
    { if (!VARIABLE.Tipo)
        { System.Console.WriteLine("----------------------------------");
            System.Console.WriteLine(VARIABLE.Categoria);
            System.Console.WriteLine(VARIABLE.Descripcion);
            System.Console.WriteLine($"${VARIABLE.Monto} mxn");
            System.Console.WriteLine("----------------------------------");
        }
    }
    System.Console.WriteLine($"Retiros Totales: ${RE.RetirosTotales} mxn");
    System.Console.WriteLine("----------------------------------");
    System.Console.WriteLine($"Saldo Actual: ${IN.IngresosTotales - RE.RetirosTotales} mxn");
    System.Console.WriteLine("----------------------------------");
    
}

static void informeFinanzas()
{
    String Description;
    System.Console.Write("Disponibles: ");
    foreach (var VARIABLE in listTransacciones)
    {
        DescripcionDistinta.Add(VARIABLE.Descripcion);
    }
    DescripcionDistinta = DescripcionDistinta.Distinct().ToList();
    Console.WriteLine(String.Join(",", DescripcionDistinta));
    
    System.Console.Write("Ingresa una descripcion de Busqueda: ");
    Description = System.Console.ReadLine() ?? "";


    Transacciones transaccionBusqueda;

    transaccionBusqueda = managers.searchTransacciones(listTransacciones, Description);

    if(transaccionBusqueda != null)
    {
        System.Console.WriteLine("----------------------------------");
        if (transaccionBusqueda.Tipo)
        {
            System.Console.WriteLine("----- Ingreso -----");
        }
        else
        {
            System.Console.WriteLine("----- Retiro -----");
        }

        System.Console.WriteLine(transaccionBusqueda.Categoria);
        System.Console.WriteLine(transaccionBusqueda.Descripcion);
        System.Console.WriteLine($"${transaccionBusqueda.Monto} mxn");
        System.Console.WriteLine("----------------------------------");
    }
    else
    {
        System.Console.WriteLine("No se encontro la descripcion");
    }



}

static void Opcion3()
{
    float option;
    do
    {
        System.Console.WriteLine("---------- METAS Y PRESUPUESTOS ----------");
        System.Console.WriteLine("1. Meta Financiera ");
        System.Console.WriteLine("2. Presupuesto Mensual ");
        System.Console.WriteLine("0. Regresar al Menu Principal");
        System.Console.Write("Ingresa Una Opcion -->: ");
        Single.TryParse(System.Console.ReadLine(), out option);

        switch (option)
        {
            case 1:
                meta();
                break;
            case 2:
                presupuestoMensual();
                break;
            case 0:
            System.Console.WriteLine();
                System.Console.WriteLine();
                break;
            default:
                System.Console.WriteLine("No es una opcion del Sistema");
                break;
        }
    } while (option != 0);
    
}

public static void meta()
{
    float MoneyMeta;
    int Limite;

    var service = new TransaccionService();
    var managers = new TransaccionManager(service);

System.Console.WriteLine($"Saldo Actual ${SA.saldoactual} mxn");
    System.Console.Write("¿Cuanto es tu Meta Financiera?: ");
    Single.TryParse(System.Console.ReadLine(), out MoneyMeta);
    
    

    Limite = managers.GetMeta(MoneyMeta, SA);


    System.Console.WriteLine($"Llevas {Limite}% de tu Meta Financiera de ${MoneyMeta} mxn");

    Console.Write("Progreso: ");
        for (int i = 0; i <= Limite; i++)
        {
            Console.Write("[");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(new string('=', i / 2));
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write(new string(' ', 50 - i / 2));
            Console.Write("] {0,3}%\r", i);
            Thread.Sleep(45); // Simular una operación que lleva tiempo
        }
        Console.WriteLine();

}

public static void presupuestoMensual()
{
    double ingresos_totales;
    double gastos_fijos;
    double gastos_variables;
    double ahorros;
    double saldo_final;




    
    // Ingresar datos
    Console.Write("Ingrese sus ingresos totales:");
    ingresos_totales = Convert.ToDouble(Console.ReadLine());

    Console.Write("Ingrese sus gastos fijos:");
    gastos_fijos = Convert.ToDouble(Console.ReadLine());

    Console.Write("Ingrese sus gastos variables:");
    gastos_variables = Convert.ToDouble(Console.ReadLine());

    Console.Write("Ingrese la cantidad que desea ahorrar:");
    ahorros = Convert.ToDouble(Console.ReadLine());

    // Calcular saldo final
    saldo_final = managers.GetSaldoFinal(ingresos_totales, gastos_fijos, gastos_variables, ahorros);

    // Mostrar resultados
    Console.WriteLine("Presupuesto mensual:");
    Console.WriteLine("Ingresos totales: {0:C}", ingresos_totales);
    Console.WriteLine("Gastos fijos: {0:C}", gastos_fijos);
    Console.WriteLine("Gastos variables: {0:C}", gastos_variables);
    Console.WriteLine("Ahorros: {0:C}", ahorros);
    Console.WriteLine("Saldo final: {0:C}", saldo_final);
    

}



}
