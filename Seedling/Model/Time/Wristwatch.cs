using System;

namespace Seedling.Model.Time
{
    public class Wristwatch : IHaveGotTheTime
    {
        public DateTime Now
        {
            get { return DateTime.Now; }
        }
    }
}