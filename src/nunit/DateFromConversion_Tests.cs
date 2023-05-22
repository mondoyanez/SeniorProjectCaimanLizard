using WatchParty.Utilities;

namespace WatchPartyTest;
public class DateFromConversion_Tests
{
    [Test]
    public void DateFromConversion_JustPosted_ShouldReturnJustPosted()
    {
        // Arrange
        DateFromConversion conversion = new DateFromConversion();
        DateTime datePosted = new DateTime(2023, 4, 16, 13, 10, 0);
        DateTime dateNow = new DateTime(2023, 4, 16, 13, 9, 5);

        // Act
        string actual = conversion.ConvertDate(datePosted, dateNow);

        // Assert
        Assert.That(actual, Is.EqualTo("just now"));
    }

    [Test]
    public void DateFromConversion_PostedSecondsAgo_ShouldReturnSecondsAgoPosted()
    {
        // Arrange
        DateFromConversion conversion = new DateFromConversion();
        DateTime datePosted = new DateTime(2023, 4, 16, 13, 10, 0);
        DateTime dateNow = new DateTime(2023, 4, 16, 13, 10, 15);
        
        
        // Act
        string actual = conversion.ConvertDate(datePosted, dateNow);

        // Assert
        Assert.That(actual, Is.EqualTo("15 seconds ago"));
    }

    [Test]
    public void DateFromConversion_PostedOneMinuteAgo_ShouldReturnPostedOneMinuteAgo()
    {
        // Arrange
        DateFromConversion conversion = new DateFromConversion();
        DateTime datePosted = new DateTime(2023, 4, 16, 13, 10, 0);
        DateTime dateNow = new DateTime(2023, 4, 16, 13, 11, 10);


        // Act
        string actual = conversion.ConvertDate(datePosted, dateNow);

        // Assert
        Assert.That(actual, Is.EqualTo("1 minute ago"));
    }

    [Test]
    public void DateFromConversion_PostedThirtyTwoMinutesAgo_ShouldReturnPostedThirtyTwoMinutesAgo()
    {
        // Arrange
        DateFromConversion conversion = new DateFromConversion();
        DateTime datePosted = new DateTime(2023, 4, 16, 13, 10, 0);
        DateTime dateNow = new DateTime(2023, 4, 16, 13, 42, 10);


        // Act
        string actual = conversion.ConvertDate(datePosted, dateNow);

        // Assert
        Assert.That(actual, Is.EqualTo("32 minutes ago"));
    }

    [Test]
    public void DateFromConversion_PostedOneHourAgo_ShouldReturnPostedOneHourAgo()
    {
        // Arrange
        DateFromConversion conversion = new DateFromConversion();
        DateTime datePosted = new DateTime(2023, 4, 16, 23, 10, 0);
        DateTime dateNow = new DateTime(2023, 4, 17, 0, 10, 0);


        // Act
        string actual = conversion.ConvertDate(datePosted, dateNow);

        // Assert
        Assert.That(actual, Is.EqualTo("1 hour ago"));
    }

    [Test]
    public void DateFromConversion_PostedFiveHoursAgo_ShouldReturnPostedFiveHoursAgo()
    {
        // Arrange
        DateFromConversion conversion = new DateFromConversion();
        DateTime datePosted = new DateTime(2023, 4, 16, 23, 10, 0);
        DateTime dateNow = new DateTime(2023, 4, 17, 4, 10, 0);


        // Act
        string actual = conversion.ConvertDate(datePosted, dateNow);

        // Assert
        Assert.That(actual, Is.EqualTo("5 hours ago"));
    }

    [Test]
    public void DateFromConversion_PostedOneDayAgo_ShouldReturnPostedOneDayAgo()
    {
        // Arrange
        DateFromConversion conversion = new DateFromConversion();
        DateTime datePosted = new DateTime(2023, 4, 16, 23, 10, 0);
        DateTime dateNow = new DateTime(2023, 4, 17, 23, 10, 0);


        // Act
        string actual = conversion.ConvertDate(datePosted, dateNow);

        // Assert
        Assert.That(actual, Is.EqualTo("1 day ago"));
    }

    [Test]
    public void DateFromConversion_PostedTwentyFiveDaysAgo_ShouldReturnPostedTwentyFiveDaysAgo()
    {
        // Arrange
        DateFromConversion conversion = new DateFromConversion();
        DateTime datePosted = new DateTime(2023, 4, 1, 23, 10, 0);
        DateTime dateNow = new DateTime(2023, 4, 26, 23, 10, 0);


        // Act
        string actual = conversion.ConvertDate(datePosted, dateNow);

        // Assert
        Assert.That(actual, Is.EqualTo("25 days ago"));
    }

    [Test]
    public void DateFromConversion_PostedOneMonthAgo_ShouldReturnPostedOneMonthAgo()
    {
        // Arrange
        DateFromConversion conversion = new DateFromConversion();
        DateTime datePosted = new DateTime(2023, 4, 16, 23, 10, 0);
        DateTime dateNow = new DateTime(2023, 5, 26, 23, 10, 0);


        // Act
        string actual = conversion.ConvertDate(datePosted, dateNow);

        // Assert
        Assert.That(actual, Is.EqualTo("1 month ago"));
    }

    [Test]
    public void DateFromConversion_PostedSevenMonthsAgo_ShouldReturnPostedSevenMonthsAgo()
    {
        // Arrange
        DateFromConversion conversion = new DateFromConversion();
        DateTime datePosted = new DateTime(2023, 4, 16, 23, 10, 0);
        DateTime dateNow = new DateTime(2023, 11, 26, 23, 10, 0);


        // Act
        string actual = conversion.ConvertDate(datePosted, dateNow);

        // Assert
        Assert.That(actual, Is.EqualTo("7 months ago"));
    }

    [Test]
    public void DateFromConversion_PostedOneYearAgo_ShouldReturnPostedOneYearAgo()
    {
        // Arrange
        DateFromConversion conversion = new DateFromConversion();
        DateTime datePosted = new DateTime(2023, 4, 16, 23, 10, 0);
        DateTime dateNow = new DateTime(2024, 4, 26, 23, 10, 0);


        // Act
        string actual = conversion.ConvertDate(datePosted, dateNow);

        // Assert
        Assert.That(actual, Is.EqualTo("1 year ago"));
    }

    [Test]
    public void DateFromConversion_PostedSixYearsAgo_ShouldReturnPostedSixYearsAgo()
    {
        // Arrange
        DateFromConversion conversion = new DateFromConversion();
        DateTime datePosted = new DateTime(2023, 4, 16, 23, 10, 0);
        DateTime dateNow = new DateTime(2029, 10, 13, 23, 10, 0);


        // Act
        string actual = conversion.ConvertDate(datePosted, dateNow);

        // Assert
        Assert.That(actual, Is.EqualTo("6 years ago"));
    }
}