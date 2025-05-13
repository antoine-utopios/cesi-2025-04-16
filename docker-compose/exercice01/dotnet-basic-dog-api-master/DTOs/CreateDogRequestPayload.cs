namespace DogAPI.DTOs
{
    public class CreateDogRequestPayload
    {
        public string Name { get; set; }
        public string Breed { get; set; }
        public int Age { get; set; }
    }
}