using Seedling.Commands.Synchronize;

namespace Seedling.Tests.IntegrationTests
{
    public class UrlProvider : IAskForAUrl
    {
        #region IAskForAUrl Members

        public string AskForUrl()
        {
            return "http://cessor.de/okra.json";
        }

        #endregion
    }
}