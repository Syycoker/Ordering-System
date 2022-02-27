using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TQSSandwichSystem
{
  public class MenuItem
  {
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; } = 0.00m;
    public string? Description { get; set; }
  }
}
