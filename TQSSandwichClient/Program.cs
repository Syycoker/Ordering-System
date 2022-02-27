using TQSSandwichSystem;

namespace TQSSandwichClient
{
  internal static class Program
  {
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
      ApplicationConfiguration.Initialize();
      InitialiseMenuItems.Initialise();
      if (!InitialiseMenuItems.Initialised) { MessageBox.Show("The Menu Items are not available.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
      Application.Run(new ClientForm());
    }
  }
}