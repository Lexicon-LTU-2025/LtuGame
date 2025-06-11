using LtuGame.ConsoleGame.Extensions;
using Microsoft.Extensions.Configuration;
using Moq;

namespace LtuGame.Tests;

public class MapTests
{
    [Fact]
    public void Constructor_SetCorrectWidth_WithExtension2()
    {
        //Arrange
        const int expectedWidth = 10;

        var iconfigMock = new Mock<IConfiguration>();
        var getMapSizeForMock = new Mock<IGetMapSizeFor>();

        getMapSizeForMock.Setup(x => x.GetMapSizeFor2(iconfigMock.Object, It.IsAny<string>())).Returns(expectedWidth);
        GetMapSizeForClass.Implementation = getMapSizeForMock.Object;

        //Act
        var map = new Map(iconfigMock.Object);

        //Assert
        Assert.Equal(expectedWidth, map.Width);
    }
}
