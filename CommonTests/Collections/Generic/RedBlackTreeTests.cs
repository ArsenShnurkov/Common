namespace CommonTests.Collections.Generic
{
    using System;
    using Common.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class RedBlackTreeTests
    {

        #region RedBlackTree.Insert

        [TestMethod]
        [TestCategory("RedBlackTree")]
        public void Insert_IntoEmptyTree()
        {
            RedBlackTree<int> b = new RedBlackTree<int>();
            b.Insert(50);
            Assert.AreEqual<int>(0, b.Height);
            Assert.AreEqual<int>(0, b.Balance);
            Assert.AreEqual<int>(1, b.Count);
            Assert.AreEqual<int>(50, b.Root.Value);
            Assert.AreEqual<Colour>(Colour.Black, b.RootRaw.Colour);
        }

        [TestMethod]
        [TestCategory("RedBlackTree")]
        public void Insert_SecondNodeLeft()
        {
            RedBlackTree<int> b = new RedBlackTree<int>();
            b.Insert(50);
            b.Insert(25);

            Assert.AreEqual<int>(1, b.Height);
            Assert.AreEqual<int>(1, b.Balance);
            Assert.AreEqual<int>(2, b.Count);
            Assert.AreEqual<int>(50, b.Root.Value);
            Assert.AreEqual<int>(25, b.Root.Left.Value);
            Assert.AreEqual<Colour>(Colour.Black, b.RootRaw.Colour);
            Assert.AreEqual<Colour>(Colour.Red, b.RootRaw.Left.Colour);
        }

        [TestMethod]
        [TestCategory("RedBlackTree")]
        public void Insert_SecondNodeRight()
        {
            RedBlackTree<int> b = new RedBlackTree<int>();
            b.Insert(50);
            b.Insert(75);

            Assert.AreEqual<int>(1, b.Height);
            Assert.AreEqual<int>(-1, b.Balance);
            Assert.AreEqual<int>(2, b.Count);
            Assert.AreEqual<int>(50, b.Root.Value);
            Assert.AreEqual<int>(75, b.Root.Right.Value);
            Assert.AreEqual<Colour>(Colour.Black, b.RootRaw.Colour);
            Assert.AreEqual<Colour>(Colour.Red, b.RootRaw.Right.Colour);
        }

        [TestMethod]
        [TestCategory("RedBlackTree")]
        public void Insert_ThirdNodeFull()
        {
            RedBlackTree<int> b = new RedBlackTree<int>();
            b.Insert(10);
            b.Insert(1);
            b.Insert(20);

            Assert.AreEqual<int>(10, b.Root.Value);
            Assert.AreEqual<Colour>(Colour.Black, b.RootRaw.Colour);
            Assert.AreEqual<int>(1, b.Root.Left.Value);
            Assert.AreEqual<Colour>(Colour.Red, b.RootRaw.Left.Colour);
            Assert.AreEqual<int>(20, b.Root.Right.Value);
            Assert.AreEqual<Colour>(Colour.Red, b.RootRaw.Right.Colour);
        }


        [TestMethod]
        [TestCategory("RedBlackTree")]
        public void Insert_ThirdNodeLeftLeft_Case2_Left()
        {
            RedBlackTree<int> b = new RedBlackTree<int>();
            b.Insert(50);
            b.Insert(25);
            b.Insert(10);

            Assert.AreEqual<int>(1, b.Height);
            Assert.AreEqual<int>(0, b.Balance);
            Assert.AreEqual<int>(3, b.Count);
            Assert.AreEqual<int>(25, b.Root.Value);
            Assert.AreEqual<int>(50, b.Root.Right.Value);
            Assert.AreEqual<int>(10, b.Root.Left.Value);
            Assert.AreEqual<Colour>(Colour.Black, b.RootRaw.Colour);
            Assert.AreEqual<Colour>(Colour.Red, b.RootRaw.Left.Colour);
            Assert.AreEqual<Colour>(Colour.Red, b.RootRaw.Right.Colour);
        }

        [TestMethod]
        [TestCategory("RedBlackTree")]
        public void Insert_ThirdNodeLeftRight_Case3_Left()
        {
            RedBlackTree<int> b = new RedBlackTree<int>();
            b.Insert(50);
            b.Insert(25);
            b.Insert(40);

            Assert.AreEqual<int>(1, b.Height);
            Assert.AreEqual<int>(0, b.Balance);
            Assert.AreEqual<int>(3, b.Count);
            Assert.AreEqual<int>(40, b.Root.Value);
            Assert.AreEqual<int>(50, b.Root.Right.Value);
            Assert.AreEqual<int>(25, b.Root.Left.Value);
            Assert.AreEqual<Colour>(Colour.Black, b.RootRaw.Colour);
            Assert.AreEqual<Colour>(Colour.Red, b.RootRaw.Left.Colour);
            Assert.AreEqual<Colour>(Colour.Red, b.RootRaw.Right.Colour);
        }

        [TestMethod]
        [TestCategory("RedBlackTree")]
        public void Insert_ThirdNodeRightRight_Case2_Right()
        {
            RedBlackTree<int> b = new RedBlackTree<int>();
            b.Insert(50);
            b.Insert(75);
            b.Insert(100);

            Assert.AreEqual<int>(1, b.Height);
            Assert.AreEqual<int>(0, b.Balance);
            Assert.AreEqual<int>(3, b.Count);
            Assert.AreEqual<int>(75, b.Root.Value);
            Assert.AreEqual<int>(100, b.Root.Right.Value);
            Assert.AreEqual<int>(50, b.Root.Left.Value);
            Assert.AreEqual<Colour>(Colour.Black, b.RootRaw.Colour);
            Assert.AreEqual<Colour>(Colour.Red, b.RootRaw.Left.Colour);
            Assert.AreEqual<Colour>(Colour.Red, b.RootRaw.Right.Colour);
        }

        [TestMethod]
        [TestCategory("RedBlackTree")]
        public void Insert_ThirdNodeRightLeftCase3_Right()
        {
            RedBlackTree<int> b = new RedBlackTree<int>();
            b.Insert(50);
            b.Insert(75);
            b.Insert(60);

            Assert.AreEqual<int>(1, b.Height);
            Assert.AreEqual<int>(0, b.Balance);
            Assert.AreEqual<int>(3, b.Count);
            Assert.AreEqual<int>(60, b.Root.Value);
            Assert.AreEqual<int>(75, b.Root.Right.Value);
            Assert.AreEqual<int>(50, b.Root.Left.Value);
            Assert.AreEqual<Colour>(Colour.Black, b.RootRaw.Colour);
            Assert.AreEqual<Colour>(Colour.Red, b.RootRaw.Left.Colour);
            Assert.AreEqual<Colour>(Colour.Red, b.RootRaw.Right.Colour);
        }

        [TestMethod]
        [TestCategory("RedBlackTree")]
        public void Insert_ThirdNodeRightLeftCase1_Left()
        {
            RedBlackTree<int> b = new RedBlackTree<int>();
            b.Insert(10);
            b.Insert(20);
            b.Insert(5);
            b.Insert(1);

            Assert.AreEqual<int>(2, b.Height);
            Assert.AreEqual<int>(1, b.Balance);
            Assert.AreEqual<int>(4, b.Count);
            Assert.AreEqual<int>(10, b.Root.Value);
            Assert.AreEqual<int>(20, b.Root.Right.Value);
            Assert.AreEqual<int>(5, b.Root.Left.Value);
            Assert.AreEqual<int>(1, b.Root.Left.Left.Value);
            Assert.AreEqual<Colour>(Colour.Black, b.RootRaw.Colour);
            Assert.AreEqual<Colour>(Colour.Black, b.RootRaw.Left.Colour);
            Assert.AreEqual<Colour>(Colour.Black, b.RootRaw.Right.Colour);
            Assert.AreEqual<Colour>(Colour.Red, b.RootRaw.Left.Left.Colour);
        }

        [TestMethod]
        [TestCategory("RedBlackTree")]
        public void Insert_ThirdNodeRightLeftCase1_Right()
        {
            RedBlackTree<int> b = new RedBlackTree<int>();
            b.Insert(10);
            b.Insert(20);
            b.Insert(5);
            b.Insert(30);

            Assert.AreEqual<int>(2, b.Height);
            Assert.AreEqual<int>(-1, b.Balance);
            Assert.AreEqual<int>(4, b.Count);
            Assert.AreEqual<int>(10, b.Root.Value);
            Assert.AreEqual<int>(20, b.Root.Right.Value);
            Assert.AreEqual<int>(5, b.Root.Left.Value);
            Assert.AreEqual<int>(30, b.Root.Right.Right.Value);
            Assert.AreEqual<Colour>(Colour.Black, b.RootRaw.Colour);
            Assert.AreEqual<Colour>(Colour.Black, b.RootRaw.Left.Colour);
            Assert.AreEqual<Colour>(Colour.Black, b.RootRaw.Right.Colour);
            Assert.AreEqual<Colour>(Colour.Red, b.RootRaw.Right.Right.Colour);
        }

        #endregion

        #region RedBlackTree.Delete

        [TestMethod]
        [TestCategory("RedBlackTree")]
        [ExpectedException(typeof(TreeNotRootedException))]
        public void Delete_FromEmptyTree()
        {
            RedBlackTree<int> tree = new RedBlackTree<int>();
            tree.Delete(10);
        }

        [TestMethod]
        [TestCategory("RedBlackTree")]
        public void Delete_OnlyRoot()
        {
            RedBlackTree<int> tree = new RedBlackTree<int>();
            tree.Insert(10);
            tree.Delete(10);

            Assert.AreEqual<int>(0, tree.Count);
            Assert.AreEqual<int>(0, tree.Balance);
            Assert.AreEqual<int>(-1, tree.Height);
        }

        [TestMethod]
        [TestCategory("RedBlackTree")]
        public void Delete_RootWithLeftChild()
        {
            RedBlackTree<int> tree = new RedBlackTree<int>();
            tree.Insert(10);
            tree.Insert(5);
            tree.Delete(10);

            Assert.AreEqual<int>(1, tree.Count);
            Assert.AreEqual<int>(0, tree.Balance);
            Assert.AreEqual<int>(0, tree.Height);
            Assert.AreEqual<int>(5, tree.Root.Value);
            Assert.AreEqual<Colour>(Colour.Black, tree.RootRaw.Colour);
        }

        [TestMethod]
        [TestCategory("RedBlackTree")]
        public void Delete_RootWithRightChild()
        {
            RedBlackTree<int> tree = new RedBlackTree<int>();
            tree.Insert(10);
            tree.Insert(15);
            tree.Delete(10);

            Assert.AreEqual<int>(1, tree.Count);
            Assert.AreEqual<int>(0, tree.Balance);
            Assert.AreEqual<int>(0, tree.Height);
            Assert.AreEqual<int>(15, tree.Root.Value);
            Assert.AreEqual<Colour>(Colour.Black, tree.RootRaw.Colour);
        }

        [TestMethod]
        [TestCategory("RedBlackTree")]
        public void Delete_RootWithBothChildren()
        {
            RedBlackTree<int> tree = new RedBlackTree<int>();
            tree.Insert(10);
            tree.Insert(5);
            tree.Insert(15);
            tree.Delete(10);

            Assert.AreEqual<int>(2, tree.Count);
            Assert.AreEqual<int>(-1, tree.Balance);
            Assert.AreEqual<int>(1, tree.Height);
            Assert.AreEqual<int>(5, tree.Root.Value);
            Assert.AreEqual<Colour>(Colour.Black, tree.RootRaw.Colour);
            Assert.AreEqual<int>(15, tree.Root.Right.Value);
            Assert.AreEqual<Colour>(Colour.Red, tree.RootRaw.Right.Colour);
        }

        [TestMethod]
        [TestCategory("RedBlackTree")]
        public void Delete_LeftChildOfRootInFullTree()
        {
            RedBlackTree<int> tree = new RedBlackTree<int>();
            tree.Insert(10);
            tree.Insert(5);
            tree.Insert(15);
            tree.Delete(5);

            Assert.AreEqual<int>(2, tree.Count);
            Assert.AreEqual<int>(-1, tree.Balance);
            Assert.AreEqual<int>(1, tree.Height);
            Assert.AreEqual<int>(10, tree.Root.Value);
            Assert.AreEqual<Colour>(Colour.Black, tree.RootRaw.Colour);
            Assert.AreEqual<int>(15, tree.Root.Right.Value);
            Assert.AreEqual<Colour>(Colour.Red, tree.RootRaw.Right.Colour);
        }

        [TestMethod]
        [TestCategory("RedBlackTree")]
        public void Delete_RightChildOfRootInFullTree()
        {
            RedBlackTree<int> tree = new RedBlackTree<int>();
            tree.Insert(10);
            tree.Insert(5);
            tree.Insert(15);
            tree.Delete(15);

            Assert.AreEqual<int>(2, tree.Count);
            Assert.AreEqual<int>(1, tree.Balance);
            Assert.AreEqual<int>(1, tree.Height);
            Assert.AreEqual<int>(10, tree.Root.Value);
            Assert.AreEqual<Colour>(Colour.Black, tree.RootRaw.Colour);
            Assert.AreEqual<int>(5, tree.Root.Left.Value);
            Assert.AreEqual<Colour>(Colour.Red, tree.RootRaw.Left.Colour);
        }

        [TestMethod]
        [TestCategory("RedBlackTree")]
        public void Delete_RebalanceLeft()
        {
            RedBlackTree<int> tree = new RedBlackTree<int>();
            tree.Insert(1); //                2b
            tree.Insert(2); //               /  \
            tree.Insert(3); //             1b   4r
            tree.Insert(4); //                 /  \
            tree.Insert(5); //                3b   5b
            tree.Insert(6); //                        \6r

            tree.Delete(1); // delete the black 1 requiring a left rebalance

            Assert.AreEqual<int>(5, tree.Count);
            Assert.AreEqual<int>(0, tree.Balance);
            Assert.AreEqual<int>(2, tree.Height);

            Assert.AreEqual<int>(4, tree.Root.Value);
            Assert.AreEqual<Colour>(Colour.Black, tree.RootRaw.Colour);

            Assert.AreEqual<int>(2, tree.Root.Left.Value);
            Assert.AreEqual<Colour>(Colour.Black, tree.RootRaw.Left.Colour);
            Assert.AreEqual<int>(5, tree.Root.Right.Value);
            Assert.AreEqual<Colour>(Colour.Black, tree.RootRaw.Right.Colour);

            Assert.AreEqual<int>(3, tree.Root.Left.Right.Value);
            Assert.AreEqual<Colour>(Colour.Red, tree.RootRaw.Left.Right.Colour);

            Assert.AreEqual<int>(6, tree.Root.Right.Right.Value);
            Assert.AreEqual<Colour>(Colour.Red, tree.RootRaw.Right.Right.Colour);
        }

        [TestMethod]
        [TestCategory("RedBlackTree")]
        public void Delete_RebalanceRight()
        {
            RedBlackTree<int> tree = new RedBlackTree<int>();
            tree.Insert(6); //                5b
            tree.Insert(5); //               /  \
            tree.Insert(4); //             3r   6b
            tree.Insert(3); //            /  \
            tree.Insert(2); //           2b   4b
            tree.Insert(1); //        1r/

            tree.Delete(6); // delete the black 6 requiring a right rebalance

            Assert.AreEqual<int>(5, tree.Count);
            Assert.AreEqual<int>(0, tree.Balance);
            Assert.AreEqual<int>(2, tree.Height);

            Assert.AreEqual<int>(3, tree.Root.Value);
            Assert.AreEqual<Colour>(Colour.Black, tree.RootRaw.Colour);

            Assert.AreEqual<int>(2, tree.Root.Left.Value);
            Assert.AreEqual<Colour>(Colour.Black, tree.RootRaw.Left.Colour);
            Assert.AreEqual<int>(5, tree.Root.Right.Value);
            Assert.AreEqual<Colour>(Colour.Black, tree.RootRaw.Right.Colour);

            Assert.AreEqual<int>(4, tree.Root.Right.Left.Value);
            Assert.AreEqual<Colour>(Colour.Red, tree.RootRaw.Right.Left.Colour);

            Assert.AreEqual<int>(1, tree.Root.Left.Left.Value);
            Assert.AreEqual<Colour>(Colour.Red, tree.RootRaw.Left.Left.Colour);
        }

        [TestMethod]
        [TestCategory("RedBlackTree")]
        public void Delete_BlackChildOfRedWithOneRedChildRight()
        {
            RedBlackTree<int> tree = new RedBlackTree<int>();
            tree.Insert(10);
            tree.Insert(20);
            tree.Insert(5);
            tree.Insert(25);
            tree.Insert(15);
            tree.Insert(1);
            tree.Insert(7);
            tree.Insert(9);

            tree.Delete(7); // delete the black 6 requiring a right rebalance

            Assert.AreEqual<int>(7, tree.Count);
            Assert.AreEqual<int>(0, tree.Balance);
            Assert.AreEqual<int>(2, tree.Height);

            Assert.AreEqual<int>(10, tree.Root.Value);
            Assert.AreEqual<Colour>(Colour.Black, tree.RootRaw.Colour);

            Assert.AreEqual<int>(5, tree.Root.Left.Value);
            Assert.AreEqual<Colour>(Colour.Red, tree.RootRaw.Left.Colour);
            Assert.AreEqual<int>(20, tree.Root.Right.Value);
            Assert.AreEqual<Colour>(Colour.Black, tree.RootRaw.Right.Colour);

            Assert.AreEqual<int>(1, tree.Root.Left.Left.Value);
            Assert.AreEqual<Colour>(Colour.Black, tree.RootRaw.Left.Left.Colour);
            Assert.AreEqual<int>(9, tree.Root.Left.Right.Value);
            Assert.AreEqual<Colour>(Colour.Black, tree.RootRaw.Left.Right.Colour);
            Assert.AreEqual<int>(15, tree.Root.Right.Left.Value);
            Assert.AreEqual<Colour>(Colour.Red, tree.RootRaw.Right.Left.Colour);
            Assert.AreEqual<int>(25, tree.Root.Right.Right.Value);
            Assert.AreEqual<Colour>(Colour.Red, tree.RootRaw.Right.Right.Colour);
        }

        [TestMethod]
        [TestCategory("RedBlackTree")]
        public void Delete_BlackChildOfRedWithOneRedChildLeft()
        {
            RedBlackTree<int> tree = new RedBlackTree<int>();
            tree.Insert(10);
            tree.Insert(20);
            tree.Insert(5);
            tree.Insert(1);
            tree.Insert(7);
            tree.Insert(25);
            tree.Insert(15);
            tree.Insert(12);

            tree.Delete(15); // delete the black 6 requiring a right rebalance

            Assert.AreEqual<int>(7, tree.Count);
            Assert.AreEqual<int>(0, tree.Balance);
            Assert.AreEqual<int>(2, tree.Height);

            Assert.AreEqual<int>(10, tree.Root.Value);
            Assert.AreEqual<Colour>(Colour.Black, tree.RootRaw.Colour);

            Assert.AreEqual<int>(5, tree.Root.Left.Value);
            Assert.AreEqual<Colour>(Colour.Black, tree.RootRaw.Left.Colour);
            Assert.AreEqual<int>(20, tree.Root.Right.Value);
            Assert.AreEqual<Colour>(Colour.Red, tree.RootRaw.Right.Colour);

            Assert.AreEqual<int>(1, tree.Root.Left.Left.Value);
            Assert.AreEqual<Colour>(Colour.Red, tree.RootRaw.Left.Left.Colour);
            Assert.AreEqual<int>(7, tree.Root.Left.Right.Value);
            Assert.AreEqual<Colour>(Colour.Red, tree.RootRaw.Left.Right.Colour);
            Assert.AreEqual<int>(12, tree.Root.Right.Left.Value);
            Assert.AreEqual<Colour>(Colour.Black, tree.RootRaw.Right.Left.Colour);
            Assert.AreEqual<int>(25, tree.Root.Right.Right.Value);
            Assert.AreEqual<Colour>(Colour.Black, tree.RootRaw.Right.Right.Colour);
        }

        [TestMethod]
        [TestCategory("RedBlackTree")]
        public void Delete_BlackChildOfRedWithBlackSiblingThatHasRedChild_Left()
        {
            RedBlackTree<int> tree = new RedBlackTree<int>();
            tree.Insert(50);
            tree.Insert(100);
            tree.Insert(25);
            tree.Insert(150);
            tree.Insert(75);
            tree.Insert(10);
            tree.Insert(40);
            tree.Insert(30);

            tree.Delete(10); // delete the black 6 requiring a right rebalance

            Assert.AreEqual<int>(7, tree.Count);
            Assert.AreEqual<int>(0, tree.Balance);
            Assert.AreEqual<int>(2, tree.Height);

            Assert.AreEqual<int>(50, tree.Root.Value);
            Assert.AreEqual<Colour>(Colour.Black, tree.RootRaw.Colour);

            Assert.AreEqual<int>(30, tree.Root.Left.Value);
            Assert.AreEqual<Colour>(Colour.Red, tree.RootRaw.Left.Colour);
            Assert.AreEqual<int>(100, tree.Root.Right.Value);
            Assert.AreEqual<Colour>(Colour.Black, tree.RootRaw.Right.Colour);

            Assert.AreEqual<int>(25, tree.Root.Left.Left.Value);
            Assert.AreEqual<Colour>(Colour.Black, tree.RootRaw.Left.Left.Colour);
            Assert.AreEqual<int>(40, tree.Root.Left.Right.Value);
            Assert.AreEqual<Colour>(Colour.Black, tree.RootRaw.Left.Right.Colour);
            Assert.AreEqual<int>(75, tree.Root.Right.Left.Value);
            Assert.AreEqual<Colour>(Colour.Red, tree.RootRaw.Right.Left.Colour);
            Assert.AreEqual<int>(150, tree.Root.Right.Right.Value);
            Assert.AreEqual<Colour>(Colour.Red, tree.RootRaw.Right.Right.Colour);
        }

        [TestMethod]
        [TestCategory("RedBlackTree")]
        public void Delete_BlackChildOfRedWithBlackSiblingThatHasRedChild_Right()
        {
            RedBlackTree<int> tree = new RedBlackTree<int>();
            tree.Insert(50);
            tree.Insert(100);
            tree.Insert(25);
            tree.Insert(150);
            tree.Insert(75);
            tree.Insert(10);
            tree.Insert(40);
            tree.Insert(80);

            tree.Delete(150); // delete the black 6 requiring a right rebalance

            Assert.AreEqual<int>(7, tree.Count);
            Assert.AreEqual<int>(0, tree.Balance);
            Assert.AreEqual<int>(2, tree.Height);

            Assert.AreEqual<int>(50, tree.Root.Value);
            Assert.AreEqual<Colour>(Colour.Black, tree.RootRaw.Colour);

            Assert.AreEqual<int>(25, tree.Root.Left.Value);
            Assert.AreEqual<Colour>(Colour.Black, tree.RootRaw.Left.Colour);
            Assert.AreEqual<int>(80, tree.Root.Right.Value);
            Assert.AreEqual<Colour>(Colour.Red, tree.RootRaw.Right.Colour);

            Assert.AreEqual<int>(10, tree.Root.Left.Left.Value);
            Assert.AreEqual<Colour>(Colour.Red, tree.RootRaw.Left.Left.Colour);
            Assert.AreEqual<int>(40, tree.Root.Left.Right.Value);
            Assert.AreEqual<Colour>(Colour.Red, tree.RootRaw.Left.Right.Colour);
            Assert.AreEqual<int>(75, tree.Root.Right.Left.Value);
            Assert.AreEqual<Colour>(Colour.Black, tree.RootRaw.Right.Left.Colour);
            Assert.AreEqual<int>(100, tree.Root.Right.Right.Value);
            Assert.AreEqual<Colour>(Colour.Black, tree.RootRaw.Right.Right.Colour);
        }

        #endregion

        #region RedBlackTree.AssertTree

        [TestMethod]
        [TestCategory("RedBlackTree")]
        public void Assert_ValidTree()
        {
            RedBlackNode<int> root = new RedBlackNode<int>(100) { Colour = Colour.Black };
            root.Left = new RedBlackNode<int>(50) { Colour = Colour.Red };
            root.Right = new RedBlackNode<int>(150) { Colour = Colour.Red };

            RedBlackTree<int> bst = new RedBlackTree<int>();
            bst.Root = root;

            bst.AssertValidTree();
        }

        [TestMethod]
        [TestCategory("RedBlackTree")]
        [ExpectedException(typeof(InvalidTreeException))]
        public void Assert_InvalidTree_DoubleRed_Left()
        {
            RedBlackNode<int> root = new RedBlackNode<int>(100) { Colour = Colour.Black };
            root.Left = new RedBlackNode<int>(50) { Colour = Colour.Red };
            root.Right = new RedBlackNode<int>(150) { Colour = Colour.Red };
            root.Left.Left = new RedBlackNode<int>(40) { Colour = Colour.Red };

            RedBlackTree<int> bst = new RedBlackTree<int>();
            bst.Root = root;

            bst.AssertValidTree();
        }

        [TestMethod]
        [TestCategory("RedBlackTree")]
        [ExpectedException(typeof(InvalidTreeException))]
        public void Assert_InvalidTree_DoubleRed_Right()
        {
            RedBlackNode<int> root = new RedBlackNode<int>(100) { Colour = Colour.Black };
            root.Left = new RedBlackNode<int>(50) { Colour = Colour.Red };
            root.Right = new RedBlackNode<int>(150) { Colour = Colour.Red };
            root.Right.Right = new RedBlackNode<int>(160) { Colour = Colour.Red };

            RedBlackTree<int> bst = new RedBlackTree<int>();
            bst.Root = root;

            bst.AssertValidTree();
        }

        [TestMethod]
        [TestCategory("RedBlackTree")]
        [ExpectedException(typeof(InvalidTreeException))]
        public void Assert_InvalidTree_BlackMismatch_Left()
        {
            RedBlackNode<int> root = new RedBlackNode<int>(100) { Colour = Colour.Black };
            root.Left = new RedBlackNode<int>(50) { Colour = Colour.Red };
            root.Right = new RedBlackNode<int>(150) { Colour = Colour.Red };
            root.Left.Left = new RedBlackNode<int>(40) { Colour = Colour.Black };

            RedBlackTree<int> bst = new RedBlackTree<int>();
            bst.Root = root;

            bst.AssertValidTree();
        }

        [TestMethod]
        [TestCategory("RedBlackTree")]
        [ExpectedException(typeof(InvalidTreeException))]
        public void Assert_InvalidTree_BlackMismatch_Right()
        {
            RedBlackNode<int> root = new RedBlackNode<int>(100) { Colour = Colour.Black };
            root.Left = new RedBlackNode<int>(50) { Colour = Colour.Red };
            root.Right = new RedBlackNode<int>(150) { Colour = Colour.Red };
            root.Right.Right = new RedBlackNode<int>(160) { Colour = Colour.Black };

            RedBlackTree<int> bst = new RedBlackTree<int>();
            bst.Root = root;

            bst.AssertValidTree();
        }

        #endregion
    }
}
