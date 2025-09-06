namespace Meetopia.Domain.Activities.Entities;

public class Activity
{
    public string Id { get; set; } = Guid.NewGuid().ToString();

    public required string Title { get; set; }

    // Should use UTC
    public DateTime Date { get; set; }

    public required string Description { get; set; }

    public required string Category { get; set; }

    public bool IsCancelled { get; set; }

    public required string City { get; set; }
    public required string Venue { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }

    public void UpdateFrom(Activity activity)
    {
        ArgumentNullException.ThrowIfNull(activity);

        Title = activity.Title;
        Date = activity.Date;
        Description = activity.Description;
        Category = activity.Category;
        City = activity.City;
        Venue = activity.Venue;
        IsCancelled = activity.IsCancelled;
        Latitude = activity.Latitude;
        Longitude = activity.Longitude;
    }
}