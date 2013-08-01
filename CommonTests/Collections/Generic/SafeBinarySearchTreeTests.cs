namespace CommonTests.Collections.Generic
{
    using System;
    using Common.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class SafeBinarySearchTreeTests
    {
        #region SafeBinarySearchTree.Insert

        [TestMethod]
        [TestCategory("SafeBinarySearchTree")]
        public void Insert_IntoEmptyTree()
        {
            SafeBinarySearchTree<int> b = new SafeBinarySearchTree<int>();
            b.Insert(50);

            Assert.IsNotNull(b.Root);
            Assert.AreEqual<int>(50, b.Root.Value);
            Assert.AreEqual<int>(0, b.Height);
            Assert.AreEqual<int>(1, b.Count);
            Assert.AreEqual<int>(0, b.Balance);
        }

        [TestMethod]
        [TestCategory("SafeBinarySearchTree")]
        public void Insert_SecondNode_Left()
        {
            SafeBinarySearchTree<int> b = new SafeBinarySearchTree<int>();
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
        [TestCategory("SafeBinarySearchTree")]
        public void Insert_SecondNode_Right()
        {
            SafeBinarySearchTree<int> b = new SafeBinarySearchTree<int>();
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
        [TestCategory("SafeBinarySearchTree")]
        public void Insert_ThirdNode_FullTree()
        {
            SafeBinarySearchTree<int> b = new SafeBinarySearchTree<int>();
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
        [TestCategory("SafeBinarySearchTree")]
        public void Insert_ThirdNode_LeftLeft()
        {
            SafeBinarySearchTree<int> b = new SafeBinarySearchTree<int>();
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
        [TestCategory("SafeBinarySearchTree")]
        public void Insert_ThirdNode_LeftRight()
        {
            SafeBinarySearchTree<int> b = new SafeBinarySearchTree<int>();
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
        [TestCategory("SafeBinarySearchTree")]
        public void Insert_ThirdNode_RightLeft()
        {
            SafeBinarySearchTree<int> b = new SafeBinarySearchTree<int>();
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
        [TestCategory("SafeBinarySearchTree")]
        public void Insert_ThirdNode_RightRight()
        {
            SafeBinarySearchTree<int> b = new SafeBinarySearchTree<int>();
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
        [TestCategory("SafeBinarySearchTree")]
        [ExpectedException(typeof(ArgumentException))]
        public void Insert_DuplicateAtRoot()
        {
            SafeBinarySearchTree<int> b = new SafeBinarySearchTree<int>();
            b.Insert(50);
            b.Insert(75);
            b.Insert(100);

            b.Insert(50);
        }

        [TestMethod]
        [TestCategory("SafeBinarySearchTree")]
        [ExpectedException(typeof(ArgumentException))]
        public void Insert_DuplicateInMiddle()
        {
            SafeBinarySearchTree<int> b = new SafeBinarySearchTree<int>();
            b.Insert(50);
            b.Insert(75);
            b.Insert(100);

            b.Insert(75);
        }

        [TestMethod]
        [TestCategory("SafeBinarySearchTree")]
        [ExpectedException(typeof(ArgumentException))]
        public void Insert_DuplicateAsLeaf()
        {
            SafeBinarySearchTree<int> b = new SafeBinarySearchTree<int>();
            b.Insert(50);
            b.Insert(75);
            b.Insert(100);

            b.Insert(100);
        }

        [TestMethod]
        [TestCategory("SafeBinarySearchTree")]
        public void Insert_InOrder_NoStackOverflow()
        {
            var bst = new SafeBinarySearchTree<int>();
            int n = 30000;
            for (int i = 0; i < n; ++i)
                bst.Insert(i);

            Assert.AreEqual<int>(n - 1, bst.Height);
            Assert.AreEqual<int>(n, bst.Count);
            Assert.AreEqual<int>(1-n, bst.Balance); 
        }

        #endregion

        #region SafeBinarySearchTree.Find

        [TestMethod]
        [TestCategory("SafeBinarySearchTree")]
        [ExpectedException(typeof(TreeNotRootedException))]
        public void Find_EmptyTree()
        {
            SafeBinarySearchTree<int> b = new SafeBinarySearchTree<int>();
            b.Find(50);
        }

        [TestMethod]
        [TestCategory("SafeBinarySearchTree")]
        [ExpectedException(typeof(NodeNotFoundException))]
        public void Find_OnlyRoot_NotFound()
        {
            IBinarySearchTree<int> b = new SafeBinarySearchTree<int>();
            b.Insert(50);

            b.Find(60);
        }

        [TestMethod]
        [TestCategory("SafeBinarySearchTree")]
        public void FindOrDefault_OnlyRoot_NotFound()
        {
            IBinarySearchTree<int> b = new SafeBinarySearchTree<int>();
            b.Insert(50);

            Assert.IsNull(b.FindOrDefault(60));
        }

        [TestMethod]
        [TestCategory("SafeBinarySearchTree")]
        public void Find_OnlyRoot_Found()
        {
            IBinarySearchTree<int> b = new SafeBinarySearchTree<int>();
            b.Insert(50);

            var result = b.Find(50);
            Assert.IsNotNull(result);
            Assert.AreEqual<int>(50, result.Value);
        }

        [TestMethod]
        [TestCategory("SafeBinarySearchTree")]
        public void Find_Height_Equals_1_Found_Left()
        {
            IBinarySearchTree<int> b = new SafeBinarySearchTree<int>();
            b.Insert(50);
            b.Insert(30);

            var result = b.Find(30);
            Assert.IsNotNull(result);
            Assert.AreEqual<int>(30, result.Value);
        }

        [TestMethod]
        [TestCategory("SafeBinarySearchTree")]
        public void Find_Height_Equals_1_Found_Right()
        {
            IBinarySearchTree<int> b = new SafeBinarySearchTree<int>();
            b.Insert(50);
            b.Insert(70);

            var result = b.Find(70);
            Assert.IsNotNull(result);
            Assert.AreEqual<int>(70, result.Value);
        }

        [TestMethod]
        [TestCategory("SafeBinarySearchTree")]
        public void Find_Height_Equals_1_FullTree_Found_Left()
        {
            IBinarySearchTree<int> b = new SafeBinarySearchTree<int>();
            b.Insert(50);
            b.Insert(30);
            b.Insert(70);

            var result = b.Find(30);
            Assert.IsNotNull(result);
            Assert.AreEqual<int>(30, result.Value);
        }

        [TestMethod]
        [TestCategory("SafeBinarySearchTree")]
        public void Find_Height_Equals_1_FullTree_Found_Right()
        {
            IBinarySearchTree<int> b = new SafeBinarySearchTree<int>();
            b.Insert(50);
            b.Insert(30);
            b.Insert(70);

            var result = b.Find(70);
            Assert.IsNotNull(result);
            Assert.AreEqual<int>(70, result.Value);
        }

        [TestMethod]
        [TestCategory("SafeBinarySearchTree")]
        [ExpectedException(typeof(NodeNotFoundException))]
        public void Find_BiggerTree_NotFound()
        {
            IBinarySearchTree<int> b = new SafeBinarySearchTree<int>();
            b.Insert(100);

            b.Insert(50);
            b.Insert(150);

            b.Insert(25);
            b.Insert(75);
            b.Insert(125);
            b.Insert(175);

            b.Insert(30);
            b.Insert(160);

            b.Find(200);
        }

        [TestMethod]
        [TestCategory("SafeBinarySearchTree")]
        [ExpectedException(typeof(NodeNotFoundException))]
        public void FindOrDefault_BiggerTree_NotFound()
        {
            IBinarySearchTree<int> b = new SafeBinarySearchTree<int>();
            b.Insert(100);

            b.Insert(50);
            b.Insert(150);

            b.Insert(25);
            b.Insert(75);
            b.Insert(125);
            b.Insert(175);

            b.Insert(30);
            b.Insert(160);

            Assert.IsNull(b.Find(200));
        }

        [TestMethod]
        [TestCategory("SafeBinarySearchTree")]
        public void Find_BiggerTree_Found_Part1()
        {
            IBinarySearchTree<int> b = new SafeBinarySearchTree<int>();
            b.Insert(100);

            b.Insert(50);
            b.Insert(150);

            b.Insert(25);
            b.Insert(75);
            b.Insert(125);
            b.Insert(175);

            b.Insert(30);
            b.Insert(160);

            var result = b.Find(75);

            Assert.IsNotNull(result);
            Assert.AreEqual<int>(75, result.Value);
        }

        [TestMethod]
        [TestCategory("SafeBinarySearchTree")]
        public void Find_BiggerTree_Found_Part2()
        {
            IBinarySearchTree<int> b = new SafeBinarySearchTree<int>();
            b.Insert(100);

            b.Insert(50);
            b.Insert(150);

            b.Insert(25);
            b.Insert(75);
            b.Insert(125);
            b.Insert(175);

            b.Insert(30);
            b.Insert(160);

            var result = b.Find(30);

            Assert.IsNotNull(result);
            Assert.AreEqual<int>(30, result.Value);
        }

        [TestMethod]
        [TestCategory("SafeBinarySearchTree")]
        public void Find_InOrder_NoStackOverflow()
        {
            var bst = new SafeBinarySearchTree<int>();
            int n = 30000;
            for (int i = 0; i < n; ++i)
                bst.Insert(i);

            Assert.IsNotNull(bst.Find(n-1));
        }

        #endregion

        #region SafeBinarySearchTree.Delete

        [TestMethod]
        [TestCategory("SafeBinarySearchTree")]
        [ExpectedException(typeof(TreeNotRootedException))]
        public void Delete_EmptyTree()
        {
            SafeBinarySearchTree<int> b = new SafeBinarySearchTree<int>();
            b.Delete(50);
        }

        [TestMethod]
        [TestCategory("SafeBinarySearchTree")]
        [ExpectedException(typeof(NodeNotFoundException))]
        public void Delete_OnlyRoot_NotFound()
        {
            SafeBinarySearchTree<int> b = new SafeBinarySearchTree<int>();
            b.Insert(50);
            b.Delete(60);
        }

        [TestMethod]
        [TestCategory("SafeBinarySearchTree")]
        public void Delete_OnlyRoot_Found()
        {
            SafeBinarySearchTree<int> b = new SafeBinarySearchTree<int>();
            b.Insert(50);
            b.Delete(50);

            Assert.IsNotNull(b);
            Assert.IsNull(b.Root);
            Assert.AreEqual<int>(0, b.Count);
            Assert.AreEqual<int>(0, b.Balance);
            Assert.AreEqual<int>(-1, b.Height);
        }

        [TestMethod]
        [TestCategory("SafeBinarySearchTree")]
        public void Delete_LeftLeaf()
        {
            SafeBinarySearchTree<int> b = new SafeBinarySearchTree<int>();
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
        [TestCategory("SafeBinarySearchTree")]
        public void Delete_RightLeaf()
        {
            SafeBinarySearchTree<int> b = new SafeBinarySearchTree<int>();
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
        [TestCategory("SafeBinarySearchTree")]
        public void Delete_NodeThatOnlyHasRightChild()
        {
            SafeBinarySearchTree<int> b = new SafeBinarySearchTree<int>();
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
        [TestCategory("SafeBinarySearchTree")]
        public void Delete_NodeThatOnlyHasLeftChild()
        {
            SafeBinarySearchTree<int> b = new SafeBinarySearchTree<int>();
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
        [TestCategory("SafeBinarySearchTree")]
        public void Delete_Node_ThatHasBothChildren()
        {
            SafeBinarySearchTree<int> b = new SafeBinarySearchTree<int>();
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

        [TestMethod]
        [TestCategory("SafeBinarySearchTree")]
        public void Delete_InOrder_NoStackOverflow()
        {
            var bst = new SafeBinarySearchTree<int>();
            int n = 30000;
            for (int i = 0; i < n; ++i)
                bst.Insert(i);

            bst.Delete(n-1);
        }

        #endregion

        #region SafeBinarySearchTree.Depth
        [TestMethod]
        [TestCategory("SafeBinarySearchTree")]
        [ExpectedException(typeof(TreeNotRootedException))]
        public void Depth_NoRoot()
        {
            IBinarySearchTree<int> b = new SafeBinarySearchTree<int>();
            int depth = b.Depth(10);
        }

        [TestMethod]
        [TestCategory("SafeBinarySearchTree")]
        public void Depth_OnlyRoot()
        {
            SafeBinarySearchTree<int> b = new SafeBinarySearchTree<int>();
            b.Root = new SafeBinaryNode<int>(10);

            Assert.AreEqual<int>(0, b.Depth(10));
        }

        [TestMethod]
        [TestCategory("SafeBinarySearchTree")]
        public void DepthOfRoot()
        {
            SafeBinarySearchTree<int> b = new SafeBinarySearchTree<int>();
            b.Root = new SafeBinaryNode<int>(10);
            b.Root.Left = new SafeBinaryNode<int>(5);

            Assert.AreEqual<int>(0, b.Depth(10));
        }

        [TestMethod]
        [TestCategory("SafeBinarySearchTree")]
        public void SimpleTree_DepthOfLeaf()
        {
            SafeBinarySearchTree<int> b = new SafeBinarySearchTree<int>();
            b.Root = new SafeBinaryNode<int>(10);
            b.Root.Left = new SafeBinaryNode<int>(5);

            Assert.AreEqual<int>(1, b.Depth(5));
        }

        [TestMethod]
        [TestCategory("SafeBinarySearchTree")]
        public void Depth_Equals_1_Left()
        {
            SafeBinarySearchTree<int> b = new SafeBinarySearchTree<int>();
            b.Root = new SafeBinaryNode<int>(100);
            b.Root.Left = new SafeBinaryNode<int>(50);
            b.Root.Right = new SafeBinaryNode<int>(150);

            b.Root.Left.Left = new SafeBinaryNode<int>(25);
            b.Root.Left.Right = new SafeBinaryNode<int>(75);

            b.Root.Right.Left = new SafeBinaryNode<int>(125);
            b.Root.Right.Right = new SafeBinaryNode<int>(175);

            b.Root.Left.Left.Right = new SafeBinaryNode<int>(30);
            b.Root.Right.Right.Left = new SafeBinaryNode<int>(160);

            Assert.AreEqual<int>(1, b.Depth(50));
        }

        [TestMethod]
        [TestCategory("SafeBinarySearchTree")]
        public void Depth_Equals_1_Right()
        {
            SafeBinarySearchTree<int> b = new SafeBinarySearchTree<int>();
            b.Root = new SafeBinaryNode<int>(100);
            b.Root.Left = new SafeBinaryNode<int>(50);
            b.Root.Right = new SafeBinaryNode<int>(150);

            b.Root.Left.Left = new SafeBinaryNode<int>(25);
            b.Root.Left.Right = new SafeBinaryNode<int>(75);

            b.Root.Right.Left = new SafeBinaryNode<int>(125);
            b.Root.Right.Right = new SafeBinaryNode<int>(175);

            b.Root.Left.Left.Right = new SafeBinaryNode<int>(30);
            b.Root.Right.Right.Left = new SafeBinaryNode<int>(160);

            Assert.AreEqual<int>(1, b.Depth(150));
        }

        [TestMethod]
        [TestCategory("SafeBinarySearchTree")]
        public void Depth_Equals_2_LeftLeft()
        {
            SafeBinarySearchTree<int> b = new SafeBinarySearchTree<int>();
            b.Root = new SafeBinaryNode<int>(100);
            b.Root.Left = new SafeBinaryNode<int>(50);
            b.Root.Right = new SafeBinaryNode<int>(150);

            b.Root.Left.Left = new SafeBinaryNode<int>(25);
            b.Root.Left.Right = new SafeBinaryNode<int>(75);

            b.Root.Right.Left = new SafeBinaryNode<int>(125);
            b.Root.Right.Right = new SafeBinaryNode<int>(175);

            b.Root.Left.Left.Right = new SafeBinaryNode<int>(30);
            b.Root.Right.Right.Left = new SafeBinaryNode<int>(160);

            Assert.AreEqual<int>(2, b.Depth(25));
        }

        [TestMethod]
        [TestCategory("SafeBinarySearchTree")]
        public void Depth_Equals_2_LeftRight()
        {
            SafeBinarySearchTree<int> b = new SafeBinarySearchTree<int>();
            b.Root = new SafeBinaryNode<int>(100);
            b.Root.Left = new SafeBinaryNode<int>(50);
            b.Root.Right = new SafeBinaryNode<int>(150);

            b.Root.Left.Left = new SafeBinaryNode<int>(25);
            b.Root.Left.Right = new SafeBinaryNode<int>(75);

            b.Root.Right.Left = new SafeBinaryNode<int>(125);
            b.Root.Right.Right = new SafeBinaryNode<int>(175);

            b.Root.Left.Left.Right = new SafeBinaryNode<int>(30);
            b.Root.Right.Right.Left = new SafeBinaryNode<int>(160);

            Assert.AreEqual<int>(2, b.Depth(75));
        }

        [TestMethod]
        [TestCategory("SafeBinarySearchTree")]
        public void Depth_Equals_2_RightLeft()
        {
            SafeBinarySearchTree<int> b = new SafeBinarySearchTree<int>();
            b.Root = new SafeBinaryNode<int>(100);
            b.Root.Left = new SafeBinaryNode<int>(50);
            b.Root.Right = new SafeBinaryNode<int>(150);

            b.Root.Left.Left = new SafeBinaryNode<int>(25);
            b.Root.Left.Right = new SafeBinaryNode<int>(75);

            b.Root.Right.Left = new SafeBinaryNode<int>(125);
            b.Root.Right.Right = new SafeBinaryNode<int>(175);

            b.Root.Left.Left.Right = new SafeBinaryNode<int>(30);
            b.Root.Right.Right.Left = new SafeBinaryNode<int>(160);

            Assert.AreEqual<int>(2, b.Depth(125));
        }

        [TestMethod]
        [TestCategory("SafeBinarySearchTree")]
        public void Depth_Equals_2_RightRight()
        {
            SafeBinarySearchTree<int> b = new SafeBinarySearchTree<int>();
            b.Root = new SafeBinaryNode<int>(100);
            b.Root.Left = new SafeBinaryNode<int>(50);
            b.Root.Right = new SafeBinaryNode<int>(150);

            b.Root.Left.Left = new SafeBinaryNode<int>(25);
            b.Root.Left.Right = new SafeBinaryNode<int>(75);

            b.Root.Right.Left = new SafeBinaryNode<int>(125);
            b.Root.Right.Right = new SafeBinaryNode<int>(175);

            b.Root.Left.Left.Right = new SafeBinaryNode<int>(30);
            b.Root.Right.Right.Left = new SafeBinaryNode<int>(160);

            Assert.AreEqual<int>(2, b.Depth(175));
        }

        [TestMethod]
        [TestCategory("SafeBinarySearchTree")]
        public void Depth_Equals_3_LeftLeftRight()
        {
            SafeBinarySearchTree<int> b = new SafeBinarySearchTree<int>();
            b.Root = new SafeBinaryNode<int>(100);
            b.Root.Left = new SafeBinaryNode<int>(50);
            b.Root.Right = new SafeBinaryNode<int>(150);

            b.Root.Left.Left = new SafeBinaryNode<int>(25);
            b.Root.Left.Right = new SafeBinaryNode<int>(75);

            b.Root.Right.Left = new SafeBinaryNode<int>(125);
            b.Root.Right.Right = new SafeBinaryNode<int>(175);

            b.Root.Left.Left.Right = new SafeBinaryNode<int>(30);
            b.Root.Right.Right.Left = new SafeBinaryNode<int>(160);

            Assert.AreEqual<int>(3, b.Depth(30));
        }

        [TestMethod]
        [TestCategory("SafeBinarySearchTree")]
        [ExpectedException(typeof(NodeNotFoundException))]
        public void Depth_NodeNotFound()
        {
            SafeBinarySearchTree<int> b = new SafeBinarySearchTree<int>();
            b.Root = new SafeBinaryNode<int>(100);
            b.Root.Left = new SafeBinaryNode<int>(50);
            b.Root.Right = new SafeBinaryNode<int>(150);

            b.Root.Left.Left = new SafeBinaryNode<int>(25);
            b.Root.Left.Right = new SafeBinaryNode<int>(75);

            b.Root.Right.Left = new SafeBinaryNode<int>(125);
            b.Root.Right.Right = new SafeBinaryNode<int>(175);

            b.Root.Left.Left.Right = new SafeBinaryNode<int>(30);
            b.Root.Right.Right.Left = new SafeBinaryNode<int>(160);

            b.Depth(60);
        }

        [TestMethod]
        [TestCategory("SafeBinarySearchTree")]
        public void Depth_InOrder_NoStackOverflow()
        {
            var bst = new SafeBinarySearchTree<int>();
            int n = 30000;
            for (int i = 0; i < n; ++i)
                bst.Insert(i);

            Assert.AreEqual<int>(n-1, bst.Depth(n-1));
        }

        #endregion

        #region SafeBinarySearchTree.Traversals
        [TestMethod]
        [TestCategory("SafeBinarySearchTree")]
        [ExpectedException(typeof(TreeNotRootedException))]
        public void Inorder_EmptyTree()
        {
            IBinarySearchTree<int> b = new SafeBinarySearchTree<int>();

            var enumerator = b.InOrderIterator.GetEnumerator();
            enumerator.MoveNext();
        }

        [TestMethod]
        [TestCategory("SafeBinarySearchTree")]
        public void Inorder_BigTree()
        {
            IBinarySearchTree<int> b = new SafeBinarySearchTree<int>();
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
        [TestCategory("SafeBinarySearchTree")]
        [ExpectedException(typeof(TreeNotRootedException))]
        public void Preorder_EmptyTree()
        {
            IBinarySearchTree<int> b = new SafeBinarySearchTree<int>();

            var enumerator = b.PreOrderIterator.GetEnumerator();
            enumerator.MoveNext();
        }

        [TestMethod]
        [TestCategory("SafeBinarySearchTree")]
        public void Preorder_BigTree()
        {
            IBinarySearchTree<int> b = new SafeBinarySearchTree<int>();
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
        [TestCategory("SafeBinarySearchTree")]
        [ExpectedException(typeof(TreeNotRootedException))]
        public void Postorder_EmptyTree()
        {
            IBinarySearchTree<int> b = new SafeBinarySearchTree<int>();

            var enumerator = b.PostOrderIterator.GetEnumerator();
            enumerator.MoveNext();
        }

        [TestMethod]
        [TestCategory("SafeBinarySearchTree")]
        public void Postorder_BigTree()
        {
            IBinarySearchTree<int> b = new SafeBinarySearchTree<int>();
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
    }
}
