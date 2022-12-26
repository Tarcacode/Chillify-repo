namespace Chillify.Blaz.Shared.Models;

public class ServiceResponse<T>
{
    public T? Data { get; set; }
    public string? Message { get; set; }
    public bool Success { get; set; } = true;

}
