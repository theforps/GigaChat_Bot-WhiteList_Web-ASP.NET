using System.ComponentModel.DataAnnotations;

namespace WhiteList_Web.Models;

public class History
{

    [Key]
    public int Id { get; set; }
    public string? Role { get; set; }
    public string? Message { get; set; }
    public User? User { get; set; }
}