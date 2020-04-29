using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace RockPaperScissor
{
    public class Player

    {
		private int _PlayerID;
		public int PlayerId { get => _PlayerID; set => _PlayerID = value; }
		public String Name;
		public int wins;
		public Player(string str)
		{
			this.Name = str;
			wins = 0;
		}

		public Player() { }
		



	}
}
