using Backend.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GoodsController : ControllerBase
    {
        private readonly ILogger<GoodsController> _logger;

        public GoodsController(ILogger<GoodsController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetGoods")]
        public IEnumerable<Goods> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new Goods
            {
                ItemId = index,
                ProductName = "product_"+index,
                UnitPrice = 0,
                Inventory = 3
            })
            .ToArray();
        }
    }
}