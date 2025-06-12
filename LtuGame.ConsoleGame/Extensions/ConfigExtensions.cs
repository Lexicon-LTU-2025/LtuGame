using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LtuGame.ConsoleGame.Extensions;
public static class ConfigExtensions
{
    public static int GetMapSizeFor(this IConfiguration config, string key)
    {
        var section = config.GetSection("game:mapsettings");
        return int.TryParse(section[key], out int result) ? result : 0;
    }
}

public static class GetMapSizeForClass
{
    public static IGetMapSizeFor Implementation { private get; set; } = new GetMapSizeFor();
    public static int GetMapSizeFor2(this IConfiguration config, string key)
    {
        return Implementation.GetMapSizeFor2(config, key);
    }
}

public static class GetMapSizeForClassFunc
{
    public static Func<IConfiguration, string, int> Implementation { private get; set; } = (config, key) =>
    {
        var section = config.GetSection("game:mapsettings");
        return int.TryParse(section[key], out int result) ? result : 0;
    };

    public static int GetMapSizeFor3(this IConfiguration config, string key)
    {
        return Implementation(config, key);
    }
}

public interface IGetMapSizeFor
{
    int GetMapSizeFor2(IConfiguration config, string key);
}

public class GetMapSizeFor : IGetMapSizeFor
{
    public int GetMapSizeFor2(IConfiguration config, string key)
    {
        var section = config.GetSection("game:mapsettings");
        return int.TryParse(section[key], out int result) ? result : 0;
    }
}