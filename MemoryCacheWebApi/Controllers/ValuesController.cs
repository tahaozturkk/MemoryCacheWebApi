using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace MemoryCacheWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IMemoryCache _memoryCache;
        public ValuesController(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<string> Values = new();
            Values = _memoryCache.Get<List<string>>("Values");

            if (Values is null)
            {
                Values = new()
            {
                "MemoryCacheTest1",
                "MemoryCacheTest2",
                "MemoryCacheTest3",
                "MemoryCacheTest4",
                "MemoryCacheTest5",
                "MemoryCacheTest6",
            };
                Thread.Sleep(3000);
                _memoryCache.Set("Values", Values, TimeSpan.FromSeconds(10));
            }

            return Ok(Values);
        }
    }
}
