namespace CommonTestsInternal.Collections.Generic
{
    using Common.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class IterativeBinaryNodeTests
    {
        [TestMethod]
        [TestCategory("IterativeBinaryNode")]
        public void Height_Root()
        {
            IterativeBinaryNode<int> root = new IterativeBinaryNode<int>(100);

            Assert.AreEqual<int>(0, root.Height);
        }

        [TestMethod]
        [TestCategory("IterativeBinaryNode")]
        public void Height_RootWithLeftChild()
        {
            IterativeBinaryNode<int> root = new IterativeBinaryNode<int>(100);
            root.Left = new IterativeBinaryNode<int>(50);

            Assert.AreEqual<int>(1, root.Height);
        }

        [TestMethod]
        [TestCategory("IterativeBinaryNode")]
        public void Height_RootWithRightChild()
        {
            IterativeBinaryNode<int> root = new IterativeBinaryNode<int>(100);
            root.Right = new IterativeBinaryNode<int>(150);

            Assert.AreEqual<int>(1, root.Height);
        }

        [TestMethod]
        [TestCategory("IterativeBinaryNode")]
        public void Height_RootWithBothChildren()
        {
            IterativeBinaryNode<int> root = new IterativeBinaryNode<int>(100);
            root.Left = new IterativeBinaryNode<int>(50);
            root.Right = new IterativeBinaryNode<int>(150);

            Assert.AreEqual<int>(1, root.Height);
        }

        [TestMethod]
        [TestCategory("IterativeBinaryNode")]
        public void Height_2_LeftLeft()
        {
            IterativeBinaryNode<int> root = new IterativeBinaryNode<int>(100);
            root.Left = new IterativeBinaryNode<int>(50);
            root.Right = new IterativeBinaryNode<int>(150);

            root.Left.Left = new IterativeBinaryNode<int>(40);

            Assert.AreEqual<int>(2, root.Height);
        }

        [TestMethod]
        [TestCategory("IterativeBinaryNode")]
        public void Height_2_LeftRight()
        {
            IterativeBinaryNode<int> root = new IterativeBinaryNode<int>(100);
            root.Left = new IterativeBinaryNode<int>(50);
            root.Right = new IterativeBinaryNode<int>(150);

            root.Left.Right = new IterativeBinaryNode<int>(60);

            Assert.AreEqual<int>(2, root.Height);
        }

        [TestMethod]
        [TestCategory("IterativeBinaryNode")]
        public void Height_2_RightLeft()
        {
            IterativeBinaryNode<int> root = new IterativeBinaryNode<int>(100);
            root.Left = new IterativeBinaryNode<int>(50);
            root.Right = new IterativeBinaryNode<int>(150);

            root.Right.Left = new IterativeBinaryNode<int>(110);

            Assert.AreEqual<int>(2, root.Height);
        }

        [TestMethod]
        [TestCategory("IterativeBinaryNode")]
        public void Height_2_RightRight()
        {
            IterativeBinaryNode<int> root = new IterativeBinaryNode<int>(100);
            root.Left = new IterativeBinaryNode<int>(50);
            root.Right = new IterativeBinaryNode<int>(150);

            root.Right.Right = new IterativeBinaryNode<int>(160);

            Assert.AreEqual<int>(2, root.Height);
        }

        [TestMethod]
        [TestCategory("IterativeBinaryNode")]
        public void Height_2_FullSecondLevel()
        {
            IterativeBinaryNode<int> root = new IterativeBinaryNode<int>(100);
            root.Left = new IterativeBinaryNode<int>(50);
            root.Right = new IterativeBinaryNode<int>(150);

            root.Left.Left = new IterativeBinaryNode<int>(40);
            root.Left.Right = new IterativeBinaryNode<int>(60);
            root.Right.Left = new IterativeBinaryNode<int>(110);
            root.Right.Right = new IterativeBinaryNode<int>(160);

            Assert.AreEqual<int>(2, root.Height);
        }

        [TestMethod]
        [TestCategory("IterativeBinaryNode")]
        public void Height_3_LeftLeftLeft()
        {
            IterativeBinaryNode<int> root = new IterativeBinaryNode<int>(100);
            root.Left = new IterativeBinaryNode<int>(50);
            root.Right = new IterativeBinaryNode<int>(150);

            root.Left.Left = new IterativeBinaryNode<int>(40);
            root.Left.Right = new IterativeBinaryNode<int>(60);
            root.Right.Left = new IterativeBinaryNode<int>(110);
            root.Right.Right = new IterativeBinaryNode<int>(160);

            root.Left.Left.Left = new IterativeBinaryNode<int>(30);

            Assert.AreEqual<int>(3, root.Height);
        }

    }
}
