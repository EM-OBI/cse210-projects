using System.Runtime.CompilerServices;

public class Menu
{
    private List<string> _menuItems;
    public Menu()
    {
        Console.Clear();
        _menuItems = new List<string>();
        GetMenuItems();
        DisplayMenuItems();
    }
    public List<string> GetMenuItems()
    {
        _menuItems.Add("1. Start breathing activity");
        _menuItems.Add("2. Start reflecting activity");
        _menuItems.Add("3. Start listing activity");
        _menuItems.Add("4. Quit");
        return _menuItems;
    }
    public void DisplayMenuItems()
    {
        Console.WriteLine("Menu Options:");
        foreach (string item in _menuItems)
        {
            Console.WriteLine(item);
        }
    
    }
}