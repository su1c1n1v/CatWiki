using System.Text.Json.Serialization;

namespace CatWiki.Models
{
    public class ImageViewModel
    {
        public string id { get; set; }
        public string url { get; set; }
        public Breed[] breeds { get; set; }
        public int width { get; set; }
        public int height { get; set; }
    }

}
