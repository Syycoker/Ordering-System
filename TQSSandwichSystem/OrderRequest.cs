using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Security.Principal;
using TQSSandwichSystem.Enumerations;

namespace TQSSandwichSystem
{
  public class OrderRequest
  {
    public MenuItemAction Action { get; set; } = MenuItemAction.NONE;
    public string User { get; init; } = WindowsIdentity.GetCurrent().Name;
    public DateTime OrderTime { get; init; } = DateTime.UtcNow;
    public List<string>? OrderItems { get; set; } = null;
    public string? DietaryRequirement { get; set; } = string.Empty;

    public OrderRequest(MenuItemAction action, List<string> order, string dietaryRequirements = "")
    {
      Action = action;
      OrderItems = order;
      DietaryRequirement = dietaryRequirements;
    }
  }
}
