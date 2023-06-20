using TestReact.Models.Entities;

namespace TestReact.Models.Interfaces;

/// <summary>
/// Manage all articles
/// </summary>
public interface IArticleService
{
    /// <summary>
    /// Create an article
    /// </summary>
    /// <param name="article"></param>
    /// <returns></returns>
    Article Create(Article article);
}