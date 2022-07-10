using NodaTime;

namespace EFCoreDemo.Services;

public interface IClockService
{
    Instant Now { get; }
}

public class ClockService : IClockService
{
    private readonly IClock _clock;

    public ClockService() : this(SystemClock.Instance) {}
    public ClockService(IClock clock)
    {
        _clock = clock;
    }

    public Instant Now => _clock.GetCurrentInstant();
}