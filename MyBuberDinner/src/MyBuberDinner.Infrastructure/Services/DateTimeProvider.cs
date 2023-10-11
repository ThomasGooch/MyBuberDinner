using MyBuberDinner.Application.Common.Interfaces.Services;

namespace MyBuberDinner.Infrastructure.Services;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}
