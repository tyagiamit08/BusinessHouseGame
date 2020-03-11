using System;
using BusinessHouseGame.BL.Interfaces;
using BusinessHouseGame.BL.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BusinessHouseGame
{
	class Program
	{
		static void Main(string[] args)
		{
			const string diceOutput = "2,2,1, 4,4,2, 4,4,2, 2,2,1, 4,4,2, 4,4,2, 2,2,1";
			const string boardCells = "J,H,L,H,E,L,H,L,H,J";

			var serviceProvider = ConfigureServices();
			var gameService = serviceProvider.GetService<IGameService>();

			var result = gameService.StartGame(boardCells, diceOutput);

			result.ForEach(Console.WriteLine);

			Console.ReadLine();
		}

		private static ServiceProvider ConfigureServices()
		{
			var collection = new ServiceCollection();
			collection.AddScoped<IGameService, GameService>();
			collection.AddScoped<IGameLoader, GameLoader>();
			collection.AddScoped<IPlayerService, PlayerService>();
			collection.AddScoped<ILotteryService, LotteryService>();
			collection.AddScoped<IJailService, JailService>();
			collection.AddScoped<IHotelService, HotelService>();
			return collection.BuildServiceProvider();
		}
	}
}
