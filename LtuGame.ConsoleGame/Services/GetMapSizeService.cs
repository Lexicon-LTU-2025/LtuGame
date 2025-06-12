using LtuGame.ConsoleGame.Extensions;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LtuGame.ConsoleGame.Services;

public interface IGetMapSizeService
{
    (int width, int height) GetMapSize();
}

public class GetMapSizeService : IGetMapSizeService
{
    private readonly IConfiguration configuration;

    public GetMapSizeService(IConfiguration configuration)
    {
        this.configuration = configuration;
    }

    public (int width, int height) GetMapSize()
    {
        return (width: configuration.GetMapSizeFor("x"), height: configuration.GetMapSizeFor("y"));
    }
}
