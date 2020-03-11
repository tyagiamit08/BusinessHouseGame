using System.Linq;
using BusinessHouseGame.BL.Enums;
using BusinessHouseGame.BL.Interfaces;
using BusinessHouseGame.BL.Models;
using AppConstants = BusinessHouseGame.BL.Constants.Constants;

namespace BusinessHouseGame.BL.Services
{
	public class HotelService : IHotelService
	{
		public void ProcessGame(Board gameBoard, Player player, string playerName)
		{
			if (player.HotelsOwned.Count == 0)
			{
				AddHotel(player, playerName, HotelType.Silver);

				gameBoard.BankMoney += AppConstants.SilverHotelValue;
				player.Money -= AppConstants.SilverHotelValue;
			}
			else
			{
				var hotelTypes = player.HotelsOwned.Select(h => h.Type).ToList();

				var hasOwnedSilverHotel = hotelTypes.Any(t => t == HotelType.Silver);
				var hasOwnedGoldHotel = hotelTypes.Any(t => t == HotelType.Gold);

				if (hasOwnedSilverHotel)
				{
					AddHotel(player, playerName, HotelType.Gold);

					var deltaMoney = AppConstants.GoldHotelValue - AppConstants.SilverHotelValue;

					gameBoard.BankMoney += deltaMoney;
					player.Money -= deltaMoney;
				}
				else if (hasOwnedGoldHotel)
				{
					AddHotel(player, playerName, HotelType.Platinum);

					gameBoard.BankMoney += AppConstants.PlatinumHotelValue;
					player.Money -= AppConstants.PlatinumHotelValue;
				}
			}
		}

		private void AddHotel(Player player, string playerName, HotelType hotelType)
		{
			player.HotelsOwned.Add(new Hotel
			{
				Type = hotelType,
				OwnedBy = playerName,
				Rent = GetHotelRent(hotelType),
				RentedTo = string.Empty,
				Value = GetHotelValue(hotelType)
			});
		}

		private int GetHotelRent(HotelType hotelType)
		{
			switch (hotelType)
			{
				case HotelType.Gold:
					return AppConstants.GoldHotelRent;
				case HotelType.Platinum:
					return AppConstants.PlatinumHotelRent;
				default:
					return AppConstants.SilverHotelRent;
			}
		}

		private int GetHotelValue(HotelType hotelType)
		{
			switch (hotelType)
			{
				case HotelType.Gold:
					return AppConstants.GoldHotelValue;
				case HotelType.Platinum:
					return AppConstants.PlatinumHotelValue;
				default:
					return AppConstants.SilverHotelValue;
			}
		}
	}
}
