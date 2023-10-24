using Utils;

namespace ObjectClassLibrary;

public class BodyMassIndex
{
    private double _weight;
    private double _height;

    public string Name { get; set; }

    public double Weight
    {
        get
        {
            return _weight;
        }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentOutOfRangeException("Weight must be a positive non-zero value");
            }
            _weight = value;
        }
    }

    public double Height
    {
        get
        {
            return _height;
        }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentOutOfRangeException("Height must be a positive non-zero value");
            }
            _height = value;
        }
    }

    public BodyMassIndex(string name, double weight, double height)
    {
        if (!Utilities.IsNullEmptyOrWhiteSpace(name))
        {
            Name = name;
        }
        else
        {
            throw new ArgumentNullException("Name cannot be blank");
        }
        Weight = weight;
        Height = height;
    }
    /// <summary>
    /// Calculate the body mass index (BMI) using the weight and height of the person.
    ///
    /// The BMI of a person is calculated using the formula: BMI = 700 * weight / (height* height)
    /// where weight is in pounds and height is in inches.
    /// </summary>
    /// <returns>the body mass index (BMI) value of the person</returns>

    public double Bmi()
    {
        double bmiValue = (703 * Weight) / (Height * Height);
        bmiValue = Math.Round(bmiValue, 1);
        return bmiValue;
    }
    /// <summary>
    /// Determines the BMI Category of the person using their BMI value.
    /// </summary>
    /// <returns>one of following: underweight, normal, overweight, obese.</returns>
    
    public string BmiCategory()
    {
        string category = "Unknown";
        double bmiValue = Bmi();
        if (bmiValue < 18.5)
        {
            category = "underweight";
        }
        else if (bmiValue < 24.9)
        {
            category = "normal";
        }
        else if (bmiValue < 29.9)
        {
            category = "overweight";
        }
        else if (bmiValue >= 30)
        {
            category = "obese";
        }
        return category;
    }
}

