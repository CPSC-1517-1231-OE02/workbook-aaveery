using FluentAssertions;
using Utils;

namespace UtilitiesTestProject;

public class UtilitiesTest
{
    // when testing, you want to test all possibilities

    [Theory]
    [InlineData(1)]
    [InlineData(1D)]
    [InlineData("1.0")]
    public void Utilities_IsPositive_ReturnsTrueForPositive(object value)
    {
        // arrange
        bool actual;

        // act
        if (value.GetType() == typeof(int))
        {
            actual = Utilities.IsPositive((int)value);
        }
        else if (value.GetType() == typeof(double))
        {
            actual = Utilities.IsPositive((double)value);
        }
        else
        {
            actual = Utilities.IsPositive(Convert.ToDecimal(value));
        }

        // assert
        actual.Should().BeTrue();
    }

    // DateOnly data generator
        // <object[]> refers to a generic array that can accept any data types
        // used when the value we want to provide is not compatible
    public static IEnumerable<object[]> GenerateIsInTheFutureTestData()
    {
        yield return new object[] {
            // present
            DateOnly.FromDateTime(DateTime.Now), false
        };
        yield return new object[] {
            // past
            DateOnly.FromDateTime(DateTime.Now).AddDays(-1), false
        };
        yield return new object[] {
            // future
            DateOnly.FromDateTime(DateTime.Now).AddDays(1), true
        };

    }

    [Theory]
    [MemberData(nameof(GenerateIsInTheFutureTestData))] // present
    public void Utilities_IsInTheFuture_ReturnsTrueForFutureFalseOtherwise(DateOnly date, bool expected)
    {
        // arrange
        bool actual;

        // act
        actual = Utilities.IsInTheFuture(date);

        // assert
        actual.Should().Be(expected);
    }

    [Theory] // this allows us to test multiple values from a data source
    [InlineData("")]
    [InlineData(" ")]
    [InlineData(null)]
    public void Utilities_IsNullEmptyOrWhiteSpace_ReturnsTrueForEmptyNullOrWhitespace(string value)
    {
        // arrange
        bool actual;

        // act
        actual = Utilities.IsNullEmptyOrWhiteSpace(value);

        // assert
        actual.Should().BeTrue();
    }

    [Fact]
    public void Utilities_IsNullEmptyOrWhitespace_ReturnsFalseForNonEmpty()
    {

        // arrange
        bool actual;
        const string GOOD_STRING = "lol";

        // act
        actual = Utilities.IsNullEmptyOrWhiteSpace(GOOD_STRING);

        // assert
        actual.Should().BeFalse();
    }
}
