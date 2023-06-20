using Microsoft.AspNetCore.Mvc;
using TestReact.Helpers;
using TestReact.Models.Entities;
using TestReact.Models.Interfaces;
using TestReact.Models.StoredProcedures;

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

    /// <summary>
    /// Initialize service
    /// </summary>
    /// <param name="articleService"></param>
    public ArticleController(IArticleService articleService)
    {
        _articleService = articleService;
    }

    /// <summary>
    /// Create article
    /// </summary>
    /// <param name="article"></param>
    /// <returns>Article</returns>
    [Authorize]
    [HttpPost]
    [Route("create")]
    public IActionResult Create([FromBody] Article article)
    {
        Article newArticle = _articleService.Create(article);

        return Created("/article/" + newArticle.Id, newArticle);
    }

    /// <summary>
    /// Get all articles
    /// </summary>
    /// <returns>List of articles</returns>
    [HttpGet]
    [Route("all")]
    public IActionResult GetAllArticles()
    {
        List<GetAllArticles> articles = _articleService.GetAllArticles();
        return Ok(articles);
    }
}