using System;

namespace Okra.Model.Time
{
    public class Wristwatch : IHaveGotTheTime
    {
        public DateTime Now
        {
            get { return DateTime.Now; }
        }
    }
}