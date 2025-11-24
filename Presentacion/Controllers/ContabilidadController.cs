using Microsoft.AspNetCore.Mvc;
using RRHH.Core.Models;
using System.Text;
using System.Text.Json;

[Route("api/[controller]")]
[ApiController]
public class ContabilidadController : ControllerBase
{
    private readonly HttpClient _http;

    public ContabilidadController(HttpClient http)
    {
        _http = http;
        _http.BaseAddress = new Uri("https://contabilidad-production-8be2.up.railway.app/");
    }

    [HttpPost("contabilidad/santa-cruz/pagos/")]
    public async Task<IActionResult> RealizarPago([FromBody] PagoRequest pagoRequest)
    {
        // Validar el modelo de datos
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        // Serializar el objeto PagoRequest a JSON
        var jsonContent = new StringContent(JsonSerializer.Serialize(pagoRequest), Encoding.UTF8, "application/json");

        // Definir la URL del endpoint externo
        var url = $"api/Contabilidad/pagos/"; // Cambiar según el endpoint correcto

        try
        {
            // Hacer la solicitud POST al endpoint externo
            var response = await _http.PostAsync(url, jsonContent);

            // Si la respuesta es exitosa
            if (response.IsSuccessStatusCode)
            {
                var res = await response.Content.ReadAsStringAsync();
                var data = JsonSerializer.Deserialize<object>(res);
                return Ok(data);
            }

            // Si la respuesta no es exitosa
            return StatusCode((int)response.StatusCode, "Error al procesar el pago.");
        }
        catch (Exception ex)
        {
            // Si ocurre un error al hacer la solicitud
            return StatusCode(500, $"Error al realizar la solicitud: {ex.Message}");
        }
    }
}
