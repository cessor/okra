using System;

namespace Seedling.Model.Time
{
    public interface IHaveGotTheTime
    {
        DateTime Now { get; }
    }
}