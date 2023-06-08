using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;


namespace Lab3
{
    [TestClass]
    public class SquareMatrixTests
    {
        SquareMatrix TestMatrix = new SquareMatrix(4);

        [TestMethod]
        public void DeterminantTest()
        {
            Assert.IsNotNull(SquareMatrix.Determinant(TestMatrix));
        }

        [TestMethod]
        public void InverseTest()
        {
            Assert.IsInstanceOfType(SquareMatrix.Inverse(TestMatrix), typeof(SquareMatrix));
        }

        [TestMethod]
        public void ToStringTest()
        {
            Assert.IsInstanceOfType(TestMatrix.ToString(), typeof(String));
        }

        [TestMethod]
        public void CompareToTest()
        {
            SquareMatrix CompareToTestMatrix = TestMatrix;

            Assert.AreEqual(SquareMatrix.CompareTo(TestMatrix, CompareToTestMatrix), 0);
        }

        [TestMethod]
        public void EqualsTest()
        {
            SquareMatrix EqualsTestMatrix = TestMatrix;

            Assert.IsTrue(TestMatrix.Equals(EqualsTestMatrix));
        }

        [TestMethod]
        public void GetHashCodeTest()
        {
            Assert.AreEqual(TestMatrix.GetHashCode(), TestMatrix.Matrix.GetHashCode());
        }
    }
}