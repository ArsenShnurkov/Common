namespace CommonTestsInternal.Collections.Generic
{
    using System.Collections;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    public partial class AVLTreeTests
    {
        #region IEnumerable

        [TestMethod]
        [TestCategory("AVLTree")]
        public void GetEnumerator_FiveNodesLeftFull()
        {
            IEnumerable ienumerable = (IEnumerable)FiveNodesLeftFull;

            IEnumerator enumerator = ienumerable.GetEnumerator();

            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual<object>(12, enumerator.Current);
            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual<object>(25, enumerator.Current);
            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual<object>(32, enumerator.Current);
            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual<object>(50, enumerator.Current);
            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual<object>(75, enumerator.Current);
            Assert.IsFalse(enumerator.MoveNext());
        }

        [TestMethod]
        [TestCategory("AVLTree")]
        public void GetEnumeratorGeneric_FiveNodesLeftFull()
        {
            IEnumerable<int> ienumerable = (IEnumerable<int>)FiveNodesLeftFull;

            IEnumerator<int> enumerator = ienumerable.GetEnumerator();

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
    }
}
