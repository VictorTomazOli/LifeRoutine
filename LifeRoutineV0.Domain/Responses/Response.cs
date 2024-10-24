using LifeRoutineV0.Domain.Enums;
using System.Text.Json.Serialization;

namespace LifeRoutineV0.Domain.Responses;

public class Response<TData>
{
    public Response()
    {
        StatusCode = EStatusCode.Ok;
    }

    public Response(TData? data, EStatusCode code = EStatusCode.Ok, string? message = null)
    {
        Data = data;
        StatusCode = code;
        Message = message;
    }

    public TData? Data { get; set; }
    public EStatusCode StatusCode { get; set; }
    public string? Message { get; set; }
    [JsonIgnore]
    public bool IsSuccess => (int)StatusCode is >= 200 and <= 299;
}