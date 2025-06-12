namespace TheWeatherApp.Models
{
    public class ObjectMessage
    {
        public bool IsFromAndroid { get; set; }
        public object Message { get; set; }
        public string Sender { get; set; }
        public object Value { get; set; }
    }
}
