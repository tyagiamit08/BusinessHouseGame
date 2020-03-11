using System.Collections.Generic;

namespace BusinessHouseGame.BL.Interfaces
{
	public interface IGameService
	{
		List<string> StartGame(string inputCells, string diceOutput);
	}
}
