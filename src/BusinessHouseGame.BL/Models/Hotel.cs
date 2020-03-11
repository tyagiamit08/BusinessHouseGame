using BusinessHouseGame.BL.Enums;

namespace BusinessHouseGame.BL.Models
{
	public class Hotel
	{
		public HotelType Type { get; set; }
		public int Value { get; set; }
		public int Rent { get; set; }
		public string OwnedBy { get; set; }
		public string RentedTo { get; set; }
	}
}
