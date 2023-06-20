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
public class CommentController : ControllerBase
{
    private readonly TestReactContext _context;
    private readonly ICommentService _commentService;

    /// <summary>
    /// Initialize services
    /// </summary>
    /// <param name="context"></param>
    /// <param name="commentService"></param>
    public CommentController(TestReactContext context, ICommentService commentService)
    {
        _context = context;
        _commentService = commentService;
    }

    /// <summary>
    /// Create a comment
    /// </summary>
    /// <param name="newComment"></param>
    /// <returns>Comments</returns>
    [HttpPost]
    [Route("add")]
    public IActionResult AddComment([FromBody] Comment newComment)
    {
        Article article = _context.Articles
            .FirstOrDefault(x => x.Id == newComment.Article);

        if (article == null)
        {
            return NotFound(new { message = "L'article n'existe pas." });
        } 

        _commentService.AddComment(newComment);
        
        return Created("/comment/" + newComment.Id, newComment);
    }
}