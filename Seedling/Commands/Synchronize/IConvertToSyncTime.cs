namespace Seedling.Commands.Synchronize
{
    public interface IConvertToSyncTime
    {
        SyncTime FromJson(string json);
    }
}