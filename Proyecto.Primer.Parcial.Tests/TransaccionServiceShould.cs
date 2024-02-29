using Xunit;
using Proyecto.Primer.Parcial.Core.Entities;
using Proyecto.Primer.Parcial.Core.Services;

namespace Proyecto.Primer.Parcial.Tests
{
    public class TransaccionServiceShould
    {
        [Fact]
        public void ProcessTransacciones_ReturnsCorrectTransacciones()
        {
            // Arrange
            var registros = new Registros
            {
                Tipo = true,
                Descripcion = "Ingreso",
                Monto = 100
            };
            var transaccionService = new TransaccionService();

            // Act
            var transacciones = transaccionService.ProcessTransacciones(registros);

            // Assert
            Assert.NotNull(transacciones);
            Assert.Equal(registros.Tipo, transacciones.Tipo);
            Assert.Equal(registros.Descripcion, transacciones.Descripcion);
            Assert.Equal(registros.Monto, transacciones.Monto);
        }

        [Fact]
        public void ProcessTransaccionesListAndSaldoActual_ReturnsUpdatedListAndSaldoActual()
        {
            // Arrange
            var listaActualTransacciones = new List<Transacciones>();
            var saldoActual = new SaldoActual { saldoactual = 100 };
            var tipo = true;
            var transaccionService = new TransaccionService();
            var registros = new Registros
            {
                Tipo = true,
                Categoria = "Comida",
                Descripcion = "Ingreso",
                Monto = 100
            };
            

            // Act
            var result = transaccionService.ProcessTransaccionesListAndSaldoActualTest(listaActualTransacciones, saldoActual, tipo, registros);

            // Assert
            Assert.NotNull(result);
            Assert.NotNull(result.Item1);
            Assert.NotNull(result.Item2);
            Assert.Single(result.Item1); // Verificar que se agregó una transacción a la lista
            Assert.Equal(200, result.Item2.saldoactual); // Verificar que el saldo actual se actualizó correctamente
        }




        [Fact]
        public void ProcessMeta_ReturnsCorrectLimite()
        {
            // Arrange
            var moneyMeta = 500f;
            var saldoActual = new SaldoActual { saldoactual = 300 };
            var transaccionService = new TransaccionService();

            // Act
            var limite = transaccionService.ProcessMeta(moneyMeta, saldoActual);

            // Assert
            Assert.Equal(60, limite); // Verificar que el límite calculado sea correcto
        }

        [Fact]
        public void ProcessSaldoFinal_ReturnsCorrectSaldoFinal()
        {
            // Arrange
            var ingresosTotales = 1000;
            var gastosFijos = 500;
            var gastosVariables = 300;
            var ahorros = 200;
            var transaccionService = new TransaccionService();

            // Act
            var saldoFinal = transaccionService.ProcessSaldoFinal(ingresosTotales, gastosFijos, gastosVariables, ahorros);


            double expected = 1000 - 500 - 300 - 200;
            // Assert
            Assert.Equal( expected, saldoFinal); // Verificar que el saldo final se haya calculado correctamente
        }

        [Fact]
        public void SearchTransacciones_ReturnsCorrectTransaccion()
        {
            // Arrange
            var listaTransacciones = new List<Transacciones>
            {
                new Transacciones { Descripcion = "Compra de alimentos", Monto = 50 },
                new Transacciones { Descripcion = "Compra de ropa", Monto = 30 },
                new Transacciones { Descripcion = "Pago de servicios", Monto = 80 }
            };
            var query = "Compra de ropa";
            var transaccionService = new TransaccionService();

            // Act
            var transaccion = transaccionService.searchTransacciones(listaTransacciones, query);

            // Assert
            Assert.NotNull(transaccion);
            Assert.Equal(query, transaccion.Descripcion);
        }
    }
}
