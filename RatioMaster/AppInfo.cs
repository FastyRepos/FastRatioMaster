using System;
using System.Diagnostics;
using System.Reflection;
using System.Windows.Forms;

namespace RatioMaster {
  /// <summary>
  /// Minimal local app metadata / About helpers.
  /// Owned by FastLife — no third-party updater or remote checks.
  /// </summary>
  internal static class AppInfo {
    public const string Name = "RatioMaster";
    public const string Author = "FastLife";
    public const string SiteUrl = "https://github.com/FastyRepos/FastRatioMaster";

    public static string Title {
      get {
        var v = Version;
        return string.IsNullOrEmpty(v) ? Name : Name + " " + v;
      }
    }

    public static string Version {
      get {
        var ver = Assembly.GetExecutingAssembly().GetName().Version;
        return ver == null ? "" : ver.ToString(3);
      }
    }

    public static void ShowAbout() {
      MessageBox.Show(
        Name + " " + Version + "\n\n" +
        "BitTorrent tracker announce simulator.\n" +
        "Maintained by " + Author + ".\n\n" +
        "No third-party updater libraries are used.",
        Title,
        MessageBoxButtons.OK,
        MessageBoxIcon.Information);
    }

    public static void VisitSite() {
      try {
        Process.Start(new ProcessStartInfo {
          FileName = SiteUrl,
          UseShellExecute = true
        });
      }
      catch (Exception ex) {
        MessageBox.Show("Could not open site:\n" + SiteUrl + "\n\n" + ex.Message,
          Title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
      }
    }

    public static void ShowNoAutoUpdate() {
      MessageBox.Show(
        "Automatic updates have been removed.\n" +
        "Update the app manually from:\n" + SiteUrl,
        Title,
        MessageBoxButtons.OK,
        MessageBoxIcon.Information);
    }
  }
}
