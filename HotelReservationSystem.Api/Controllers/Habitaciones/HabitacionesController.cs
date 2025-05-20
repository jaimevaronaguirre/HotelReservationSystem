using HotelReservationSystem.Application.Habitaciones.SearchHabitaciones;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HotelReservationSystem.Api.Controllers.Habitaciones
{
    [ApiController]
    [Route("api/habitaciones")]
    public class HabitacionesController : Controller
    {
        private readonly ISender _sender;

        public HabitacionesController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet]
        public async Task<IActionResult> SearchHabitaciones(
            DateOnly startDate,
            DateOnly endDate,
            CancellationToken cancellationToken
        )
        {
            var query = new SearchHabitacionesQuery(startDate, endDate);
            var resultados = await _sender.Send(query, cancellationToken);
            return Ok(resultados.Value);
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
