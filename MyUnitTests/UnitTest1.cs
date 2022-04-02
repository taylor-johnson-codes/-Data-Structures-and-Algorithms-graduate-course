using Microsoft.VisualStudio.TestTools.UnitTesting;
using _3_29_22_classwork;

namespace MyUnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMaxWith3Values()
        {
            // Arrange
            BST<int> myTree = new BST<int>();
            myTree.Add(10);
            myTree.Add(20);
            myTree.Add(15);

            // Act
            int actualMax = myTree.Max();
            int expectedMax = 20;

            // Assert (check your work)
            Assert.AreEqual(actualMax, expectedMax);

            // Test file menu --> run all tests
        }

        [TestMethod]
        public void TestMaxWith3ValuesFAIL()
        {
            // Arrange
            BST<int> myTree = new BST<int>();
            myTree.Add(10);
            myTree.Add(20);
            myTree.Add(15);

            // Act
            int actualMax = myTree.Max();
            int expectedMax = 15;

            // Assert (check your work)
            Assert.AreEqual(actualMax, expectedMax);

            // Test file menu --> run all tests
        }

        [TestMethod]
        public void TestCountProperty()
        {
            // Arrange
            BST<int> myTree = new BST<int>();
            myTree.Add(10);
            myTree.Add(10);

            // Act
            int actualCount = myTree.Count;
            int expectedCount = 2;

            // Assert (check your work)
            Assert.AreEqual(actualCount, expectedCount);

            // Test file menu --> run all tests
        }

        [TestMethod]
        public void TestCountPropertyFAIL()
        {
            // Arrange
            BST<int> myTree = new BST<int>();
            myTree.Add(10);
            myTree.Add(10);

            // Act
            int actualCount = myTree.Count;
            int expectedCount = 1;

            // Assert (check your work)
            Assert.AreEqual(actualCount, expectedCount);

            // Test file menu --> run all tests
        }
    }
}
