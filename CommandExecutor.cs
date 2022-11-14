
namespace Clock
{
    public class CommandExecutor
    {
        readonly HelpCommand helpCommand = new();
        readonly CalculateAngleCommand calculateAngleCommand = new();

        public (int Return_code, string? Return_string) ExecuteCommand(string command)
        {
            string[] commandArgs = command.Trim().Split(' ');
            string? commandExecuteResult;
            if(commandArgs[0].Trim().ToLower() == "exit")
            {
                return (Return_code: (int)ReturnCodes.Exit, Return_string: "");
            }
            if(commandArgs[0].Trim().ToLower() == "help")
            {
                commandExecuteResult = helpCommand.Execute(commandArgs);
                return commandExecuteResult != null ? (Return_code: (int)ReturnCodes.Help, Return_string: commandExecuteResult) : (Return_code: (int)ReturnCodes.Not_found, Return_string: command);
            }
            if (commandArgs[0].Trim().Contains(':')){
                commandExecuteResult = calculateAngleCommand.Execute(commandArgs);
                return Double.TryParse(commandExecuteResult, out _) ? (Return_code: (int)ReturnCodes.Success, Return_string: commandExecuteResult) : (Return_code: (int)ReturnCodes.Failure, Return_string: commandExecuteResult);
            }
            return (Return_code: (int)ReturnCodes.Not_found, Return_string: command);
           
        }
    }
}
