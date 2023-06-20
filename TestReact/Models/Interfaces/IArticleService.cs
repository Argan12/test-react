using TestReact.Models.Entities;
using TestReact.Models.StoredProcedures;

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

    /// <summary>
    /// Get all articles
    /// </summary>
    /// <returns>Articles</returns>
    List<GetAllArticles> GetAllArticles();
}