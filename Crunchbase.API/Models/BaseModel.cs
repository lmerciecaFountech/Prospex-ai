using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crunchbase.API.Models
{
    internal class BaseModel 
    {
        public int CreatedAt { get; set; }
        public int UpdatedAt { get; set; }
    }
}