using Autofac.Extras.Moq;
using Demo.Application.Contracts;
using Demo.Application.Contracts.Repositories;
using Demo.Application.Exceptions;
using Demo.Application.Features.Products.Command;
using Demo.Domain.Entities;
using MapsterMapper;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Application.UnitTests.Features.Products.Command
{
    public class ProductAddCommandHandlerTests
    {
        private AutoMock _mock;
        private ProductAddCommandHandler _handler;
        private Mock<IApplicationUnitOfWork> _mockUnitOfWork;
        private Mock<IProductRepository> _mockProductRepository;
        private Mock<IMapper> _mockMapper;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            _mock = AutoMock.GetLoose();
           
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            _mock?.Dispose();
        }

        [SetUp]
        public void Setup()
        {
            _mockUnitOfWork = _mock.Mock<IApplicationUnitOfWork>();
            _mockProductRepository = _mock.Mock<IProductRepository>();
            _mockMapper = _mock.Mock<IMapper>();
            _handler = _mock.Create<ProductAddCommandHandler>(); 
        }
        [TearDown]
        public void TearDown()
        {
            _mockUnitOfWork?.Reset();
            _mockProductRepository?.Reset();
            _mockMapper?.Reset();
        }

        [Test]
        public async Task Handle_UniqueProductName_AddsProduct()
        {
            //Arrange
            var command = new ProductAddCommand
            {
                Name = "Unique Product",
                Price = 12.99,
                ImageName = "Unique_Product.jpg",
            };

            var product = new Product
            {
                Name = command.Name,
                Price = command.Price,
                ImageName = command.ImageName
            };


            _mockUnitOfWork.SetupGet(x => x.ProductRepository).Returns(_mockProductRepository.Object);
            _mockProductRepository.Setup(x => x.IsDuplicateProductName(command.Name, null, It.IsAny<CancellationToken>())).ReturnsAsync(false).Verifiable();

            _mockMapper.Setup(x => x.Map<Product>(command)).Returns(product);

            _mockProductRepository.Setup(x => x.AddAsync(product, It.IsAny<CancellationToken>())).Verifiable();
            _mockUnitOfWork.Setup(x => x.SaveAsync(It.IsAny<CancellationToken>())).Verifiable();



            // Act
            var result = await _handler.Handle(command, default);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNull(),
                () => result.Name.ShouldBe(command.Name),
                () => result.Id.ShouldNotBe(Guid.Empty),
                () => result.Price.ShouldBe(command.Price),
                () => result.ImageName.ShouldBe(command.ImageName)

                );
        }

        [Test]
        public async Task Handle_DuplicateProductName_DuplicateDataException()
        {
            // arrange
            var command = new ProductAddCommand
            {
                Name = "Duplicate Product",
                Price = 99.99,
                ImageName = "Duplicate_Product.jpg"
            };
            
            _mockUnitOfWork.SetupGet(x => x.ProductRepository).Returns(_mockProductRepository.Object);
            _mockProductRepository.Setup(x => x.IsDuplicateProductName(command.Name, null, It.IsAny<CancellationToken>())).ReturnsAsync(true).Verifiable();

            //Act & Assert
          
            Should.ThrowAsync<DuplicateDataException>(async () => await _handler.Handle(command, default))
                .Result.Message.ShouldBe("Product name is duplicate");
        }

    }
}
