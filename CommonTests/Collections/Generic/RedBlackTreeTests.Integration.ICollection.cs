namespace CommonTestsInternal.Collections.Generic
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using Common.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    public partial class RedBlackTreeTests
    {
        #region ICollection

        [TestMethod]
        [TestCategory("RedBlackTree")]
        public void Clear_Bigger()
        {
            InstanceBigger.Clear();
            Assert.IsNull(InstanceBigger.Root);
        }

        [TestMethod]
        [TestCategory("RedBlackTree")]
        public void IsReadOnly_Bigger()
        {
            Assert.IsFalse(InstanceBigger.IsReadOnly);
        }

        [TestMethod]
        [TestCategory("RedBlackTree")]
        [ExpectedException(typeof(NotImplementedException))]
        public void CopyTo_Bigger()
        {
            InstanceBigger.CopyTo(null, 0);
        }

        // Just a couple of Add tests to ensure it's hooked up to Insert which is tested in greater depth elsewhere

        [TestMethod]
        [TestCategory("RedBlackTree")]
        public void Add_EmptyTree()
        {
            InstanceEmpty.Add(50);
            Assert.AreEqual<int>(50, InstanceEmpty.Root.Value);
            Assert.AreEqual<int>(1, InstanceEmpty.Count);

            Assert.IsFalse(InstanceEmpty.Root.IsRed);
        }

        [TestMethod]
        [TestCategory("RedBlackTree")]
        public void Add_RootLeft()
        {
            InstanceRootLeft.Add(10);

            Assert.AreEqual<int>(25, InstanceRootLeft.Root.Value);
            Assert.AreEqual<int>(10, InstanceRootLeft.Root.Left.Value);
            Assert.AreEqual<int>(50, InstanceRootLeft.Root.Right.Value);

            Assert.IsFalse(InstanceRootLeft.Root.IsRed);
            Assert.IsTrue(InstanceRootLeft.Root.Left.IsRed);
            Assert.IsTrue(InstanceRootLeft.Root.Right.IsRed);

            InstanceRootLeft.AssertValidTree();
        }

        // Just a couple of Remove tests to ensure it's hooked up to Delete which is tested in greater depth elsewhere

        [TestMethod]
        [TestCategory("RedBlackTree")]
        public void Remove_RootOnly()
        {
            Assert.IsTrue(InstanceRootOnly.Remove(50));
            Assert.IsNull(InstanceRootOnly.Root);
            Assert.AreEqual<int>(0, InstanceRootOnly.Count);
        }

        [TestMethod]
        [TestCategory("RedBlackTree")]
        public void Remove_RootLeft()
        {
            Assert.IsTrue(InstanceRootLeft.Remove(25));
            Assert.AreEqual<int>(50, InstanceRootLeft.Root.Value);
            Assert.AreEqual<int>(1, InstanceRootLeft.Count);
        }

        [TestMethod]
        [TestCategory("RedBlackTree")]
        public void Remove_RootLeft_NotFound()
        {
            Assert.IsFalse(InstanceRootLeft.Remove(10));
        }

        #endregion
    }
}
