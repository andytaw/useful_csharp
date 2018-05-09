namespace Useful.Tests.Tests.Extensions
{
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Useful.Extensions;

    [TestClass]
    public class IEnumerableExtensionsTests
    {
        #region ForEach Tests

        [TestMethod]
        public void IEnumerableExtensions_ForEach_Happy()
        {
            var stash = new List<int>();

            var values = new[] { 1, 2, 3, 4, 5 };

            values.ForEach(x => stash.Add(x));

            Assert.IsNotNull(stash);
            Assert.IsTrue(stash.Any());

            for(var i = 0; i < stash.Count(); i++)
            {
                Assert.AreEqual(values[i], stash.Skip(i).First());
            }
        }

        [TestMethod]
        public void IEnumerableExtensions_ForEach_Null_Action()
        {
            var values = new[] { 1, 2, 3, 4, 5 };

            values.ForEach(null);
        }

        [TestMethod]
        [ExpectedException(typeof(System.NullReferenceException))]
        public void IEnumerableExtensions_ForEach_Null_Ref_Throws_Exception()
        {
            int[] values = null;

            values.ForEach(null);
        }

        #endregion

        #region Permute Tests

        [TestMethod]
        public void IEnumerableExtensions_Permute_Happy_1()
        {
            var data = new[] { new [] { 1, 2 } };
            var newData = new[] { 8, 9 };

            var result = data.Permute(newData).ToArrays();

            var expected = new[] { new[] { 1, 2, 8 }, new[] { 1, 2, 9 } };

            for(var i = 0; i < expected.Length; i++)
            {
                for (var ii = 0; ii < expected[i].Length; ii++)
                {
                    Assert.AreEqual(expected[i][ii], result[i][ii]);
                }
            }
        }

        [TestMethod]
        public void IEnumerableExtensions_Permute_Happy_2()
        {
            var data = new[] { new[] { 1, 2, 8 }, new[] { 1, 2, 9 } };
            var newData = new[] { 5, 6 };

            var result = data.Permute(newData).ToArrays();

            var expected = new[] { new[] { 1, 2, 8, 5 }, new[] { 1, 2, 8, 6 }, new[] { 1, 2, 9, 5 }, new[] { 1, 2, 9, 6 } };

            for (var i = 0; i < expected.Length; i++)
            {
                for (var ii = 0; ii < expected[i].Length; ii++)
                {
                    Assert.AreEqual(expected[i][ii], result[i][ii]);
                }
            }
        }

        [TestMethod]
        public void IEnumerableExtensions_Permute_Null_Input()
        {
            var data = new[] { new[] { 1, 2, 8 }, new[] { 1, 2, 9 } };
            int[] newData = null;

            var result = data.Permute(newData).ToArrays();

            var expected = new[] { new[] { 1, 2, 8 }, new[] { 1, 2, 9 } };

            for (var i = 0; i < expected.Length; i++)
            {
                for (var ii = 0; ii < expected[i].Length; ii++)
                {
                    Assert.AreEqual(expected[i][ii], result[i][ii]);
                }
            }
        }

        [TestMethod]
        [ExpectedException(typeof(System.NullReferenceException))]
        public void IEnumerableExtensions_Permute_Null_Ref_Throws_Exception()
        {
            int[][] data = null;
            int[] newData = null;

            var result = data.Permute(newData).ToArrays();
        }

        #endregion

        #region Permutations Tests

        [TestMethod]
        public void IEnumerableExtensions_Permutations_Happy()
        {
            var data = new[] { new[] { 1 }, new[] { 8, 9 }, new[] { 4, 5, 6 } };

            var result = data.Permutations().ToArrays();

            var expected = new[] {
                new[] { 1, 8, 4 },
                new[] { 1, 8, 5 },
                new[] { 1, 8, 6 },
                new[] { 1, 9, 4 },
                new[] { 1, 9, 5 },
                new[] { 1, 9, 6 }
            };

            for (var i = 0; i < expected.Length; i++)
            {
                for (var ii = 0; ii < expected[i].Length; ii++)
                {
                    Assert.AreEqual(expected[i][ii], result[i][ii]);
                }
            }
        }

        [TestMethod]
        [ExpectedException(typeof(System.NullReferenceException))]
        public void IEnumerableExtensions_Permutations_Null_Ref_Throws_Exception()
        {
            int[][] data = null;

            var result = data.Permutations().ToArrays();
        }

        #endregion
    }
}
