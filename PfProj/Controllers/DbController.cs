namespace WebApi.Controllers;

using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PfProj.Models.DataModels;
using PfProj.Services;

[ApiController]
[Route("[controller]")]
public class DataModelsController : ControllerBase
{
    private ISharedService _ModelService;
    private IMapper _mapper;

    public DataModelsController(
        ISharedService ModelService,
        IMapper mapper)
    {
        _ModelService = ModelService;
        _mapper = mapper;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var models = _ModelService.GetAll();
        return Ok(models);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var models = _ModelService.GetById(id);
        return Ok(models);
    }

    [HttpPost]
    public IActionResult Create(CreateRequest model)
    {
        _ModelService.Create(model);
        return Ok(new { message = "Created Model" });
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, UpdateRequest model)
    {
        _ModelService.Update(id, model);
        return Ok(new { message = "Updated" });
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _ModelService.Delete(id);
        return Ok(new { message = "Deleted" });
    }
}