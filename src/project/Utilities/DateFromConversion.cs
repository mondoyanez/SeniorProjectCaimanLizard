namespace WatchParty.Utilities;
public class DateFromConversion
{
    public string ConvertDate(DateTime datePosted, DateTime currentTime)
    {
        string dateString = string.Empty;

        if (datePosted.AddSeconds(10) > currentTime)
        {
            dateString = "just now";
        }
        else if (datePosted.AddMinutes(1) > currentTime)
        {
            int numSeconds = (currentTime - datePosted).Seconds;
            dateString = $"{numSeconds} seconds ago";
        }
        else if (datePosted.AddHours(1) > currentTime)
        {
            if (datePosted.AddMinutes(2) > currentTime)
            {
                dateString = "1 minute ago";
            }
            else
            {
                int numMinutes = (currentTime - datePosted).Minutes;
                dateString = $"{numMinutes} minutes ago";
            }
        }
        else if (datePosted.AddDays(1) > currentTime)
        {
            if (datePosted.AddHours(2) > currentTime)
            {
                dateString = "1 hour ago";
            }
            else
            {
                int numHours = (currentTime - datePosted).Hours;
                dateString = $"{numHours} hours ago";
            }
        }
        else if (datePosted.AddMonths(1) > currentTime)
        {
            if (datePosted.AddDays(2) > currentTime)
            {
                dateString = "1 day ago";
            }
            else
            {
                int numDays = (currentTime - datePosted).Days;
                dateString = $"{numDays} days ago";
            }
        }
        else if (datePosted.AddYears(1) > currentTime)
        {
            if (datePosted.AddMonths(2) > currentTime)
            {
                dateString = "1 month ago";
            }
            else
            {
                int numMonths = (currentTime - datePosted).Days / 30;
                dateString = $"{numMonths} months ago";
            }
        }
        else
        {
            if (datePosted.AddYears(2) > currentTime)
            {
                dateString = "1 year ago";
            }
            else
            {
                int numYears = (currentTime - datePosted).Days / 365;
                dateString = $"{numYears} years ago";
            }
        }

        return dateString;
    }
}