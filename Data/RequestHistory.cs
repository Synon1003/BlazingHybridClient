using SQLite;

namespace BlazingHybridClient.Data;

public class RequestHistory
{
    [PrimaryKey, AutoIncrement]
    public int Id {get;set;}
    public DateTime At { get; set; }
    public string Method { get; set; }
    public string Url { get; set; }

    public string? QueryString {get; set;}
    public string? AuthHeaderValue {get; set;}
    public string? Headers {get;set;}
    public string? Body {get;set;}
}