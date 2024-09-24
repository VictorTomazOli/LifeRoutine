using System.Text.Json.Serialization;

namespace LifeRoutine.Domain.Response;

public class Response<TData>
{
    [JsonConstructor]
    public Response(TData? data, int code = 200, string? message=null)
    {
        Data = data;
        StatusCode = code;
        Message = message;
    }
    private int StatusCode { get; set; }
    public TData? Data { get; set; }
    public string? Message { get; set; }

    [JsonIgnore]
    public bool IsSuccess => StatusCode is >= 200 and <= 299;
}