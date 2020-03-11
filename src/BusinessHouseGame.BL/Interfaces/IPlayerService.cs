using BusinessHouseGame.BL.Models;

namespace BusinessHouseGame.BL.Interfaces
{
	public interface IPlayerService
	{
		(Player, Player, Player) CreatePlayers(string diceOutput);
	}
}
