using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HashTable.Test
{
    [TestClass]
    public class HashTableTests
    {
        [TestMethod]
        public void AddingNewKeyPairShouldWorkCorrect()
        {
            var hashTable = new HashTable<string, int>();
            hashTable.Add("Ivan", 1);

            Assert.IsTrue(hashTable.ContainsKey("Ivan"));
            Assert.AreEqual(hashTable["Ivan"], 1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void AddingNewKeyPairShouldThrowWhenSameKeyAded()
        {
            var hashTable = new HashTable<string, int>();
            hashTable.Add("Ivan", 1);
            hashTable.Add("Ivan", 1);

        }

        [TestMethod]
        public void FindNewKeyPairShouldWorkCorrectly()
        {
            var hashTable = new HashTable<string, int>();
            hashTable.Add("Ivan", 1);

            Assert.AreEqual(hashTable.Find("Ivan"), 1);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void FindNewKeyPairShouldThrowWhenKeyNotExists()
        {
            var hashTable = new HashTable<string, int>();
            hashTable.Add("Ivan", 1);
            hashTable.Find("Asen");

        }

        [TestMethod]
        public void RemovingNewKeyPairShouldWorkCorrectly()
        {
            var hashTable = new HashTable<string, int>();
            hashTable.Add("Ivan", 1);
            hashTable.Add("Ivan1", 2);
            hashTable.Add("Ivan2", 3);
            hashTable.Remove("Ivan");
            Assert.AreEqual(hashTable.Count, 2);
        }

        [TestMethod]
        public void AddingNewKeyPairShouldCountCorrectly()
        {
            var hashTable = new HashTable<string, int>();
            hashTable.Add("Ivan", 1);
            hashTable.Add("Ivan1", 2);
            hashTable.Add("Ivan2", 3);

            Assert.AreEqual(hashTable.Count, 3);
        }

        [TestMethod]
        public void ClearNewKeyPairShouldWorkCorrectly()
        {
            var hashTable = new HashTable<string, int>();
            hashTable.Add("Ivan", 1);
            hashTable.Add("Ivan1", 2);
            hashTable.Add("Ivan2", 3);
            hashTable.Clear();

            Assert.AreEqual(hashTable.Count, 0);
        }

        [TestMethod]
        public void ThisShouldWorkCorrectly()
        {
            var hashTable = new HashTable<string, int>();
            hashTable.Add("Ivan", 1);

            Assert.AreEqual(hashTable["Ivan"], 1);
        }

        [TestMethod]
        public void ThisWorkCorrectWhenSetingNewValue()
        {
            var hashTable = new HashTable<string, int>();
            hashTable.Add("Ivan", 1);
            hashTable["Ivan"] = 3;
            Assert.AreEqual(hashTable["Ivan"], 3);
        }

        [TestMethod]
        public void KeysShouldWorkCorrectly()
        {
            var hashTable = new HashTable<string, int>();
            hashTable.Add("Ivan", 1);
            hashTable.Add("Ivan1", 2);
            hashTable.Add("Ivan2", 3);
            hashTable.Clear();

            Assert.AreEqual(hashTable.Keys.Count, 0);
        }

        [TestMethod]
        public void SetInitialCapacityShoulBeCorrect()
        {
            var hashTable = new HashTable<string, int>();

            Assert.AreEqual(hashTable.Capacity, 16);
        }

        [TestMethod]
        public void CapacityShouldResizeCorrectly()
        {
            var hashTable = new HashTable<string, int>();
            
            for (int i = 0; i <= 128; i++)
            {
                hashTable.Add("Iv" + i, i);
            }
            Assert.AreEqual(hashTable.Capacity, 32);
        }
    }
}
