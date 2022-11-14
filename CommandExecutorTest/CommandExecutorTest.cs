using Clock;
using Xunit;

namespace CommandExecutorTest
{
    public class CommandExecutorTest
    {
        [Theory]
        [InlineData("exit")]
        [InlineData("    exit     ")]
        [InlineData("ExIt")]
        public void ExecuteCommand_ExitCommandGiven_ShouldReturnReturnCodesExit(string command)
        {
            CommandExecutor commandExecutor = new CommandExecutor();

            (int Return_code, string? Return_string) actual = commandExecutor.ExecuteCommand(command);

            Assert.Equal((int)ReturnCodes.Exit, actual.Return_code);
        }

        [Theory]
        [InlineData("bad command")]
        [InlineData("")]
        public void ExecuteCommand_NotValidCommandGiven_ShouldReturnReturnCodesNotFound(string command)
        {
            CommandExecutor commandExecutor = new CommandExecutor();

            (int Return_code, string? Return_string) actual = commandExecutor.ExecuteCommand(command);

            Assert.Equal((int)ReturnCodes.Not_found, actual.Return_code);
        }

        [Theory]
        [InlineData("bad command")]
        [InlineData("")]
        public void ExecuteCommand_NotValidCommandGiven_ShouldReturnCommandInStringType(string command)
        {
            CommandExecutor commandExecutor = new CommandExecutor();

            (int Return_code, string? Return_string) actual = commandExecutor.ExecuteCommand(command);

            Assert.Equal(command, actual.Return_string);
        }

        [Theory]
        [InlineData("help")]
        [InlineData("    Help   ")]
        [InlineData("hElp")]
        public void ExecuteCommand_HelpCommandGiven_ShouldReturnReturnCodesHelp(string command)
        {
            CommandExecutor commandExecutor = new CommandExecutor();

            (int Return_code, string? Return_string) actual = commandExecutor.ExecuteCommand(command);

            Assert.Equal((int)ReturnCodes.Help, actual.Return_code);
        }

        [Theory]
        [InlineData("help")]
        [InlineData("    Help   ")]
        [InlineData("hElp")]
        public void ExecuteCommand_HelpCommandGiven_ShouldReturnHelpInStringType(string command)
        {
            CommandExecutor commandExecutor = new CommandExecutor();
            string helpStringExpected = "List of commands:\n"
                                +"HH:mm -> where HH is hours and mm is minutes returns lesser angle between arms of analog clock\n"
                                +"help -> returns this list of all commands\n"
                                +"exit -> exits the program\n";

            (int Return_code, string? Return_string) actual = commandExecutor.ExecuteCommand(command);

            Assert.Equal(helpStringExpected, actual.Return_string);
        }


        [Theory]
        [InlineData("6:15")]
        [InlineData("18:0")]
        public void ExecuteCommand_ValidTimeGiven_ShouldReturnReturnTypeSuccess(string command)
        {
            CommandExecutor commandExecutor = new CommandExecutor();

            (int Return_code, string? Return_string) actual = commandExecutor.ExecuteCommand(command);

            Assert.Equal((int)ReturnCodes.Success, actual.Return_code);
        }

        [Theory]
        [InlineData("25:15")]
        [InlineData("-18:0")]
        [InlineData(" 60:   -30")]
        [InlineData("24:60")]
        [InlineData("a:60")]
        [InlineData("24:b")]
        [InlineData("a:b")]
        [InlineData(":")]
        public void ExecuteCommand_NotValidTimeGiven_ShouldReturnReturnTypeFailure(string command)
        {
            CommandExecutor commandExecutor = new CommandExecutor();

            (int Return_code, string? Return_string) actual = commandExecutor.ExecuteCommand(command);

            Assert.Equal((int)ReturnCodes.Failure, actual.Return_code);
        }

        [Theory]
        [InlineData("4:45", "127,5")]
        [InlineData("04:45", "127,5")]
        [InlineData("4:045", "127,5")]
        [InlineData("00:00", "0")]
        [InlineData("12:00", "0")]
        [InlineData("03:00", "90")]
        [InlineData("15:00", "90")]
        [InlineData("06:00", "180")]
        [InlineData("18:00", "180")]
        [InlineData("09:00", "90")]
        [InlineData("21:00", "90")]
        [InlineData("16:40", "100")]
        [InlineData("3:30", "75")]
        [InlineData("3:50", "175")]
        [InlineData("8:45", "7,5")]
        [InlineData("10:43", "63,5")]
        public void ExecuteCommand_ValidTimeGiven_ShouldReturnLesserAngleBetweenArms(string command, string expected)
        {
            CommandExecutor commandExecutor = new CommandExecutor();

            (int Return_code, string? Return_string) actual = commandExecutor.ExecuteCommand(command);

            Assert.Equal(expected, actual.Return_string);
        }

        [Theory]
        [InlineData("-1:45", -1)]
        [InlineData("24:45", 24)]
        public void ExecuteCommand_NotValidTimeGiven_ShouldReturnStringMessageSayingHoursNotValid(string command, int hours)
        {
            CommandExecutor commandExecutor = new CommandExecutor();

            (int Return_code, string? Return_string) actual = commandExecutor.ExecuteCommand(command);

            Assert.Equal($"{hours} is not a valid hour. enter number between 0 and 23", actual.Return_string);
        }


        [Theory]
        [InlineData("0:-1", -1)]
        [InlineData("0:60", 60)]
        public void ExecuteCommand_NotValidTimeGiven_ShouldReturnStringMessageSayingMinutesNotValid(string command, int minutes)
        {
            CommandExecutor commandExecutor = new CommandExecutor();

            (int Return_code, string? Return_string) actual = commandExecutor.ExecuteCommand(command);

            Assert.Equal($"{minutes} is not a valid amount minutes. Enter number between 0 and 59", actual.Return_string);
        }

    }
}