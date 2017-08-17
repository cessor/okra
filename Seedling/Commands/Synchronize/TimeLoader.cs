namespace Seedling.Commands.Synchronize
{
    public class TimeLoader : IGetSyncTimeFromAUrl
    {
        private readonly IConvertToSyncTime _convert;
        private readonly IGet _web;

        public TimeLoader(IGet web, IConvertToSyncTime convert)
        {
            _web = web;
            _convert = convert;
        }

        #region IGetSyncTimeFromAUrl Members

        public SyncTime From(string url)
        {
            return _convert.FromJson(_web.Get(url));
        }

        #endregion
    }
}