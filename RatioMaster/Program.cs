using System;
using System.Windows.Forms;

namespace RatioMaster {
  internal static class Program {

    [STAThread]
    internal static void Main() {
      if (!SingleInstance.TryEnter()) {
        MessageBox.Show(AppInfo.Name + " is already running.", AppInfo.Name,
          MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        return;
      }

      try {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(new MainForm());
      }
      finally {
        SingleInstance.Release();
      }
    }
  }
}
