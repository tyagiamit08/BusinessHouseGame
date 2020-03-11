using System;
using BusinessHouseGame.BL.Interfaces;
using BusinessHouseGame.BL.Models;


namespace BusinessHouseGame.BL.Services
{
	public class PlayerService : IPlayerService
	{
		public (Player, Player, Player) CreatePlayers(string diceOutput)
		{
			var player1 = new Player();
			var player2 = new Player();
			var player3 = new Player();

			InitializePlayersMoves(diceOutput, player1, player2, player3);

			return (player1, player2, player3);
		}

		private static void InitializePlayersMoves(string diceOutput, Player player1, Player player2, Player player3)
		{
			var playersMoves = diceOutput.Split(' ');
			foreach (var moves in playersMoves)
			{
				var playersMove = moves.Split(',');

				player1.Moves.Add(Convert.ToInt32(playersMove[0]));
				player2.Moves.Add(Convert.ToInt32(playersMove[1]));
				player3.Moves.Add(Convert.ToInt32(playersMove[2]));
			}
		}
	}
}
