namespace Okra.Commands.Synchronize
{
    public interface IConvertToSyncTime
    {
        SyncTime FromJson(string json);
    }
}