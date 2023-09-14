using HockeyClassLibrary.Data;
using FluentAssertions;

namespace Hockey.Test;

public class HockeyPlayerTest
{
    // makes a new hockey player instance so that we can have an object to test our data on 
    public HockeyPlayer GenerateTestPlayer()
    {
        return new HockeyPlayer();
    }

    [Fact]
    public void HockeyPlayer_FirstName_ReturnsGoodFirstName()
    {
        // arrange - defining values
        HockeyPlayer player = GenerateTestPlayer();
        const string NAME = "test";
        player.FirstName = NAME;

        // act - what should the test be equivalent to?
        string actual = player.FirstName;

        // assert - the actual test
        actual.Should().Be(NAME);
    }

    [Fact]
    public void HockeyPlayer_FirstName_ThrowsExceptionForEmptyArg()
    {
        // arrange
        HockeyPlayer player = GenerateTestPlayer();
        const string EMPTY_NAME = "";

        // act
        Action act = () => player.FirstName = EMPTY_NAME;

        // assert
        act.Should().Throw<ArgumentException>().WithMessage("First Name cannot be null or empty.");
    }
}
