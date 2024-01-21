using System.ComponentModel.DataAnnotations;

namespace Deneme.WebUI.Models
{
    public class ProductVM
    {
        public int Id { get; set; }

      
        public string Name { get; set; }

        public decimal? Price { get; set; }
        public IFormFile? File { get; set; }
    }
}
