using HockeyClassLibrary.Data;
using FluentAssertions;
using System.Collections;

namespace Hockey.Test;

public class HockeyPlayerTest
{
    // constants for a test player
    const string FirstName = "Connor";
    const string LastName = "Brown";
    const string BirthPlace = "Toronto, Ontario";
    const int HeightInInches = 72;
    const int WeightInPounds = 188;
    const int JerseyNumber = 28;
    const Position PlayerPosition = Position.Center;
    const Shot PlayerShot = Shot.Left;
    // cant be a constant so we make it static readonly 
    static readonly DateOnly DateOfBirth = new DateOnly(1994, 01, 14); // he should be 29
    const string ToStringValue = $"{FirstName}, {LastName}";
    readonly int Age = (DateOnly.FromDateTime(DateTime.Now).DayNumber - DateOfBirth.DayNumber) / 365;

    public HockeyPlayer CreateTestHockeyPlayer()
    {
        return new HockeyPlayer(FirstName, LastName, BirthPlace, DateOfBirth, WeightInPounds, HeightInInches, JerseyNumber, PlayerPosition, PlayerShot);
    }

    private class BadHockeyPlayerTestDataGenerator : IEnumerable<object[]>
    {
        private readonly List<object[]> _data = new List<object[]>
            {
                // First Name tests
                new object[]{"", LastName, BirthPlace, DateOfBirth, HeightInInches, WeightInPounds, JerseyNumber, PlayerPosition, PlayerShot, "First name cannot be null or empty." },
                new object[]{" ", LastName, BirthPlace, DateOfBirth, HeightInInches, WeightInPounds, JerseyNumber, PlayerPosition, PlayerShot, "First name cannot be null or empty." },
                new object[]{null, LastName, BirthPlace, DateOfBirth, HeightInInches, WeightInPounds, JerseyNumber, PlayerPosition, PlayerShot, "First name cannot be null or empty." },

                // TODO: complete remaining private set tests
            };

        public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    // Alternative test data generator for member data (see line 97 below)
    public static IEnumerable<object[]> GoodHockeyPlayerTestDataGenerator()
    {
        // Yield as many test objects as desired/required
        yield return new object[]
        {
               FirstName, LastName, BirthPlace, DateOfBirth, HeightInInches, WeightInPounds, JerseyNumber, PlayerPosition, PlayerShot,
        };
    }

    // the above code is for the following test on the constructor
    [Theory]
    [MemberData(nameof(GoodHockeyPlayerTestDataGenerator))]
    public void HockeyPlayer_GreedyConstructor_ReturnHockeyPlayer(string firstname, string lastname, string birthplace, DateOnly dateOfBirth, int heightInInches, int weightInPounds, int jerseyNumber, Position position, Shot shot)
    {
        HockeyPlayer actual;

        actual = new HockeyPlayer(firstname, lastname, birthplace, dateOfBirth, heightInInches, weightInPounds, jerseyNumber, position, shot);

        actual.Should().NotBeNull();
    }

    [Fact]
    public void HockeyPlayer_Age_ReturnsCorrectValue()
    {
        HockeyPlayer player = CreateTestHockeyPlayer();
        int actual;

        actual = player.Age;

        actual.Should().Be(Age);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(98)]
    public void HockeyPlayer_JerseyNumber_GoodSetAndGet(int value)
    {
        HockeyPlayer player = CreateTestHockeyPlayer();
        int actual;

        player.JerseyNumber = value;
        actual = player.JerseyNumber;

        actual.Should().Be(value);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(99)]
    public void HockeyPlayer_JerseyNumber_BadSetThrows(int value)
    {
        HockeyPlayer player = CreateTestHockeyPlayer();

        Action act = () => player.JerseyNumber = value;

        act.Should().Throw<ArgumentOutOfRangeException>().WithMessage("Jersey Number should be between 1 and 98");
    }

    [Fact]
    public void HockeyPlayer_ToString_ReturnsCorrectValue()
    {
        // arrange
        HockeyPlayer player = CreateTestHockeyPlayer();
        string actual;

        // act
        actual = player.ToString();

        // assert
        actual.Should().Be(ToStringValue);
    }

    // how you could test that your age logic is correct
    //[Fact]
    //public void Age_IsCorrect()
    //{
    //    Age.Should().Be(29);
    //}

}
