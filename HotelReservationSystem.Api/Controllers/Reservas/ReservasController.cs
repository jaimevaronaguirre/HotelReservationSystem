using HotelReservationSystem.Application.Reservas.GetReservar;
using HotelReservationSystem.Application.Reservas.ReservaHabitacion;
using HotelReservationSystem.Domain.Habitaciones;
using HotelReservationSystem.Domain.Users;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HotelReservationSystem.Api.Controllers.Reservas
{
    [ApiController]
    [Route("api/reservas")]
    public class ReservasController : Controller
    {
        private readonly ISender _sender;

        public ReservasController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetReserva(
            Guid id,
            CancellationToken cancellationToken
        )
        {
            var query = new GetReservarQuery(id);
            var resultado = await _sender.Send(query, cancellationToken);
            return resultado.IsSuccess ? Ok(resultado.Value) : NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> ReservaHabitacion(
            Guid id,
            ReservarHabitacionRequest request,
            CancellationToken cancellationToken
        )
        {
            var command = new ReservaHabitacionCammand
            (
                request.HabitacionId,
                request.UserId,
                request.StartDate,
                request.EndDate
            );           
            
            var resultado = await _sender.Send (command, cancellationToken);

            if (resultado.IsFailure) 
            {
                return BadRequest(resultado.Error);
            }
            
            return CreatedAtAction(nameof(GetReserva), new { id = resultado.Value }, resultado.Value);

        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
