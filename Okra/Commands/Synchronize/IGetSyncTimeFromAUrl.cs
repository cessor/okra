namespace Okra.Commands.Synchronize
{
    public interface IGetSyncTimeFromAUrl
    {
        SyncTime From(string url);
    }
}