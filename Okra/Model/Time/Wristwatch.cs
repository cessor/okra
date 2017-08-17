using System;

namespace Okra.Model.Time
{
    public class Wristwatch : IHaveGotTheTime
    {
        #region IHaveGotTheTime Members

        public DateTime Now
        {
            get { return DateTime.Now; }
        }

        #endregion
    }
}