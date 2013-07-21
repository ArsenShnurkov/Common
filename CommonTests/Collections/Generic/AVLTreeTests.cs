namespace CommonTests.Collections.Generic
{
    using System;
    using Common.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class AVLTreeTests
    {

        #region AVLTree.Insert

        [TestMethod]
        [TestCategory("AVLTree.Insert")]
        public void Insert_Into_EmptyTree()
        {
            AVLTree<int> avlTree = new AVLTree<int>();
            avlTree.Insert(50);

            Assert.AreEqual<int>(0, avlTree.Balance);
        }

        [TestMethod]
        [TestCategory("AVLTree.Insert")]
        public void Insert_RootLeft()
        {
            AVLTree<int> avlTree = new AVLTree<int>();
            avlTree.Insert(50);
            avlTree.Insert(25);

            Assert.AreEqual<int>(1, avlTree.Balance);
        }

        [TestMethod]
        [TestCategory("AVLTree.Insert")]
        public void Insert_RootRight()
        {
            AVLTree<int> avlTree = new AVLTree<int>();
            avlTree.Insert(50);
            avlTree.Insert(75);

            Assert.AreEqual<int>(-1, avlTree.Balance);
        }

        [TestMethod]
        [TestCategory("AVLTree.Insert")]
        public void Insert_RootLeftLeft_OuterLeftOffBalance()
        {
            AVLTree<int> avlTree = new AVLTree<int>();
            avlTree.Insert(50);
            avlTree.Insert(25);
            avlTree.Insert(10);

            Assert.AreEqual<int>(0, avlTree.Balance);
            Assert.AreEqual<int>(25, avlTree.Root.Value);
            Assert.AreEqual<int>(10, avlTree.Root.Left.Value);
            Assert.AreEqual<int>(50, avlTree.Root.Right.Value);
        }

        [TestMethod]
        [TestCategory("AVLTree.Insert")]
        public void Insert_RootRightRight_OuterRightOffBalance()
        {
            AVLTree<int> avlTree = new AVLTree<int>();
            avlTree.Insert(50);
            avlTree.Insert(75);
            avlTree.Insert(100);

            Assert.AreEqual<int>(0, avlTree.Balance);
            Assert.AreEqual<int>(75, avlTree.Root.Value);
            Assert.AreEqual<int>(50, avlTree.Root.Left.Value);
            Assert.AreEqual<int>(100, avlTree.Root.Right.Value);
        }

        [TestMethod]
        [TestCategory("AVLTree.Insert")]
        public void Insert_RootLeftRight_InnerLeftOffBalance()
        {
            AVLTree<int> avlTree = new AVLTree<int>();
            avlTree.Insert(50);
            avlTree.Insert(25);
            avlTree.Insert(30);

            Assert.AreEqual<int>(0, avlTree.Balance);
            Assert.AreEqual<int>(30, avlTree.Root.Value);
            Assert.AreEqual<int>(25, avlTree.Root.Left.Value);
            Assert.AreEqual<int>(50, avlTree.Root.Right.Value);
        }

        [TestMethod]
        [TestCategory("AVLTree.Insert")]
        public void Insert_RootRightLeft_InnerRightOffBalance()
        {
            AVLTree<int> avlTree = new AVLTree<int>();
            avlTree.Insert(50);
            avlTree.Insert(75);
            avlTree.Insert(60);

            Assert.AreEqual<int>(0, avlTree.Balance);
            Assert.AreEqual<int>(60, avlTree.Root.Value);
            Assert.AreEqual<int>(50, avlTree.Root.Left.Value);
            Assert.AreEqual<int>(75, avlTree.Root.Right.Value);
        }

        [TestMethod]
        [TestCategory("AVLTree.Insert")]
        public void Insert_Randoms()
        {
            AVLTree<int> avlTree = new AVLTree<int>();

            avlTree.Insert(1497812207);
            avlTree.Insert(694294668);
            avlTree.Insert(413707771);
            avlTree.Insert(887315894);
            avlTree.Insert(1043416025);

            Assert.AreEqual<int>(-1, avlTree.Balance);
            Assert.AreEqual<int>(694294668, avlTree.Root.Value);
            Assert.AreEqual<int>(413707771, avlTree.Root.Left.Value);
            Assert.AreEqual<int>(1043416025, avlTree.Root.Right.Value);
            Assert.AreEqual<int>(887315894, avlTree.Root.Right.Left.Value);
            Assert.AreEqual<int>(1497812207, avlTree.Root.Right.Right.Value);
        }


        





        #endregion

        #region AVLTree.Delete

        [TestMethod]
        [TestCategory("AVLTree.Delete")]
        public void Delete_ResultingIn_LeftLeft()
        {
            AVLTree<int> avlTree = new AVLTree<int>();
            avlTree.Insert(100);

            avlTree.Insert(50);
            avlTree.Insert(150);

            avlTree.Insert(25);
            avlTree.Insert(75);

            avlTree.Delete(150);

            Assert.IsNotNull(avlTree.Root);

            Assert.AreEqual<int>(50, avlTree.Root.Value);
            Assert.AreEqual<int>(4, avlTree.Count);
            Assert.AreEqual<int>(100, avlTree.Root.Right.Value);
            Assert.AreEqual<int>(75, avlTree.Root.Right.Left.Value);
            Assert.AreEqual<int>(25, avlTree.Root.Left.Value);

            Assert.AreEqual<int>(2, avlTree.Root.Height);
            Assert.AreEqual<int>(0, avlTree.Root.Left.Height);
            Assert.AreEqual<int>(1, avlTree.Root.Right.Height);
            Assert.AreEqual<int>(0, avlTree.Root.Right.Left.Height);
        }

        [TestMethod]
        [TestCategory("AVLTree.Delete")]
        public void Delete_ResultingIn_RightRight()
        {
            AVLTree<int> avlTree = new AVLTree<int>();
            avlTree.Insert(100);

            avlTree.Insert(50);
            avlTree.Insert(150);

            avlTree.Insert(125);
            avlTree.Insert(175);

            avlTree.Delete(50);

            Assert.IsNotNull(avlTree.Root);
            Assert.AreEqual<int>(150, avlTree.Root.Value);
            Assert.AreEqual<int>(4, avlTree.Count);
            Assert.AreEqual<int>(175, avlTree.Root.Right.Value);
            Assert.AreEqual<int>(100, avlTree.Root.Left.Value);
            Assert.AreEqual<int>(125, avlTree.Root.Left.Right.Value);

            Assert.AreEqual<int>(2, avlTree.Root.Height);
            Assert.AreEqual<int>(0, avlTree.Root.Right.Height);
            Assert.AreEqual<int>(1, avlTree.Root.Left.Height);
            Assert.AreEqual<int>(0, avlTree.Root.Left.Right.Height);
        }

        [TestMethod]
        [TestCategory("AVLTree.Delete")]
        public void Delete_ResultingIn_LeftRight()
        {
            AVLTree<int> avlTree = new AVLTree<int>();
            avlTree.Insert(100);
            avlTree.Insert(50);
            avlTree.Insert(150);
            avlTree.Insert(75);

            avlTree.Delete(150);

            Assert.IsNotNull(avlTree.Root);
            Assert.AreEqual<int>(75, avlTree.Root.Value);
            Assert.AreEqual<int>(50, avlTree.Root.Left.Value);
            Assert.AreEqual<int>(100, avlTree.Root.Right.Value);
            Assert.AreEqual<int>(3, avlTree.Count);
            Assert.IsNull(avlTree.Root.Left.Left);
            Assert.IsNull(avlTree.Root.Left.Right);
            Assert.IsNull(avlTree.Root.Right.Left);
            Assert.IsNull(avlTree.Root.Right.Right);

            Assert.AreEqual<int>(1, avlTree.Root.Height);
            Assert.AreEqual<int>(0, avlTree.Root.Left.Height);
            Assert.AreEqual<int>(0, avlTree.Root.Right.Height);

        }

        [TestMethod]
        [TestCategory("AVLTree.Delete")]
        public void Delete_ResultingIn_RightLeft()
        {
            AVLTree<int> avlTree = new AVLTree<int>();
            avlTree.Insert(100);
            avlTree.Insert(50);
            avlTree.Insert(150);
            avlTree.Insert(125);

            avlTree.Delete(50);

            Assert.IsNotNull(avlTree.Root);
            Assert.AreEqual<int>(125, avlTree.Root.Value);
            Assert.AreEqual<int>(100, avlTree.Root.Left.Value);
            Assert.AreEqual<int>(150, avlTree.Root.Right.Value);
            Assert.AreEqual<int>(3, avlTree.Count);
            Assert.IsNull(avlTree.Root.Left.Left);
            Assert.IsNull(avlTree.Root.Left.Right);
            Assert.IsNull(avlTree.Root.Right.Left);
            Assert.IsNull(avlTree.Root.Right.Right);

            Assert.AreEqual<int>(1, avlTree.Root.Height);
            Assert.AreEqual<int>(0, avlTree.Root.Left.Height);
            Assert.AreEqual<int>(0, avlTree.Root.Right.Height);
        }

        [TestMethod]
        [TestCategory("AVLTree.Delete")]
        public void Delete_ResultingIn_MultipleRebalances()
        {
            AVLTree<int> avlTree = new AVLTree<int>();
            avlTree.Insert(100);

            avlTree.Insert(50);
            avlTree.Insert(150);

            avlTree.Insert(25);
            avlTree.Insert(75);
            avlTree.Insert(125);
            avlTree.Insert(175);

            avlTree.Insert(30);
            avlTree.Insert(120);
            avlTree.Insert(130);
            avlTree.Insert(170);
            avlTree.Insert(180);
            avlTree.Insert(190);

            avlTree.Delete(75);

            Assert.IsNotNull(avlTree.Root);

            Assert.AreEqual<int>(150, avlTree.Root.Value);

            Assert.AreEqual<int>(100, avlTree.Root.Left.Value);
            Assert.AreEqual<int>(175, avlTree.Root.Right.Value);

            Assert.AreEqual<int>(30, avlTree.Root.Left.Left.Value);     // left of 100
            Assert.AreEqual<int>(125, avlTree.Root.Left.Right.Value);   // right of 100
            Assert.AreEqual<int>(170, avlTree.Root.Right.Left.Value);   // left of 175
            Assert.AreEqual<int>(180, avlTree.Root.Right.Right.Value);  // right of 175

            Assert.AreEqual<int>(25, avlTree.Root.Left.Left.Left.Value);     //left of 30
            Assert.AreEqual<int>(50, avlTree.Root.Left.Left.Right.Value);    // right of 30
            Assert.AreEqual<int>(120, avlTree.Root.Left.Right.Left.Value);   // left of 125
            Assert.AreEqual<int>(130, avlTree.Root.Left.Right.Right.Value);  // right of 125
            Assert.IsNull(avlTree.Root.Right.Left.Left);                     // left of 170
            Assert.IsNull(avlTree.Root.Right.Left.Right);                    // right of 170
            Assert.IsNull(avlTree.Root.Right.Right.Left);                    // left of 180
            Assert.AreEqual<int>(190, avlTree.Root.Right.Right.Right.Value); // right of 180

            Assert.AreEqual<int>(12, avlTree.Count);

            Assert.AreEqual<int>(3, avlTree.Root.Height);
            Assert.AreEqual<int>(2, avlTree.Root.Left.Height);
            Assert.AreEqual<int>(2, avlTree.Root.Right.Height);
            Assert.AreEqual<int>(1, avlTree.Root.Left.Left.Height);
            Assert.AreEqual<int>(1, avlTree.Root.Left.Right.Height);
            Assert.AreEqual<int>(0, avlTree.Root.Right.Left.Height);
            Assert.AreEqual<int>(1, avlTree.Root.Right.Right.Height);
            Assert.AreEqual<int>(0, avlTree.Root.Left.Left.Left.Height);
            Assert.AreEqual<int>(0, avlTree.Root.Left.Left.Right.Height);
            Assert.AreEqual<int>(0, avlTree.Root.Right.Right.Right.Height);
        }

        #endregion
    }
}
