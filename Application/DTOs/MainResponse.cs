using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class MainResponse
    {
        public bool IsSuccess { get; set; } = false;
        public List<string> Messages { get; set; } = new List<string>();
        public object? Data { get; set; }
    }
}
