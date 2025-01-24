using CylinderProject.Models;
using System.Xml.Linq;
using System;
namespace CylinderTestProject
{
    public class UnitTest1
    {
        [Theory]
        [InlineData(1, 3)]
        [InlineData(100, 41110)]
        public void ConstructorTestForValidArguements(double radius, double height)
        {
            var unit = new Cylinder(radius, height);
            Assert.NotNull(unit.Radius);
            Assert.NotNull(unit.Height);
            Assert.Equal(radius, unit.Radius);
            Assert.Equal(height, unit.Height);
        }

        [Theory]
        [InlineData(0,3)]
        [InlineData(100,0)]
        [InlineData(-1,3)]
        [InlineData(32,-3)]
        public void ConstructorTestForInvalidArguements(double radius, double height)
        {
            Assert.Throws<ArgumentException>(() => new Cylinder(radius, height));
        }

        [Fact]
        public void MethodsTest()
        {
            var cylinder = new Cylinder(3, 40);
            Assert.Equal(1130.97, Math.Round(cylinder.GetVolume(),2));
            Assert.Equal(810.5, Math.Round(cylinder.GetSurfaceArea(),1));
        }

        [Fact]
        public void ResizeUpdateRadiusAndHeight()
        {
            var cylinder = new Cylinder(5, 10);

            cylinder.Resize(7, 15);

            Assert.Equal(7, cylinder.Radius);   
            Assert.Equal(15, cylinder.Height);  
        }

        [Theory]
        [InlineData(0, 10)]  
        [InlineData(5, -1)]   
        [InlineData(-2, 5)]   
        public void ResizeThrowsArgumentExceptionTest(double newRadius, double newHeight)
        {
            var cylinder = new Cylinder(5, 10);

            var exception = Assert.Throws<ArgumentException>(() => cylinder.Resize(newRadius, newHeight));
            Assert.Equal("A sugárnak és magasságnak pozitív számnak kell lennie!", exception.Message);
        }

        [Fact]
        public void Constructor_ShouldCreateCylinderObject()
        {
            var cylinder = new Cylinder(5, 10);

            Assert.NotNull(cylinder);  
        }

        [Fact]
        public void hValidRadius_WhenRadiusIsInRange()
        {
            var cylinder = new Cylinder(50, 10);  

            Assert.InRange(cylinder.Radius, 1, 100);  
        }

        //[Theory]
        //[InlineData(0)]   
        //[InlineData(101)] 
        //public void Constructor_ShouldThrowArgumentException_WhenRadiusIsOutOfRange(double radius)
        //{
        //    var exception = Assert.Throws<ArgumentException>(() => new Cylinder(radius, 10));
        //}
    }
}