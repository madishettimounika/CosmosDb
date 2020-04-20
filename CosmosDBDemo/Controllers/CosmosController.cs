using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CosmosDBDemo.DataAccess;
using CosmosDBDemo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CosmosDBDemo.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    [Route("[controller]")]
    public class CosmosController : ControllerBase
    {
        /// <summary>
        /// </summary>
        ICosmosDataAdapter _adapter;
        public CosmosController(ICosmosDataAdapter adapter)
        {
            _adapter = adapter;
        }

        // GET: api/Cosmos/5
        [HttpGet("createdb")]
        public async Task<IActionResult> CreateDatabase()
        {
            var result = await _adapter.CreateDatabase("test-db-three");
            return Ok(result);
        }

        [HttpGet("createcollection")]
        public async Task<IActionResult> CreateCollection()
        {
            var result = await _adapter.CreateCollection("test-db-three", "test-collection-three");
            return Ok(result);
        }

        [HttpPost("createdocument")]
        public async Task<IActionResult> CreateDocument([FromBody] UserInfo user)
        {
            var result = await _adapter.CreateDocument("test-db-three", "test-collection-three", user);
            return Ok(result);
        }

        [HttpPost("placeorder")]
        public async Task<IActionResult> Post([FromBody] Order order)
        {
            var result = await _adapter.PlaceOrder("test-db-three", "test-collection-three", order);
            return Ok();
        }
        [HttpGet("get")]
        public async Task<IActionResult> Get()
        {
            var result = await _adapter.GetData("test-db-three", "test-collection-three");
            return Ok(result);
        }

        // POST: api/Cosmos
        [HttpPost("save")]
        public async Task<IActionResult> Post([FromBody] UserInfo user)
        {
            var result = await _adapter.UpsertUserAsync(user);
            return Ok();
        }

        // PUT: api/Cosmos/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var result = await _adapter.DeleteUserAsync("test-db-three", "test-collection-three", id);
            return Ok(result);
        }
    }
}
