// To exceed requirements, I included a delete option in order to delete a journal file. I also included exception handling logic to catch an errors while loading or deleting files.
using System.IO;

public class Journal 
{
    public List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }

    public void DisplayAll()
    {
        foreach (Entry entry in _entries)
        {
            entry.Display();
            Console.WriteLine();
        }
    }

    public void SaveToFile(string myJournalFileName)
    {
        using (StreamWriter outputFile = new StreamWriter(myJournalFileName))
        {       
            foreach (Entry entry in _entries)
            {
                outputFile.WriteLine($"{entry._promptText} || {entry._entryText} || {entry._date}");
            }
        }
    }

    public void LoadFromFile(string myJournalFileName)
    {
        try
        {
            if (File.Exists(myJournalFileName))
            {
                string[] lines = System.IO.File.ReadAllLines(myJournalFileName);
                foreach (string line in lines)
                {
                    Console.WriteLine(line);
                }
            }
            else 
            {
                Console.WriteLine($"File '{myJournalFileName}' does not exist or has been deleted."); 
            }
        }
        catch (Exception ex)
        {
             Console.WriteLine($"An error occured: {ex.Message}");
        }
    }

    public void DeleteFile(string myJournalFileName)
    {
        try 
        {
            if (File.Exists(myJournalFileName))
            {
                File.Delete(myJournalFileName);
                Console.WriteLine($"{myJournalFileName} deleted successfully!");
            }
            else
            {
                Console.WriteLine($"File '{myJournalFileName}' does not exist.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occured: {ex.Message}");
        }
    }
}