using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Triangle
{
    [TestClass]
    public class UnitTest1
    {
        [TestClass]
        public class UnitTestForTriangle
        {
            [TestMethod]
            public void IsTriangleIsoscelesTriangle()
            {
                Assert.IsTrue(Triangle.IsTriangle(7, 7, 9));
            }

            [TestMethod]
            public void IsRightTriangle()
            {
                Assert.IsTrue(Triangle.IsTriangle(6, 8, 10));
            }

            [TestMethod]
            public void IsTrianglePossible_SumMoreThanSideLength()
            {
                Assert.IsTrue(Triangle.IsTriangle(3, 2, 5));
            }

            [TestMethod]
            public void IsTriangleEquilateralTriangle()
            {
                Assert.IsTrue(Triangle.IsTriangle(7, 7, 7));
            }

            [TestMethod]
            public void OneSideIsNegative()
            {
                Assert.IsFalse(Triangle.IsTriangle(-3, 2, 4));
            }

            [TestMethod]
            public void TwoSideIsNegative()
            {
                Assert.IsFalse(Triangle.IsTriangle(-3, -2, 4));
            }

            [TestMethod]
            public void AllSidesIsNegative()
            {
                Assert.IsFalse(Triangle.IsTriangle(-3, -2, 4));
            }
            [TestMethod]
            public void OneSideIsZero()
            {
                Assert.IsFalse(Triangle.IsTriangle(0, 1, 5));
            }
            [TestMethod]
            public void TwoSideIsZero()
            {
                Assert.IsFalse(Triangle.IsTriangle(0, 0, 5));
            }

            [TestMethod]
            public void AllSidesIsZero()
            {
                Assert.IsFalse(Triangle.IsTriangle(0, 0, 0));
            }
        }
    }
}
