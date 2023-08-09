using Fundamentals;
using System.Diagnostics;

namespace Tests;
[TestFixture]
public class BinarySearchTests
{
    [Test]
    public void IndexOf_ReturnsCorrectIndex_WhenKeyExistsInArray()
    {
        // Arrange
        int[] array = { 1, 3, 5, 7, 9 };
        int key = 5;

        // Act
        int index = BinarySearch.IndexOf(array, key);

        // Assert
        Assert.AreEqual(2, index);
    }

    [Test]
    public void RecursiveIndexOf_ReturnsCorrectIndex_WhenKeyExistsInArray()
    {
        // Arrange
        int[] array = { 1, 3, 5, 7, 9 };
        int key = 1;

        // Act
        int index = RecursiveBinarySearch.IndexOf(array, key);

        // Assert
        Assert.AreEqual(0, index);
    }

    [Test]
    public void IndexOf_ReturnsNegativeOne_WhenKeyDoesNotExistInArray()
    {
        // Arrange
        int[] array = { 1, 3, 5, 7, 9 };
        int key = 8;

        // Act
        int index = BinarySearch.IndexOf(array, key);

        // Assert
        Assert.AreEqual(-1, index);
    }

    [Test]
    public void DistinctSortAndIndexOf_ReturnsCorrectIndex_WhenKeyExistsInArray()
    {
        // Arrange
        int[] array = { 9, 7, 5, 5, 5, 3, 1};
        int key = 7;

        // Act
        var stopwatch = Stopwatch.StartNew();
        int index = BinarySearch.DistinctSortAndIndexOf(array, key);
        stopwatch.Stop();


        // Assert
        Assert.AreEqual(3, index);
    }

    [Test]
    public void DistinctSortAndIndexOf_ReturnsNegativeOne_WhenKeyDoesNotExistInArray()
    {
        // Arrange
        int[] array = { 9, 7, 5, 3, 1 };
        int key = 4;

        // Act
        var stopwatch = Stopwatch.StartNew();
        int index = BinarySearch.DistinctSortAndIndexOf(array, key);
        stopwatch.Stop();


        // Assert
        Assert.AreEqual(-1, index);
    }


    [Test]
    public void DistinctHashSortAndIndexOf_ReturnsCorrectIndex_WhenKeyExistsInArray()
    {
        // Arrange
        int[] array = { 9, 7, 5, 5, 5, 3, 1};
        int key = 7;

        // Act
        var stopwatch = Stopwatch.StartNew();
        int index = BinarySearch.DistinctHashSortAndIndexOf(array, key);
        stopwatch.Stop();

        // Assert
        Assert.AreEqual(3, index);
    }

    [Test]
    public void DistinctHashSortAndIndexOf_ReturnsNegativeOne_WhenKeyDoesNotExistInArray()
    {
        // Arrange
        int[] array = { 9, 7, 5, 3, 1 };
        int key = 4;

        // Act
        int index = BinarySearch.DistinctHashSortAndIndexOf(array, key);

        // Assert
        Assert.AreEqual(-1, index);
    }
}
