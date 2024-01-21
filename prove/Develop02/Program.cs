using System;

class Program
{
    static void Main(string[] args)
    {
        int response;
        Journal myJournal = new Journal();
        do
        {
            Console.WriteLine("What would you like to do today? \n1. Write \n2. Display \n3. Load \n4. Save \n5. Delete \n6. Quit");
            response = int.Parse(Console.ReadLine());
            
            if (response == 1)
            {
                Entry newEntry = new Entry();
                PromptGenerator promptGenerator = new PromptGenerator();
                newEntry._promptText = promptGenerator.GetRandomPrompt();
                Console.WriteLine(newEntry._promptText);
                Console.Write("> ");
                newEntry._entryText = Console.ReadLine();
                DateTime theCurrentTime = DateTime.Now;
                string dateText = theCurrentTime.ToShortDateString();
                newEntry._date = dateText;
                myJournal.AddEntry(newEntry);
                newEntry.Display(); 
            }

            else if (response == 2)
            {
               myJournal.DisplayAll();
            }

            else if (response == 3)
            {
               Console.WriteLine("Enter a name of the file you want to load: ");
               string myJournalFileName = Console.ReadLine();
               myJournal.LoadFromFile(myJournalFileName);               

            }

            else if (response == 4)
            {
                Console.WriteLine("Enter a name you'd like to call your file: ");
                string myJournalFileName = Console.ReadLine();
                myJournal.SaveToFile(myJournalFileName);
            }

            else if (response == 5)
            {
                Console.WriteLine("Enter the name of the file you'd like to delete: ");
                string myJournalFileName = Console.ReadLine();
                myJournal.DeleteFile(myJournalFileName);
            }

        } while (response != 6);
    }
}