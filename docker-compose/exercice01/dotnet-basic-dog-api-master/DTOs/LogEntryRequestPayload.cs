namespace DogAPI.DTOs
{
    public class LogEntryRequestPayload
    {
        public string Message { get; set; }
        public string Source { get; set; }
        public string Level { get; set; }
    }
}
