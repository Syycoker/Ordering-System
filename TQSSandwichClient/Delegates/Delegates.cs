using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TQSSandwichClient.Enumerations;

namespace TQSSandwichClient.Delegates
{
  public delegate void MenuItemModified(MenuItemAction action, string name, decimal price, int amount);
  public delegate void OrderRequestSent(object? obj);
}
