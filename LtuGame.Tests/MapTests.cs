using LtuGame.ConsoleGame;
using LtuGame.ConsoleGame.Extensions;
using LtuGame.ConsoleGame.Services;
using Microsoft.Extensions.Configuration;
using Moq;

namespace LtuGame.Tests;

public class MapTests
{
    //[Fact]
    //public void Constructor_SetCorrectWidth_WithExtension2()
    //{
    //    //Arrange
    //    const int expectedWidth = 10;

    //    var iconfigMock = new Mock<IConfiguration>();
    //    var getMapSizeForMock = new Mock<IGetMapSizeFor>();

    //    getMapSizeForMock.Setup(x => x.GetMapSizeFor2(iconfigMock.Object, It.IsAny<string>())).Returns(expectedWidth);
    //    GetMapSizeForClass.Implementation = getMapSizeForMock.Object;

    //    //Act
    //    var map = new Map(iconfigMock.Object);

    //    //Assert
    //    Assert.Equal(expectedWidth, map.Width);
    //}

    //[Fact]
    //public void Constructor_SetCorrectWidth_WithFunc()
    //{
    //    //Arrange
    //    const int expectedWidth = 10;
    //    var iconfigMock = new Mock<IConfiguration>();
    //    GetMapSizeForClassFunc.Implementation = (config, key) => expectedWidth;

    //    //Act
    //    var map = new Map(iconfigMock.Object);

    //    //Assert
    //    Assert.Equal(expectedWidth, map.Width);
    //}

    //[Fact]
    //public void Constructor_SetCorrectWidth_WithIConfig()
    //{
    //    //Arrange
    //    const int expectedWidth = 10;
    //    var iconfigMock = new Mock<IConfiguration>();
    //    iconfigMock.Setup(config => config.GetMapSizeFor(It.IsAny<string>())).Returns(expectedWidth);

    //    //Act
    //    var map = new Map(iconfigMock.Object);

    //    //Assert
    //    Assert.Equal(expectedWidth, map.Width);
    //}

    //[Fact]
    //public void Constructor_SetCorrectWidth_WithIMapSettings()
    //{
    //    //Arrange
    //    const int expectedWidth = 10;
    //    //var mapsettings = new Mock<IMapSettings>();
    //    //mapsettings.Setup(settings => settings.Y).Returns(expectedWidth);
    //    var mapSettings = new MapSettings { X = expectedWidth };

    //    //Act
    //   // var map = new Map(mapsettings.Object);
    //    var map = new Map(mapSettings);

    //    //Assert
    //    Assert.Equal(expectedWidth, map.Width);
    //}

    [Fact]
    public void Constructor_SetCorrectWidth_With_IGetMapSizeService()
    {
        //Arrange
        const int expectedWidth = 10;
        const int expectedHeight = 10;
       
        var mapServiceMock = new Mock<IGetMapSizeService>();
        mapServiceMock.Setup(service => service.GetMapSize()).Returns((expectedWidth, expectedHeight));

        //Act
       // var map = new Map(mapsettings.Object);
        var map = new Map(mapServiceMock.Object);

        //Assert
        Assert.Equal(expectedWidth, map.Width);
    }
}
