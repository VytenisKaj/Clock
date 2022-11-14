
namespace Clock
{
    internal class HelpCommand : ICommand
    {
        private string helpString = "List of commands:\n"
                                + "HH:mm -> where HH is hours and mm is minutes returns lesser angle between arms of analog clock\n"
                                + "help -> returns this list of all commands\n"
                                + "exit -> exits the program\n";
        public string? Execute(string[] args)
        {
            return args.Length == 1 ? helpString : null;
        }
    }
}
