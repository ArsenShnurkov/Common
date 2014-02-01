namespace CommonTestsInternal.Collections.Generic
{
    using System;
    using System.Collections.Generic;
    using Common.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public abstract class IBinarySearchTreeTests<T> where T : IBinarySearchTree<int>, new()
    {
        public TestContext TestContext { set; get; }

        #region Setup

        public IBinarySearchTree<int> Empty;
        public IBinarySearchTree<int> RootOnly;
        public IBinarySearchTree<int> RootLeft;
        public IBinarySearchTree<int> RootRight;
        public IBinarySearchTree<int> ThreeNodesFull;
        public IBinarySearchTree<int> FourNodesLeftLeft;
        public IBinarySearchTree<int> FourNodesLeftRight;
        public IBinarySearchTree<int> FourNodesRightLeft;
        public IBinarySearchTree<int> FourNodesRightRight;
        public IBinarySearchTree<int> FiveNodesLeftFull;
        public IBinarySearchTree<int> Bigger;

        [TestInitialize]
        public void InitTreesForTests()
        {
            if (TestContext.TestName.Contains("Empty"))
                this.InitEmptyTreeForTests();
            else if (TestContext.TestName.Contains("RootOnly"))
                this.InitRootOnlyForTests();
            else if (TestContext.TestName.Contains("RootLeft"))
                this.InitRootLeftForTests();
            else if (TestContext.TestName.Contains("RootRight"))
                this.InitRootRightForTests();
            else if (TestContext.TestName.Contains("ThreeNodesFull"))
                this.InitThreeNodesFullForTests();
            else if (TestContext.TestName.Contains("FourNodesLeftLeft"))
                this.InitFourNodesLeftLeft();
            else if (TestContext.TestName.Contains("FourNodesLeftRight"))
                this.InitFourNodesLeftRight();
            else if (TestContext.TestName.Contains("FourNodesRightLeft"))
                this.InitFourNodesRightLeft();
            else if (TestContext.TestName.Contains("FourNodesRightRight"))
                this.InitFourNodesRightRight();
            else if (TestContext.TestName.Contains("FiveNodesLeftFull"))
                this.InitFiveNodesLeftFullForTests();
            else if (TestContext.TestName.Contains("Bigger"))
                this.InitBiggerForTests();
            else
                this.InitCustomForTests();
        }

        public abstract void InitEmptyTreeForTests();
        public abstract void InitRootOnlyForTests();
        public abstract void InitRootLeftForTests();
        public abstract void InitRootRightForTests();
        public abstract void InitThreeNodesFullForTests();
        public abstract void InitFourNodesLeftLeft();
        public abstract void InitFourNodesLeftRight();
        public abstract void InitFourNodesRightLeft();
        public abstract void InitFourNodesRightRight();
        public abstract void InitFiveNodesLeftFullForTests();
        public abstract void InitBiggerForTests();
        public virtual void InitCustomForTests()
        {
        }

        [TestCleanup]
        public void CleanupFromTests()
        {
            Empty = null;
            RootOnly = null;
            RootLeft = null;
            RootRight = null;
            ThreeNodesFull = null;
            FourNodesLeftLeft = null;
            FourNodesLeftRight = null;
            FourNodesRightLeft = null;
            FourNodesRightRight = null;
            Bigger = null;
            CleanupCustom();
        }

        public virtual void CleanupCustom()
        {
        }

        #endregion

        #region IBinarySearchTree.Height

        [TestMethod]
        [TestCategory("IBinarySearchTree")]
        public virtual void Height_Empty()
        {
            Assert.AreEqual<int>(-1, Empty.Height);
        }

        [TestMethod]
        [TestCategory("IBinarySearchTree")]
        public virtual void Height_RootOnly()
        {
            Assert.AreEqual<int>(0, RootOnly.Height);
        }

        [TestMethod]
        [TestCategory("IBinarySearchTree")]
        public virtual void Height_RootLeft()
        {
            Assert.AreEqual<int>(1, RootLeft.Height);
        }

        [TestMethod]
        [TestCategory("IBinarySearchTree")]
        public virtual void Height_RootRight()
        {
            Assert.AreEqual<int>(1, RootRight.Height);
        }

        [TestMethod]
        [TestCategory("IBinarySearchTree")]
        public virtual void Height_ThreeNodesFull()
        {
            Assert.AreEqual<int>(1, ThreeNodesFull.Height);
        }

        [TestMethod]
        [TestCategory("IBinarySearchTree")]
        public virtual void Height_FourNodesLeftLeft()
        {
            Assert.AreEqual<int>(2, FourNodesLeftLeft.Height);
        }

        [TestMethod]
        [TestCategory("IBinarySearchTree")]
        public virtual void Height_FourNodesLeftRight()
        {
            Assert.AreEqual<int>(2, FourNodesLeftRight.Height);
        }

        [TestMethod]
        [TestCategory("IBinarySearchTree")]
        public virtual void Height_FourNodesRightLeft()
        {
            Assert.AreEqual<int>(2, FourNodesRightLeft.Height);
        }

        [TestMethod]
        [TestCategory("IBinarySearchTree")]
        public virtual void Height_FourNodesRightRight()
        {
            Assert.AreEqual<int>(2, FourNodesRightRight.Height);
        }

        [TestMethod]
        [TestCategory("IBinarySearchTree")]
        public virtual void Height_FiveNodesLeftFull()
        {
            Assert.AreEqual<int>(2, FiveNodesLeftFull.Height);
        }

        #endregion

        #region IBinarySearchTree.Balance

        [TestMethod]
        [TestCategory("IBinarySearchTree")]
        public virtual void Balance_Empty()
        {
            Assert.AreEqual<int>(0, Empty.Balance);
        }

        [TestMethod]
        [TestCategory("IBinarySearchTree")]
        public virtual void Balance_RootOnly()
        {
            Assert.AreEqual<int>(0, RootOnly.Balance);
        }

        [TestMethod]
        [TestCategory("IBinarySearchTree")]
        public virtual void Balance_RootLeft()
        {
            Assert.AreEqual<int>(1, RootLeft.Balance);
        }

        [TestMethod]
        [TestCategory("IBinarySearchTree")]
        public virtual void Balance_RootRight()
        {
            Assert.AreEqual<int>(-1, RootRight.Balance);
        }

        [TestMethod]
        [TestCategory("IBinarySearchTree")]
        public virtual void Balance_ThreeNodesFull()
        {
            Assert.AreEqual<int>(0, ThreeNodesFull.Balance);
        }

        #endregion

        #region IBinarySearchTree.Count

        [TestMethod]
        [TestCategory("IBinarySearchTree")]
        public virtual void Count_Empty()
        {
            Assert.AreEqual<int>(0, Empty.Count);
        }

        [TestMethod]
        [TestCategory("IBinarySearchTree")]
        public virtual void Count_RootOnly()
        {
            Assert.AreEqual<int>(1, RootOnly.Count);
        }

        [TestMethod]
        [TestCategory("IBinarySearchTree")]
        public virtual void Count_RootLeft()
        {
            Assert.AreEqual<int>(2, RootLeft.Count);
        }

        [TestMethod]
        [TestCategory("IBinarySearchTree")]
        public virtual void Count_RootRight()
        {
            Assert.AreEqual<int>(2, RootRight.Count);
        }

        [TestMethod]
        [TestCategory("IBinarySearchTree")]
        public virtual void Count_ThreeNodesFull()
        {
            Assert.AreEqual<int>(3, ThreeNodesFull.Count);
        }

        [TestMethod]
        [TestCategory("IBinarySearchTree")]
        public virtual void Count_FourNodesLeftLeft()
        {
            Assert.AreEqual<int>(4, FourNodesLeftLeft.Count);
        }

        [TestMethod]
        [TestCategory("IBinarySearchTree")]
        public virtual void Count_FourNodesLeftRight()
        {
            Assert.AreEqual<int>(4, FourNodesLeftRight.Count);
        }

        [TestMethod]
        [TestCategory("IBinarySearchTree")]
        public virtual void Count_FourNodesRightLeft()
        {
            Assert.AreEqual<int>(4, FourNodesRightLeft.Count);
        }

        [TestMethod]
        [TestCategory("IBinarySearchTree")]
        public virtual void Count_FourNodesRightRight()
        {
            Assert.AreEqual<int>(4, FourNodesRightRight.Count);
        }

        [TestMethod]
        [TestCategory("IBinarySearchTree")]
        public virtual void Count_FiveNodesLeftFull()
        {
            Assert.AreEqual<int>(5, FiveNodesLeftFull.Count);
        }

        #endregion

        #region IBinarySearchTree.InOrderIterator

        [TestMethod]
        [TestCategory("IBinarySearchTree")]
        public virtual void InOrderIterator_Empty()
        {
            IEnumerator<int> enumerator = Empty.InOrderIterator.GetEnumerator();
            Assert.IsFalse(enumerator.MoveNext());
        }

        [TestMethod]
        [TestCategory("IBinarySearchTree")]
        public virtual void InOrderIterator_RootOnly()
        {
            IEnumerator<int> enumerator = RootOnly.InOrderIterator.GetEnumerator();

            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual<int>(50, enumerator.Current);
            Assert.IsFalse(enumerator.MoveNext());
        }

        [TestMethod]
        [TestCategory("IBinarySearchTree")]
        public virtual void InOrderIterator_RootLeft()
        {
            IEnumerator<int> enumerator = RootLeft.InOrderIterator.GetEnumerator();

            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual<int>(25, enumerator.Current);
            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual<int>(50, enumerator.Current);
            Assert.IsFalse(enumerator.MoveNext());
        }

        [TestMethod]
        [TestCategory("IBinarySearchTree")]
        public virtual void InOrderIterator_RootRight()
        {
            IEnumerator<int> enumerator = RootRight.InOrderIterator.GetEnumerator();

            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual<int>(50, enumerator.Current);
            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual<int>(75, enumerator.Current);
            Assert.IsFalse(enumerator.MoveNext());
        }

        [TestMethod]
        [TestCategory("IBinarySearchTree")]
        public virtual void InOrderIterator_ThreeNodesFull()
        {
            IEnumerator<int> enumerator = ThreeNodesFull.InOrderIterator.GetEnumerator();

            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual<int>(25, enumerator.Current);
            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual<int>(50, enumerator.Current);
            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual<int>(75, enumerator.Current);
            Assert.IsFalse(enumerator.MoveNext());
        }

        [TestMethod]
        [TestCategory("IBinarySearchTree")]
        public virtual void InOrderIterator_FourNodesLeftLeft()
        {
            IEnumerator<int> enumerator = FourNodesLeftLeft.InOrderIterator.GetEnumerator();

            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual<int>(12, enumerator.Current);
            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual<int>(25, enumerator.Current);
            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual<int>(50, enumerator.Current);
            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual<int>(75, enumerator.Current);
            Assert.IsFalse(enumerator.MoveNext());
        }

        [TestMethod]
        [TestCategory("IBinarySearchTree")]
        public virtual void InOrderIterator_FourNodesLeftRight()
        {
            IEnumerator<int> enumerator = FourNodesLeftRight.InOrderIterator.GetEnumerator();

            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual<int>(25, enumerator.Current);
            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual<int>(32, enumerator.Current);
            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual<int>(50, enumerator.Current);
            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual<int>(75, enumerator.Current);
            Assert.IsFalse(enumerator.MoveNext());
        }

        [TestMethod]
        [TestCategory("IBinarySearchTree")]
        public virtual void InOrderIterator_FourNodesRightLeft()
        {
            IEnumerator<int> enumerator = FourNodesRightLeft.InOrderIterator.GetEnumerator();

            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual<int>(25, enumerator.Current);
            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual<int>(50, enumerator.Current);
            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual<int>(63, enumerator.Current);
            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual<int>(75, enumerator.Current);
            Assert.IsFalse(enumerator.MoveNext());
        }

        [TestMethod]
        [TestCategory("IBinarySearchTree")]
        public virtual void InOrderIterator_FourNodesRightRight()
        {
            IEnumerator<int> enumerator = FourNodesRightRight.InOrderIterator.GetEnumerator();

            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual<int>(25, enumerator.Current);
            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual<int>(50, enumerator.Current);
            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual<int>(75, enumerator.Current);
            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual<int>(100, enumerator.Current);
            Assert.IsFalse(enumerator.MoveNext());
        }

        [TestMethod]
        [TestCategory("IBinarySearchTree")]
        public virtual void InOrderIterator_FiveNodesLeftFull()
        {
            IEnumerator<int> enumerator = FiveNodesLeftFull.InOrderIterator.GetEnumerator();

            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual<int>(12, enumerator.Current);
            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual<int>(25, enumerator.Current);
            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual<int>(32, enumerator.Current);
            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual<int>(50, enumerator.Current);
            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual<int>(75, enumerator.Current);
            Assert.IsFalse(enumerator.MoveNext());
        }

        #endregion

        #region IBinarySearchTree.PostOrderIterator

        [TestMethod]
        [TestCategory("IBinarySearchTree")]
        public virtual void PostOrderIterator_Empty()
        {
            IEnumerator<int> enumerator = Empty.PostOrderIterator.GetEnumerator();
            Assert.IsFalse(enumerator.MoveNext());
        }

        [TestMethod]
        [TestCategory("IBinarySearchTree")]
        public virtual void PostOrderIterator_RootOnly()
        {
            IEnumerator<int> enumerator = RootOnly.PostOrderIterator.GetEnumerator();

            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual<int>(50, enumerator.Current);
            Assert.IsFalse(enumerator.MoveNext());
        }

        [TestMethod]
        [TestCategory("IBinarySearchTree")]
        public virtual void PostOrderIterator_RootLeft()
        {
            IEnumerator<int> enumerator = RootLeft.PostOrderIterator.GetEnumerator();

            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual<int>(25, enumerator.Current);
            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual<int>(50, enumerator.Current);
            Assert.IsFalse(enumerator.MoveNext());
        }

        [TestMethod]
        [TestCategory("IBinarySearchTree")]
        public virtual void PostOrderIterator_RootRight()
        {
            IEnumerator<int> enumerator = RootRight.PostOrderIterator.GetEnumerator();

            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual<int>(75, enumerator.Current);
            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual<int>(50, enumerator.Current);
            Assert.IsFalse(enumerator.MoveNext());
        }

        [TestMethod]
        [TestCategory("IBinarySearchTree")]
        public virtual void PostOrderIterator_ThreeNodesFull()
        {
            IEnumerator<int> enumerator = ThreeNodesFull.PostOrderIterator.GetEnumerator();

            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual<int>(25, enumerator.Current);
            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual<int>(75, enumerator.Current);
            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual<int>(50, enumerator.Current);
            Assert.IsFalse(enumerator.MoveNext());
        }

        [TestMethod]
        [TestCategory("IBinarySearchTree")]
        public virtual void PostOrderIterator_FourNodesLeftLeft()
        {
            IEnumerator<int> enumerator = FourNodesLeftLeft.PostOrderIterator.GetEnumerator();

            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual<int>(12, enumerator.Current);
            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual<int>(25, enumerator.Current);
            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual<int>(75, enumerator.Current);
            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual<int>(50, enumerator.Current);
            Assert.IsFalse(enumerator.MoveNext());
        }

        [TestMethod]
        [TestCategory("IBinarySearchTree")]
        public virtual void PostOrderIterator_FourNodesLeftRight()
        {
            IEnumerator<int> enumerator = FourNodesLeftRight.PostOrderIterator.GetEnumerator();

            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual<int>(32, enumerator.Current);
            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual<int>(25, enumerator.Current);
            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual<int>(75, enumerator.Current);
            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual<int>(50, enumerator.Current);
            Assert.IsFalse(enumerator.MoveNext());
        }

        [TestMethod]
        [TestCategory("IBinarySearchTree")]
        public virtual void PostOrderIterator_FourNodesRightLeft()
        {
            IEnumerator<int> enumerator = FourNodesRightLeft.PostOrderIterator.GetEnumerator();

            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual<int>(25, enumerator.Current);
            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual<int>(63, enumerator.Current);
            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual<int>(75, enumerator.Current);
            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual<int>(50, enumerator.Current);
            Assert.IsFalse(enumerator.MoveNext());
        }

        [TestMethod]
        [TestCategory("IBinarySearchTree")]
        public virtual void PostOrderIterator_FourNodesRightRight()
        {
            IEnumerator<int> enumerator = FourNodesRightRight.PostOrderIterator.GetEnumerator();

            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual<int>(25, enumerator.Current);
            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual<int>(100, enumerator.Current);
            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual<int>(75, enumerator.Current);
            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual<int>(50, enumerator.Current);
            Assert.IsFalse(enumerator.MoveNext());
        }

        [TestMethod]
        [TestCategory("IBinarySearchTree")]
        public virtual void PostOrderIterator_FiveNodesLeftFull()
        {
            IEnumerator<int> enumerator = FiveNodesLeftFull.PostOrderIterator.GetEnumerator();

            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual<int>(12, enumerator.Current);
            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual<int>(32, enumerator.Current);
            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual<int>(25, enumerator.Current);
            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual<int>(75, enumerator.Current);
            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual<int>(50, enumerator.Current);
            Assert.IsFalse(enumerator.MoveNext());
        }

        #endregion

        #region IBinarySearchTree.PreOrderIterator

        [TestMethod]
        [TestCategory("IBinarySearchTree")]
        public virtual void PreOrderIterator_Empty()
        {
            IEnumerator<int> enumerator = Empty.PreOrderIterator.GetEnumerator();
            Assert.IsFalse(enumerator.MoveNext());
        }

        [TestMethod]
        [TestCategory("IBinarySearchTree")]
        public virtual void PreOrderIterator_RootOnly()
        {
            IEnumerator<int> enumerator = RootOnly.PreOrderIterator.GetEnumerator();

            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual<int>(50, enumerator.Current);
            Assert.IsFalse(enumerator.MoveNext());
        }

        [TestMethod]
        [TestCategory("IBinarySearchTree")]
        public virtual void PreOrderIterator_RootLeft()
        {
            IEnumerator<int> enumerator = RootLeft.PreOrderIterator.GetEnumerator();

            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual<int>(50, enumerator.Current);
            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual<int>(25, enumerator.Current);
            Assert.IsFalse(enumerator.MoveNext());
        }

        [TestMethod]
        [TestCategory("IBinarySearchTree")]
        public virtual void PreOrderIterator_RootRight()
        {
            IEnumerator<int> enumerator = RootRight.PreOrderIterator.GetEnumerator();

            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual<int>(50, enumerator.Current);
            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual<int>(75, enumerator.Current);
            Assert.IsFalse(enumerator.MoveNext());
        }

        [TestMethod]
        [TestCategory("IBinarySearchTree")]
        public virtual void PreOrderIterator_ThreeNodesFull()
        {
            IEnumerator<int> enumerator = ThreeNodesFull.PreOrderIterator.GetEnumerator();

            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual<int>(50, enumerator.Current);
            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual<int>(25, enumerator.Current);
            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual<int>(75, enumerator.Current);
            Assert.IsFalse(enumerator.MoveNext());
        }

        [TestMethod]
        [TestCategory("IBinarySearchTree")]
        public virtual void PreOrderIterator_FourNodesLeftLeft()
        {
            IEnumerator<int> enumerator = FourNodesLeftLeft.PreOrderIterator.GetEnumerator();

            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual<int>(50, enumerator.Current);
            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual<int>(25, enumerator.Current);
            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual<int>(12, enumerator.Current);
            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual<int>(75, enumerator.Current);
            Assert.IsFalse(enumerator.MoveNext());
        }

        [TestMethod]
        [TestCategory("IBinarySearchTree")]
        public virtual void PreOrderIterator_FourNodesLeftRight()
        {
            IEnumerator<int> enumerator = FourNodesLeftRight.PreOrderIterator.GetEnumerator();

            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual<int>(50, enumerator.Current);
            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual<int>(25, enumerator.Current);
            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual<int>(32, enumerator.Current);
            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual<int>(75, enumerator.Current);
            Assert.IsFalse(enumerator.MoveNext());
        }

        [TestMethod]
        [TestCategory("IBinarySearchTree")]
        public virtual void PreOrderIterator_FourNodesRightLeft()
        {
            IEnumerator<int> enumerator = FourNodesRightLeft.PreOrderIterator.GetEnumerator();

            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual<int>(50, enumerator.Current);
            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual<int>(25, enumerator.Current);
            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual<int>(75, enumerator.Current);
            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual<int>(63, enumerator.Current);
            Assert.IsFalse(enumerator.MoveNext());
        }

        [TestMethod]
        [TestCategory("IBinarySearchTree")]
        public virtual void PreOrderIterator_FourNodesRightRight()
        {
            IEnumerator<int> enumerator = FourNodesRightRight.PreOrderIterator.GetEnumerator();

            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual<int>(50, enumerator.Current);
            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual<int>(25, enumerator.Current);
            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual<int>(75, enumerator.Current);
            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual<int>(100, enumerator.Current);
            Assert.IsFalse(enumerator.MoveNext());
        }

        [TestMethod]
        [TestCategory("IBinarySearchTree")]
        public virtual void PreOrderIterator_FiveNodesLeftFull()
        {
            IEnumerator<int> enumerator = FiveNodesLeftFull.PreOrderIterator.GetEnumerator();

            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual<int>(50, enumerator.Current);
            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual<int>(25, enumerator.Current);
            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual<int>(12, enumerator.Current);
            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual<int>(32, enumerator.Current);
            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual<int>(75, enumerator.Current);
            Assert.IsFalse(enumerator.MoveNext());
        }

        #endregion

        #region IBinarySearchTree.Insert

        [TestMethod]
        [TestCategory("IBinarySearchTree")]
        public virtual void Insert_IntoEmpty()
        {
            Empty.Insert(50);

            Assert.AreEqual<int>(1, Empty.Count);
        }

        [TestMethod]
        [TestCategory("IBinarySearchTree")]
        public virtual void Insert_IntoRootOnly_Smaller()
        {
            RootOnly.Insert(25);

            Assert.AreEqual<int>(2, RootOnly.Count);
        }

        [TestMethod]
        [TestCategory("IBinarySearchTree")]
        public virtual void Insert_IntoRootOnly_Larger()
        {
            RootOnly.Insert(75);

            Assert.AreEqual<int>(2, RootOnly.Count);
        }

        [TestMethod]
        [TestCategory("IBinarySearchTree")]
        public virtual void Insert_ThirdNode_IntoRootLeft()
        {
            RootLeft.Insert(75);

            Assert.AreEqual<int>(3, RootLeft.Count);
        }

        [TestMethod]
        [TestCategory("IBinarySearchTree")]
        public virtual void Insert_ThirdNode_IntoRootRight()
        {
            RootRight.Insert(25);

            Assert.AreEqual<int>(3, RootRight.Count);
        }

        [TestMethod]
        [TestCategory("IBinarySearchTree")]
        public virtual void Insert_ThirdNodeAtStart_IntoRootLeft()
        {
            RootLeft.Insert(13);

            Assert.AreEqual<int>(3, RootLeft.Count);
        }

        [TestMethod]
        [TestCategory("IBinarySearchTree")]
        public virtual void Insert_ThirdNodeInMiddle_IntoRootLeft()
        {
            RootLeft.Insert(32);

            Assert.AreEqual<int>(3, RootLeft.Count);
        }

        [TestMethod]
        [TestCategory("IBinarySearchTree")]
        public virtual void Insert_ThirdNodeAtEnd_IntoRootRight()
        {
            RootRight.Insert(100);

            Assert.AreEqual<int>(3, RootRight.Count);
        }

        [TestMethod]
        [TestCategory("IBinarySearchTree")]
        public virtual void Insert_ThirdNodeInMiddle_IntoRootRight()
        {
            RootRight.Insert(62);

            Assert.AreEqual<int>(3, RootRight.Count);
        }

        [TestMethod]
        [TestCategory("IBinarySearchTree")]
        [ExpectedException(typeof(ArgumentException))]
        public virtual void Insert_DuplicateAtRoot_OfThreeNodesFull()
        {
            ThreeNodesFull.Insert(50);
        }

        [TestMethod]
        [TestCategory("IBinarySearchTree")]
        [ExpectedException(typeof(ArgumentException))]
        public virtual void Insert_DuplicateInMiddle_OfFourNodesLeftLeft()
        {
            FourNodesLeftLeft.Insert(25);
        }

        [TestMethod]
        [TestCategory("IBinarySearchTree")]
        [ExpectedException(typeof(ArgumentException))]
        public virtual void Insert_DuplicateInMiddle_OfFourNodesLeftRight()
        {
            FourNodesLeftRight.Insert(25);
        }

        [TestMethod]
        [TestCategory("IBinarySearchTree")]
        [ExpectedException(typeof(ArgumentException))]
        public virtual void Insert_DuplicateInMiddle_OfFourNodesRightLeft()
        {
            FourNodesRightLeft.Insert(75);
        }

        [TestMethod]
        [TestCategory("IBinarySearchTree")]
        [ExpectedException(typeof(ArgumentException))]
        public virtual void Insert_DuplicateInMiddle_OfFourNodesRightRight()
        {
            FourNodesRightRight.Insert(75);
        }

        [TestMethod]
        [TestCategory("IBinarySearchTree")]
        [ExpectedException(typeof(ArgumentException))]
        public virtual void Insert_DuplicateAsLeaf_OfFourNodesLeftLeft()
        {
            FourNodesLeftLeft.Insert(25);
        }

        #endregion

        #region IBinarySearchTree.Contains

        [TestMethod]
        [TestCategory("IBinarySearchTree")]
        public virtual void Contains_EmptyTree()
        {
            Assert.IsFalse(Empty.Contains(50));
        }

        [TestMethod]
        [TestCategory("IBinarySearchTree")]
        public virtual void Contains_RootOnly_NotFound()
        {
            Assert.IsFalse(RootOnly.Contains(60));
        }

        [TestMethod]
        [TestCategory("IBinarySearchTree")]
        public virtual void Contains_RootOnly_Found()
        {
            Assert.IsTrue(RootOnly.Contains(50));
        }

        [TestMethod]
        [TestCategory("IBinarySearchTree")]
        public virtual void Contains_RootLeft_FoundLeaf()
        {
            Assert.IsTrue(RootLeft.Contains(25));
        }

        [TestMethod]
        [TestCategory("IBinarySearchTree")]
        public virtual void Contains_RootRight_FoundLeaf()
        {
            Assert.IsTrue(RootRight.Contains(75));
        }

        [TestMethod]
        [TestCategory("IBinarySearchTree")]
        public virtual void Contains_ThreeNodesFull_FoundLeftLeaf()
        {
            Assert.IsTrue(ThreeNodesFull.Contains(25));
        }

        [TestMethod]
        [TestCategory("IBinarySearchTree")]
        public virtual void Contains_ThreeNodesFull_FoundRightLeaf()
        {
            Assert.IsTrue(ThreeNodesFull.Contains(75));
        }

        [TestMethod]
        [TestCategory("IBinarySearchTree")]
        public virtual void Contains_BiggerTree_NotFound()
        {
            Assert.IsFalse(Bigger.Contains(200));
        }

        [TestMethod]
        [TestCategory("IBinarySearchTree")]
        public virtual void Contains_BiggerTree_Found()
        {
            Assert.IsTrue(Bigger.Contains(75));
            Assert.IsTrue(Bigger.Contains(30));
        }

        #endregion

        #region BinarySearchTree.Delete

        [TestMethod]
        [TestCategory("IBinarySearchTree")]
        public virtual void Delete_EmptyTree()
        {
            Assert.IsFalse(Empty.Delete(50));
        }

        [TestMethod]
        [TestCategory("IBinarySearchTree")]
        public virtual void Delete_RootOnly_NotFound()
        {
            Assert.IsFalse(RootOnly.Delete(60));
        }

        [TestMethod]
        [TestCategory("IBinarySearchTree")]
        public virtual void Delete_RootOnly_Found()
        {
            Assert.IsTrue(RootOnly.Delete(50));

            Assert.AreEqual<int>(0, RootOnly.Count);
        }

        [TestMethod]
        [TestCategory("IBinarySearchTree")]
        public virtual void Delete_RootLeft_NotFound1()
        {
            Assert.IsFalse(RootLeft.Delete(10));
        }

        [TestMethod]
        [TestCategory("IBinarySearchTree")]
        public virtual void Delete_RootLeft_NotFound2()
        {
            Assert.IsFalse(RootLeft.Delete(30));
        }

        [TestMethod]
        [TestCategory("IBinarySearchTree")]
        public virtual void Delete_RootLeft_NotFound3()
        {
            Assert.IsFalse(RootLeft.Delete(75));
        }

        [TestMethod]
        [TestCategory("IBinarySearchTree")]
        public virtual void Delete_RootRight_NotFound1()
        {
            Assert.IsFalse(RootRight.Delete(25));
        }

        [TestMethod]
        [TestCategory("IBinarySearchTree")]
        public virtual void Delete_RootRight_NotFound2()
        {
            Assert.IsFalse(RootRight.Delete(60));
        }

        [TestMethod]
        [TestCategory("IBinarySearchTree")]
        public virtual void Delete_RootRight_NotFound3()
        {
            Assert.IsFalse(RootRight.Delete(100));
        }

        [TestMethod]
        [TestCategory("IBinarySearchTree")]
        public virtual void Delete_RootLeft_Root()
        {
            Assert.IsTrue(RootLeft.Delete(50));

            Assert.AreEqual<int>(1, RootLeft.Count);
        }

        [TestMethod]
        [TestCategory("IBinarySearchTree")]
        public virtual void Delete_RootRight_Root()
        {
           Assert.IsTrue( RootRight.Delete(50));

            Assert.AreEqual<int>(1, RootRight.Count);
        }

        [TestMethod]
        [TestCategory("IBinarySearchTree")]
        public virtual void Delete_ThreeNodesFull_Root()
        {
            Assert.IsTrue(ThreeNodesFull.Delete(50));

            Assert.AreEqual<int>(2, ThreeNodesFull.Count);
        }

        [TestMethod]
        [TestCategory("IBinarySearchTree")]
        public virtual void Delete_RootLeft_Leaf()
        {
            Assert.IsTrue(RootLeft.Delete(25));

            Assert.AreEqual<int>(1, RootLeft.Count);
        }

        [TestMethod]
        [TestCategory("IBinarySearchTree")]
        public virtual void Delete_RootRight_Leaf()
        {
            Assert.IsTrue(RootRight.Delete(75));

            Assert.AreEqual<int>(1, RootRight.Count);
        }

        [TestMethod]
        [TestCategory("IBinarySearchTree")]
        public virtual void Delete_ThreeNodesFull_LeftLeaf()
        {
            Assert.IsTrue(ThreeNodesFull.Delete(25));

            Assert.AreEqual<int>(2, ThreeNodesFull.Count);
        }

        [TestMethod]
        [TestCategory("IBinarySearchTree")]
        public virtual void Delete_ThreeNodesFull_RightLeaf()
        {
            Assert.IsTrue(ThreeNodesFull.Delete(75));

            Assert.AreEqual<int>(2, ThreeNodesFull.Count);
        }

        [TestMethod]
        [TestCategory("IBinarySearchTree")]
        public virtual void Delete_FourNodesLeftLeft_HasParentAndChild()
        {
            Assert.IsTrue(FourNodesLeftLeft.Delete(25));

            Assert.AreEqual<int>(3, FourNodesLeftLeft.Count);
        }

        [TestMethod]
        [TestCategory("IBinarySearchTree")]
        public virtual void Delete_FourNodesLeftRight_Start()
        {
            Assert.IsTrue(FourNodesLeftRight.Delete(25));

            Assert.AreEqual<int>(3, FourNodesLeftRight.Count);
        }

        [TestMethod]
        [TestCategory("IBinarySearchTree")]
        public virtual void Delete_FourNodesRightLeft_End()
        {
            Assert.IsTrue(FourNodesRightLeft.Delete(75));

            Assert.AreEqual<int>(3, FourNodesRightLeft.Count);
        }

        [TestMethod]
        [TestCategory("IBinarySearchTree")]
        public virtual void Delete_FourNodesRightRight_HasParentAndChild()
        {
            Assert.IsTrue(FourNodesRightRight.Delete(75));

            Assert.AreEqual<int>(3, FourNodesRightRight.Count);
        }

        [TestMethod]
        [TestCategory("IBinarySearchTree")]
        public virtual void Delete_FiveNodesLeftFull_HasBothChildren()
        {
            Assert.IsTrue(FiveNodesLeftFull.Delete(25));

            Assert.AreEqual<int>(4, FiveNodesLeftFull.Count);
        }

        #endregion

        #region BinarySearchTree.Depth

        [TestMethod]
        [TestCategory("IBinarySearchTree")]
        [ExpectedException(typeof(ValueNotFoundException))]
        public virtual void Depth_Empty()
        {
            Empty.Depth(50);
        }

        [TestMethod]
        [TestCategory("IBinarySearchTree")]
        public virtual void Depth_RootOnly()
        {
            Assert.AreEqual<int>(0, RootOnly.Depth(50));
        }

        [TestMethod]
        [TestCategory("IBinarySearchTree")]
        [ExpectedException(typeof(ValueNotFoundException))]
        public virtual void Depth_RootOnly_NotFound1()
        {
            RootOnly.Depth(25);
        }

        [TestMethod]
        [TestCategory("IBinarySearchTree")]
        [ExpectedException(typeof(ValueNotFoundException))]
        public virtual void Depth_RootOnly_NotFound2()
        {
            RootOnly.Depth(75);
        }

        [TestMethod]
        [TestCategory("IBinarySearchTree")]
        public virtual void Depth_RootLeft1()
        {
            Assert.AreEqual<int>(0, RootLeft.Depth(50));
        }

        [TestMethod]
        [TestCategory("IBinarySearchTree")]
        public virtual void Depth_RootLeft2()
        {
            Assert.AreEqual<int>(1, RootLeft.Depth(25));
        }

        [TestMethod]
        [TestCategory("IBinarySearchTree")]
        public virtual void Depth_RootRight1()
        {
            Assert.AreEqual<int>(0, RootRight.Depth(50));
        }

        [TestMethod]
        [TestCategory("IBinarySearchTree")]
        public virtual void Depth_RootRight2()
        {
            Assert.AreEqual<int>(1, RootRight.Depth(75));
        }

        [TestMethod]
        [TestCategory("IBinarySearchTree")]
        public virtual void Depth_ThreeNodesFull1()
        {
            Assert.AreEqual<int>(0, ThreeNodesFull.Depth(50));
        }

        [TestMethod]
        [TestCategory("IBinarySearchTree")]
        public virtual void Depth_ThreeNodesFull2()
        {
            Assert.AreEqual<int>(1, ThreeNodesFull.Depth(25));
        }

        [TestMethod]
        [TestCategory("IBinarySearchTree")]
        public virtual void Depth_ThreeNodesFull3()
        {
            Assert.AreEqual<int>(1, ThreeNodesFull.Depth(75));
        }

        [TestMethod]
        [TestCategory("IBinarySearchTree")]
        public virtual void Depth_FourNodesLeftLeft()
        {
            Assert.AreEqual<int>(2, FourNodesLeftLeft.Depth(12));
        }

        [TestMethod]
        [TestCategory("IBinarySearchTree")]
        public virtual void Depth_FourNodesLeftRight()
        {
            Assert.AreEqual<int>(2, FourNodesLeftRight.Depth(32));
        }

        [TestMethod]
        [TestCategory("IBinarySearchTree")]
        public virtual void Depth_FourNodesRightLeft()
        {
            Assert.AreEqual<int>(2, FourNodesRightLeft.Depth(63));
        }

        [TestMethod]
        [TestCategory("IBinarySearchTree")]
        public virtual void Depth_FourNodesRightRight()
        {
            Assert.AreEqual<int>(2, FourNodesRightRight.Depth(100));
        }

        [TestMethod]
        [TestCategory("IBinarySearchTree")]
        public virtual void Depth_FiveNodesLeftFull()
        {
            Assert.AreEqual<int>(2, FiveNodesLeftFull.Depth(32));
        }

        #endregion

        #region BinarySearchTree.AssertTree

        [TestMethod]
        [TestCategory("IBinarySearchTree")]
        public virtual void AssertValidTree_Empty()
        {
            Empty.AssertValidTree();
        }

        [TestMethod]
        [TestCategory("IBinarySearchTree")]
        public virtual void AssertValidTree_RootOnly()
        {
            RootOnly.AssertValidTree();
        }

        [TestMethod]
        [TestCategory("IBinarySearchTree")]
        public virtual void AssertValidTree_RootLeft()
        {
            RootLeft.AssertValidTree();
        }

        [TestMethod]
        [TestCategory("IBinarySearchTree")]
        public virtual void AssertValidTree_RootRight()
        {
            RootRight.AssertValidTree();
        }

        [TestMethod]
        [TestCategory("IBinarySearchTree")]
        public virtual void AssertValidTree_ThreeNodesFull()
        {
            ThreeNodesFull.AssertValidTree();
        }

        [TestMethod]
        [TestCategory("IBinarySearchTree")]
        public virtual void AssertValidTree_FourNodesLeftLeft()
        {
            FourNodesLeftLeft.AssertValidTree();
        }

        [TestMethod]
        [TestCategory("IBinarySearchTree")]
        public virtual void AssertValidTree_FourNodesLeftRight()
        {
            FourNodesLeftRight.AssertValidTree();
        }

        [TestMethod]
        [TestCategory("IBinarySearchTree")]
        public virtual void AssertValidTree_FourNodesRightLeft()
        {
            FourNodesRightLeft.AssertValidTree();
        }

        [TestMethod]
        [TestCategory("IBinarySearchTree")]
        public virtual void AssertValidTree_FourNodesRightRight()
        {
            FourNodesRightRight.AssertValidTree();
        }

        [TestMethod]
        [TestCategory("IBinarySearchTree")]
        public virtual void AssertValidTree_FiveNodesLeftFull()
        {
            FiveNodesLeftFull.AssertValidTree();
        }

        #endregion
    }
}
