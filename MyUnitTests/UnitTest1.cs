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

            // Assert (check your work)
            Assert.AreEqual(actualMax, 20);  // what you're expecting
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

            // Assert (check your work)
            Assert.AreEqual(actualMax, 15);  // what you're expecting

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

            // Assert (check your work)
            Assert.AreEqual(actualCount, 2);  // what you're expecting

            // Test file menu --> run all tests
        }
    }
}
