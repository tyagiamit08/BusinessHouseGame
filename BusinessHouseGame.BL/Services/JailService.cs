using BusinessHouseGame.BL.Interfaces;
using BusinessHouseGame.BL.Models;
using AppConstants = BusinessHouseGame.BL.Constants.Constants;

namespace BusinessHouseGame.BL.Services
{
	public class JailService : IJailService
	{
		public void ProcessGame(Board gameBoard, Player player)
		{
			player.Money -= AppConstants.JailFine;
			gameBoard.BankMoney += AppConstants.JailFine;
		}
	}
}
