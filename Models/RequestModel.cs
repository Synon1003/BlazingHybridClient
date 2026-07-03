using System.Text.Json;
using BlazingHybridClient.Data;

namespace BlazingHybridClient.Models;

public class RequestModel
{
    public int Id {get;set;}
    public DateTime At { get; set; }
    public string Method { get; set; }
    public string Url { get; set; }
    
    public List<KeyValueModel> QueryParameters {get; set;} = [];
    public string? AuthHeaderValue {get; set;}
    public List<KeyValueModel> Headers {get;set;} = [];
    public string? Body {get;set;}

    public RequestHistory ToEntity()
    {
        var entity = new RequestHistory
        {
            At = At,
            Method = Method,
            Url = Url,
            AuthHeaderValue = AuthHeaderValue,
            Body = Body,
            QueryString = QueryParameters.Any() ? JsonSerializer.Serialize(QueryParameters) : null,
            Headers = Headers.Any() ? JsonSerializer.Serialize(Headers) : null
        };

        return entity;
    }

    public static RequestModel FromEntity(RequestHistory entity)
    {
        var model = new RequestModel
        {
            Id = entity.Id,
            At = entity.At,
            Method = entity.Method,
            Url = entity.Url,
            AuthHeaderValue = entity.AuthHeaderValue,
            Body = entity.Body,
            QueryParameters = !string.IsNullOrWhiteSpace(entity.QueryString)
                ? JsonSerializer.Deserialize<List<KeyValueModel>>(entity.QueryString)!
                : [],
            Headers = !string.IsNullOrWhiteSpace(entity.Headers)
                ? JsonSerializer.Deserialize<List<KeyValueModel>>(entity.Headers)!
                : []
        };

        return model;
    }
}