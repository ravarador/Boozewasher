using System;

namespace Boozewasher.Application.Interfaces.Shared
{
    public interface IDateTimeService
    {
        DateTime NowUtc { get; }
    }
}