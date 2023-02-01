using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FoodCatergoryWeb.Models;

public class Catergory
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string? Name { get; set; }
    [DisplayName("Display")]
    [Range(1,100,ErrorMessage ="Display Order Must Be Between 1 and 100 only")]
    public int Display { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;

}
