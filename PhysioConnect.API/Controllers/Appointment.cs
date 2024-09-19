using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Physio.Application.Dtos.Appointment;
using Physio.Application.Interfaces;
using Physio.Application.Mappers;
using Physio.Domain.Models;
using PhysioConnect.API.Extensions;
using System.Security.Claims;

namespace PhysioConnect.API.Controllers
{
    [Route("api/appointment")]
    [ApiController]
    public class Appointment : ControllerBase
    {
        private readonly IAppointment _appointment;
        private readonly UserManager<User> _userManager;
        private readonly IUserRepository _userRepository;

        public Appointment(IAppointment appointment, UserManager<User> userManager, IUserRepository userRepository)
        {
            _appointment = appointment;
            _userManager = userManager;
            _userRepository = userRepository;
        }

        [HttpPost]
        [Authorize(Roles = "Client")]
        public async Task<IActionResult> Create([FromBody] CreateAppointmentDto appointment)
        {
            try
            {
                if(!ModelState.IsValid)
                    return BadRequest(ModelState);

                var userId = User.GetUserId();

                var physiotherapistId = appointment.PhysiotherapistId.ToString();

                var appointmentModel = appointment.ToAppointmentFromCreateDto(userId, physiotherapistId);

                await _appointment.CreateAsync(appointmentModel);
                return CreatedAtAction(nameof(GetAppointmentById), new { id = appointmentModel.Id }, appointmentModel.ToAppointmentDto());


            }
            catch (Exception ex) 
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id:int}")]
        [Authorize]
        public async Task<IActionResult> GetAppointmentById([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var appointment = await _appointment.GetAppointmentById(id);

            if(appointment == null)
                return NotFound();

            return Ok(appointment.ToAppointmentDto());

        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAppointment()
        {
            try
            {
                var userId = User.GetUserId(); 
                var userRole = User.GetUserRole();

                if (userRole == "Client")
                {
                    var appointments = await _appointment.GetAppointmentsByClientIdAsync(userId);
                    return Ok(appointments);
                }
                else if (userRole == "Physiotherapist")
                {
                    var appointments = await _appointment.GetAppointmentsByPhysiotherapistIdAsync(userId);
                    return Ok(appointments);
                }
                else
                {
                    return Forbid("Acesso não permitido.");
                }

            }
            catch (Exception ex) 
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
