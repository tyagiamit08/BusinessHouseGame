using System.Collections.Generic;

namespace BusinessHouseGame.BL.Models
{
	public class Board
	{
		public int BankMoney { get; set; } = 5000;
		public List<BoardCell> Cells { get; set; }
	}
}
