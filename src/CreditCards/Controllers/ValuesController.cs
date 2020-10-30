﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreditCards.Controllers
{
    [Route("api/[controller")]

    public class ValuesController : Controller
    {
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new[] { "value1", "value2" };
        }



        [HttpGet("{Id}")]
        public IActionResult Get(int id)
        {
            if(id < 1)
            {
                return BadRequest($"Invalid request for id {id}");
            }
            return Content($"Value {id}");
        }

        [HttpPost("StartJob")]
        public IActionResult StartJob()
        {
            return Ok(("Batch Job Started"));
        }
    }
}
