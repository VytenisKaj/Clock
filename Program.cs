using Clock;

public class Program
{

    private readonly CommandExecutor commandExecutor = new CommandExecutor();
    public void Run()
    {
        string? input;
        (int Return_code, string? Return_string) result;
        while (true)
        {
            Console.Write("Enter hours and minutes in format HH:mm for caltulation, enter \"help\" to see list of commands: ");
            input = Console.ReadLine();
            if (input != null)
            {
                result = commandExecutor.ExecuteCommand(input);
                if (result.Return_code == (int)ReturnCodes.Exit)
                {
                    break;
                }
                if(result.Return_code == (int)ReturnCodes.Not_found)
                {
                    Console.WriteLine($"{result.Return_string} is not a valid command");
                }
                if(result.Return_code == (int)ReturnCodes.Help)
                {
                    Console.WriteLine(result.Return_string);
                }
                if(result.Return_code == (int)ReturnCodes.Failure)
                {
                    Console.WriteLine(result.Return_string);
                }
                if(result.Return_code == (int)ReturnCodes.Success)
                {
                    Console.WriteLine($"Angle between clock hour and minute arms is {result.Return_string} degrees");
                }
            }
            else
            {
                Console.WriteLine("Nothing was inputted");
            }
        }
    }

    public static void Main()
    {
        Program p = new();
        p.Run();
    }
}
