using System;

namespace Okra.Model.Time
{
    public interface IHaveGotTheTime
    {
        DateTime Now { get; }
    }
}