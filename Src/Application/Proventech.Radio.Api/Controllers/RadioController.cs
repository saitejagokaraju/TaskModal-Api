using Microsoft.AspNetCore.Mvc;
using Proventech.Radio.Core.Contracts.IRepositories;
using System.Collections.Generic;
using System.Threading.Tasks;

// Specifies that the class is an API controller and defines the route for API requests.
[ApiController]
[Route("api/[controller]")]
public class RadioController : ControllerBase
{
    // Private field to hold an instance of the repository interface.
    private readonly IRepositoryRadio _radioRepository;

    // Constructor that initializes the controller with a repository instance.
    public RadioController(IRepositoryRadio radioRepository)
    {
        _radioRepository = radioRepository;
    }

    // Endpoint to retrieve all dates asynchronously from the repository.
    [HttpGet("dates")]
    public async Task<IActionResult> GetDates()
    {
        // Calls the repository method to get all dates asynchronously.
        var dates = await _radioRepository.GetAllDatesAsync();

        // Returns an OK response with the retrieved dates.
        return Ok(dates);
    }

    // Endpoint to retrieve all weekdays asynchronously from the repository.
    [HttpGet("weekdays")]
    public async Task<IActionResult> GetWeekdays()
    {
        // Calls the repository method to get all weekdays asynchronously.
        var weekdays = await _radioRepository.GetAllWeekdaysAsync();

        // Returns an OK response with the retrieved weekdays.
        return Ok(weekdays);
    }
}
