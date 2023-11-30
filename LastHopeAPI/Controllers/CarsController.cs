using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LastHopeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly CarDbContext carDbContext;

        public CarsController(CarDbContext carDbContext)
        {
            this.carDbContext = carDbContext;
        }
        [HttpGet]
        public IActionResult GetCars()
        {
            var res = carDbContext.Cars.ToList();
            return Ok(res);
        }
        [HttpPost]
        public IActionResult CreateCar(Car car)
        {
            carDbContext.Cars.Add(car);
            carDbContext.SaveChanges();
            return Ok(car);
        }
    }
}
