namespace CommonTestsInternal.Collections.Generic
{
    using System.Collections;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    public partial class SkipListTests
    {
        #region IEnumerable

        [TestMethod]
        [TestCategory("SkipList")]
        public void GetEnumeratorGeneric_2LevelsFourNodes()
        {
            IEnumerable<int> enumerable = this.TwoLevelsFourNodes;
            IEnumerator<int> enumerator = enumerable.GetEnumerator();

            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual<int>(50, enumerator.Current);
            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual<int>(75, enumerator.Current);
            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual<int>(100, enumerator.Current);
            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual<int>(125, enumerator.Current);
            Assert.IsFalse(enumerator.MoveNext());
        }

        [TestMethod]
        [TestCategory("SkipList")]
        public void GetEnumerator_2LevelsFourNodes()
        {
            IEnumerable enumerable = this.TwoLevelsFourNodes;
            IEnumerator enumerator = enumerable.GetEnumerator();

            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual<object>(50, enumerator.Current);
            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual<object>(75, enumerator.Current);
            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual<object>(100, enumerator.Current);
            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual<object>(125, enumerator.Current);
            Assert.IsFalse(enumerator.MoveNext());
        }

        #endregion
    }
}
