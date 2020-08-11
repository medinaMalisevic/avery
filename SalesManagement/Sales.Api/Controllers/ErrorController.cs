using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Sales.Api.Controllers
{
    /// <summary>
    /// Exception handling controller
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class ErrorController : ControllerBase
    {
        /// <summary>
        /// Action that triggers on unhandled exeptions
        /// </summary>
        /// <returns>Action result with object result stripped of sensitive details</returns>
        [HttpGet]
        public IActionResult Error() => Problem(statusCode: StatusCodes.Status500InternalServerError);
    }
}
