using DevHabit.Api.Database;
using Microsoft.AspNetCore.Mvc;

namespace DevHabit.Api.Controllers
{
    [ApiController]
    [Route("Habits")]
    public sealed class HabitsController(ApplicationDBContext dBContext) : ControllerBase
    {
        [HttpGet]

        public async Task<IActionResult> GetHabits()
        {
            var habits = dBContext.Habits.ToList();
            return Ok(habits);
        }
    }
}
