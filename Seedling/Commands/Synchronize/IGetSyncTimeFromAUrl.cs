namespace Seedling.Commands.Synchronize
{
    public interface IGetSyncTimeFromAUrl
    {
        SyncTime From(string url);
    }
}