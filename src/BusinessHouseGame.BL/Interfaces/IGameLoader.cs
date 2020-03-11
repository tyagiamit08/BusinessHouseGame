using BusinessHouseGame.BL.Models;

namespace BusinessHouseGame.BL.Interfaces
{
	public interface IGameLoader
	{
		Board LoadGameBoard(string inputCells);
		(Player, Player, Player) LoadPlayers(string diceOutput);
	}
}
