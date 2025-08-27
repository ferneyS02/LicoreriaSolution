using LicoreriaSolution.Core.Application.Interfaces.Repositories;
using LicoreriaSolution.Core.Application.Services;
using LicoreriaSolution.Core.Domain.Entities;
using Moq;

namespace LicoreriaSolution.Tests.Unit;

public class ProductoServiceTests
{
    [Fact]
    public async Task CreateAsync_LlamaAddUnaVez_CuandoProductoValido()
    {
        // Arrange
        var mockRepo = new Mock<IProductoRepository>();
        mockRepo.Setup(r => r.AddAsync(It.IsAny<Producto>())).Returns(Task.CompletedTask);

        var svc = new ProductoService(mockRepo.Object);
        var nuevo = new Producto { Nombre = "Ron", Precio = 50000m };

        // Act
        await svc.CreateAsync(nuevo);

        // Assert
        mockRepo.Verify(r => r.AddAsync(It.IsAny<Producto>()), Times.Once);
    }

    [Fact]
    public async Task CreateAsync_LanzaExcepcion_SiNombreVacio()
    {
        var mockRepo = new Mock<IProductoRepository>();
        var svc = new ProductoService(mockRepo.Object);

        var invalido = new Producto { Nombre = "", Precio = 1000m };

        await Assert.ThrowsAsync<ArgumentException>(() => svc.CreateAsync(invalido));
    }

    [Fact]
    public async Task CreateAsync_LanzaExcepcion_SiPrecioNegativo()
    {
        var mockRepo = new Mock<IProductoRepository>();
        var svc = new ProductoService(mockRepo.Object);

        var invalido = new Producto { Nombre = "Cerveza", Precio = -1m };

        await Assert.ThrowsAsync<ArgumentException>(() => svc.CreateAsync(invalido));
    }
}
