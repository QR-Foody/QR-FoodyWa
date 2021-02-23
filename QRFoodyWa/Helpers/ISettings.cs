namespace QRFoodyWa.Helpers
{
    public interface ISettings
    {
        string GetStorageTablePrimaryConnectionString();
        string GetStorageTableSecondaryConnectionString();
        string GetApiKey();
        string GetApplicationName();
    }
}