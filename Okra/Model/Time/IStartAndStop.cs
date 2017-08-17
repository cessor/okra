using System;

namespace Okra.Model.Time
{
    public interface IStartAndStop
    {
        Action Tick { get; set; }
        void Start();
        void Stop();
    }
}