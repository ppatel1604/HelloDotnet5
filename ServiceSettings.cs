namespace HelloDotnet5
{
    public class ServiceSettings
    {
        public string OpenWeatherHost { get; set; }
        public string ApiKey { get; set; }
        public string EndPoint { get; set; }

        public string WeatherHostUrl(){
            return $"https://{OpenWeatherHost}{EndPoint}?appid={ApiKey}";
        }
    }
}