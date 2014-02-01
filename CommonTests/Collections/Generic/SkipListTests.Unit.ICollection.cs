namespace CommonTestsInternal.Collections.Generic
{
    using System;
using System.Collections;
using System.Collections.Generic;
using Common.Collections.Generic;
using Common.Collections.Generic.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

    public partial class SkipListTests
    {
        #region ICollection

        [TestMethod]
        [TestCategory("SkipList")]
        public void AddIsHookedUpToInsert()
        {
            using (ShimsContext.Create())
            {
                int insertedValue = int.MinValue;
                ShimSkipList<int>.AllInstances.InsertT0 = (skipList, value) => { insertedValue = value; };

                ICollection<int> collection = new SkipList<int>();
                collection.Add(50);
                Assert.AreEqual<int>(50, insertedValue);
            }
        }

        [TestMethod]
        [TestCategory("SkipList")]
        public void Clear_2LevelsFourNodes()
        {
            ICollection<int> collection = this.TwoLevelsFourNodes;
            collection.Clear();
            Assert.AreEqual<int>(0, this.TwoLevelsFourNodes.Count);
            Assert.AreEqual<int>(1, this.TwoLevelsFourNodes.Levels);

            foreach (SkipListNode<int> node in this.TwoLevelsFourNodes.Head.Next)
                Assert.IsNull(node);
        }

        [TestMethod]
        [TestCategoryAttribute("SkipList")]
        [ExpectedException(typeof(NotImplementedException))]
        public void CopyTo()
        {
            ICollection<int> collection = new SkipList<int>();
            collection.CopyTo(null, 0);
        }

        [TestMethod]
        [TestCategoryAttribute("SkipList")]
        public void IsReadOnly()
        {
            ICollection<int> collection = new SkipList<int>();
            Assert.IsFalse(collection.IsReadOnly);
        }

        [TestMethod]
        [TestCategory("SkipList")]
        public void RemoveIsHookedUpToDelete()
        {
            using (ShimsContext.Create())
            {
                int deletedValue = int.MinValue;
                ShimSkipList<int>.AllInstances.DeleteT0 = (skipList, value) => { deletedValue = value; return true; };

                ICollection<int> collection = new SkipList<int>();
                Assert.IsTrue(collection.Remove(50));
                Assert.AreEqual<int>(50, deletedValue);
            }
        }

        #endregion
    }
}
