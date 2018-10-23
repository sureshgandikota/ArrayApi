using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArrayApi.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ArrayApi.Controllers
{
    [Produces("application/json")]
    [Route("api/ArrayCalc")]
    public class ArrayCalcController : ControllerBase
    {
        private readonly ILogger<ArrayCalcController> _logger;

        public ArrayCalcController(ILogger<ArrayCalcController> logger)
        {
            _logger = logger;
        }

        // GET: api/ArrayCalc
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new int[] { 1,2,3,4,5});
        }

        // GET: api/ArrayCalc/Reverse
        [HttpGet("Reverse")]
        public IActionResult Reverse([FromQuery(Name ="productIds")]int[] productIds)
        {
            try
            {
                return Ok(ArrayService<int>.Reverse(productIds));
            }
            catch(Exception e)
            {
                _logger.LogError(e.Message);
                return BadRequest(e.Message);
            }
        }

        [HttpGet("DeletePart")]
        public IActionResult DeletePart([FromQuery(Name ="position")]int position ,[FromQuery(Name = "productIds")]int[] productIds)
        {
            try
            {
                return Ok(ArrayService<int>.DeletePart(position, productIds));
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return BadRequest(e.Message);
            }
        }

    }
}
