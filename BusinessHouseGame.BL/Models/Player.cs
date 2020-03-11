using System.Collections.Generic;

namespace BusinessHouseGame.BL.Models
{
	public class Player
	{
		public Player()
		{
			Moves = new List<int>();
			HotelsOwned = new List<Hotel>();
		}
		public int Money { get; set; } = 1000;
		public List<int> Moves { get; set; }
		public int MovesPlayed { get; set; }
		public List<Hotel> HotelsOwned { get; set; }
	}
}
