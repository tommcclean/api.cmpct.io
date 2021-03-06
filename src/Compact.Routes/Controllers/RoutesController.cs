﻿using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Compact.Routes
{
    [ApiController]
    public class RoutesController : ControllerBase
    {
        private readonly IRoutesReader _routesReader;
        private readonly IRoutesWriter _routesWriter;

        public RoutesController(
            IRoutesReader routesReader,
            IRoutesWriter routesWriter)
        {
            _routesReader = routesReader;
            _routesWriter = routesWriter;
        }

        /// <summary>
        /// Get details about a specific route
        /// </summary>
        [HttpGet("/api/routes/{routeId}")]
        [ProducesResponseType(typeof(Route), 200)]
        public async Task<ActionResult<IEnumerable<string>>> GetAsync(string routeId)
        {
            var response = await _routesReader.GetAsync(routeId);

            if (response == null)
            {
                return NotFound();
            }

            return Ok(response);
        }

        /// <summary>
        /// Create a new route
        /// </summary>
        /// <param name="request"></param>
        [HttpPost("/api/routes")]
        [ProducesResponseType(204)]
        public async Task<ActionResult> PostAsync(PostRouteRequestModel request)
        {
            if (!request.Links.Any())
            {
                return BadRequest("No links were provided, at least one must link must be specified");
            }

            await _routesWriter.CreateAsync(request.RouteId, request.Links);

            return NoContent();
        }
    }
}