namespace CommonTestsInternal.Collections.Generic
{
    using Common.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class SafeBinaryNodeTests
    {
        [TestMethod]
        [TestCategory("SafeBinaryNode")]
        public void Height_Root()
        {
            SafeBinaryNode<int> root = new SafeBinaryNode<int>(100);

            Assert.AreEqual<int>(0, root.Height);
        }

        [TestMethod]
        [TestCategory("SafeBinaryNode")]
        public void Height_RootWithLeftChild()
        {
            SafeBinaryNode<int> root = new SafeBinaryNode<int>(100);
            root.Left = new SafeBinaryNode<int>(50);

            Assert.AreEqual<int>(1, root.Height);
        }

        [TestMethod]
        [TestCategory("SafeBinaryNode")]
        public void Height_RootWithRightChild()
        {
            SafeBinaryNode<int> root = new SafeBinaryNode<int>(100);
            root.Right = new SafeBinaryNode<int>(150);

            Assert.AreEqual<int>(1, root.Height);
        }

        [TestMethod]
        [TestCategory("SafeBinaryNode")]
        public void Height_RootWithBothChildren()
        {
            SafeBinaryNode<int> root = new SafeBinaryNode<int>(100);
            root.Left = new SafeBinaryNode<int>(50);
            root.Right = new SafeBinaryNode<int>(150);

            Assert.AreEqual<int>(1, root.Height);
        }

        [TestMethod]
        [TestCategory("SafeBinaryNode")]
        public void Height_2_LeftLeft()
        {
            SafeBinaryNode<int> root = new SafeBinaryNode<int>(100);
            root.Left = new SafeBinaryNode<int>(50);
            root.Right = new SafeBinaryNode<int>(150);

            root.Left.Left = new SafeBinaryNode<int>(40);

            Assert.AreEqual<int>(2, root.Height);
        }

        [TestMethod]
        [TestCategory("SafeBinaryNode")]
        public void Height_2_LeftRight()
        {
            SafeBinaryNode<int> root = new SafeBinaryNode<int>(100);
            root.Left = new SafeBinaryNode<int>(50);
            root.Right = new SafeBinaryNode<int>(150);

            root.Left.Right = new SafeBinaryNode<int>(60);

            Assert.AreEqual<int>(2, root.Height);
        }

        [TestMethod]
        [TestCategory("SafeBinaryNode")]
        public void Height_2_RightLeft()
        {
            SafeBinaryNode<int> root = new SafeBinaryNode<int>(100);
            root.Left = new SafeBinaryNode<int>(50);
            root.Right = new SafeBinaryNode<int>(150);

            root.Right.Left = new SafeBinaryNode<int>(110);

            Assert.AreEqual<int>(2, root.Height);
        }

        [TestMethod]
        [TestCategory("SafeBinaryNode")]
        public void Height_2_RightRight()
        {
            SafeBinaryNode<int> root = new SafeBinaryNode<int>(100);
            root.Left = new SafeBinaryNode<int>(50);
            root.Right = new SafeBinaryNode<int>(150);

            root.Right.Right = new SafeBinaryNode<int>(160);

            Assert.AreEqual<int>(2, root.Height);
        }

        [TestMethod]
        [TestCategory("SafeBinaryNode")]
        public void Height_2_FullSecondLevel()
        {
            SafeBinaryNode<int> root = new SafeBinaryNode<int>(100);
            root.Left = new SafeBinaryNode<int>(50);
            root.Right = new SafeBinaryNode<int>(150);

            root.Left.Left = new SafeBinaryNode<int>(40);
            root.Left.Right = new SafeBinaryNode<int>(60);
            root.Right.Left = new SafeBinaryNode<int>(110);
            root.Right.Right = new SafeBinaryNode<int>(160);

            Assert.AreEqual<int>(2, root.Height);
        }

        [TestMethod]
        [TestCategory("SafeBinaryNode")]
        public void Height_3_LeftLeftLeft()
        {
            SafeBinaryNode<int> root = new SafeBinaryNode<int>(100);
            root.Left = new SafeBinaryNode<int>(50);
            root.Right = new SafeBinaryNode<int>(150);

            root.Left.Left = new SafeBinaryNode<int>(40);
            root.Left.Right = new SafeBinaryNode<int>(60);
            root.Right.Left = new SafeBinaryNode<int>(110);
            root.Right.Right = new SafeBinaryNode<int>(160);

            root.Left.Left.Left = new SafeBinaryNode<int>(30);

            Assert.AreEqual<int>(3, root.Height);
        }

    }
}
