using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TQSSandwichSystem
{
  public static class InitialiseMenuItems
  {
    public static bool Initialised { get; set; } = false;
    public static string MenuItemsJson { get; set; } = string.Empty;
    public static bool Initialise()
    {
      try
      {
        List<MenuItems> menuItemsList = new List<MenuItems>();

        menuItemsList.Add(SetBuildYourBreakFast());
        menuItemsList.Add(SetBreakfastSandwiches());
        menuItemsList.Add(SetSmallBreakfasts());
        menuItemsList.Add(SetBreakfastBoxes());
        menuItemsList.Add(SetBreakfastWraps());
        menuItemsList.Add(SetSignatureSandwiches());
        menuItemsList.Add(SetColdSandwichSelection());
        menuItemsList.Add(SetPaninisAndToasties());
        menuItemsList.Add(SetOvenBakedPotatoes());
        menuItemsList.Add(SetSaladBoxes());
        menuItemsList.Add(SetDerbyshireOatcakes());
        menuItemsList.Add(SetDoubleSandwichedOatcakes());
        menuItemsList.Add(SetPiesAndSausageRolls());
        menuItemsList.Add(SetChips());
        menuItemsList.Add(SetCakes());
        menuItemsList.Add(SetCrisps());
        menuItemsList.Add(SetConfectioneries());
        menuItemsList.Add(SetColdDrinks());
        menuItemsList.Add(SetHotDrinks());

        MenuItemsJson = JsonConvert.SerializeObject(menuItemsList);
        if (string.IsNullOrEmpty(MenuItemsJson)) { Initialised = false; return false; }
        Initialised = true;
        return true;
      }
      catch
      {
        MenuItemsJson = string.Empty;
        Initialised = false;
        return false;
      }
    }
    public static MenuItems SetBuildYourBreakFast()
    {
      MenuItems buildYourBreakfast = new MenuItems()
      {
        Category = "Build Your Breakfast",
        Items = new List<MenuItem>()
        {
          new MenuItem()
          {
            Name = "Prime Back Bacon",
            Price = 0.50m
          },
          new MenuItem()
          {
            Name = "Premium Pork Sausage",
            Price = 0.50m
          },
          new MenuItem()
          {
            Name = "Fried Egg",
            Price = 0.50m
          },
          new MenuItem()
          {
            Name = "Plum Tomatoes",
            Price = 0.50m
          },
          new MenuItem()
          {
            Name = "Heinz Beans",
            Price = 0.50m
          },
          new MenuItem()
          {
            Name = "Black Pudding",
            Price = 0.50m
          },
          new MenuItem()
          {
            Name = "Hash Brown",
            Price = 0.50m
          },
          new MenuItem()
          {
            Name = "Mushrooms",
            Price = 0.50m
          },
          new MenuItem()
          {
            Name = "Slice of Toast",
            Price = 0.50m
          },
          new MenuItem()
          {
            Name = "Bread & Spread",
            Price = 0.50m
          },
          new MenuItem()
          {
            Name = "Beans on Toast",
            Price = 2.20m
          },
          new MenuItem()
          {
            Name = "2 Scrambled Eggs on Toast",
            Price = 2.20m
          },
          new MenuItem()
          {
            Name = "Cheesy Beans on Toast",
            Price = 2.20m
          }
        },
        Description = "All above are served in trays with disposable cutlery"
      };

      return buildYourBreakfast;
    }
    public static MenuItems SetBreakfastSandwiches()
    {
      MenuItems breakfastSandwiches = new MenuItems()
      {
        Category = "Breakfast Sandwiches",
        Items = new List<MenuItem>()
        {
          new MenuItem()
          {
            Name = "2 Slices Prime Back Bacon",
            Price = 2.50M,
            Description = "Served on a white or Granary Bap, Toasted Bread or Bread & Spread.",
          },
          new MenuItem()
          {
            Name = "2 Premium Pork Sausages",
            Price = 2.50M,
            Description = "Served on a white or Granary Bap, Toasted Bread or Bread & Spread.",
          },
          new MenuItem()
          {
            Name = "2 Fried Eggs",
            Price = 2.50M,
            Description = "Served on a white or Granary Bap, Toasted Bread or Bread & Spread.",
          },
          new MenuItem()
          {
            Name = "3 Slices Prime Back Bacon",
            Price = 3.30M,
            Description = "Served on a white or Granary Vienna.",
          },
          new MenuItem()
          {
            Name = "3 Premium Sausages",
            Price = 3.30M,
            Description = "Served on a white or Granary Vienna.",
          },
        }
      };

      return breakfastSandwiches;
    }
    public static MenuItems SetSmallBreakfasts()
    {
      MenuItems smallBreakfasts = new MenuItems()
      {
        Category = "Small Breakfast",
        Items = new List<MenuItem>()
        {
          new MenuItem()
          {
            Name = "1 Bacon, 1 Sausage, Egg, Beans, Toast.",
            Price = 2.50m,
          }
        }
      };

      return smallBreakfasts;
    }
    public static MenuItems SetBreakfastBoxes()
    {
      MenuItems breakfastBoxes = new MenuItems()
      {
        Category = "Breakfast Box",
        Items = new List<MenuItem>()
        {
          new MenuItem()
          {
            Name = "2 Bacon, 2 Sausage, Egg, Black Pudding, Beans, Plum Tomatoes, Hash Brown, 2 Slices Toast.",
            Price = 5.50m
          }
        }
      };

      return breakfastBoxes;
    }
    public static MenuItems SetBreakfastWraps()
    {
      MenuItems breakfastWraps = new MenuItems()
      {
        Category = "Breakfast Wrap",
        Items = new List<MenuItem>()
        {
          new MenuItem()
          {
            Name = "2 Bacon, 2 Sausage, 2 Hash Brown, Cheese.",
            Price = 4.00m,
          }
        }
      };

      return breakfastWraps;
    }
    public static MenuItems SetSignatureSandwiches()
    {
      MenuItems signitureSandwiches = new MenuItems()
      {
        Category = "Signature Sandwiches",
        Items = new List<MenuItem>()
        {
          new MenuItem()
          {
            Name = "Breakfast Club",
            Price = 4.00m,
            Description = "3 Slices of toast filled with Bacon, Egg, Sausages & Cheese.",
          },
          new MenuItem()
          {
            Name = "Toasted Club",
            Price = 4.00m,
            Description = "3 Slices of toast filled with Lettuce, Tomato, Chicken, Bacon & Mayo.",
          },
          new MenuItem()
          {
            Name = "Steak Canadian",
            Price = 4.50m,
            Description = "Served with mushrooms & onions on a Vienna.",
          }
        }
      };

      return signitureSandwiches;
    }
    public static MenuItems SetColdSandwichSelection()
    {
      MenuItems coldMenuItems = new MenuItems()
      {
        Category = "Cold Sandwich Selection",
        Items= new List<MenuItem>()
        {
          new MenuItem()
          {
            Name = "Roasted Top Side of Beef",
            Price = 3.00m,
          },
          new MenuItem()
          {
            Name = "Roasted Gammon Ham",
            Price = 3.00m,
          },
          new MenuItem()
          {
            Name = "Roasted Chicken Breast",
            Price = 3.00m,
          },
          new MenuItem()
          {
            Name = "Egg Mayo & Cress",
            Price = 3.00m,
          },
          new MenuItem()
          {
            Name = "Cheese & Onion Mix",
            Price = 3.00m,
          },
          new MenuItem()
          {
            Name = "Tuna Mayo",
            Price = 3.00m,
          },
          new MenuItem()
          {
            Name = "Prawn in Marie Roase with Lettuce",
            Price = 3.00m,
          }
        },
        Description = "All of the above are served on White or Granary Bap with Salad."
      };

      return coldMenuItems;
    }
    public static MenuItems SetPaninisAndToasties()
    {
      MenuItems paninisAndToasties = new MenuItems()
      {
        Category = "Paninis & Toasties",
        Items = new List<MenuItem>()
        {
          new MenuItem()
          {
            Name = "Cheese & Ham",
            Price = 3.00m,
            Description = "Served on a thick sliced toast Bacon, Lettuce, Tomato & Mayo."
          },
          new MenuItem()
          {
            Name = "Cheese & Onion",
            Price = 3.00m,
            Description = "Served on a thick sliced toast Bacon, Lettuce, Tomato & Mayo."
          },
          new MenuItem()
          {
            Name = "Cheese & Tomato",
            Price = 3.00m,
            Description = "Served on a thick sliced toast Bacon, Lettuce, Tomato & Mayo."
          },
          new MenuItem()
          {
            Name = "BLT (Bacon, Lettuce & Tomato)",
            Price = 3.00m,
            Description = "Served on a thick sliced toast Bacon, Lettuce, Tomato & Mayo."
          },
          new MenuItem()
          {
            Name = "Tuna Melt",
            Price = 4.00m,
            Description = "Tuna Mayo, Diced Peppers & Onion"
          },
          new MenuItem()
          {
            Name = "Major League Melt",
            Price = 4.00m,
            Description = "2 Sausage, Cheese, Onions & Mushroms"
          },
          new MenuItem()
          {
            Name = "B.E.S.T",
            Price = 4.00m,
            Description = "Bacon, Egg, Sausage & Fresh Tomato"
          },
          new MenuItem()
          {
            Name = "Salt & Pepper Chicken",
            Price = 4.00m,
            Description = "Served with Peppers & Onions."
          },
        },
      };

      return paninisAndToasties;
    }
    public static MenuItems SetOvenBakedPotatoes()
    {
      MenuItems ovenBakedPotatoes = new MenuItems()
      {
        Category = "Oven Baked Potatoes",
        Items = new List<MenuItem>()
        {
          new MenuItem()
          {
            Name = "Plain With Butter",
            Price = 2.00m,
          },
          new MenuItem()
          {
            Name = "Chilli",
            Price = 3.00m,
          },
          new MenuItem()
          {
            Name = "Cheese",
            Price = 2.50m,
          },
          new MenuItem()
          {
            Name = "Tuna Mayo",
            Price = 3.00m,
          },
          new MenuItem()
          {
            Name = "Prawn in Marie Rose Sauce",
            Price = 3.00m,
          },
        },
        Description = "All of the above Served in a Tray with Salad"
      };
      return ovenBakedPotatoes;
    }
    public static MenuItems SetSaladBoxes()
    {
      MenuItems saladBoxes = new MenuItems()
      {
        Category = "Salad Boxes",
        Items = new List<MenuItem>()
        {
          new MenuItem()
          {
            Name = "Roasted Top Side of Beef",
            Price = 4.00m,
          },
          new MenuItem()
          {
            Name = "Roasted Gammon Ham",
            Price = 4.00m,
          },
          new MenuItem()
          {
            Name = "Roasted Chicken Breast",
            Price = 4.00m,
          },
          new MenuItem()
          {
            Name = "Tuna Mayo",
            Price = 4.00m,
          },
          new MenuItem()
          {
            Name = "Prawn in Marie Rose with Lettuce",
            Price = 4.00m,
          }
        },
        Description = "All of the above are served with Salad Leaves, Tomatoes, Cucumber, Red Onion, Sweetcorn & Coleslaw"
      };

      return saladBoxes;
    }
    public static MenuItems SetDerbyshireOatcakes()
    {
      MenuItems derbyshireOatcakes = new MenuItems()
      {
        Category = "Derbyshire Oatcakes",
        Items = new List<MenuItem>()
        {
          new MenuItem()
          {
            Name = "Plain with Butter Rolled",
            Price = 1.00m
          },
          new MenuItem()
          {
            Name = "Cheese & Bacon",
            Price = 2.00m
          },
          new MenuItem()
          {
            Name = "Cheese & Onion",
            Price = 2.00m
          }
        }
      };

      return derbyshireOatcakes;
    }
    public static MenuItems SetDoubleSandwichedOatcakes()
    {
      MenuItems doubleSandwichedOatcakes = new MenuItems()
      {
        Category = "Double Sandwiched Oatcakes",
        Items = new List<MenuItem>()
        {
          new MenuItem()
          {
            Name = "Cheese, Bacon & Mushrooms",
            Price = 3.00m
          },
          new MenuItem()
          {
            Name = "Bacon, Egg & Tomatoes",
            Price = 3.00m
          }
        }
      };

      return doubleSandwichedOatcakes;
    }
    public static MenuItems SetPiesAndSausageRolls()
    {
      MenuItems piesAndSausageRolls = new MenuItems()
      {
        Category = "Pies & Sausage Rolls",
        Items = new List<MenuItem>()
        {
          new MenuItem()
          {
            Name = "Steak & Kidney",
            Price = 1.80m
          },
          new MenuItem()
          {
            Name = "Meat & Potato",
            Price = 1.80m
          },
          new MenuItem()
          {
            Name = "Cheese & Onion",
            Price = 1.80m
          },
          new MenuItem()
          {
            Name = "Cornish Pasties",
            Price = 1.80m
          },
          new MenuItem()
          {
            Name = "Large Sausagee Roll",
            Price = 1.50m
          },
        }
      };

      return piesAndSausageRolls;
    }
    public static MenuItems SetChips()
    {
      MenuItems chips = new MenuItems()
      {
        Category = "Chips",
        Items = new List<MenuItem>()
        {
          new MenuItem()
          {
            Name = "Chips",
            Price = 2.00m
          },
          new MenuItem()
          {
            Name = "Chips & Gravy",
            Price = 2.80m
          },
          new MenuItem()
          {
            Name = "Chips & Cheese",
            Price = 2.80m
          },
          new MenuItem()
          {
            Name = "Chip Bap",
            Price = 2.20m
          },
          new MenuItem()
          {
            Name = "Soup",
            Price = 1.50m
          },
        }
      };

      return chips;
    }
    public static MenuItems SetCakes()
    {
      MenuItems cakes = new MenuItems()
      {
        Category = "Cakes",
        Items = new List<MenuItem>()
        {
          new MenuItem()
          {
            Name = "Chocolate Brownie",
            Price = 1.50m
          },
          new MenuItem()
          {
            Name = "Millionaire Shortcake",
            Price = 1.50m
          },
          new MenuItem()
          {
            Name = "Almond Slice",
            Price = 1.50m
          },
          new MenuItem()
          {
            Name = "Flap Jacks",
            Price = 1.50m
          }
        }
      };

      return cakes;
    }
    public static MenuItems SetCrisps()
    {
      MenuItems crisps = new MenuItems()
      {
        Category = "Crisps",
        Items = new List<MenuItem>()
        {
          new MenuItem()
          {
            Name = "Ready Salted",
            Price = 0.75m
          },
          new MenuItem()
          {
            Name = "Salt & Vinegar",
            Price = 0.75m
          },
          new MenuItem()
          {
            Name = "Cheese & Onion",
            Price = 0.75m
          }
        }
      };

      return crisps;
    }
    public static MenuItems SetConfectioneries()
    {
      MenuItems confectionaries = new MenuItems()
      {
        Category = "Confectionery",
        Items = new List<MenuItem>()
        {
          new MenuItem()
          {
            Name = "Mars Bar",
            Price = 0.80m
          },
          new MenuItem()
          {
            Name = "Snickers",
            Price = 0.80m
          },
          new MenuItem()
          {
            Name = "Kit Kat",
            Price = 0.80m
          },
          new MenuItem()
          {
            Name = "Twix",
            Price = 0.80m
          }
        }
      };

      return confectionaries;
    }
    public static MenuItems SetColdDrinks()
    {
      MenuItems coldDrinks = new MenuItems()
      {
        Category = "Cold Drinks",
        Items= new List<MenuItem>()
        {
          new MenuItem()
          {
            Name = "Various",
            Price = 1.00m,
            Description = "Various"
          }
        },
        Description = "Various Bottles and Cans from £1.00"
      };

      return coldDrinks;
    }
    public static MenuItems SetHotDrinks()
    {
      MenuItems hotDrinks = new MenuItems()
      {
        Category = "Hot Drinks",
        Items = new List<MenuItem>()
        {
          new MenuItem()
          {
            Name = "Yorkshire Tea",
            Price = 1.00m,
          },
          new MenuItem()
          {
            Name = "Nescafe",
            Price = 1.20m,
          },
          new MenuItem()
          {
            Name = "Hot Chocolate",
            Price = 1.20m,
          }
        }
      };

      return hotDrinks;
    }
  }
}
