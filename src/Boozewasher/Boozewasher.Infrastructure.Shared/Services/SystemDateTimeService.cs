using Boozewasher.Application.Interfaces.Shared;
using System;

namespace Boozewasher.Infrastructure.Shared.Services
{
    public class SystemDateTimeService : IDateTimeService
    {
        public DateTime NowUtc => DateTime.UtcNow;
    }
}