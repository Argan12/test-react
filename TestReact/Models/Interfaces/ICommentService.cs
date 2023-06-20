using TestReact.Models.Entities;

namespace TestReact.Models.Interfaces;

/// <summary>
/// Manage comments
/// </summary>
public interface ICommentService
{
    /// <summary>
    /// Create a comment
    /// </summary>
    /// <param name="comment"></param>
    /// <returns>Comment</returns>
    void AddComment(Comment comment);
}