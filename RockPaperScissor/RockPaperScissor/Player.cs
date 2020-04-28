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
		public int PlayerId { get; set; }
		public String Name;
		public int wins;
		public Player(string str)
		{
			this.Name = str;
			wins = 0;
		}
		



	}
}
