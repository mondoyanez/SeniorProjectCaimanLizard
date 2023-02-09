namespace WatchPartyTest;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Sample_Test()
    {
        // Arrange
        var x = 1;
        var y = 2;

        // Act
        var z = x + y;

        // Assert
        Assert.That(z, Is.EqualTo(3));
    }
}