using HotelReservationSystem.Domain.Habitaciones;
using HotelReservationSystem.Domain.Shared;

namespace HotelReservationSystem.Domain.Reservas
{
    public class PrecioService
    {
        public PrecioDetalle CalcularPrecio(Habitacion habitacion, DateRange periodo)
        {
            var tipoMoneda = habitacion.PrecioReserva!.TipoMoneda;
            var precioPorNoche = new Moneda(
                periodo.CantidadDias * habitacion.PrecioReserva.Monto, tipoMoneda);

            decimal porcentageChange = 0;

            //Moneda totalAdicionales = Moneda.Zero(precioBase.TipoMoneda);

            //foreach (var accesorio in habitacion.Accesorios)
            //{
            //    totalAdicionales += accesorio switch
            //    {
            //        AccesorioHabitacion.AireAcondicionado => new Moneda(30000, precioBase.TipoMoneda),
            //        AccesorioHabitacion.Minibar => new Moneda(15000, precioBase.TipoMoneda),
            //        AccesorioHabitacion.Jacuzzi => new Moneda(50000, precioBase.TipoMoneda),
            //        AccesorioHabitacion.Balcon => new Moneda(10000, precioBase.TipoMoneda),
            //        // agrega otros accesorios con valores fijos si aplica
            //        _ => Moneda.Zero(precioBase.TipoMoneda)
            //    };
            //}

            //Moneda precioFinal = precioBase + totalAdicionales;

            foreach (var accesorio in habitacion.Accesorios)
            {
                porcentageChange += accesorio switch
                {
                    AccesorioHabitacion.AireAcondicionado => 0.08m,  // A/C en clima cálido es esencial, suele ser incluido, pero si se cobra: ~8%
                    AccesorioHabitacion.Minibar => 0.05m,             // Minibar con snacks o bebidas
                    AccesorioHabitacion.Jacuzzi => 0.10m,             // Jacuzzi es premium
                    AccesorioHabitacion.Balcon => 0.04m,              // Vista o espacio adicional
                    AccesorioHabitacion.Televisor => 0.02m,                  // Básico, pero algunos lo consideran opcional
                    AccesorioHabitacion.CajaFuerte => 0.03m,  
                    
                    _=> 0
                };
            }
            var accesorioCharges = Moneda.Zero(tipoMoneda);

            if(porcentageChange > 0)
            {
                accesorioCharges = new Moneda(
                    precioPorNoche.Monto * porcentageChange,
                    tipoMoneda
                );
            }

            var precioTotal = Moneda.Zero();
            precioTotal += precioPorNoche;

            if(!habitacion!.ServicioAdicional!.IsZero())
            {
                precioTotal += habitacion.ServicioAdicional;
            }
            precioTotal += accesorioCharges;

            return new PrecioDetalle(
                precioPorNoche,
                habitacion.ServicioAdicional,
                accesorioCharges,
                precioTotal
                );
        }
    }
}
