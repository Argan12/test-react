using Microsoft.AspNetCore.Http;
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
    private readonly TestReactContext _context;
    private readonly IArticleService _articleService;
    private readonly IJwtService _jwtService;

    /// <summary>
    /// Initialize service
    /// </summary>
    /// <param name="articleService"></param>
    public ArticleController(TestReactContext context, IArticleService articleService, IJwtService jwtService)
    {
        _context = context;
        _articleService = articleService;
        _jwtService = jwtService;
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

    /// <summary>
    /// Edit article
    /// </summary>
    /// <param name="updatedArticle"></param>
    /// <returns>Updated article</returns>
    [Authorize]
    [HttpPatch]
    [Route("edit")]
    public IActionResult EditArticle([FromBody] Article updatedArticle)
    {
        Article article = _context.Articles.FirstOrDefault(x => x.Id == updatedArticle.Id);

        if (article == null)
        {
            return NotFound(new { message = "L'article n'existe pas." });
        }

        // Parse jwt to check if connected user is the author of the article
        var jwt = _jwtService.ParseJwt(HttpContext.Request.Headers["Authorization"][0].Split(" ")[1]);

        if (article.Author.Trim() != jwt["id"].ToString().Trim())
        {
            return Forbid();
        }

        // Update article
        article.Title = updatedArticle.Title;
        article.Content = updatedArticle.Content;
        _context.SaveChanges();

        return Ok(updatedArticle);
    }
}