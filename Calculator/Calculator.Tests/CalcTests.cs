using Microsoft.QualityTools.Testing.Fakes;
using System;
using Xunit;

namespace Calculator.Tests
{
    public class CalcTests
    {
        [Fact]
        public void Sum_4_and_5_results_9()
        {
            //Arrange
            Calc calc = new();

            //Act
            int result = calc.Sum(4, 5);

            //Assert
            Assert.Equal(9, result);
        }

        [Fact]
        public void Sum_0_and_0_results_0()
        {
            //Arrange
            Calc calc = new();

            //Act
            int result = calc.Sum(0, 0);

            //Assert
            Assert.Equal(0, result);
        }

        [Fact]
        public void Sum_1_and_MAX_throws_OverflowException()
        {
            Calc calc = new();

            Assert.Throws<OverflowException>(() => calc.Sum(1, int.MaxValue));
        }

        [Theory]
        [InlineData(0, 0, 0)]
        [InlineData(2, 4, 6)]
        [InlineData(-2, -7, -9)]
        [InlineData(-2, 7, 5)]
        public void Sum(int a, int b, int exp)
        {
            //Arrange
            Calc calc = new();

            //Act
            int result = calc.Sum(a, b);

            //Assert
            Assert.Equal(exp, result);
        }

        [Fact]
        public void IsWeekend()
        {
            Calc calc = new();


            using (ShimsContext.Create())
            {

                //System.Fakes.ShimDateTime.NowGet = () => new DateTime(2021, 10, 4, 12, 30, 0);
                //Assert.False(oh.IsWeekend());
                //System.Fakes.ShimDateTime.NowGet = () => new DateTime(2021, 10, 5, 12, 30, 0);
                //Assert.False(oh.IsWeekend());
                //System.Fakes.ShimDateTime.NowGet = () => new DateTime(2021, 10, 6, 12, 30, 0);
                //Assert.False(oh.IsWeekend());
                //System.Fakes.ShimDateTime.NowGet = () => new DateTime(2021, 10, 7, 12, 30, 0);
                //Assert.False(oh.IsWeekend());
                //System.Fakes.ShimDateTime.NowGet = () => new DateTime(2021, 10, 8, 12, 30, 0);
                //Assert.False(oh.IsWeekend());
                //System.Fakes.ShimDateTime.NowGet = () => new DateTime(2021, 10, 9, 12, 30, 0);
                //Assert.True(oh.IsWeekend());
                //System.Fakes.ShimDateTime.NowGet = () => new DateTime(2021, 10, 10, 12, 30, 0);
                //Assert.True(oh.IsWeekend());
            }
        }



    }
}