using BusinessHouseGame.BL.Interfaces;
using BusinessHouseGame.BL.Models;
using AppConstants = BusinessHouseGame.BL.Constants.Constants;


namespace BusinessHouseGame.BL.Services
{
	public class LotteryService : ILotteryService
	{
		public void ProcessGame(Board gameBoard, Player player)
		{
			player.Money += AppConstants.LotteryValue;
			gameBoard.BankMoney -= AppConstants.LotteryValue;
		}
	}
}
