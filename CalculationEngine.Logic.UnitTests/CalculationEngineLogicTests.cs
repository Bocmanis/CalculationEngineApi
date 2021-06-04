using CalculationEngine.Core.DbModels;
using CalculationEngine.Core.Interfaces;
using Moq;
using NUnit.Framework;

namespace CalculationEngine.Logic.UnitTests
{
    public class CalculationEngineLogicTests
    {
        private Mock<IProductRepository> _productRepositoryMock;
        private ICalculationEngineLogic _target;
        [SetUp]
        public void Setup()
        {
            _productRepositoryMock = new Mock<IProductRepository>();
            _target = new CalculationEngineLogic(_productRepositoryMock.Object);
        }

        [Test]
        public void CalculateProductPricing_ProductNotFound_ReturnsNull()
        {
            //arrange
            var productCode = "TestProduct";
            var unitCount = 0;
            Product product = null;
            _productRepositoryMock.Setup(x => x.GetProductByCode(productCode)).Returns(product);

            //act
            var result = _target.GetProductPricing(productCode, unitCount);

            //assert
            Assert.IsNull(result);
        }

        [Test]
        [TestCase(0, 0)]
        [TestCase(1, 0)]
        [TestCase(4, 1)]
        [TestCase(5, 1)]
        [TestCase(99, 24)]
        public void CalculateProductPricing_ProductIsFound_CalculatesCartonsCountCorrectly(
            int unitCount, int expectedCartonsCount)
        {
            //arrange
            var productCode = "TestProduct";
            Product product = new Product()
            {
                PricePerCarton = 20,
                PricePerUnit = 6,
                ProductName = "Product Name",
                ProductCode = productCode,
                UnitsPerCarton = 4,
            };

            _productRepositoryMock.Setup(x => x.GetProductByCode(productCode)).Returns(product);

            // act 
            var result = _target.GetProductPricing(productCode, unitCount);
            // assert
            Assert.AreEqual(expectedCartonsCount, result.Cartons);
            Assert.AreEqual(unitCount, result.UnitsTotal);
        }

        [Test]
        [TestCase(0, 0)]
        [TestCase(1, 1)]
        [TestCase(4, 0)]
        [TestCase(5, 1)]
        [TestCase(99, 3)]
        public void CalculateProductPricing_ProductIsFound_CalculatesRemainderUnitCount(
    int unitCount, int expectedRemainderUnitsCount)
        {
            //arrange
            var productCode = "TestProduct";
            Product product = new Product()
            {
                PricePerCarton = 20,
                PricePerUnit = 6,
                ProductName = "Product Name",
                ProductCode = productCode,
                UnitsPerCarton = 4,
            };

            _productRepositoryMock.Setup(x => x.GetProductByCode(productCode)).Returns(product);

            // act 
            var result = _target.GetProductPricing(productCode, unitCount);
            // assert
            Assert.AreEqual(expectedRemainderUnitsCount, result.UnitsRemainder);
            Assert.AreEqual(unitCount, result.UnitsTotal);
        }

        [Test]
        [TestCase(0,0,0,0)]
        [TestCase(1, 6, 0, 6)]
        [TestCase(4, 20, 20, 0)]
        [TestCase(5, 26, 20, 6)]
        [TestCase(99, 498, 480, 18)]
        public void CalculateProductPricing_ProductIsFound_ReturnsPricing(
            int unitCount, 
            decimal expectedTotalPrice, 
            decimal expectedPriceForCartons,
            decimal expectedPriceForUnits)
        {
            //arrange
            var productCode = "TestProduct";
            Product product = new Product()
            {
                PricePerCarton = 20,
                PricePerUnit = 6,
                ProductName = "Product Name",
                ProductCode = productCode,
                UnitsPerCarton = 4,
            };

            _productRepositoryMock.Setup(x => x.GetProductByCode(productCode)).Returns(product);

            // act 
            var result = _target.GetProductPricing(productCode, unitCount);
            // assert
            Assert.AreEqual(expectedTotalPrice, result.PriceTotal);
            Assert.AreEqual(expectedPriceForCartons, result.PriceForCartons);
            Assert.AreEqual(expectedPriceForUnits, result.PriceForUnits);
            Assert.AreEqual(unitCount, result.UnitsTotal);
        }

        [Test]
        [TestCase(0, 0, 0, 0)]
        [TestCase(1, 6.03, 0, 6.03)]
        [TestCase(4, 20.06, 20.06, 0)]
        [TestCase(5, 26.09, 20.06, 6.03)]
        [TestCase(99, 499.53, 481.44, 18.09)]
        public void CalculateProductPricing_ProductIsFoundPricesWithDecimals_ReturnsPricing(
                    int unitCount,
                    decimal expectedTotalPrice,
                    decimal expectedPriceForCartons,
                    decimal expectedPriceForUnits)
        {
            //arrange
            var productCode = "TestProduct";
            Product product = new Product()
            {
                PricePerCarton = 20.06m,
                PricePerUnit = 6.03m,
                ProductName = "Product Name",
                ProductCode = productCode,
                UnitsPerCarton = 4,
            };

            _productRepositoryMock.Setup(x => x.GetProductByCode(productCode)).Returns(product);

            // act 
            var result = _target.GetProductPricing(productCode, unitCount);
            // assert
            Assert.AreEqual(expectedTotalPrice, result.PriceTotal);
            Assert.AreEqual(expectedPriceForCartons, result.PriceForCartons);
            Assert.AreEqual(expectedPriceForUnits, result.PriceForUnits);
            Assert.AreEqual(unitCount, result.UnitsTotal);
        }

    }
}