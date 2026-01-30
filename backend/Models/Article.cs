using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models;

public class Article
{
    [Key]
    public int ArticleId { get; set; }
    public string? Headline { get; set; }
    
    public string? Author { get; set; }

    public DateTime DatePublished { get; set; }
    public string? Content { get; set; }
}
