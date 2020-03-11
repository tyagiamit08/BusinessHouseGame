using System.Collections.Generic;
using System.Linq;
using BusinessHouseGame.BL.Enums;
using BusinessHouseGame.BL.Interfaces;
using BusinessHouseGame.BL.Models;
using AppConstants = BusinessHouseGame.BL.Constants.Constants;

namespace BusinessHouseGame.BL.Services
{
	public class GameService : IGameService
	{
		private readonly IGameLoader _gameLoaderService;
		private readonly IHotelService _hotelService;
		private readonly IJailService _jailService;
		private readonly ILotteryService _lotteryService;
		public GameService(IGameLoader gameLoaderService, IHotelService hotelService, IJailService jailService, ILotteryService lotteryService)
		{
			_gameLoaderService = gameLoaderService;
			_hotelService = hotelService;
			_jailService = jailService;
			_lotteryService = lotteryService;
		}

		public List<string> StartGame(string inputCells, string diceOutput)
		{
			var gameBoard = _gameLoaderService.LoadGameBoard(inputCells);

			var players = _gameLoaderService.LoadPlayers(diceOutput);

			var result = PlayGame(players, gameBoard);

			return result;
		}

		public List<string> PlayGame((Player, Player, Player) players, Board gameBoard)
		{
			var result = new List<string>();
			var (player1, player2, player3) = players;

			while (player1.MovesPlayed < player1.Moves.Count ||
				   player2.MovesPlayed < player2.Moves.Count ||
				   player3.MovesPlayed < player3.Moves.Count)
			{
				PlayMove(gameBoard, player1, "Player-1");
				PlayMove(gameBoard, player2, "Player-2");
				PlayMove(gameBoard, player3, "Player-3");
			}

			result.Add($"Player-1 has total money {player1.Money} and asset of amount {player1.HotelsOwned.Sum(h => h.Value)}");
			result.Add($"Player-2 has total money {player2.Money} and asset of amount {player2.HotelsOwned.Sum(h => h.Value)}");
			result.Add($"Player-3 has total money {player3.Money} and asset of amount {player3.HotelsOwned.Sum(h => h.Value)}");
			result.Add($"Balance at Bank {gameBoard.BankMoney}");
			return result;
		}

		private void PayRent(Player hotelOwner, int rentAmount)
		{
			hotelOwner.Money += rentAmount;
		}

		private void PlayMove(Board gameBoard, Player player, string playerName)
		{
			if (player.MovesPlayed == AppConstants.MaxChancesAwardedPerPlayer)
				return;

			if (player.MovesPlayed >= player.Moves.Count)
				return;

			var playerMove = player.Moves[player.MovesPlayed];
			var boardCell = gameBoard.Cells[playerMove];

			if (boardCell == null) return;

			player.MovesPlayed += 1;

			switch (boardCell.Type)
			{
				case CellType.Lottery:
					_lotteryService.ProcessGame(gameBoard, player);
					break;
				case CellType.Jail:
					_jailService.ProcessGame(gameBoard, player);
					break;
				case CellType.Hotel:
					_hotelService.ProcessGame(gameBoard, player, playerName);
					break;
			}
		}
	}
}
