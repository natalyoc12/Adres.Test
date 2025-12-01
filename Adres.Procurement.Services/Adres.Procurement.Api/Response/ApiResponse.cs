using System.Net;

namespace Adres.Procurement.Api.Response;

public class ApiResponse<T>(HttpStatusCode code, string message, T? data = default)
{
    public HttpStatusCode Code { get; set; } = code;
    public string Message { get; set; } = message;
    public T? Data { get; set; } = data;
}
