using BusinessHouseGame.BL.Models;

namespace BusinessHouseGame.BL.Interfaces
{
	public interface IHotelService
	{
		void ProcessGame(Board gameBoard, Player player, string playerName);
	}
}
