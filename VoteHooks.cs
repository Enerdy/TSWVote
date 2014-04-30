﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TShockAPI;

namespace TSWVote
{
	public static class VoteHooks
	{
		private static event VoteSuccessHandler VoteSuccess;

		internal static void InvokeVoteSuccess(TSPlayer Player)
		{
			if (VoteSuccess != null) VoteSuccess.Invoke(new VoteSuccessArgs(Player));
		}

		public static void VoteSuccessRegister(VoteSuccessHandler Handler)
		{
			VoteSuccess += Handler;
		}

		public static void VoteSuccessDeregister(VoteSuccessHandler Handler)
		{
			VoteSuccess -= Handler;
		}
	}

	public delegate void VoteSuccessHandler(VoteSuccessArgs e);

	public class VoteSuccessArgs : EventArgs
	{
		public TSPlayer Player;

		public VoteSuccessArgs(TSPlayer player)
		{
			Player = player;
		}
	}
}