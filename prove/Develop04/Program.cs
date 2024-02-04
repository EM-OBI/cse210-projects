// I exceeded the requirements by making the random questions and prompts didn't repeat until a full cycle had been completed through the available questions and prompts.
using System;

class Program
{
    static void Main(string[] args)
    {
        int option;
        string name;
        string description;
        do{
            Menu menu = new Menu();
            Console.WriteLine("Select a choice from the menu: ");
            option = int.Parse(Console.ReadLine());
            if (option == 1){
                name = "Breathing";
                description = "This activity will help you relax by walking you through the Belly Breathing exercise where you breathe in, hold that breath and breathe out. \nClear your mind and focus on your breathing.";
                BreathingActivity breathingActivity = new BreathingActivity(name, description);
                breathingActivity.DisplayStartingMessage();
                breathingActivity.Run();
                breathingActivity.DisplayEndingMessage();
            }
            else if (option == 2)
            {
                name = "Reflecting";
                description = "Thus activity will help you reflect on times in your life when you have shown strength and resilience. \nThis will help you recognize the power you have and how you can use it in other aspects of your life.";
                ReflectingActivity refletingActivity = new ReflectingActivity(name, description);
                refletingActivity.DisplayStartingMessage();
                refletingActivity.Run();
                refletingActivity.DisplayEndingMessage(); 
            }
            else if (option == 3)
            {
                name = "Listing";
                description = "This will help you reflect on the good things in your life by having you list as many things as you can in certain areas.";
                ListingActivity listingActivity = new ListingActivity(name, description);
                listingActivity.DisplayStartingMessage();
                listingActivity.Run();
                listingActivity.DisplayEndingMessage();
            }
            else if (option == 4)
            {
                break;
            }
            else 
            {
                Console.WriteLine("Choose valid option. Press enter to reselect."); 
                Console.ReadLine();
            }    
        } while (option != 4);
        
    }
}