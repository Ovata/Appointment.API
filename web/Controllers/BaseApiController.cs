using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace web.Controllers
{
    public class BaseApiController : ControllerBase
    {
        protected IActionResult CreateApiException(Exception ex)
        {
            return Problem(ex.StackTrace, ex.Source, 500, ex.Message);
        }
    }
}
