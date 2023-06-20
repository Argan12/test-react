using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using TestReact.Models.Entities;
using TestReact.Models.Interfaces;
using TestReact.Models.StoredProcedures;

namespace TestReact.Models.Services;

/// <summary>
/// Manage all articles
/// </summary>
public class ArticleService : IArticleService
{
    private readonly TestReactContext _context;
    private readonly StoredProceduresContext _storedProceduresContext;

    /// <summary>
    /// Initialize services
    /// </summary>
    /// <param name="context">dbContext</param>
    public ArticleService(TestReactContext context, StoredProceduresContext storedProceduresContext)
    {
        _context = context;
        _storedProceduresContext = storedProceduresContext;
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
            article.Date = DateTime.Now;
            _context.Add(article);
            _context.SaveChanges();

            return article;
        }
        catch (ArgumentException e)
        {
            throw new ArgumentException("Error during creating an article.", e);
        }
    }

    /// <summary>
    /// Get all articles
    /// </summary>
    /// <returns>Articles</returns>
    public List<GetAllArticles> GetAllArticles()
    {
        try
        {
            return _storedProceduresContext.GetAllArticles
                .FromSqlRaw<GetAllArticles>("EXEC GetAllArticles")
                .ToList();
        }
        catch (ArgumentException e)
        {
            throw new ArgumentException("Unable to get all articles.", e);
        }
    }
}