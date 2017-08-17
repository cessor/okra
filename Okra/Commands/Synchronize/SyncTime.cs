using System;
using Newtonsoft.Json;
using Okra.Readability;

namespace Okra.Commands.Synchronize
{
    public class SyncTime : IConvertToSyncTime
    {
        public TimeSpan Duration { get; set; }
        public DateTime Start { get; set; }
        public DateTime Now { get; set; }
        public bool Running { get; set; }

        public TimeSpan TimeLeft
        {
            get
            {
                TimeSpan timePassed = (Now - Start);
                return (Duration - timePassed).ToTheSecond();
            }
        }

        #region IConvertToSyncTime Members

        public SyncTime FromJson(string json)
        {
            return JsonConvert.DeserializeObject<SyncTime>(json);
        }

        #endregion
    }
}