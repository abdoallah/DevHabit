namespace DevHabit.Api.Entities
{
    public sealed class Habit
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public HabitType Type { get; set; } = HabitType.None;
        public Frequancy Frequancy { get; set; } = new Frequancy { Type = FrequancyType.None, TimesPerPeriod = 0 };
        public Target Target { get; set; }
        public HabitStatus Status { get; set; } = HabitStatus.None;
        public bool IsArchived { get; set; }
        public DateOnly? EndDate { get; set; }
        public Milesyone? Milesyone { get; set; }
        public DateTime CreartedAtUtc { get; set; }
        public DateTime? UpdatedAtUtc { get; set; }
        public DateTime? LastCompletedAtUtc { get; set; }

    }
}

public enum HabitStatus
{
    None = 0,
    Ongoing = 1,
    Completed = 2,
}
public enum HabitType
{
    None = 0,
    Binary = 1,
    Measurable = 2,
}

public sealed class Frequancy : Audit
{
    public FrequancyType Type { get; set; }
    public int TimesPerPeriod { get; set; }
}

public enum FrequancyType
{
    None = 0,
    Daily = 1,
    Weekly = 2,
    Monthly = 3,
}
public sealed class Target : Audit
{
    public int Value { get; set; }
    public string Unit { get; set; }
}

public sealed class Milesyone : Audit
{
    public Target Target { get; set; }
    public int Current { get; set; }

}

public class Audit
{
    public int Id { get; set; }
    public DateTime CreatedAtUtc { get; set; }
    public DateTime? UpdatedAtUtc { get; set; }
    public DateTime? LastCompletedAtUtc { get; set; }
}
