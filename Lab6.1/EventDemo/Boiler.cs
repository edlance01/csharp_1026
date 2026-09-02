namespace EventDemo
{
    // The delegate - what the method must look like
    public delegate void TemperatureHandler(string message);
    public class Boiler
    {
        //The event - uses the delegate to create a notification hook
        public event TemperatureHandler? OnCriticalTemp;

        public void HeatUp(int currentTemp)
        {
            Console.WriteLine($"Current temperature: {currentTemp}°C");
            if (currentTemp > 90)
            {
                OnCriticalTemp?.Invoke($"ALARM Critical temperature reached! {currentTemp}°C");
            }
        }
    }
}
