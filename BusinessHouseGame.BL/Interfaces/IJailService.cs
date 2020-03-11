using BusinessHouseGame.BL.Models;

namespace BusinessHouseGame.BL.Interfaces
{
	public interface IJailService
	{
		void ProcessGame(Board gameBoard, Player player);
	}
}
