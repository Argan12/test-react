using System;
using TestReact.Models.Entities;
using TestReact.Models.Interfaces;

namespace TestReact.Models.Services;

/// <summary>
/// Manage comments
/// </summary>
public class CommentService : ICommentService
{
    private readonly TestReactContext _context;

    /// <summary>
    /// Initialize services
    /// </summary>
    /// <param name="context"></param>
    public CommentService(TestReactContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create a comment
    /// </summary>
    /// <param name="comment"></param>
    public void AddComment(Comment comment)
    {
        try
        {
            comment.Date = DateTime.Now;
            
            _context.Add(comment);
            _context.SaveChanges();
        }
        catch (ArgumentException e)
        {
            throw new ArgumentException("Error during publishing a comment.", e);
        }
    }
}