﻿using System;
using Eto;
using Eto.Forms;

namespace MDGui.Wpf
{
	public class Program
	{
		[STAThread]
		public static void Main (string[] args)
		{
			new Application (Platforms.Wpf).Run (new MainForm ());
		}
	}
}
