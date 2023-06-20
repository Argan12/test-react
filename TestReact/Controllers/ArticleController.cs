using Microsoft.AspNetCore.Mvc;
using TestReact.Models.Entities;
using TestReact.Models.Interfaces;

namespace TestReact.Controllers;

/// <summary>
/// UserController
/// Manage users
/// </summary>
[ApiController]
[Route("[controller]")]
public class ArticleController : ControllerBase
{
    private readonly IArticleService _articleService;

    public ArticleController(IArticleService articleService)
    {
        _articleService = articleService;
    }

    [HttpPost]
    [Route("create")]
    public IActionResult Create([FromBody] Article article)
    {
        Article newArticle = _articleService.Create(article);

        return Created("/article/" + newArticle.Id, newArticle);
    }
}