using DogAPI.Data;
using DogAPI.DTOs;
using DogAPI.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using static System.Net.Mime.MediaTypeNames;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DogAPI.Controllers
{
    [Route("api/v1/dogs")]
    [ApiController]
    public class DogController : ControllerBase
    {
        private readonly string _logApiUrl;
        private readonly HttpClient _httpClient;
        private readonly JsonSerializerOptions  _jsonSerializerOptions;
        private readonly FakeDb _fakeDb;

        public DogController(HttpClient httpClient, FakeDb fakeDb)
        {
            _httpClient = httpClient;
            _fakeDb = fakeDb;
            _jsonSerializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
            _logApiUrl = Environment.GetEnvironmentVariable("LOG_API_URL") ?? "http://localhost:3000/api/v1/logs";
        }

        // GET: api/v1/dogs
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var body = new LogEntryRequestPayload
            {
                Message = "Dogs list accessed",
                Source = "DogAPI",
                Level = "info"
            };

            var httpContent = new StringContent(JsonSerializer.Serialize(body, _jsonSerializerOptions), System.Text.Encoding.UTF8, Application.Json);

            await _httpClient.PostAsync(_logApiUrl, httpContent);

            return Ok(_fakeDb.GetAllDogs());
        }

        // GET: api/v1/dogs/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var body = new LogEntryRequestPayload
            {
                Message = "Dog by id accessed",
                Source = "DogAPI",
                Level = "info"
            };

            var httpContent = new StringContent(JsonSerializer.Serialize(body, _jsonSerializerOptions), System.Text.Encoding.UTF8, Application.Json);

            await _httpClient.PostAsync(_logApiUrl, httpContent);

            var dog = _fakeDb.GetDogById(id);
            if (dog == null)
            {
                body = new LogEntryRequestPayload
                {
                    Message = $"Cannot find a dog with id: {id}",
                    Source = "DogAPI",
                    Level = "warn"
                };

                httpContent = new StringContent(JsonSerializer.Serialize(body, _jsonSerializerOptions), System.Text.Encoding.UTF8, Application.Json);

                await _httpClient.PostAsync(_logApiUrl, httpContent);
                return NotFound();
            }
            return Ok(dog);
        }

        // POST: api/v1/dogs
        [HttpPost]
        public IActionResult Post([FromBody] CreateDogRequestPayload payload)
        {

            var dog = new Dog
            {
                Name = payload.Name,
                Breed = payload.Breed,
                Age = payload.Age
            };

            _fakeDb.AddDog(dog);

            return CreatedAtAction(nameof(Get), new { id = dog.Id }, dog);
        }

        // PUT: api/v1/dogs/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] EditDogRequestPayload payload)
        {
            if (_fakeDb.ExistsById(id) == false)
            {
                return NotFound();
            }

            var dog = new Dog
            {
                Id = id,
                Name = payload.Name,
                Breed = payload.Breed,
                Age = payload.Age
            };
            
            _fakeDb.UpdateDog(dog);

            return NoContent();
        }

        // DELETE: api/v1/dogs/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (_fakeDb.ExistsById(id))
            {
                return NotFound();
            }

            _fakeDb.DeleteDog(id);

            return NoContent();
        }
    }
}
