using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace RoleMenecment.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    [Authorize(Policy = "Permission:Permission.Create")]
    [HttpPost("create")]
    public IActionResult Create() => Ok("Product created");

    [Authorize(Policy = "Permission:Permission.Update")]
    [HttpPut("update")]
    public IActionResult Update() => Ok("Product updated");

    [Authorize(Policy = "Permission:Permission.View")]
    [HttpGet("view")]
    public IActionResult View() => Ok("Product details");
}

