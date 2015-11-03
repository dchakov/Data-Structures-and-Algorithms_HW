using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HashTable.Test
{
    [TestClass]
    public class HashedSet
    {
        [TestMethod]
        public void AddingItemShouldWorkCorrect()
        {
            var hashSet = new HashedSet<string>();
            hashSet.Add("Ivan");
            hashSet.Add("Asen");

            Assert.AreEqual(hashSet.Count, 2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void AddingItemShouldThrowWhenSameItemAded()
        {
            var hashSet = new HashedSet<string>();
            hashSet.Add("Ivan");
            hashSet.Add("Ivan");
        }

        [TestMethod]
        public void FindItemShouldWorkCorrectly()
        {
            var hashSet = new HashedSet<string>();
            hashSet.Add("Ivan");

            Assert.AreEqual(hashSet.Find("Ivan"), "Ivan");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void FindItemShouldThrowWhenKeyNotExists()
        {
            var hashSet = new HashedSet<string>();
            hashSet.Add("Ivan");
            hashSet.Find("Asen");

        }

        [TestMethod]
        public void RemovingItemShouldWorkCorrectly()
        {
            var hashSet = new HashedSet<string>();
            hashSet.Add("Ivan");
            hashSet.Add("Ivan1");
            hashSet.Add("Ivan2");
            hashSet.Remove("Ivan");
            Assert.AreEqual(hashSet.Count, 2);
        }

        [TestMethod]
        public void AddingItemShouldCountCorrectly()
        {
            var hashSet = new HashedSet<string>();
            hashSet.Add("Ivan");
            hashSet.Add("Ivan1");
            hashSet.Add("Ivan2");

            Assert.AreEqual(hashSet.Count, 3);
        }

        [TestMethod]
        public void ClearShouldWorkCorrectly()
        {
            var hashSet = new HashedSet<string>();
            hashSet.Add("Ivan");
            hashSet.Add("Ivan1");
            hashSet.Add("Ivan2");
            hashSet.Clear();

            Assert.AreEqual(hashSet.Count, 0);
        }

        [TestMethod]
        public void UnionShouldWorkCorrectly()
        {
            var hashSet1 = new HashedSet<string>();
            hashSet1.Add("Ivan");
            hashSet1.Add("Ivan1");
            hashSet1.Add("Ivan2");

            var hashSet2 = new HashedSet<string>();
            hashSet2.Add("Asen");
            hashSet2.Add("Ivan1");
            hashSet2.Add("Asen1");

            hashSet1.Union(hashSet2);

            Assert.IsTrue(hashSet1.Find("Asen1") == "Asen1");
            Assert.AreEqual(hashSet1.Count, 5);
        }

        [TestMethod]
        public void IntersectShouldWorkCorrectly()
        {
            var hashSet1 = new HashedSet<string>();
            hashSet1.Add("Ivan");
            hashSet1.Add("Ivan1");
            hashSet1.Add("Ivan2");

            var hashSet2 = new HashedSet<string>();
            hashSet2.Add("Asen");
            hashSet2.Add("Ivan1");
            hashSet2.Add("Asen1");

            hashSet1.Intersect(hashSet2);

            Assert.IsTrue(hashSet1.Find("Ivan1") == "Ivan1");
            Assert.AreEqual(hashSet1.Count, 1);
        }
    }
}
