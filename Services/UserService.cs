using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using PruebaFront.DTOs;

namespace PruebaFront.Services
{
    public class UserService
    {
        private readonly HttpClient _httpClient;

        public UserService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // Obtener todos los usuarios
        public async Task<List<UserResponseDTO>> GetAllUsers()
        {
            var response = await _httpClient.GetFromJsonAsync<List<UserResponseDTO>>("api/users");
            return response;
        }

        // Crear un nuevo usuario
        public async Task CreateUser(UserDTO user)
        {
            await _httpClient.PostAsJsonAsync("api/users", user);
        }

        // Actualizar un usuario
        public async Task UpdateUser(int id, UserDTO user)
        {
            await _httpClient.PutAsJsonAsync($"api/users/{id}", user);
        }

        // Eliminar un usuario
        public async Task DeleteUser(int id)
        {
            await _httpClient.DeleteAsync($"api/users/{id}");
        }
    }
}
