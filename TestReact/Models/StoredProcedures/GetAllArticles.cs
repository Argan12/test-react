using System.Text.Json.Serialization;

namespace TestReact.Models.StoredProcedures;

public class GetAllArticles
{
    [JsonPropertyName("articleId")]
    public int article_id { get; set; }

    public string title { get; set; }

    public string content { get; set; }

    [JsonPropertyName("userId")]
    public string user_id { get; set; }

    public string pseudo { get; set; }
    
    public DateTime date { get; set; }
}