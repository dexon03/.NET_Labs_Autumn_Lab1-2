using MyLibrary;

namespace Lab2UnitTests;

public class DequeTests
{
    [Fact]
    public void TestPushFront()
    {
        // Arrange
        var deque = new Deque<int>();

        // Act
        deque.PushFront(1);
        deque.PushFront(2);
        deque.PushFront(3);

        // Assert
        Assert.Equal("[3, 2, 1]", deque.ToString());
    }

    [Fact]
    public void TestPushBack()
    {
        // Arrange
        var deque = new Deque<int>();

        // Act
        deque.PushBack(1);
        deque.PushBack(2);
        deque.PushBack(3);

        // Assert
        Assert.Equal("[1, 2, 3]", deque.ToString());
    }

    [Fact]
    public void TestPopFront()
    {
        // Arrange
        var deque = new Deque<int>();
        deque.PushBack(1);
        deque.PushBack(2);
        deque.PushBack(3);

        // Act
        var popped = deque.PopFront();
        
        // Assert
        var expectedDeque = new Deque<int>();
        expectedDeque.PushBack(2);
        expectedDeque.PushBack(3);
        Assert.Equal(1, popped);
        Assert.Equal("[2, 3]", deque.ToString());
        Assert.Equal(expectedDeque,deque);
    }

    [Fact]
    public void TestPopBack()
    {
        // Arrange
        var deque = new Deque<int>();
        deque.PushBack(1);
        deque.PushBack(2);
        deque.PushBack(3);

        // Act
        var popped = deque.PopBack();

        // Assert
        Assert.Equal(3, popped);
        Assert.Equal("[1, 2]", deque.ToString());
    }

    [Fact]
    public void TestPeekFront()
    {
        // Arrange
        var deque = new Deque<int>();
        deque.PushBack(1);
        deque.PushBack(2);

        // Act
        var peeked = deque.PeekFront();

        // Assert
        Assert.Equal(1, peeked);
    }

    [Fact]
    public void TestPeekBack()
    {
        // Arrange
        var deque = new Deque<int>();
        deque.PushBack(1);
        deque.PushBack(2);

        // Act
        var peeked = deque.PeekBack();

        // Assert
        Assert.Equal(2, peeked);
    }

    [Fact]
    public void TestIsEmpty()
    {
        // Arrange
        var emptyDeque = new Deque<int>();
        var nonEmptyDeque = new Deque<int>();
        nonEmptyDeque.PushFront(1);

        // Act & Assert
        Assert.True(emptyDeque.IsEmpty());
        Assert.False(nonEmptyDeque.IsEmpty());
    }

    [Fact]
    public void TestClear()
    {
        // Arrange
        var deque = new Deque<int>();
        deque.PushBack(1);
        deque.PushBack(2);

        // Act
        deque.Clear();

        // Assert
        Assert.True(deque.IsEmpty());
    }

    [Fact]
    public void TestContains()
    {
        // Arrange
        var deque = new Deque<string>();
        deque.PushBack("apple");
        deque.PushBack("banana");
        deque.PushBack("cherry");

        // Act & Assert
        Assert.True(deque.Contains("banana"));
        Assert.False(deque.Contains("grape"));
    }

    [Fact]
    public void TestReverse()
    {
        // Arrange
        var deque = new Deque<int>();
        deque.PushBack(1);
        deque.PushBack(2);
        deque.PushBack(3);

        // Act
        deque.Reverse();

        // Assert
        Assert.Equal("[3, 2, 1]", deque.ToString());
    }
    
     [Fact]
    public void TestDequeueEmptyDeque()
    {
        // Arrange
        var deque = new Deque<int>();

        // Act & Assert
        Assert.Throws<InvalidOperationException>(() => deque.PopFront());
        Assert.Throws<InvalidOperationException>(() => deque.PopBack());
    }

    [Fact]
    public void TestPeekEmptyDeque()
    {
        // Arrange
        var deque = new Deque<int>();

        // Act & Assert
        Assert.Throws<InvalidOperationException>(() => deque.PeekFront());
        Assert.Throws<InvalidOperationException>(() => deque.PeekBack());
    }

    [Fact]
    public void TestReverseEmptyDeque()
    {
        // Arrange
        var deque = new Deque<int>();

        // Act
        deque.Reverse();

        // Assert
        Assert.True(deque.IsEmpty());
    }

    [Fact]
    public void TestReverseSingleItemDeque()
    {
        // Arrange
        var deque = new Deque<int>();
        deque.PushBack(1);

        // Act
        deque.Reverse();

        // Assert
        Assert.Equal("[1]", deque.ToString());
    }

    [Fact]
    public void TestGetEnumerator()
    {
        // Arrange
        var deque = new Deque<int>();
        deque.PushBack(1);
        deque.PushBack(2);
        deque.PushBack(3);

        // Act
        var enumerator = deque.GetEnumerator();

        // Assert
        Assert.True(enumerator.MoveNext());
        Assert.Equal(1, enumerator.Current);
        Assert.True(enumerator.MoveNext());
        Assert.Equal(2, enumerator.Current);
        Assert.True(enumerator.MoveNext());
        Assert.Equal(3, enumerator.Current);
        Assert.False(enumerator.MoveNext());
    }

    [Fact]
    public void TestEnumeratorReset()
    {
        // Arrange
        var deque = new Deque<int>();
        deque.PushBack(1);
        deque.PushBack(2);

        // Act
        var enumerator = deque.GetEnumerator();
        enumerator.MoveNext();
        enumerator.Reset();

        // Assert
        enumerator.MoveNext();
        Assert.Equal(1, enumerator.Current);
    }

    [Fact]
    public void TestEnumeratorCurrentBeforeEnumeration()
    {
        // Arrange
        var deque = new Deque<int>();

        // Act & Assert
        var enumerator = deque.GetEnumerator();
        Assert.Throws<InvalidOperationException>(() => enumerator.Current);
    }
    
    [Fact]
    public void TestCurrentFromEnumeratorWithoutMoveNext()
    {
        // Arrange
        var deque = new Deque<int>(1); 

        // Act
        var enumerator = deque.GetEnumerator();

        // Assert
        Assert.Throws<InvalidOperationException>(() => enumerator.Current);
    }
    
    [Fact]
    public void TestCurrentFromEnumeratorAfterMoveNext()
    {
        // Arrange
        var deque = new Deque<int>();
        deque.PushBack(2);
        deque.PushBack(3);

        // Act
        var enumerator = deque.GetEnumerator();
        enumerator.MoveNext();
        var current = enumerator.Current;

        // Assert
        Assert.Equal(2, current);
    }
}