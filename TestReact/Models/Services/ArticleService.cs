using System;
using TestReact.Models.Entities;
using TestReact.Models.Interfaces;

namespace TestReact.Models.Services;

/// <summary>
/// Manage all articles
/// </summary>
public class ArticleService : IArticleService
{
    private readonly TestReactContext _context;

    /// <summary>
    /// Initialize services
    /// </summary>
    /// <param name="context">dbContext</param>
    public ArticleService(TestReactContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create an article
    /// </summary>
    /// <param name="article"></param>
    /// <returns></returns>
    public Article Create(Article article)
    {
        try
        {
            _context.Add(article);
            _context.SaveChanges();

            return article;
        }
        catch (ArgumentException e)
        {
            throw new ArgumentException("Error during creating an article.", e);
        }
    }
}