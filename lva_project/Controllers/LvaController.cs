using lva_project.Models;
using lva_project.Services;
using Microsoft.AspNetCore.Mvc;

namespace lva_project.Controllers;

/// <summary>
/// API for a management system of Courses at university (LVAs)
/// </summary>
[ApiController]
[Route("[controller]")]
public class LvaController : Controller
{
    private readonly ILvaService _lvaService;

    public LvaController(ILvaService lvaService)
    {
        _lvaService = lvaService;
    }

    /// <summary>
    /// HttpGet: Returns a List of all LVAs
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public IActionResult GetAllLva()
    {
        var lvas = _lvaService.ReadAllLva();
        return Ok(lvas);
    }

    [HttpGet("semester/{id}")]
    public IActionResult GetLvaPerSemester([FromRoute] int id)
    {
        var lvasPerSem = _lvaService.ReadAllPerSemester(id);
        return Ok(lvasPerSem);
    }

    /// <summary>
    /// Returns the LVA with the specified ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public IActionResult GetLvaById([FromRoute] int id)
    {
        var lva = _lvaService.ReadLva(id);
        return Ok(lva);
    }

    /// <summary>
    /// Creates an LVA with the specified attributes
    /// </summary>
    /// <param name="lva"></param>
    /// <returns></returns>
    [HttpPost]
    public IActionResult CreateLva([FromBody] Lva lva)
    {
        _lvaService.CreateLva(lva);
        return Ok(new {message = "LVA created!"});
    }

    /// <summary>
    /// Updates an LVA with a specific ID with the specified Attributes
    /// </summary>
    /// <param name="id"></param>
    /// <param name="lva"></param>
    /// <returns></returns>
    [HttpPatch("{id}")]
    public IActionResult UpdateLva([FromRoute] int id, [FromBody] Lva lva)
    {
        _lvaService.UpdateLva(id, lva);
        return Ok(new {message = "LVA updated!"});
    }

    /// <summary>
    /// Deletes an LVA with the specified ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public IActionResult DeleteLva([FromRoute] int id)
    {
        _lvaService.DeleteLva(id);
        return Ok(new {message = "LVA deleted!"});
    }
}