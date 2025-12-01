using System.Net;
using Adres.Procurement.Api.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi;

namespace Adres.Procurement.Api.Controllers;

public class CustomControllerBase : ControllerBase
{
    public ActionResult<ApiResponse<T>> OkResponse<T>(T? dto)
    {
        return base.Ok(CreateResponse(HttpStatusCode.OK, dto));
    }

    public ActionResult<ApiResponse<T>> CreatedResponse<T>(string actionName, object? routeValues, T? dto)
    {
        return base.CreatedAtAction(actionName, routeValues, CreateResponse(HttpStatusCode.Created, dto));
    }

    private static ApiResponse<T> CreateResponse<T>(HttpStatusCode statusCode, T? dto)
    {
        return new ApiResponse<T>(statusCode, statusCode.GetDisplayName(), dto);
    }
}
