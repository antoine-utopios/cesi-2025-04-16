﻿namespace DogAPI.DTOs
{
    public class EditDogRequestPayload
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Breed { get; set; }
        public int Age { get; set; }
    }
}
