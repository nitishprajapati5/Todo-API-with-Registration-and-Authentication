using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIServices.Models.Response
{
    public class TodoListResponse
    {
        public long Id { get; set; }
        public string? Title { get; set; }
        public string? Type { get; set; }
        public DateTime ExpiresAt { get; set; }
    }
}
