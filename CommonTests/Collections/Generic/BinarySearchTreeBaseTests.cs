namespace CommonTestsInternal.Collections.Generic
{
    using System;
    using Common.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class BinarySearchTreeBaseTests
    {
        #region BinarySearchTree.Insert

        [TestMethod]
        [TestCategory("BinarySearchTreeBase")]
        public void Insert_IntoEmptyTree()
        {
            BinarySearchTreeBase<int> b = new BinarySearchTreeBase<int>();
            b.Insert(50);

            Assert.IsNotNull(b.Root);
            Assert.AreEqual<int>(50, b.Root.Value);
            Assert.AreEqual<int>(0, b.Height);
            Assert.AreEqual<int>(1, b.Count);
            Assert.AreEqual<int>(0, b.Balance);
        }

        [TestMethod]
        [TestCategory("BinarySearchTreeBase")]
        public void Insert_SecondNode_Left()
        {
            BinarySearchTreeBase<int> b = new BinarySearchTreeBase<int>();
            b.Insert(50);
            b.Insert(25);

            Assert.IsNotNull(b.Root);
            Assert.IsNotNull(b.Root.Left);
            Assert.IsNull(b.Root.Right);
            Assert.AreEqual<int>(50, b.Root.Value);
            Assert.AreEqual<int>(25, b.Root.Left.Value);
            Assert.AreEqual<int>(1, b.Height);
            Assert.AreEqual<int>(2, b.Count);
            Assert.AreEqual<int>(1, b.Balance);
        }

        [TestMethod]
        [TestCategory("BinarySearchTreeBase")]
        public void Insert_SecondNode_Right()
        {
            BinarySearchTreeBase<int> b = new BinarySearchTreeBase<int>();
            b.Insert(50);
            b.Insert(75);

            Assert.IsNotNull(b.Root);
            Assert.IsNotNull(b.Root.Right);
            Assert.IsNull(b.Root.Left);
            Assert.AreEqual<int>(50, b.Root.Value);
            Assert.AreEqual<int>(75, b.Root.Right.Value);
            Assert.AreEqual<int>(1, b.Height);
            Assert.AreEqual<int>(2, b.Count);
            Assert.AreEqual<int>(-1, b.Balance);
        }

        [TestMethod]
        [TestCategory("BinarySearchTreeBase")]
        public void Insert_ThirdNode_FullTree()
        {
            BinarySearchTreeBase<int> b = new BinarySearchTreeBase<int>();
            b.Insert(50);
            b.Insert(25);
            b.Insert(75);

            Assert.IsNotNull(b.Root);
            Assert.IsNotNull(b.Root.Right);
            Assert.IsNotNull(b.Root.Left);
            Assert.AreEqual<int>(50, b.Root.Value);
            Assert.AreEqual<int>(25, b.Root.Left.Value);
            Assert.AreEqual<int>(75, b.Root.Right.Value);
            Assert.AreEqual<int>(3, b.Count);
            Assert.AreEqual<int>(1, b.Height);
            Assert.AreEqual<int>(0, b.Balance);
        }

        [TestMethod]
        [TestCategory("BinarySearchTreeBase")]
        public void Insert_ThirdNode_LeftLeft()
        {
            BinarySearchTreeBase<int> b = new BinarySearchTreeBase<int>();
            b.Insert(50);
            b.Insert(25);
            b.Insert(13);

            Assert.IsNotNull(b.Root);

            Assert.IsNull(b.Root.Right);
            Assert.IsNotNull(b.Root.Left);

            Assert.IsNotNull(b.Root.Left.Left);
            Assert.IsNull(b.Root.Left.Right);

            Assert.AreEqual<int>(50, b.Root.Value);
            Assert.AreEqual<int>(25, b.Root.Left.Value);
            Assert.AreEqual<int>(13, b.Root.Left.Left.Value);
            Assert.AreEqual<int>(3, b.Count);
            Assert.AreEqual<int>(2, b.Height);
            Assert.AreEqual<int>(2, b.Balance);
        }

        [TestMethod]
        [TestCategory("BinarySearchTreeBase")]
        public void Insert_ThirdNode_LeftRight()
        {
            BinarySearchTreeBase<int> b = new BinarySearchTreeBase<int>();
            b.Insert(50);
            b.Insert(25);
            b.Insert(32);

            Assert.IsNotNull(b.Root);

            Assert.IsNull(b.Root.Right);
            Assert.IsNotNull(b.Root.Left);

            Assert.IsNull(b.Root.Left.Left);
            Assert.IsNotNull(b.Root.Left.Right);

            Assert.AreEqual<int>(50, b.Root.Value);
            Assert.AreEqual<int>(25, b.Root.Left.Value);
            Assert.AreEqual<int>(32, b.Root.Left.Right.Value);
            Assert.AreEqual<int>(3, b.Count);
            Assert.AreEqual<int>(2, b.Height);
            Assert.AreEqual<int>(2, b.Balance);
        }

        [TestMethod]
        [TestCategory("BinarySearchTreeBase")]
        public void Insert_ThirdNode_RightLeft()
        {
            BinarySearchTreeBase<int> b = new BinarySearchTreeBase<int>();
            b.Insert(50);
            b.Insert(75);
            b.Insert(63);

            Assert.IsNotNull(b.Root);

            Assert.IsNotNull(b.Root.Right);
            Assert.IsNull(b.Root.Left);

            Assert.IsNotNull(b.Root.Right.Left);
            Assert.IsNull(b.Root.Right.Right);

            Assert.AreEqual<int>(50, b.Root.Value);
            Assert.AreEqual<int>(75, b.Root.Right.Value);
            Assert.AreEqual<int>(63, b.Root.Right.Left.Value);
            Assert.AreEqual<int>(3, b.Count);
            Assert.AreEqual<int>(2, b.Height);
            Assert.AreEqual<int>(-2, b.Balance);
        }

        [TestMethod]
        [TestCategory("BinarySearchTreeBase")]
        public void Insert_ThirdNode_RightRight()
        {
            BinarySearchTreeBase<int> b = new BinarySearchTreeBase<int>();
            b.Insert(50);
            b.Insert(75);
            b.Insert(100);

            Assert.IsNotNull(b.Root);

            Assert.IsNotNull(b.Root.Right);
            Assert.IsNull(b.Root.Left);

            Assert.IsNull(b.Root.Right.Left);
            Assert.IsNotNull(b.Root.Right.Right);

            Assert.AreEqual<int>(50, b.Root.Value);
            Assert.AreEqual<int>(75, b.Root.Right.Value);
            Assert.AreEqual<int>(100, b.Root.Right.Right.Value);
            Assert.AreEqual<int>(3, b.Count);
            Assert.AreEqual<int>(2, b.Height);
            Assert.AreEqual<int>(-2, b.Balance);
        }

        [TestMethod]
        [TestCategory("BinarySearchTreeBase")]
        [ExpectedException(typeof(ArgumentException))]
        public void Insert_DuplicateAtRoot()
        {
            BinarySearchTreeBase<int> b = new BinarySearchTreeBase<int>();
            b.Insert(50);
            b.Insert(75);
            b.Insert(100);

            b.Insert(50);
        }

        [TestMethod]
        [TestCategory("BinarySearchTreeBase")]
        [ExpectedException(typeof(ArgumentException))]
        public void Insert_DuplicateInMiddle()
        {
            BinarySearchTreeBase<int> b = new BinarySearchTreeBase<int>();
            b.Insert(50);
            b.Insert(75);
            b.Insert(100);

            b.Insert(75);
        }

        [TestMethod]
        [TestCategory("BinarySearchTreeBase")]
        [ExpectedException(typeof(ArgumentException))]
        public void Insert_DuplicateAsLeaf()
        {
            BinarySearchTreeBase<int> b = new BinarySearchTreeBase<int>();
            b.Insert(50);
            b.Insert(75);
            b.Insert(100);

            b.Insert(100);
        }

        #endregion

        #region BinarySearchTree.Contains

        [TestMethod]
        [TestCategory("BinarySearchTreeBase")]
        [ExpectedException(typeof(TreeNotRootedException))]
        public void Contains_EmptyTree()
        {
            BinarySearchTreeBase<int> b = new BinarySearchTreeBase<int>();
            b.Contains(50);
        }

        [TestMethod]
        [TestCategory("BinarySearchTreeBase")]
        public void Contains_OnlyRoot_NotFound()
        {
            IBinarySearchTree<int> b = new BinarySearchTreeBase<int>();
            b.Insert(50);

            Assert.IsFalse(b.Contains(60));
        }

        [TestMethod]
        [TestCategory("BinarySearchTreeBase")]
        public void Contains_OnlyRoot_Found()
        {
            IBinarySearchTree<int> b = new BinarySearchTreeBase<int>();
            b.Insert(50);

            Assert.IsTrue(b.Contains(50));
        }

        [TestMethod]
        [TestCategory("BinarySearchTreeBase")]
        public void Contains_Height_Equals_1_Found_Left()
        {
            IBinarySearchTree<int> b = new BinarySearchTreeBase<int>();
            b.Insert(50);
            b.Insert(30);

            Assert.IsTrue(b.Contains(30));
        }

        [TestMethod]
        [TestCategory("BinarySearchTreeBase")]
        public void Contains_Height_Equals_1_Found_Right()
        {
            IBinarySearchTree<int> b = new BinarySearchTreeBase<int>();
            b.Insert(50);
            b.Insert(70);

            Assert.IsTrue(b.Contains(70));
        }

        [TestMethod]
        [TestCategory("BinarySearchTreeBase")]
        public void Contains_Height_Equals_1_FullTree_Found_Left()
        {
            IBinarySearchTree<int> b = new BinarySearchTreeBase<int>();
            b.Insert(50);
            b.Insert(30);
            b.Insert(70);

            Assert.IsTrue(b.Contains(30));
        }

        [TestMethod]
        [TestCategory("BinarySearchTreeBase")]
        public void Contains_Height_Equals_1_FullTree_Found_Right()
        {
            IBinarySearchTree<int> b = new BinarySearchTreeBase<int>();
            b.Insert(50);
            b.Insert(30);
            b.Insert(70);

            Assert.IsTrue(b.Contains(70));
        }

        [TestMethod]
        [TestCategory("BinarySearchTreeBase")]
        public void Contains_BiggerTree_NotFound()
        {
            IBinarySearchTree<int> b = new BinarySearchTreeBase<int>();
            b.Insert(100);

            b.Insert(50);
            b.Insert(150);

            b.Insert(25);
            b.Insert(75);
            b.Insert(125);
            b.Insert(175);

            b.Insert(30);
            b.Insert(160);

            Assert.IsFalse(b.Contains(200));
        }

        [TestMethod]
        [TestCategory("BinarySearchTreeBase")]
        public void Contains_BiggerTree_Found()
        {
            IBinarySearchTree<int> b = new BinarySearchTreeBase<int>();
            b.Insert(100);

            b.Insert(50);
            b.Insert(150);

            b.Insert(25);
            b.Insert(75);
            b.Insert(125);
            b.Insert(175);

            b.Insert(30);
            b.Insert(160);

            Assert.IsTrue(b.Contains(75));
            Assert.IsTrue(b.Contains(30));
        }

        #endregion

        #region BinarySearchTree.Delete

        [TestMethod]
        [TestCategory("BinarySearchTreeBase")]
        [ExpectedException(typeof(TreeNotRootedException))]
        public void Delete_EmptyTree()
        {
            BinarySearchTreeBase<int> b = new BinarySearchTreeBase<int>();
            b.Delete(50);
        }

        [TestMethod]
        [TestCategory("BinarySearchTreeBase")]
        [ExpectedException(typeof(NodeNotFoundException))]
        public void Delete_OnlyRoot_NotFound()
        {
            BinarySearchTreeBase<int> b = new BinarySearchTreeBase<int>();
            b.Insert(50);
            b.Delete(60);
        }

        [TestMethod]
        [TestCategory("BinarySearchTreeBase")]
        public void Delete_OnlyRoot_Found()
        {
            BinarySearchTreeBase<int> b = new BinarySearchTreeBase<int>();
            b.Insert(50);
            b.Delete(50);

            Assert.IsNotNull(b);
            Assert.IsNull(b.Root);
            Assert.AreEqual<int>(0, b.Count);
            Assert.AreEqual<int>(0, b.Balance);
            Assert.AreEqual<int>(-1, b.Height);
        }

        [TestMethod]
        [TestCategory("BinarySearchTreeBase")]
        public void Delete_LeftLeaf()
        {
            BinarySearchTreeBase<int> b = new BinarySearchTreeBase<int>();
            b.Insert(50);
            b.Insert(25);
            b.Delete(25);

            Assert.IsNotNull(b);
            Assert.IsNotNull(b.Root);
            Assert.AreEqual<int>(50, b.Root.Value);
            Assert.IsNull(b.Root.Left);
            Assert.IsNull(b.Root.Right);
            Assert.AreEqual<int>(1, b.Count);
            Assert.AreEqual<int>(0, b.Balance);
            Assert.AreEqual<int>(0, b.Height);
        }

        [TestMethod]
        [TestCategory("BinarySearchTreeBase")]
        public void Delete_RightLeaf()
        {
            BinarySearchTreeBase<int> b = new BinarySearchTreeBase<int>();
            b.Insert(50);
            b.Insert(75);
            b.Delete(75);

            Assert.IsNotNull(b);
            Assert.IsNotNull(b.Root);
            Assert.AreEqual<int>(50, b.Root.Value);
            Assert.IsNull(b.Root.Left);
            Assert.IsNull(b.Root.Right);
            Assert.AreEqual<int>(1, b.Count);
            Assert.AreEqual<int>(0, b.Balance);
            Assert.AreEqual<int>(0, b.Height);
        }

        [TestMethod]
        [TestCategory("BinarySearchTreeBase")]
        public void Delete_NodeThatOnlyHasRightChild()
        {
            BinarySearchTreeBase<int> b = new BinarySearchTreeBase<int>();
            b.Insert(50);
            b.Insert(75);
            b.Insert(100);
            b.Delete(75);

            Assert.IsNotNull(b);
            Assert.IsNotNull(b.Root);
            Assert.AreEqual<int>(50, b.Root.Value);
            Assert.AreEqual<int>(100, b.Root.Right.Value);
            Assert.IsNull(b.Root.Left);
            Assert.AreEqual<int>(2, b.Count);
            Assert.AreEqual<int>(-1, b.Balance);
            Assert.AreEqual<int>(1, b.Height);
        }

        [TestMethod]
        [TestCategory("BinarySearchTreeBase")]
        public void Delete_NodeThatOnlyHasLeftChild()
        {
            BinarySearchTreeBase<int> b = new BinarySearchTreeBase<int>();
            b.Insert(50);
            b.Insert(25);
            b.Insert(10);
            b.Delete(25);

            Assert.IsNotNull(b);
            Assert.IsNotNull(b.Root);
            Assert.AreEqual<int>(50, b.Root.Value);
            Assert.AreEqual<int>(10, b.Root.Left.Value);
            Assert.IsNull(b.Root.Right);
            Assert.AreEqual<int>(2, b.Count);
            Assert.AreEqual<int>(1, b.Balance);
            Assert.AreEqual<int>(1, b.Height);
        }

        [TestMethod]
        [TestCategory("BinarySearchTreeBase")]
        public void Delete_Node_ThatHasBothChildren()
        {
            BinarySearchTreeBase<int> b = new BinarySearchTreeBase<int>();
            b.Insert(50);
            b.Insert(25);
            b.Insert(75);

            b.Insert(20);
            b.Insert(30);

            b.Delete(25);

            Assert.IsNotNull(b);
            Assert.IsNotNull(b.Root);
            Assert.AreEqual<int>(50, b.Root.Value);
            Assert.AreEqual<int>(20, b.Root.Left.Value);
            Assert.AreEqual<int>(75, b.Root.Right.Value);
            Assert.AreEqual<int>(30, b.Root.Left.Right.Value);
            Assert.AreEqual<int>(4, b.Count);
            Assert.AreEqual<int>(1, b.Balance);
            Assert.AreEqual<int>(2, b.Height);
        }

        #endregion

        #region BinarySearchTree.Depth
        [TestMethod]
        [TestCategory("BinarySearchTreeBase")]
        [ExpectedException(typeof(TreeNotRootedException))]
        public void Depth_NoRoot()
        {
            IBinarySearchTree<int> b = new BinarySearchTreeBase<int>();
            int depth = b.Depth(10);
        }

        [TestMethod]
        [TestCategory("BinarySearchTreeBase")]
        public void Depth_OnlyRoot()
        {
            BinarySearchTreeBase<int> b = new BinarySearchTreeBase<int>();
            b.Root = new BinaryNode<int>(10);

            Assert.AreEqual<int>(0, b.Depth(10));
        }

        [TestMethod]
        [TestCategory("BinarySearchTreeBase")]
        public void DepthOfRoot()
        {
            BinarySearchTreeBase<int> b = new BinarySearchTreeBase<int>();
            b.Root = new BinaryNode<int>(10);
            b.Root.Left = new BinaryNode<int>(5);

            Assert.AreEqual<int>(0, b.Depth(10));
        }

        [TestMethod]
        [TestCategory("BinarySearchTreeBase")]
        public void SimpleTree_DepthOfLeaf()
        {
            BinarySearchTreeBase<int> b = new BinarySearchTreeBase<int>();
            b.Root = new BinaryNode<int>(10);
            b.Root.Left = new BinaryNode<int>(5);

            Assert.AreEqual<int>(1, b.Depth(5));
        }

        [TestMethod]
        [TestCategory("BinarySearchTreeBase")]
        public void Depth_Equals_1_Left()
        {
            BinarySearchTreeBase<int> b = new BinarySearchTreeBase<int>();
            b.Root = new BinaryNode<int>(100);
            b.Root.Left = new BinaryNode<int>(50);
            b.Root.Right = new BinaryNode<int>(150);

            b.Root.Left.Left = new BinaryNode<int>(25);
            b.Root.Left.Right = new BinaryNode<int>(75);

            b.Root.Right.Left = new BinaryNode<int>(125);
            b.Root.Right.Right = new BinaryNode<int>(175);

            b.Root.Left.Left.Right = new BinaryNode<int>(30);
            b.Root.Right.Right.Left = new BinaryNode<int>(160);

            Assert.AreEqual<int>(1, b.Depth(50));
        }

        [TestMethod]
        [TestCategory("BinarySearchTreeBase")]
        public void Depth_Equals_1_Right()
        {
            BinarySearchTreeBase<int> b = new BinarySearchTreeBase<int>();
            b.Root = new BinaryNode<int>(100);
            b.Root.Left = new BinaryNode<int>(50);
            b.Root.Right = new BinaryNode<int>(150);

            b.Root.Left.Left = new BinaryNode<int>(25);
            b.Root.Left.Right = new BinaryNode<int>(75);

            b.Root.Right.Left = new BinaryNode<int>(125);
            b.Root.Right.Right = new BinaryNode<int>(175);

            b.Root.Left.Left.Right = new BinaryNode<int>(30);
            b.Root.Right.Right.Left = new BinaryNode<int>(160);

            Assert.AreEqual<int>(1, b.Depth(150));
        }

        [TestMethod]
        [TestCategory("BinarySearchTreeBase")]
        public void Depth_Equals_2_LeftLeft()
        {
            BinarySearchTreeBase<int> b = new BinarySearchTreeBase<int>();
            b.Root = new BinaryNode<int>(100);
            b.Root.Left = new BinaryNode<int>(50);
            b.Root.Right = new BinaryNode<int>(150);

            b.Root.Left.Left = new BinaryNode<int>(25);
            b.Root.Left.Right = new BinaryNode<int>(75);

            b.Root.Right.Left = new BinaryNode<int>(125);
            b.Root.Right.Right = new BinaryNode<int>(175);

            b.Root.Left.Left.Right = new BinaryNode<int>(30);
            b.Root.Right.Right.Left = new BinaryNode<int>(160);

            Assert.AreEqual<int>(2, b.Depth(25));
        }

        [TestMethod]
        [TestCategory("BinarySearchTreeBase")]
        public void Depth_Equals_2_LeftRight()
        {
            BinarySearchTreeBase<int> b = new BinarySearchTreeBase<int>();
            b.Root = new BinaryNode<int>(100);
            b.Root.Left = new BinaryNode<int>(50);
            b.Root.Right = new BinaryNode<int>(150);

            b.Root.Left.Left = new BinaryNode<int>(25);
            b.Root.Left.Right = new BinaryNode<int>(75);

            b.Root.Right.Left = new BinaryNode<int>(125);
            b.Root.Right.Right = new BinaryNode<int>(175);

            b.Root.Left.Left.Right = new BinaryNode<int>(30);
            b.Root.Right.Right.Left = new BinaryNode<int>(160);

            Assert.AreEqual<int>(2, b.Depth(75));
        }

        [TestMethod]
        [TestCategory("BinarySearchTreeBase")]
        public void Depth_Equals_2_RightLeft()
        {
            BinarySearchTreeBase<int> b = new BinarySearchTreeBase<int>();
            b.Root = new BinaryNode<int>(100);
            b.Root.Left = new BinaryNode<int>(50);
            b.Root.Right = new BinaryNode<int>(150);

            b.Root.Left.Left = new BinaryNode<int>(25);
            b.Root.Left.Right = new BinaryNode<int>(75);

            b.Root.Right.Left = new BinaryNode<int>(125);
            b.Root.Right.Right = new BinaryNode<int>(175);

            b.Root.Left.Left.Right = new BinaryNode<int>(30);
            b.Root.Right.Right.Left = new BinaryNode<int>(160);

            Assert.AreEqual<int>(2, b.Depth(125));
        }

        [TestMethod]
        [TestCategory("BinarySearchTreeBase")]
        public void Depth_Equals_2_RightRight()
        {
            BinarySearchTreeBase<int> b = new BinarySearchTreeBase<int>();
            b.Root = new BinaryNode<int>(100);
            b.Root.Left = new BinaryNode<int>(50);
            b.Root.Right = new BinaryNode<int>(150);

            b.Root.Left.Left = new BinaryNode<int>(25);
            b.Root.Left.Right = new BinaryNode<int>(75);

            b.Root.Right.Left = new BinaryNode<int>(125);
            b.Root.Right.Right = new BinaryNode<int>(175);

            b.Root.Left.Left.Right = new BinaryNode<int>(30);
            b.Root.Right.Right.Left = new BinaryNode<int>(160);

            Assert.AreEqual<int>(2, b.Depth(175));
        }

        [TestMethod]
        [TestCategory("BinarySearchTreeBase")]
        public void Depth_Equals_3_LeftLeftRight()
        {
            BinarySearchTreeBase<int> b = new BinarySearchTreeBase<int>();
            b.Root = new BinaryNode<int>(100);
            b.Root.Left = new BinaryNode<int>(50);
            b.Root.Right = new BinaryNode<int>(150);

            b.Root.Left.Left = new BinaryNode<int>(25);
            b.Root.Left.Right = new BinaryNode<int>(75);

            b.Root.Right.Left = new BinaryNode<int>(125);
            b.Root.Right.Right = new BinaryNode<int>(175);

            b.Root.Left.Left.Right = new BinaryNode<int>(30);
            b.Root.Right.Right.Left = new BinaryNode<int>(160);

            Assert.AreEqual<int>(3, b.Depth(30));
        }

        [TestMethod]
        [TestCategory("BinarySearchTreeBase")]
        [ExpectedException(typeof(NodeNotFoundException))]
        public void Depth_NodeNotFound()
        {
            BinarySearchTreeBase<int> b = new BinarySearchTreeBase<int>();
            b.Root = new BinaryNode<int>(100);
            b.Root.Left = new BinaryNode<int>(50);
            b.Root.Right = new BinaryNode<int>(150);

            b.Root.Left.Left = new BinaryNode<int>(25);
            b.Root.Left.Right = new BinaryNode<int>(75);

            b.Root.Right.Left = new BinaryNode<int>(125);
            b.Root.Right.Right = new BinaryNode<int>(175);

            b.Root.Left.Left.Right = new BinaryNode<int>(30);
            b.Root.Right.Right.Left = new BinaryNode<int>(160);

            b.Depth(60);
        }
        #endregion

        #region BinarySearchTree.Traversals
        [TestMethod]
        [TestCategory("BinarySearchTreeBase")]
        [ExpectedException(typeof(TreeNotRootedException))]
        public void Inorder_EmptyTree()
        {
            IBinarySearchTree<int> b = new BinarySearchTreeBase<int>();

            var enumerator = b.InOrderIterator.GetEnumerator();
            enumerator.MoveNext();
        }

        [TestMethod]
        [TestCategory("BinarySearchTreeBase")]
        public void Inorder_BigTree()
        {
            IBinarySearchTree<int> b = new BinarySearchTreeBase<int>();
            b.Insert(100);

            b.Insert(50);
            b.Insert(150);

            b.Insert(25);
            b.Insert(75);
            b.Insert(125);
            b.Insert(175);

            b.Insert(30);
            b.Insert(160);

            var enumerator = b.InOrderIterator.GetEnumerator();

            enumerator.MoveNext();
            Assert.AreEqual<int>(25, enumerator.Current);
            enumerator.MoveNext();
            Assert.AreEqual<int>(30, enumerator.Current);
            enumerator.MoveNext();
            Assert.AreEqual<int>(50, enumerator.Current);
            enumerator.MoveNext();
            Assert.AreEqual<int>(75, enumerator.Current);
            enumerator.MoveNext();
            Assert.AreEqual<int>(100, enumerator.Current);
            enumerator.MoveNext();
            Assert.AreEqual<int>(125, enumerator.Current);
            enumerator.MoveNext();
            Assert.AreEqual<int>(150, enumerator.Current);
            enumerator.MoveNext();
            Assert.AreEqual<int>(160, enumerator.Current);
            enumerator.MoveNext();
            Assert.AreEqual<int>(175, enumerator.Current);
        }

        [TestMethod]
        [TestCategory("BinarySearchTreeBase")]
        [ExpectedException(typeof(TreeNotRootedException))]
        public void Preorder_EmptyTree()
        {
            IBinarySearchTree<int> b = new BinarySearchTreeBase<int>();

            var enumerator = b.PreOrderIterator.GetEnumerator();
            enumerator.MoveNext();
        }

        [TestMethod]
        [TestCategory("BinarySearchTreeBase")]
        public void Preorder_BigTree()
        {
            IBinarySearchTree<int> b = new BinarySearchTreeBase<int>();
            b.Insert(100);

            b.Insert(50);
            b.Insert(150);

            b.Insert(25);
            b.Insert(75);
            b.Insert(125);
            b.Insert(175);

            b.Insert(30);
            b.Insert(160);

            var enumerator = b.PreOrderIterator.GetEnumerator();

            enumerator.MoveNext();
            Assert.AreEqual<int>(100, enumerator.Current);
            enumerator.MoveNext();
            Assert.AreEqual<int>(50, enumerator.Current);
            enumerator.MoveNext();
            Assert.AreEqual<int>(25, enumerator.Current);
            enumerator.MoveNext();
            Assert.AreEqual<int>(30, enumerator.Current);
            enumerator.MoveNext();
            Assert.AreEqual<int>(75, enumerator.Current);
            enumerator.MoveNext();
            Assert.AreEqual<int>(150, enumerator.Current);
            enumerator.MoveNext();
            Assert.AreEqual<int>(125, enumerator.Current);
            enumerator.MoveNext();
            Assert.AreEqual<int>(175, enumerator.Current);
            enumerator.MoveNext();
            Assert.AreEqual<int>(160, enumerator.Current);
        }

        [TestMethod]
        [TestCategory("BinarySearchTreeBase")]
        [ExpectedException(typeof(TreeNotRootedException))]
        public void Postorder_EmptyTree()
        {
            IBinarySearchTree<int> b = new BinarySearchTreeBase<int>();

            var enumerator = b.PostOrderIterator.GetEnumerator();
            enumerator.MoveNext();
        }

        [TestMethod]
        [TestCategory("BinarySearchTreeBase")]
        public void Postorder_BigTree()
        {
            IBinarySearchTree<int> b = new BinarySearchTreeBase<int>();
            b.Insert(100);

            b.Insert(50);
            b.Insert(150);

            b.Insert(25);
            b.Insert(75);
            b.Insert(125);
            b.Insert(175);

            b.Insert(30);
            b.Insert(160);

            var enumerator = b.PostOrderIterator.GetEnumerator();

            enumerator.MoveNext();
            Assert.AreEqual<int>(30, enumerator.Current);
            enumerator.MoveNext();
            Assert.AreEqual<int>(25, enumerator.Current);
            enumerator.MoveNext();
            Assert.AreEqual<int>(75, enumerator.Current);
            enumerator.MoveNext();
            Assert.AreEqual<int>(50, enumerator.Current);
            enumerator.MoveNext();
            Assert.AreEqual<int>(125, enumerator.Current);
            enumerator.MoveNext();
            Assert.AreEqual<int>(160, enumerator.Current);
            enumerator.MoveNext();
            Assert.AreEqual<int>(175, enumerator.Current);
            enumerator.MoveNext();
            Assert.AreEqual<int>(150, enumerator.Current);
            enumerator.MoveNext();
            Assert.AreEqual<int>(100, enumerator.Current);
        }
        #endregion

        #region BinarySearchTree.AssertTree

        [TestMethod]
        [TestCategory("BinarySearchTreeBase")]
        public void Assert_ValidTree()
        {
            IInternalBinaryNode<int> root = new BinaryNode<int>(100);
            root.Left = new BinaryNode<int>(50);
            root.Right = new BinaryNode<int>(150);

            BinarySearchTreeBase<int> bst = new BinarySearchTreeBase<int>();
            bst.Root = root;

            bst.AssertValidTree();
        }

        [TestMethod]
        [TestCategory("BinarySearchTreeBase")]
        [ExpectedException(typeof(InvalidTreeException))]
        public void Assert_InvalidTree()
        {
            IInternalBinaryNode<int> root = new BinaryNode<int>(100);
            root.Right = new BinaryNode<int>(50);
            root.Left = new BinaryNode<int>(150);

            BinarySearchTreeBase<int> bst = new BinarySearchTreeBase<int>();
            bst.Root = root;

            bst.AssertValidTree();
        }

        #endregion

    }
}
