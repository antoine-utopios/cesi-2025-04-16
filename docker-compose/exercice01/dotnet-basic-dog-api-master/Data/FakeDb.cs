using DogAPI.Entities;

namespace DogAPI.Data
{
    public class FakeDb
    {
        public List<Dog> Dogs { get; set; }

        public FakeDb()
        {
            Dogs = new List<Dog>
            {
                new Dog { Id = 1, Name = "Buddy", Breed = "Golden Retriever", Age = 3 },
                new Dog { Id = 2, Name = "Max", Breed = "Bulldog", Age = 5 },
                new Dog { Id = 3, Name = "Bella", Breed = "Labrador", Age = 2 }
            };
        }

        public List<Dog> GetAllDogs()
        {
            return Dogs;
        }

        public Dog GetDogById(int id)
        {
            return Dogs.FirstOrDefault(d => d.Id == id);
        }

        public bool ExistsById(int id)
        {
            return Dogs.Any(d => d.Id == id);
        }

        public void AddDog(Dog dog)
        {
            dog.Id = Dogs.Max(d => d.Id) + 1;
            Dogs.Add(dog);
        }

        public void UpdateDog(Dog dog)
        {
            var existingDog = Dogs.FirstOrDefault(d => d.Id == dog.Id);
            if (existingDog != null)
            {
                existingDog.Name = dog.Name;
                existingDog.Breed = dog.Breed;
                existingDog.Age = dog.Age;
            }
        }

        public void DeleteDog(int id)
        {
            var dog = Dogs.FirstOrDefault(d => d.Id == id);
            if (dog != null)
            {
                Dogs.Remove(dog);
            }
        }

    }
}
