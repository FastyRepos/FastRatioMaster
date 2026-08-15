using System;
using System.Threading;

namespace RatioMaster {
  /// <summary>
  /// Simple named-mutex single-instance guard.
  /// </summary>
  internal static class SingleInstance {
    private const string MutexName = "Local\\FastLife.RatioMaster.SingleInstance";
    private static Mutex mutex;
    private static bool owned;

    /// <summary>Returns true if this process is the first instance.</summary>
    public static bool TryEnter() {
      mutex = new Mutex(true, MutexName, out owned);
      return owned;
    }

    public static void Release() {
      if (!owned || mutex == null) return;
      try {
        mutex.ReleaseMutex();
      }
      catch (ApplicationException) {
        // ignored
      }
      mutex.Dispose();
      mutex = null;
      owned = false;
    }
  }
}
