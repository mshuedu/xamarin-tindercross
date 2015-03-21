using System;

namespace TinderCross.Portable.Model
{
	public static class Globals
	{
		public static MainModel MainModel { get; set; }

		static Globals ()
		{
			MainModel = new MainModel ();
		}
	}
}

