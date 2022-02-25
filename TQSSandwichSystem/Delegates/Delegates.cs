using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TQSSandwichSystem.Enumerations;

namespace TQSSandwichSystem.Delegates
{
  public delegate void MenuItemModified(MenuItemAction action, string name, decimal price, int amount);
  public delegate void OrderRequestSent(object? obj);
}
