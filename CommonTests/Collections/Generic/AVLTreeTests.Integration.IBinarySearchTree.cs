namespace CommonTestsInternal.Collections.Generic
{
    using System;
    using Common.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    public partial class AVLTreeTests : IBinarySearchTreeTests<RedBlackTree<int>>
    {

        #region IBinarySearchTree.Height

        [TestMethod]
        [TestCategory("AVLTree")]
        public override void Height_Empty()
        {
            base.Height_Empty();
        }

        [TestMethod]
        [TestCategory("AVLTree")]
        public override void Height_RootOnly()
        {
            base.Height_RootOnly();
        }

        [TestMethod]
        [TestCategory("AVLTree")]
        public override void Height_RootLeft()
        {
            base.Height_RootLeft();
        }

        [TestMethod]
        [TestCategory("AVLTree")]
        public override void Height_RootRight()
        {
            base.Height_RootRight();
        }

        [TestMethod]
        [TestCategory("AVLTree")]
        public override void Height_ThreeNodesFull()
        {
            base.Height_ThreeNodesFull();
        }

        [TestMethod]
        [TestCategory("AVLTree")]
        public override void Height_FourNodesLeftLeft()
        {
            base.Height_FourNodesLeftLeft();
        }

        [TestMethod]
        [TestCategory("AVLTree")]
        public override void Height_FourNodesLeftRight()
        {
            base.Height_FourNodesLeftRight();
        }

        [TestMethod]
        [TestCategory("AVLTree")]
        public override void Height_FourNodesRightLeft()
        {
            base.Height_FourNodesRightLeft();
        }

        [TestMethod]
        [TestCategory("AVLTree")]
        public override void Height_FourNodesRightRight()
        {
            base.Height_FourNodesRightRight();
        }

        [TestMethod]
        [TestCategory("AVLTree")]
        public override void Height_FiveNodesLeftFull()
        {
            base.Height_FiveNodesLeftFull();
        }

        #endregion

        #region IBinarySearchTree.Balance

        [TestMethod]
        [TestCategory("AVLTree")]
        public override void Balance_Empty()
        {
            base.Balance_Empty();
        }

        [TestMethod]
        [TestCategory("AVLTree")]
        public override void Balance_RootOnly()
        {
            base.Balance_RootOnly();
        }

        [TestMethod]
        [TestCategory("AVLTree")]
        public override void Balance_RootLeft()
        {
            base.Balance_RootLeft();
        }

        [TestMethod]
        [TestCategory("AVLTree")]
        public override void Balance_RootRight()
        {
            base.Balance_RootRight();
        }

        [TestMethod]
        [TestCategory("AVLTree")]
        public override void Balance_ThreeNodesFull()
        {
            base.Balance_ThreeNodesFull();
        }

        #endregion

        #region IBinarySearchTree Count

        [TestMethod]
        [TestCategory("AVLTree")]
        public override void Count_Empty()
        {
            base.Count_Empty();
        }

        [TestMethod]
        [TestCategory("AVLTree")]
        public override void Count_RootOnly()
        {
            base.Count_RootOnly();
        }

        [TestMethod]
        [TestCategory("AVLTree")]
        public override void Count_RootLeft()
        {
            base.Count_RootLeft();
        }

        [TestMethod]
        [TestCategory("AVLTree")]
        public override void Count_RootRight()
        {
            base.Count_RootRight();
        }

        [TestMethod]
        [TestCategory("AVLTree")]
        public override void Count_ThreeNodesFull()
        {
            base.Count_ThreeNodesFull();
        }

        [TestMethod]
        [TestCategory("AVLTree")]
        public override void Count_FourNodesLeftLeft()
        {
            base.Count_FourNodesLeftLeft();
        }

        [TestMethod]
        [TestCategory("AVLTree")]
        public override void Count_FourNodesLeftRight()
        {
            base.Count_FourNodesLeftRight();
        }

        [TestMethod]
        [TestCategory("AVLTree")]
        public override void Count_FourNodesRightLeft()
        {
            base.Count_FourNodesRightLeft();
        }

        [TestMethod]
        [TestCategory("AVLTree")]
        public override void Count_FourNodesRightRight()
        {
            base.Count_FourNodesRightRight();
        }

        [TestMethod]
        [TestCategory("AVLTree")]
        public override void Count_FiveNodesLeftFull()
        {
            base.Count_FiveNodesLeftFull();
        }

        #endregion

        #region IBinarySearchTree.InOrderIterator

        [TestMethod]
        [TestCategory("AVLTree")]
        public override void InOrderIterator_Empty()
        {
            base.InOrderIterator_Empty();
        }

        [TestMethod]
        [TestCategory("AVLTree")]
        public override void InOrderIterator_RootOnly()
        {
            base.InOrderIterator_RootOnly();
        }

        [TestMethod]
        [TestCategory("AVLTree")]
        public override void InOrderIterator_RootLeft()
        {
            base.InOrderIterator_RootLeft();
        }

        [TestMethod]
        [TestCategory("AVLTree")]
        public override void InOrderIterator_RootRight()
        {
            base.InOrderIterator_RootRight();
        }

        [TestMethod]
        [TestCategory("AVLTree")]
        public override void InOrderIterator_ThreeNodesFull()
        {
            base.InOrderIterator_ThreeNodesFull();
        }

        [TestMethod]
        [TestCategory("AVLTree")]
        public override void InOrderIterator_FourNodesLeftLeft()
        {
            base.InOrderIterator_FourNodesLeftLeft();
        }

        [TestMethod]
        [TestCategory("AVLTree")]
        public override void InOrderIterator_FourNodesLeftRight()
        {
            base.InOrderIterator_FourNodesLeftRight();
        }

        [TestMethod]
        [TestCategory("AVLTree")]
        public override void InOrderIterator_FourNodesRightLeft()
        {
            base.InOrderIterator_FourNodesRightLeft();
        }

        [TestMethod]
        [TestCategory("AVLTree")]
        public override void InOrderIterator_FourNodesRightRight()
        {
            base.InOrderIterator_FourNodesRightRight();
        }

        [TestMethod]
        [TestCategory("AVLTree")]
        public override void InOrderIterator_FiveNodesLeftFull()
        {
            base.InOrderIterator_FiveNodesLeftFull();
        }

        #endregion

        #region IBinarySearchTree.PostOrderIterator

        [TestMethod]
        [TestCategory("AVLTree")]
        public override void PostOrderIterator_Empty()
        {
            base.PostOrderIterator_Empty();
        }

        [TestMethod]
        [TestCategory("AVLTree")]
        public override void PostOrderIterator_RootOnly()
        {
            base.PostOrderIterator_RootOnly();
        }

        [TestMethod]
        [TestCategory("AVLTree")]
        public override void PostOrderIterator_RootLeft()
        {
            base.PostOrderIterator_RootLeft();
        }

        [TestMethod]
        [TestCategory("AVLTree")]
        public override void PostOrderIterator_RootRight()
        {
            base.PostOrderIterator_RootRight();
        }

        [TestMethod]
        [TestCategory("AVLTree")]
        public override void PostOrderIterator_ThreeNodesFull()
        {
            base.PostOrderIterator_ThreeNodesFull();
        }

        [TestMethod]
        [TestCategory("AVLTree")]
        public override void PostOrderIterator_FourNodesLeftLeft()
        {
            base.PostOrderIterator_FourNodesLeftLeft();
        }

        [TestMethod]
        [TestCategory("AVLTree")]
        public override void PostOrderIterator_FourNodesLeftRight()
        {
            base.PostOrderIterator_FourNodesLeftRight();
        }

        [TestMethod]
        [TestCategory("AVLTree")]
        public override void PostOrderIterator_FourNodesRightLeft()
        {
            base.PostOrderIterator_FourNodesRightLeft();
        }

        [TestMethod]
        [TestCategory("AVLTree")]
        public override void PostOrderIterator_FourNodesRightRight()
        {
            base.PostOrderIterator_FourNodesRightRight();
        }

        [TestMethod]
        [TestCategory("AVLTree")]
        public override void PostOrderIterator_FiveNodesLeftFull()
        {
            base.PostOrderIterator_FiveNodesLeftFull();
        }

        #endregion

        #region IBinarySearchTree.PreOrderIterator

        [TestMethod]
        [TestCategory("AVLTree")]
        public override void PreOrderIterator_Empty()
        {
            base.PreOrderIterator_Empty();
        }

        [TestMethod]
        [TestCategory("AVLTree")]
        public override void PreOrderIterator_RootOnly()
        {
            base.PreOrderIterator_RootOnly();
        }

        [TestMethod]
        [TestCategory("AVLTree")]
        public override void PreOrderIterator_RootLeft()
        {
            base.PreOrderIterator_RootLeft();
        }

        [TestMethod]
        [TestCategory("AVLTree")]
        public override void PreOrderIterator_RootRight()
        {
            base.PreOrderIterator_RootRight();
        }

        [TestMethod]
        [TestCategory("AVLTree")]
        public override void PreOrderIterator_ThreeNodesFull()
        {
            base.PreOrderIterator_ThreeNodesFull();
        }

        [TestMethod]
        [TestCategory("AVLTree")]
        public override void PreOrderIterator_FourNodesLeftLeft()
        {
            base.PreOrderIterator_FourNodesLeftLeft();
        }

        [TestMethod]
        [TestCategory("AVLTree")]
        public override void PreOrderIterator_FourNodesLeftRight()
        {
            base.PreOrderIterator_FourNodesLeftRight();
        }

        [TestMethod]
        [TestCategory("AVLTree")]
        public override void PreOrderIterator_FourNodesRightLeft()
        {
            base.PreOrderIterator_FourNodesRightLeft();
        }

        [TestMethod]
        [TestCategory("AVLTree")]
        public override void PreOrderIterator_FourNodesRightRight()
        {
            base.PreOrderIterator_FourNodesRightRight();
        }

        [TestMethod]
        [TestCategory("AVLTree")]
        public override void PreOrderIterator_FiveNodesLeftFull()
        {
            base.PreOrderIterator_FiveNodesLeftFull();
        }

        #endregion

        #region IBinarySearchTree.Insert

        [TestMethod]
        [TestCategory("AVLTree")]
        public override void Insert_IntoEmpty()
        {
            base.Insert_IntoEmpty();

            Assert.AreEqual<int>(50, InstanceEmpty.Root.Value);
            Assert.IsNull(InstanceEmpty.Root.Left);
            Assert.IsNull(InstanceEmpty.Root.Right);
        }

        [TestMethod]
        [TestCategory("AVLTree")]
        public override void Insert_IntoRootOnly_Smaller()
        {
            base.Insert_IntoRootOnly_Smaller();

            Assert.AreEqual<int>(50, InstanceRootOnly.Root.Value);
            Assert.AreEqual<int>(25, InstanceRootOnly.Root.Left.Value);

            Assert.IsNull(InstanceRootOnly.Root.Right);
            Assert.IsNull(InstanceRootOnly.Root.Left.Left);
            Assert.IsNull(InstanceRootOnly.Root.Left.Right);
        }

        [TestMethod]
        [TestCategory("AVLTree")]
        public override void Insert_IntoRootOnly_Larger()
        {
            base.Insert_IntoRootOnly_Larger();

            Assert.AreEqual<int>(50, InstanceRootOnly.Root.Value);
            Assert.AreEqual<int>(75, InstanceRootOnly.Root.Right.Value);

            Assert.IsNull(InstanceRootOnly.Root.Left);
            Assert.IsNull(InstanceRootOnly.Root.Right.Left);
            Assert.IsNull(InstanceRootOnly.Root.Right.Right);
        }

        [TestMethod]
        [TestCategory("AVLTree")]
        public override void Insert_ThirdNode_IntoRootLeft()
        {
            base.Insert_ThirdNode_IntoRootLeft();

            Assert.AreEqual<int>(50, InstanceRootLeft.Root.Value);
            Assert.AreEqual<int>(25, InstanceRootLeft.Root.Left.Value);
            Assert.AreEqual<int>(75, InstanceRootLeft.Root.Right.Value);

            Assert.IsNull(InstanceRootLeft.Root.Left.Left);
            Assert.IsNull(InstanceRootLeft.Root.Left.Right);
            Assert.IsNull(InstanceRootLeft.Root.Right.Left);
            Assert.IsNull(InstanceRootLeft.Root.Right.Right);
        }

        [TestMethod]
        [TestCategory("AVLTree")]
        public override void Insert_ThirdNode_IntoRootRight()
        {
            base.Insert_ThirdNode_IntoRootRight();

            Assert.AreEqual<int>(50, InstanceRootRight.Root.Value);
            Assert.AreEqual<int>(25, InstanceRootRight.Root.Left.Value);
            Assert.AreEqual<int>(75, InstanceRootRight.Root.Right.Value);

            Assert.IsNull(InstanceRootRight.Root.Left.Left);
            Assert.IsNull(InstanceRootRight.Root.Left.Right);
            Assert.IsNull(InstanceRootRight.Root.Right.Left);
            Assert.IsNull(InstanceRootRight.Root.Right.Right);
        }

        [TestMethod]
        [TestCategory("AVLTree")]
        public override void Insert_ThirdNodeAtStart_IntoRootLeft()
        {
            base.Insert_ThirdNodeAtStart_IntoRootLeft();

            Assert.AreEqual<int>(25, InstanceRootLeft.Root.Value);
            Assert.AreEqual<int>(13, InstanceRootLeft.Root.Left.Value);
            Assert.AreEqual<int>(50, InstanceRootLeft.Root.Right.Value);

            Assert.IsNull(InstanceRootLeft.Root.Left.Left);
            Assert.IsNull(InstanceRootLeft.Root.Left.Right);
            Assert.IsNull(InstanceRootLeft.Root.Right.Left);
            Assert.IsNull(InstanceRootLeft.Root.Right.Right);
        }

        [TestMethod]
        [TestCategory("AVLTree")]
        public override void Insert_ThirdNodeInMiddle_IntoRootLeft()
        {
            base.Insert_ThirdNodeInMiddle_IntoRootLeft();

            Assert.AreEqual<int>(32, InstanceRootLeft.Root.Value);
            Assert.AreEqual<int>(25, InstanceRootLeft.Root.Left.Value);
            Assert.AreEqual<int>(50, InstanceRootLeft.Root.Right.Value);

            Assert.IsNull(InstanceRootLeft.Root.Left.Left);
            Assert.IsNull(InstanceRootLeft.Root.Left.Right);
            Assert.IsNull(InstanceRootLeft.Root.Right.Left);
            Assert.IsNull(InstanceRootLeft.Root.Right.Right);
        }

        [TestMethod]
        [TestCategory("AVLTree")]
        public override void Insert_ThirdNodeAtEnd_IntoRootRight()
        {
            base.Insert_ThirdNodeAtEnd_IntoRootRight();

            Assert.AreEqual<int>(75, InstanceRootRight.Root.Value);
            Assert.AreEqual<int>(50, InstanceRootRight.Root.Left.Value);
            Assert.AreEqual<int>(100, InstanceRootRight.Root.Right.Value);

            Assert.IsNull(InstanceRootRight.Root.Left.Left);
            Assert.IsNull(InstanceRootRight.Root.Left.Right);
            Assert.IsNull(InstanceRootRight.Root.Right.Left);
            Assert.IsNull(InstanceRootRight.Root.Right.Right);
        }

        [TestMethod]
        [TestCategory("AVLTree")]
        public override void Insert_ThirdNodeInMiddle_IntoRootRight()
        {
            base.Insert_ThirdNodeInMiddle_IntoRootRight();

            Assert.AreEqual<int>(62, InstanceRootRight.Root.Value);
            Assert.AreEqual<int>(50, InstanceRootRight.Root.Left.Value);
            Assert.AreEqual<int>(75, InstanceRootRight.Root.Right.Value);

            Assert.IsNull(InstanceRootRight.Root.Left.Left);
            Assert.IsNull(InstanceRootRight.Root.Left.Right);
            Assert.IsNull(InstanceRootRight.Root.Right.Left);
            Assert.IsNull(InstanceRootRight.Root.Right.Right);
        }

        [TestMethod]
        [TestCategory("AVLTree")]
        [ExpectedException(typeof(ArgumentException))]
        public override void Insert_DuplicateAtRoot_OfThreeNodesFull()
        {
            base.Insert_DuplicateAtRoot_OfThreeNodesFull();
        }

        [TestMethod]
        [TestCategory("AVLTree")]
        [ExpectedException(typeof(ArgumentException))]
        public override void Insert_DuplicateInMiddle_OfFourNodesLeftLeft()
        {
            base.Insert_DuplicateInMiddle_OfFourNodesLeftLeft();
        }

        [TestMethod]
        [TestCategory("AVLTree")]
        [ExpectedException(typeof(ArgumentException))]
        public override void Insert_DuplicateInMiddle_OfFourNodesLeftRight()
        {
            base.Insert_DuplicateInMiddle_OfFourNodesLeftRight();
        }

        [TestMethod]
        [TestCategory("AVLTree")]
        [ExpectedException(typeof(ArgumentException))]
        public override void Insert_DuplicateInMiddle_OfFourNodesRightLeft()
        {
            base.Insert_DuplicateInMiddle_OfFourNodesRightLeft();
        }

        [TestMethod]
        [TestCategory("AVLTree")]
        [ExpectedException(typeof(ArgumentException))]
        public override void Insert_DuplicateInMiddle_OfFourNodesRightRight()
        {
            base.Insert_DuplicateInMiddle_OfFourNodesRightRight();
        }

        [TestMethod]
        [TestCategory("AVLTree")]
        [ExpectedException(typeof(ArgumentException))]
        public override void Insert_DuplicateAsLeaf_OfFourNodesLeftLeft()
        {
            base.Insert_DuplicateAsLeaf_OfFourNodesLeftLeft();
        }

        #endregion

        #region IBinarySearchTree.Contains

        [TestMethod]
        [TestCategory("AVLTree")]
        public override void Contains_EmptyTree()
        {
            base.Contains_EmptyTree();
        }

        [TestMethod]
        [TestCategory("AVLTree")]
        public override void Contains_RootOnly_NotFound()
        {
            base.Contains_RootOnly_NotFound();
        }

        [TestMethod]
        [TestCategory("AVLTree")]
        public override void Contains_RootOnly_Found()
        {
            base.Contains_RootOnly_Found();
        }

        [TestMethod]
        [TestCategory("AVLTree")]
        public override void Contains_RootLeft_FoundLeaf()
        {
            base.Contains_RootLeft_FoundLeaf();
        }

        [TestMethod]
        [TestCategory("AVLTree")]
        public override void Contains_RootRight_FoundLeaf()
        {
            base.Contains_RootRight_FoundLeaf();
        }

        [TestMethod]
        [TestCategory("AVLTree")]
        public override void Contains_ThreeNodesFull_FoundLeftLeaf()
        {
            base.Contains_ThreeNodesFull_FoundLeftLeaf();
        }

        [TestMethod]
        [TestCategory("AVLTree")]
        public override void Contains_ThreeNodesFull_FoundRightLeaf()
        {
            base.Contains_ThreeNodesFull_FoundRightLeaf();
        }

        [TestMethod]
        [TestCategory("AVLTree")]
        public override void Contains_BiggerTree_NotFound()
        {
            base.Contains_BiggerTree_NotFound();
        }

        [TestMethod]
        [TestCategory("AVLTree")]
        public override void Contains_BiggerTree_Found()
        {
            base.Contains_BiggerTree_Found();
        }

        #endregion

        #region IBinarySearchTree.Delete

        [TestMethod]
        [TestCategory("AVLTree")]
        public override void Delete_EmptyTree()
        {
            base.Delete_EmptyTree();

            Assert.IsNull(InstanceEmpty.Root);
        }

        [TestMethod]
        [TestCategory("AVLTree")]
        public override void Delete_RootOnly_NotFound()
        {
            base.Delete_RootOnly_NotFound();

            Assert.AreEqual<int>(50, InstanceRootOnly.Root.Value);
            Assert.IsNull(InstanceRootOnly.Root.Left);
            Assert.IsNull(InstanceRootOnly.Root.Right);
        }

        [TestMethod]
        [TestCategory("AVLTree")]
        public override void Delete_RootOnly_Found()
        {
            base.Delete_RootOnly_Found();

            Assert.IsNull(InstanceRootOnly.Root);
        }

        [TestMethod]
        [TestCategory("AVLTree")]
        public override void Delete_RootLeft_NotFound1()
        {
            base.Delete_RootLeft_NotFound1();

            Assert.AreEqual<int>(50, InstanceRootLeft.Root.Value);
            Assert.AreEqual<int>(25, InstanceRootLeft.Root.Left.Value);

            Assert.IsNull(InstanceRootLeft.Root.Left.Left);
            Assert.IsNull(InstanceRootLeft.Root.Left.Right);
            Assert.IsNull(InstanceRootLeft.Root.Right);
        }

        [TestMethod]
        [TestCategory("AVLTree")]
        public override void Delete_RootLeft_NotFound2()
        {
            base.Delete_RootLeft_NotFound2();

            Assert.AreEqual<int>(50, InstanceRootLeft.Root.Value);
            Assert.AreEqual<int>(25, InstanceRootLeft.Root.Left.Value);

            Assert.IsNull(InstanceRootLeft.Root.Left.Left);
            Assert.IsNull(InstanceRootLeft.Root.Left.Right);
            Assert.IsNull(InstanceRootLeft.Root.Right);
        }

        [TestMethod]
        [TestCategory("AVLTree")]
        public override void Delete_RootLeft_NotFound3()
        {
            base.Delete_RootLeft_NotFound3();

            Assert.AreEqual<int>(50, InstanceRootLeft.Root.Value);
            Assert.AreEqual<int>(25, InstanceRootLeft.Root.Left.Value);

            Assert.IsNull(InstanceRootLeft.Root.Left.Left);
            Assert.IsNull(InstanceRootLeft.Root.Left.Right);
            Assert.IsNull(InstanceRootLeft.Root.Right);
        }

        [TestMethod]
        [TestCategory("AVLTree")]
        public override void Delete_RootRight_NotFound1()
        {
            base.Delete_RootRight_NotFound1();

            Assert.AreEqual<int>(50, InstanceRootRight.Root.Value);
            Assert.AreEqual<int>(75, InstanceRootRight.Root.Right.Value);

            Assert.IsNull(InstanceRootRight.Root.Left);
            Assert.IsNull(InstanceRootRight.Root.Right.Left);
            Assert.IsNull(InstanceRootRight.Root.Right.Right);
        }

        [TestMethod]
        [TestCategory("AVLTree")]
        public override void Delete_RootRight_NotFound2()
        {
            base.Delete_RootRight_NotFound2();

            Assert.AreEqual<int>(50, InstanceRootRight.Root.Value);
            Assert.AreEqual<int>(75, InstanceRootRight.Root.Right.Value);

            Assert.IsNull(InstanceRootRight.Root.Left);
            Assert.IsNull(InstanceRootRight.Root.Right.Left);
            Assert.IsNull(InstanceRootRight.Root.Right.Right);
        }

        [TestMethod]
        [TestCategory("AVLTree")]
        public override void Delete_RootRight_NotFound3()
        {
            base.Delete_RootRight_NotFound3();

            Assert.AreEqual<int>(50, InstanceRootRight.Root.Value);
            Assert.AreEqual<int>(75, InstanceRootRight.Root.Right.Value);

            Assert.IsNull(InstanceRootRight.Root.Left);
            Assert.IsNull(InstanceRootRight.Root.Right.Left);
            Assert.IsNull(InstanceRootRight.Root.Right.Right);
        }

        [TestMethod]
        [TestCategory("AVLTree")]
        public override void Delete_RootLeft_Root()
        {
            base.Delete_RootLeft_Root();

            Assert.AreEqual<int>(25, InstanceRootLeft.Root.Value);

            Assert.IsNull(InstanceRootLeft.Root.Left);
            Assert.IsNull(InstanceRootLeft.Root.Right);
        }

        [TestMethod]
        [TestCategory("AVLTree")]
        public override void Delete_RootRight_Root()
        {
            base.Delete_RootRight_Root();

            Assert.AreEqual<int>(75, InstanceRootRight.Root.Value);

            Assert.IsNull(InstanceRootRight.Root.Left);
            Assert.IsNull(InstanceRootRight.Root.Right);
        }

        [TestMethod]
        [TestCategory("AVLTree")]
        public override void Delete_RootLeft_Leaf()
        {
            base.Delete_RootLeft_Leaf();

            Assert.AreEqual<int>(50, InstanceRootLeft.Root.Value);

            Assert.IsNull(InstanceRootLeft.Root.Left);
            Assert.IsNull(InstanceRootLeft.Root.Right);
        }

        [TestMethod]
        [TestCategory("AVLTree")]
        public override void Delete_RootRight_Leaf()
        {
            base.Delete_RootRight_Leaf();

            Assert.AreEqual<int>(50, InstanceRootRight.Root.Value);

            Assert.IsNull(InstanceRootRight.Root.Left);
            Assert.IsNull(InstanceRootRight.Root.Right);
        }

        [TestMethod]
        [TestCategory("AVLTree")]
        public override void Delete_ThreeNodesFull_Root()
        {
            base.Delete_ThreeNodesFull_Root();

            Assert.AreEqual<int>(25, InstanceThreeNodesFull.Root.Value);
            Assert.AreEqual<int>(75, InstanceThreeNodesFull.Root.Right.Value);

            Assert.IsNull(InstanceThreeNodesFull.Root.Left);
            Assert.IsNull(InstanceThreeNodesFull.Root.Right.Left);
            Assert.IsNull(InstanceThreeNodesFull.Root.Right.Right);
        }

        [TestMethod]
        [TestCategory("AVLTree")]
        public override void Delete_ThreeNodesFull_LeftLeaf()
        {
            base.Delete_ThreeNodesFull_LeftLeaf();

            Assert.AreEqual<int>(50, InstanceThreeNodesFull.Root.Value);
            Assert.AreEqual<int>(75, InstanceThreeNodesFull.Root.Right.Value);

            Assert.IsNull(InstanceThreeNodesFull.Root.Left);
            Assert.IsNull(InstanceThreeNodesFull.Root.Right.Left);
            Assert.IsNull(InstanceThreeNodesFull.Root.Right.Right);
        }

        [TestMethod]
        [TestCategory("AVLTree")]
        public override void Delete_ThreeNodesFull_RightLeaf()
        {
            base.Delete_ThreeNodesFull_RightLeaf();

            Assert.AreEqual<int>(50, InstanceThreeNodesFull.Root.Value);
            Assert.AreEqual<int>(25, InstanceThreeNodesFull.Root.Left.Value);

            Assert.IsNull(InstanceThreeNodesFull.Root.Right);
            Assert.IsNull(InstanceThreeNodesFull.Root.Left.Left);
            Assert.IsNull(InstanceThreeNodesFull.Root.Left.Right);
        }

        [TestMethod]
        [TestCategory("AVLTree")]
        public override void Delete_FourNodesLeftLeft_HasParentAndChild()
        {
            base.Delete_FourNodesLeftLeft_HasParentAndChild();

            Assert.AreEqual<int>(50, InstanceFourNodesLeftLeft.Root.Value);
            Assert.AreEqual<int>(12, InstanceFourNodesLeftLeft.Root.Left.Value);
            Assert.AreEqual<int>(75, InstanceFourNodesLeftLeft.Root.Right.Value);

            Assert.IsNull(InstanceFourNodesLeftLeft.Root.Left.Left);
            Assert.IsNull(InstanceFourNodesLeftLeft.Root.Left.Right);
            Assert.IsNull(InstanceFourNodesLeftLeft.Root.Right.Left);
            Assert.IsNull(InstanceFourNodesLeftLeft.Root.Right.Right);
        }

        [TestMethod]
        [TestCategory("AVLTree")]
        public override void Delete_FourNodesLeftRight_Start()
        {
            base.Delete_FourNodesLeftRight_Start();

            Assert.AreEqual<int>(50, InstanceFourNodesLeftRight.Root.Value);
            Assert.AreEqual<int>(32, InstanceFourNodesLeftRight.Root.Left.Value);
            Assert.AreEqual<int>(75, InstanceFourNodesLeftRight.Root.Right.Value);

            Assert.IsNull(InstanceFourNodesLeftRight.Root.Left.Left);
            Assert.IsNull(InstanceFourNodesLeftRight.Root.Left.Right);
            Assert.IsNull(InstanceFourNodesLeftRight.Root.Right.Left);
            Assert.IsNull(InstanceFourNodesLeftRight.Root.Right.Right);
        }

        [TestMethod]
        [TestCategory("AVLTree")]
        public override void Delete_FourNodesRightLeft_End()
        {
            base.Delete_FourNodesRightLeft_End();

            Assert.AreEqual<int>(50, InstanceFourNodesRightLeft.Root.Value);
            Assert.AreEqual<int>(25, InstanceFourNodesRightLeft.Root.Left.Value);
            Assert.AreEqual<int>(63, InstanceFourNodesRightLeft.Root.Right.Value);

            Assert.IsNull(InstanceFourNodesRightLeft.Root.Left.Left);
            Assert.IsNull(InstanceFourNodesRightLeft.Root.Left.Right);
            Assert.IsNull(InstanceFourNodesRightLeft.Root.Right.Left);
            Assert.IsNull(InstanceFourNodesRightLeft.Root.Right.Right);
        }

        [TestMethod]
        [TestCategory("AVLTree")]
        public override void Delete_FourNodesRightRight_HasParentAndChild()
        {
            base.Delete_FourNodesRightRight_HasParentAndChild();

            Assert.AreEqual<int>(50, InstanceFourNodesRightRight.Root.Value);
            Assert.AreEqual<int>(25, InstanceFourNodesRightRight.Root.Left.Value);
            Assert.AreEqual<int>(100, InstanceFourNodesRightRight.Root.Right.Value);

            Assert.IsNull(InstanceFourNodesRightRight.Root.Left.Left);
            Assert.IsNull(InstanceFourNodesRightRight.Root.Left.Right);
            Assert.IsNull(InstanceFourNodesRightRight.Root.Right.Left);
            Assert.IsNull(InstanceFourNodesRightRight.Root.Right.Right);
        }

        [TestMethod]
        [TestCategory("AVLTree")]
        public override void Delete_FiveNodesLeftFull_HasBothChildren()
        {
            base.Delete_FiveNodesLeftFull_HasBothChildren();

            Assert.AreEqual<int>(50, InstanceFiveNodesLeftFull.Root.Value);
            Assert.AreEqual<int>(12, InstanceFiveNodesLeftFull.Root.Left.Value);
            Assert.AreEqual<int>(75, InstanceFiveNodesLeftFull.Root.Right.Value);
            Assert.AreEqual<int>(32, InstanceFiveNodesLeftFull.Root.Left.Right.Value);

            Assert.IsNull(InstanceFiveNodesLeftFull.Root.Left.Left);
            Assert.IsNull(InstanceFiveNodesLeftFull.Root.Left.Right.Left);
            Assert.IsNull(InstanceFiveNodesLeftFull.Root.Left.Right.Right);
            Assert.IsNull(InstanceFiveNodesLeftFull.Root.Right.Left);
            Assert.IsNull(InstanceFiveNodesLeftFull.Root.Right.Right);
        }

        #endregion

        #region IBinarySearchTree.Depth

        [TestMethod]
        [TestCategory("AVLTree")]
        [ExpectedException(typeof(ValueNotFoundException))]
        public override void Depth_Empty()
        {
            base.Depth_Empty();
        }

        [TestMethod]
        [TestCategory("AVLTree")]
        public override void Depth_RootOnly()
        {
            base.Depth_RootOnly();
        }

        [TestMethod]
        [TestCategory("AVLTree")]
        [ExpectedException(typeof(ValueNotFoundException))]
        public override void Depth_RootOnly_NotFound1()
        {
            base.Depth_RootOnly_NotFound1();
        }

        [TestMethod]
        [TestCategory("AVLTree")]
        [ExpectedException(typeof(ValueNotFoundException))]
        public override void Depth_RootOnly_NotFound2()
        {
            base.Depth_RootOnly_NotFound2();
        }

        [TestMethod]
        [TestCategory("AVLTree")]
        public override void Depth_RootLeft1()
        {
            base.Depth_RootLeft1();
        }

        [TestMethod]
        [TestCategory("AVLTree")]
        public override void Depth_RootLeft2()
        {
            base.Depth_RootLeft2();
        }

        [TestMethod]
        [TestCategory("AVLTree")]
        public override void Depth_RootRight1()
        {
            base.Depth_RootRight1();
        }

        [TestMethod]
        [TestCategory("AVLTree")]
        public override void Depth_RootRight2()
        {
            base.Depth_RootRight2();
        }

        [TestMethod]
        [TestCategory("AVLTree")]
        public override void Depth_FourNodesLeftLeft()
        {
            base.Depth_FourNodesLeftLeft();
        }

        [TestMethod]
        [TestCategory("AVLTree")]
        public override void Depth_FourNodesLeftRight()
        {
            base.Depth_FourNodesLeftRight();
        }

        [TestMethod]
        [TestCategory("AVLTree")]
        public override void Depth_FourNodesRightLeft()
        {
            base.Depth_FourNodesRightLeft();
        }

        [TestMethod]
        [TestCategory("AVLTree")]
        public override void Depth_FourNodesRightRight()
        {
            base.Depth_FourNodesRightRight();
        }

        [TestMethod]
        [TestCategory("AVLTree")]
        public override void Depth_FiveNodesLeftFull()
        {
            base.Depth_FiveNodesLeftFull();
        }

        [TestMethod]
        [TestCategory("AVLTree")]
        public override void Depth_ThreeNodesFull1()
        {
            base.Depth_ThreeNodesFull1();
        }

        [TestMethod]
        [TestCategory("AVLTree")]
        public override void Depth_ThreeNodesFull2()
        {
            base.Depth_ThreeNodesFull2();
        }

        [TestMethod]
        [TestCategory("AVLTree")]
        public override void Depth_ThreeNodesFull3()
        {
            base.Depth_ThreeNodesFull3();
        }

        #endregion

        #region IBinarySearchTree.AssertValidTree

        [TestMethod]
        [TestCategory("AVLTree")]
        public override void AssertValidTree_Empty()
        {
            base.AssertValidTree_Empty();
        }

        [TestMethod]
        [TestCategory("AVLTree")]
        public override void AssertValidTree_RootOnly()
        {
            base.AssertValidTree_RootOnly();
        }

        [TestMethod]
        [TestCategory("AVLTree")]
        public override void AssertValidTree_RootLeft()
        {
            base.AssertValidTree_RootLeft();
        }

        [TestMethod]
        [TestCategory("AVLTree")]
        public override void AssertValidTree_RootRight()
        {
            base.AssertValidTree_RootRight();
        }

        [TestMethod]
        [TestCategory("AVLTree")]
        public override void AssertValidTree_ThreeNodesFull()
        {
            base.AssertValidTree_ThreeNodesFull();
        }

        [TestMethod]
        [TestCategory("AVLTree")]
        public override void AssertValidTree_FourNodesLeftLeft()
        {
            base.AssertValidTree_FourNodesLeftLeft();
        }

        [TestMethod]
        [TestCategory("AVLTree")]
        public override void AssertValidTree_FourNodesLeftRight()
        {
            base.AssertValidTree_FourNodesLeftRight();
        }

        [TestMethod]
        [TestCategory("AVLTree")]
        public override void AssertValidTree_FourNodesRightLeft()
        {
            base.AssertValidTree_FourNodesRightLeft();
        }

        [TestMethod]
        [TestCategory("AVLTree")]
        public override void AssertValidTree_FourNodesRightRight()
        {
            base.AssertValidTree_FourNodesRightRight();
        }

        [TestMethod]
        [TestCategory("AVLTree")]
        public override void AssertValidTree_FiveNodesLeftFull()
        {
            base.AssertValidTree_FiveNodesLeftFull();
        }

        #endregion

    }
}
