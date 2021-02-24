using Business.Abstraction.Model;
using Business.Abstraction.Service;
using Business.Service.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace web.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AppointmentController : BaseApiController
    {
        private readonly IAppointmentService _appointmentService;

        public AppointmentController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        [HttpGet]
        [Route("getAppointmentById")]
        public async Task<IActionResult> GetApplicantById(int id)
        {
            try
            {
                var res = await _appointmentService.GetAppointment(id);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return CreateApiException(ex);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]AppointmentModel model)
        {
            try
            {
                await _appointmentService.AddAppointment(model);
                return Ok();
            }
            catch (Exception ex)
            {
                return CreateApiException(ex);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int Id)
        {
            try
            {
                await _appointmentService.RemoveAppointment(Id);
                return Ok();
            }
            catch (Exception ex)
            {
                return CreateApiException(ex);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put(AppointmentModel model, int Id)
        {
            try
            {
                await _appointmentService.UpdateAppointment(model, Id);
                return Ok();
            }
            catch (Exception ex)
            {
                return CreateApiException(ex);
            }
        }
    }
}
