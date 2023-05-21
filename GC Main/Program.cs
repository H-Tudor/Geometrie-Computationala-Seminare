global using GC.Resource;
global using GC.UI;
global using System;
global using System.Collections.Generic;
global using System.Linq;
global using System.Windows.Forms;
global using static GC.Engine.PointOperations;

namespace GC {
	internal static class Program {
		[STAThread]
		static void Main() {
			ApplicationConfiguration.Initialize();
			Application.Run(new UI.MainForm());
		}
	}
}