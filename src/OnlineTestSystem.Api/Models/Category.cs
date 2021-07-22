using System.Collections.Generic;

namespace OnlineTestSystem.Api.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }

        public ICollection<Test> Tests { get; set; }
    }
}
