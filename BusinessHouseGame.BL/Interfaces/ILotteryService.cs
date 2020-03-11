using BusinessHouseGame.BL.Models;

namespace BusinessHouseGame.BL.Interfaces
{
	public interface ILotteryService
	{
		void ProcessGame(Board gameBoard, Player player);
	}
}
