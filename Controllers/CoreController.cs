using Microsoft.AspNetCore.Mvc;
using PotatoServer.Exceptions;
using PotatoServer.Filters.HandleException;
using PotatoServer.Filters.LoggedAction;
using System;

namespace PotatoServer.Controllers.Core
{
    [Route("api/cards/test")]
    [ApiController]
    public class TestController : Controller
    {
        [LoggedActionFilter]
        [HandleExceptionFilter]
        [HttpGet("test-status-code/{code}")]
        public ActionResult GetProperStatusCode(int code)
        {
            switch (code)
            {
                case 200:
                    return Ok(new { Message = "OK" });
                case 400:
                    throw new BadRequestException("Bad request");
                case 404:
                    throw new NotFoundException("NotFound");
                case 500:
                    throw new ServerErrorException("ServerError");
                case 100:
                    throw new NullReferenceException("Dupa");
                default:
                    throw new ServerErrorException("Not supported exception");
            }
        }
    }
}
