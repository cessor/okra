using Okra.Commands.Synchronize;

namespace Okra.Tests.IntegrationTests
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