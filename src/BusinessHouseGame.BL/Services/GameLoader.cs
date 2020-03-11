using System.Collections.Generic;
using BusinessHouseGame.BL.Enums;
using BusinessHouseGame.BL.Interfaces;
using BusinessHouseGame.BL.Models;

namespace BusinessHouseGame.BL.Services
{
	public class GameLoader : IGameLoader
	{
		private readonly IPlayerService _playerService;
		public GameLoader(IPlayerService playerService)
		{
			_playerService = playerService;
		}
		public Board LoadGameBoard(string inputCells)
		{
			var boardCells = new List<BoardCell>();

			var cells = inputCells.Split(',');

			foreach (var cell in cells)
			{
				switch (cell)
				{
					case "J":
						boardCells.Add(new BoardCell { Type = CellType.Jail });
						break;
					case "H":
						boardCells.Add(new BoardCell { Type = CellType.Hotel });
						break;
					case "L":
						boardCells.Add(new BoardCell { Type = CellType.Lottery });
						break;
					case "E":
						boardCells.Add(new BoardCell { Type = CellType.Empty });
						break;
				}
			}

			return new Board
			{
				Cells = boardCells
			};
		}

		public (Player, Player, Player) LoadPlayers(string diceOutput)
		{
			return _playerService.CreatePlayers(diceOutput);
		}
	}
}
