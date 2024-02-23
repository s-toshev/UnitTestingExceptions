using NUnit.Framework;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;

namespace TestApp.UnitTests;

public class ExceptionTests
{
    private Exceptions _exceptions = null!;

    [SetUp]
    public void SetUp()
    {
        this._exceptions = new();
    }

    // TODO: finish test
    [Test]
    public void Test_Reverse_ValidString_ReturnsReversedString()
    {
        // Arrange
        string input = "imoaN";
        string expected = "Naomi";
        // Act
        string actual = this._exceptions.ArgumentNullReverse(input);
        // Assert
        Assert.AreEqual(expected, actual);
    }

    // TODO: finish test
    [Test]
    public void Test_Reverse_NullString_ThrowsArgumentNullException()
    {
        // Arrange
        string input = null;
        string exceptonMessage = Assert.Throws<ArgumentNullException>(() => this._exceptions.ArgumentNullReverse(input)).Message;

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => this._exceptions.ArgumentNullReverse(input));
        Assert.AreEqual("String cannot be null. (Parameter 's')", exceptonMessage);
    }

    [Test]
    public void Test_CalculateDiscount_ValidInput_ReturnsDiscountedPrice()
    {
        // Arrange
        decimal totalPrice = 100;
        decimal discount = 10;
        decimal expected = 90;
        // Act

        decimal actual = this._exceptions.ArgumentCalculateDiscount(totalPrice, discount);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    // TODO: finish test
    [Test]
    public void Test_CalculateDiscount_NegativeDiscount_ThrowsArgumentException()
    {
        // Arrange
        decimal totalPrice = 100;
        decimal discount = -10;
        string exceptionMessage = Assert.Throws<ArgumentException>(() => this._exceptions.ArgumentCalculateDiscount(totalPrice, discount)).Message;

        // Act & Assert
        Assert.Throws<ArgumentException>(() => this._exceptions.ArgumentCalculateDiscount(totalPrice, discount));
        Assert.AreEqual("Discount must be between 0 and 100. (Parameter 'discount')", exceptionMessage);
    }

    // TODO: finish test
    [Test]
    public void Test_CalculateDiscount_DiscountOver100_ThrowsArgumentException()
    {
        // Arrange
        decimal totalPrice = 100;
        decimal discount = 110;
        string exceptionMessage = Assert.Throws<ArgumentException>(() => this._exceptions.ArgumentCalculateDiscount(totalPrice, discount)).Message;

        // Act & Assert
        Assert.Throws<ArgumentException>(() => this._exceptions.ArgumentCalculateDiscount(totalPrice, discount));
        Assert.AreEqual("Discount must be between 0 and 100. (Parameter 'discount')", exceptionMessage);
    }

    [Test]
    public void Test_GetElement_ValidIndex_ReturnsElement()
    {
        //Arrange
        int[] input = { 1, 2, 3 };
        int index = 2;

        int expected = 3;
        //Act
        int actual = this._exceptions.IndexOutOfRangeGetElement(input, index);
        //Assert
        Assert.AreEqual(expected, actual);

    }



    // TODO: finish test
    [Test]
    public void Test_GetElement_IndexLessThanZero_ThrowsIndexOutOfRangeException()
    {
        // Arrange
        int[] input = { 1, 2, 3 };
        int index = -2;

        string exceptionMessage = Assert.Throws<IndexOutOfRangeException>(() => this._exceptions.IndexOutOfRangeGetElement(input, index)).Message;
        //"Index is out of range."

        // Act & Assert
        Assert.Throws<IndexOutOfRangeException>(() => this._exceptions.IndexOutOfRangeGetElement(input, index));
        Assert.AreEqual("Index is out of range.", exceptionMessage);
    }

    // TODO: finish test
    [Test]
    public void Test_GetElement_IndexEqualToArrayLength_ThrowsIndexOutOfRangeException()
    {
        // Arrange
        int[] input = { 10, 20, 30, 40, 50 };
        int index = input.Length;
        string exceptionMessage = Assert.Throws<IndexOutOfRangeException>(() => this._exceptions.IndexOutOfRangeGetElement(input, index)).Message;

        // Act & Assert
        Assert.Throws<IndexOutOfRangeException>(() => this._exceptions.IndexOutOfRangeGetElement(input, index));
        Assert.AreEqual("Index is out of range.", exceptionMessage);
    }

    [Test]
    public void Test_GetElement_IndexGreaterThanArrayLength_ThrowsIndexOutOfRangeException()
    {
        // Arrange
        int[] input = { 10, 20, 30, 40, 50 };
        int index = 15;
        string exceptionMessage = Assert.Throws<IndexOutOfRangeException>(() => this._exceptions.IndexOutOfRangeGetElement(input, index)).Message;

        // Act & Assert
        Assert.Throws<IndexOutOfRangeException>(() => this._exceptions.IndexOutOfRangeGetElement(input, index));
        Assert.AreEqual("Index is out of range.", exceptionMessage);
    }

    [Test]
    public void Test_PerformSecureOperation_UserLoggedIn_ReturnsUserLoggedInMessage()
    {


        //Arrange
        bool isLogged = true;

        string expected = "User logged in.";
        //Act
        string actual = this._exceptions.InvalidOperationPerformSecureOperation(isLogged);
        //Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_PerformSecureOperation_UserNotLoggedIn_ThrowsInvalidOperationException()
    {
        //Arrange
        bool isLogged = false;

        //Act
        string exceptionMessage = Assert.Throws<InvalidOperationException>(() => this._exceptions.InvalidOperationPerformSecureOperation(isLogged)).Message;

        //Assert
        Assert.Throws<InvalidOperationException>(() => this._exceptions.InvalidOperationPerformSecureOperation(isLogged));
        Assert.AreEqual("User must be logged in to perform this operation.", exceptionMessage);
    }




    [Test]
    public void Test_ParseInt_ValidInput_ReturnsParsedInteger()
    {
        //Arrange
        string input = "5";
        int expected = 5;
        //Act
        int actual = this._exceptions.FormatExceptionParseInt(input);
        //Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_ParseInt_InvalidInput_ThrowsFormatException()
    {
        //Arrange
        string input = "inTheMix";

        //Act
        string exceptionMessage = Assert.Throws<FormatException>(() => this._exceptions.FormatExceptionParseInt(input)).Message;

        //Assert
        Assert.Throws<FormatException>(() => this._exceptions.FormatExceptionParseInt(input));
        Assert.AreEqual("Input is not in the correct format for an integer.", exceptionMessage);

    }





    [Test]
    public void Test_FindValueByKey_KeyExistsInDictionary_ReturnsValue()
    {

        //Arrange
        Dictionary<string, int> kvp = new Dictionary<string, int>()
            {
           { "Apple", 10 },
           { "Banana", 20 },
          { "Orange", 15 },
          { "Grapes", 30 },
          { "Pineapple", 25 }
                };

        string key = "Apple";

        int expected = 10;

        //Act
        int actual = this._exceptions.KeyNotFoundFindValueByKey(kvp, key);


        //Assert
        Assert.AreEqual(expected, actual);

    }

    [Test]
    public void Test_FindValueByKey_KeyDoesNotExistInDictionary_ThrowsKeyNotFoundException()
    {
        //Arrange
        Dictionary<string, int> kvp = new Dictionary<string, int>()
            {
           { "Apple", 10 },
           { "Banana", 20 },
          { "Orange", 15 },
          { "Grapes", 30 },
          { "Pineapple", 25 }
                };

        string key = "Naomi";

        //Act
        string exceptionMessage = Assert.Throws<KeyNotFoundException>(() => this._exceptions.KeyNotFoundFindValueByKey(kvp, key)).Message;
        //Assert

        Assert.Throws<KeyNotFoundException>(() => this._exceptions.KeyNotFoundFindValueByKey(kvp, key));
        Assert.AreEqual("The specified key was not found in the dictionary.", exceptionMessage);
    }





    [Test]
    public void Test_AddNumbers_NoOverflow_ReturnsSum()
    {
        //Arrange
        int a = 1;
        int b = 2;

        int expected = 3;
        //Act
        int actual = this._exceptions.OverflowAddNumbers(a, b);
        //Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_AddNumbers_PositiveOverflow_ThrowsOverflowException()
    {
        //Arrange
        int a = int.MaxValue;
        int b = 999999999;


        //Act
        string exceptonMessage = Assert.Throws<OverflowException>(() => this._exceptions.OverflowAddNumbers(a, b)).Message;
        //Assert
        Assert.Throws<OverflowException>(() => this._exceptions.OverflowAddNumbers(a, b));
        Assert.AreEqual("Arithmetic overflow occurred during addition.", exceptonMessage);
    }

    [Test]
    public void Test_AddNumbers_NegativeOverflow_ThrowsOverflowException()
    {
        //Arrange
        int a = int.MinValue;
        int b = -999999999;


        //Act
        string exceptonMessage = Assert.Throws<OverflowException>(() => this._exceptions.OverflowAddNumbers(a, b)).Message;
        //Assert
        Assert.Throws<OverflowException>(() => this._exceptions.OverflowAddNumbers(a, b));
        Assert.AreEqual("Arithmetic overflow occurred during addition.", exceptonMessage);
    }



    [Test]
    public void Test_DivideNumbers_ValidDivision_ReturnsQuotient()
    {

        //Arrange
        int divident = 6;
        int divisor = 3;

        int expected = 2;
        //Act

        int actual = this._exceptions.DivideByZeroDivideNumbers(divident, divisor);
        //Assert
        Assert.AreEqual(expected, actual);


    }

    [Test]
    public void Test_DivideNumbers_DivideByZero_ThrowsDivideByZeroException()
    {

        //Arrange
        int divident = 6;
        int divisor = 0;


        //Act

        string exceptionMessage = Assert.Throws<DivideByZeroException>(() => this._exceptions.DivideByZeroDivideNumbers(divident, divisor)).Message;

        //Assert
        Assert.Throws<DivideByZeroException>(() => this._exceptions.DivideByZeroDivideNumbers(divident, divisor));
        Assert.AreEqual("Division by zero is not allowed.", exceptionMessage);

    }




    [Test]
    public void Test_SumCollectionElements_ValidCollectionAndIndex_ReturnsSum()
    {

        //Arrange
        int[] numbers = { 1, 2, 3, 4, 5, 6, 7 };
        int index = 3;

        int expected = 22;

        //Act
        int actual = this._exceptions.SumCollectionElements(numbers, index);

        //Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_SumCollectionElements_NullCollection_ThrowsArgumentNullException()
    {
        //Arrange
        int[] numbers = null;
        int index = 3;
        //Act
        string exceptionMessage = Assert.Throws<ArgumentNullException>(() => this._exceptions.SumCollectionElements(numbers, index)).Message;


        //Assert
        Assert.Throws<ArgumentNullException>(() => this._exceptions.SumCollectionElements(numbers, index));
        Assert.AreEqual("Collection cannot be null. (Parameter 'collection')", exceptionMessage);
    }

    [Test]
    public void Test_SumCollectionElements_IndexOutOfRange_ThrowsIndexOutOfRangeException()
    {
        //Arrange
        int[] numbers = { 1, 2, 3, 4, 5, 6, 7 };
        int index = 33;
        //Act
        string exceptionMessage = Assert.Throws<IndexOutOfRangeException>(() => this._exceptions.SumCollectionElements(numbers, index)).Message;


        //Assert
        Assert.Throws<IndexOutOfRangeException>(() => this._exceptions.SumCollectionElements(numbers, index));
        Assert.AreEqual("Index has to be within bounds.", exceptionMessage);

    }


    //public int GetElementAsNumber(Dictionary<string, string> dictionary, string key)
    //{
    //    if (!dictionary.ContainsKey(key))
    //    {
    //        throw new KeyNotFoundException("Key not found in the dictionary.");
    //    }

    //    string s = dictionary[key];
    //    int n;
    //    try
    //    {
    //        n = int.Parse(s);
    //    }
    //    catch (FormatException ex)
    //    {
    //        throw new FormatException("Can't parse string.", ex);
    //    }

    //    return n;
    //}



    [Test]
    public void Test_GetElementAsNumber_ValidKey_ReturnsParsedNumber()
    {
        // Arrange
        Dictionary<string, string> kvp = new Dictionary<string, string>()
         {
             {"John Doe", "5"},
             {"Alice Smith", "21"},
             {"Bob Johnson", "13"},
             {"Emily Davis", "18"},
             {"Michael Brown", "44"},
         };

        string key = "Alice Smith";
        int expected = 21;
        //Act
        int actual = this._exceptions.GetElementAsNumber(kvp, key);

        //Assert
        Assert.AreEqual(expected, actual);

    }

    [Test]
    public void Test_GetElementAsNumber_KeyNotFound_ThrowsKeyNotFoundException()
    {
        //Arrange
        Dictionary<string, string> kvp = new Dictionary<string, string>()
         {
             {"John Doe", "5"},
             {"Alice Smith", "21"},
             {"Bob Johnson", "13"},
             {"Emily Davis", "18"},
             {"Michael Brown", "44"},
         };

        string key = "Naomi Smith";


        //Act
        string exceptionMessage = Assert.Throws<KeyNotFoundException>(() => this._exceptions.GetElementAsNumber(kvp, key)).Message;

        //Assert
        Assert.Throws<KeyNotFoundException>(() => this._exceptions.GetElementAsNumber(kvp, key));
        Assert.AreEqual("Key not found in the dictionary.", exceptionMessage);

    }

    [Test]
    public void Test_GetElementAsNumber_InvalidFormat_ThrowsFormatException()
    {
        //Arrange
        Dictionary<string, string> kvp = new Dictionary<string, string>()
         {
             {"John Doe", "A"},
             {"Alice Smith", "B"},
              {"Bob Johnson", "C"},
               {"Emily Davis", "A"},
              {"Michael Brown", "B"},
         };

        string key = "Alice Smith";


        //Act
        string exceptionMessage = Assert.Throws<FormatException>(() => this._exceptions.GetElementAsNumber(kvp, key)).Message;

        //Assert
        Assert.Throws<FormatException>(() => this._exceptions.GetElementAsNumber(kvp, key));
        Assert.AreEqual("Can't parse string.", exceptionMessage);

    }
}
