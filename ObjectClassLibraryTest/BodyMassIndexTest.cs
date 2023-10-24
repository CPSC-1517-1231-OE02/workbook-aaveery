using FluentAssertions;
using ObjectClassLibrary;

namespace ObjectClassLibraryTest;

public class BodyMassIndexTest
{
    // constant for test bmi
    const string Name = "Jack Black";
    const double Weight = 180;
    const double Height = 65;

    public BodyMassIndex CreateTestBodyMassIndex()
    {
        return new BodyMassIndex(Name, Weight, Height);
    }

    [Fact]
    public void BodyMassIndex_CheckBMICalculation_GoodAnswer()
    {
        // arrange
        BodyMassIndex testBmi = CreateTestBodyMassIndex();

        // act
        double actual = testBmi.Bmi();

        // assert
        actual.Should().Be(30.0);
    }

    [Fact]
    public void BodyMassIndex_CheckBMICategory_GoodAnswer()
    {
        // arrange
        BodyMassIndex testBmi = CreateTestBodyMassIndex();

        // act
        string actual = testBmi.BmiCategory();

        // assert
        actual.Should().Be("obese");

    }

    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData(null)]
    public void BodyMassIndex_BlankOrWhiteSpaceName_ThrowsNullArgument(string value)
    {
        // arrange
        Action act = () => new BodyMassIndex(value, Weight, Height);

        // act/assert
        act.Should().Throw<ArgumentNullException>();
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-100)]
    public void BodyMassIndex_WeightBadValue_ThrowsOutOfRangeArgument(double value)
    {
        // arrange
        Action act = () => new BodyMassIndex(Name, value, Height);

        // act/assert
        act.Should().Throw<ArgumentOutOfRangeException>();

    }

    [Theory]
    [InlineData(0)]
    [InlineData(-100)]
    public void BodyMassIndex_HeightBadValue_ThrowsOutOfRangeArgument(double value)
    {
        // arrange
        Action act = () => new BodyMassIndex(Name, Weight, value);

        // act/assert
        act.Should().Throw<ArgumentOutOfRangeException>();

    }

    [Theory]
    [InlineData("Underweight Person 1", 90, 60)]
    [InlineData("Underweight Person 2", 120, 75)]
    public void BodyMassIndex_UnderweightBMICategory_GoodData(string name, double weight, double height)
    {
        // arrange
        BodyMassIndex actual = new BodyMassIndex(name, weight, height);

        // act/assert
        actual.BmiCategory().Should().Be("underweight");

    }

    [Theory]
    [InlineData("Normal weight Person 1", 111, 65)]
    [InlineData("Normal weight Person 2", 149, 65)]
    public void BodyMassIndex_NormalweightBMICategory_GoodData(string name, double weight, double height)
    {
        // arrange
        BodyMassIndex actual = new BodyMassIndex(name, weight, height);

        // act/assert
        actual.BmiCategory().Should().Be("normal");

    }

    [Theory]
    [InlineData("Overweight Person 1", 150, 65)]
    [InlineData("Overweight Person 2", 179, 65)]
    public void BodyMassIndex_OverweightBMICategory_GoodData(string name, double weight, double height)
    {
        // arrange
        BodyMassIndex actual = new BodyMassIndex(name, weight, height);

        // act/assert
        actual.BmiCategory().Should().Be("overweight");

    }

    [Theory]
    [InlineData("Obese Person 1", 180, 65)]
    [InlineData("Obese Person 2", 210, 65)]
    public void BodyMassIndex_ObseseBMICategory_GoodData(string name, double weight, double height)
    {
        // arrange
        BodyMassIndex actual = new BodyMassIndex(name, weight, height);

        // act/assert
        actual.BmiCategory().Should().Be("obese");
    }
}
