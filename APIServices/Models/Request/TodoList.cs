using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIServices.Models.Request
{
    public class TodoList
    {
        public long Id { get; set; }
        public long userId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime ExpiresAt { get; set; }
        public string? Type { get; set; }
        public string? Tag { get; set; }
        public string? Priority { get; set; }
    }
}
