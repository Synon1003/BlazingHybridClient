using System.ComponentModel;
using BlazingHybridClient.Models;

namespace BlazingHybridClient;

public class AppState: INotifyPropertyChanged
{
    public Func<string?> QueryStringGetter { get; private set; }
    public Func<string?> AuthorizationHeaderValueGetter { get; private set; }
    public Func<List<KeyValueModel>> RequestHeadersValueGetter { get; private set; }
    public Func<string?> BodyValueGetter { get; private set; }

    public void SetQueryStringGetter(Func<string?> func) => QueryStringGetter = func;
    public void SetAuthorizationHeaderValueGetter(Func<string?> func) => AuthorizationHeaderValueGetter = func;
    public void SetRequestHeadersValueGetter(Func<List<KeyValueModel>> func) => RequestHeadersValueGetter = func;
    public void SetBodyValueGetter(Func<string?> func) => BodyValueGetter = func;
    private bool _showLoader;
    public bool ShowLoader
    {
        get { return _showLoader; }
        set 
        { 
            _showLoader = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ShowLoader)));
        }
    }
    
    public event EventHandler<RequestModel>? OnHistoryAdded;
    public event EventHandler? OnQueryStringParametersSet;
    public event EventHandler<string>? OnUrlPastedWithQueryString;
    public event PropertyChangedEventHandler? PropertyChanged;
    public void NotifyHistoryAdded(RequestModel requestModel) =>
        OnHistoryAdded?.Invoke(this, requestModel);
    public void NotifyQueryStringParametersSet() =>
        OnQueryStringParametersSet?.Invoke(this, EventArgs.Empty);
    public void NotifyUrlPastedWithQueryString(string queryString) =>
        OnUrlPastedWithQueryString?.Invoke(this, queryString);
}