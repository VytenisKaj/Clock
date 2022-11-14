
namespace Clock
{
    internal class CalculateAngleCommand : ICommand
    {
        public string? Execute(string[] args)
        {

            if(args.Length > 1)
            {
                return null;
            }
            try {
                string[] hoursAndMins = args[0].Split(':');
                double hours = Int32.Parse(hoursAndMins[0].Trim()); // Automatically converts to double for calculations. Checking if it is an integer
                double minutes = Int32.Parse(hoursAndMins[1].Trim());
                if(hours < 0 || hours > 23)
                {
                    return $"{hours} is not a valid hour. enter number between 0 and 23";
                }
                if (minutes < 0 || minutes > 59)
                {
                    return $"{minutes} is not a valid amount minutes. Enter number between 0 and 59";
                }
                if (hours > 12)
                {
                    hours -= 12;
                }

                double hourArmAngle = hours * 30 + minutes/60 * 30;
                double minuteArmAngle = minutes * 6;

                double angle = Math.Abs(minuteArmAngle - hourArmAngle);

                angle = angle > 180 ? 360 - angle : angle;

                return angle.ToString();
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
            
        }
    }
}
