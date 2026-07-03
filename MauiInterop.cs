namespace BlazingHybridClient;

public class MauiInterop
{
    public static async Task ShowAlertAsync(string message, string? title = "Alert")
        => await App.Current.MainPage.DisplayAlertAsync(title, message, "OK");

    public static async Task<bool> ConfirmAsync(string message, string? title = "Confirm")
        => await App.Current.MainPage.DisplayAlertAsync(title, message, "Yes", "No");
}