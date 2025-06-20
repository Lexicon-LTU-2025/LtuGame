﻿
using LtuGame.ConsoleGame;
using LtuGame.ConsoleGame.Extensions;
using LtuGame.ConsoleGame.Services;
using LtuGame.LimitedList;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

//IEnumerable<int> list = new List<int>();

//IEnumerable<Creature> list2 = new Creature[25];
////list2.CreatureAt(new Cell(new LtuGame.ConsoleGame.GameWorld.Position(1,2)));



//IEnumerable<int> lm = new LimitedList<int>(10);

//var res = lm.Where(x => x > 5);



//foreach (int i in lm)
//{
//    Console.WriteLine(i);
//}




//var li = new List<int>(10);

//var str = "adafasgfsge";

//foreach (var item in str)
//{
//    Console.WriteLine(item);
//}

//foreach (var item in li)
//{
//    Console.WriteLine(item);
//}

//foreach (var item in lm)
//{
//    Console.WriteLine(item);
//}
IConfiguration config = new ConfigurationBuilder()
                                .SetBasePath(Environment.CurrentDirectory)
                                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                                .Build();


var host = Host.CreateDefaultBuilder(args)
               .ConfigureServices(services =>
               {
                   services.AddSingleton<IUI, ConsoleUI>();
                   services.AddSingleton<IMap, Map>();
                   services.AddSingleton<IConfiguration>(config);
                   services.AddSingleton<IMapSettings>(config.GetSection("game:mapsettings").Get<MapSettings>()!);
                   services.AddSingleton<IGetMapSizeService, GetMapSizeService>();
                   services.AddSingleton<ILimitedList<string>>(new MessageLog<string>(6));
                   services.AddSingleton<ILimitedList<Item>>(new LimitedList<Item>(3));
                   services.AddSingleton<Game>();

               })
               .UseConsoleLifetime()
               .Build();

host.Services.GetRequiredService<Game>().Run();


//var x = config.GetMapSizeFor("x");
//var y = config.GetMapSizeFor("y");


//var game = new Game(new ConsoleUI(), new Map(y, x));
//game.Run();

Console.WriteLine("Game over");