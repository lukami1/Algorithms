using Fundamentals;

namespace Tests
{
    [TestFixture]
    public class EuclidsAlgorithmTests
    {
        [TestCase(10, 25, ExpectedResult = 5)]
        [TestCase(14, 21, ExpectedResult = 7)]
        [TestCase(17, 34, ExpectedResult = 17)]
        [TestCase(30, 42, ExpectedResult = 6)]
        [TestCase(0, 8, ExpectedResult = 8)]
        [TestCase(0, 0, ExpectedResult = 0)]
        [TestCase(1111111, 1234567, ExpectedResult = 1)]
        public int GCD_ValidInput_ReturnsCorrectGCD(int p, int q)
        {
            // Act
            int result = EuclidsAlghorithm.GCD(p, q);

            // Assert
            return result;
        }
    }
}
