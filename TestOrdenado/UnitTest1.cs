using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using AlgoritmosOrdenado;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TestOrdenado
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void BubbleSort_Test()
        {
            //Arrange
            Random random = new Random();
            ArraySort arraySort = new ArraySort(10000, random);
            int[] temp = new int[arraySort.array.Length];
            Array.Copy(arraySort.array, temp, arraySort.array.Length);

            //Act
            arraySort.BubbleSort(temp);

            //Assert
            Assert.IsTrue(Enumerable.SequenceEqual(temp, arraySort.arrayIncreasing), "No ha ordenado bien");
        }
        [TestMethod]
        public void QuickSort_Test()
        {
            //Arrange
            Random random = new Random();
            ArraySort arraySort = new ArraySort(10000, random);
            int[] temp = new int[arraySort.array.Length];
            Array.Copy(arraySort.array, temp, arraySort.array.Length);

            //Act
            arraySort.QuickSort(temp);

            //Assert
            Assert.IsTrue(Enumerable.SequenceEqual(temp, arraySort.arrayIncreasing), "No ha ordenado bien");
        }

        [TestMethod]
        public void CustomSort1_Test()
        {
            //Arrange
            Random random = new Random();
            ArraySort arraySort = new ArraySort(10000, random);
            int[] temp = new int[arraySort.array.Length];
            Array.Copy(arraySort.array, temp, arraySort.array.Length);

            //Act
            arraySort.CustomSort1(temp);

            //Assert
            Assert.IsTrue(Enumerable.SequenceEqual(temp, arraySort.arrayIncreasing), "No ha ordenado bien");
        }

        [TestMethod]
        public void CustomSort2_Test()
        {
            //Arrange
            Random random = new Random();
            ArraySort arraySort = new ArraySort(10000, random);
            int[] temp = new int[arraySort.array.Length];
            Array.Copy(arraySort.array, temp, arraySort.array.Length);

            //Act
            arraySort.CustomSort2(temp);

            //Assert
            Assert.IsTrue(Enumerable.SequenceEqual(temp, arraySort.arrayIncreasing), "No ha ordenado bien");
        }
    }

}
