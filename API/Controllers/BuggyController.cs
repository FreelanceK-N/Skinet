using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Errors;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class BuggyController : BaseApiController
    {

        private readonly StoreContext _context;
        public BuggyController(StoreContext context)
        {
            _context = context;
        }

        [HttpGet("not-found")]
        public ActionResult GetNotFoundRequest()
        {
            var product = _context.Products.Find(42);

            if(product == null)
            {
                return NotFound(new ApiResponse(404));
            }
            return Ok();
        }

        [HttpGet("server-error")]
        public ActionResult GetServerErrorRequest()
        {
            var product = _context.Products.Find(42);

            var productToReturn = product.ToString();

            return Ok();
        }

        [HttpGet("bad-request")]
        public ActionResult GetBadRequest()
        {
            return BadRequest(new ApiResponse(400));
        }

        [HttpGet("bad-request/{id}")]
        public ActionResult GetBadRequestValidation(int id)
        {
            return Ok();
        }
    }
}