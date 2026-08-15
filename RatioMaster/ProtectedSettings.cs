using System;
using System.Security.Cryptography;
using System.Text;

namespace RatioMaster {
  /// <summary>
  /// DPAPI helper for secrets stored in the registry or session XML.
  /// Legacy plaintext values are still accepted on read.
  /// </summary>
  internal static class ProtectedSettings {
    private const string Prefix = "dpapi:";
    private static readonly byte[] Entropy = Encoding.UTF8.GetBytes("RatioMaster.ProxyPass.v1");

    internal static string Protect(string plaintext) {
      if (string.IsNullOrEmpty(plaintext)) {
        return "";
      }

      try {
        var data = Encoding.UTF8.GetBytes(plaintext);
        var protectedBytes = ProtectedData.Protect(data, Entropy, DataProtectionScope.CurrentUser);
        return Prefix + Convert.ToBase64String(protectedBytes);
      }
      catch {
        return "";
      }
    }

    internal static string Unprotect(string stored) {
      if (string.IsNullOrEmpty(stored)) {
        return "";
      }

      if (!stored.StartsWith(Prefix, StringComparison.Ordinal)) {
        return stored;
      }

      try {
        var protectedBytes = Convert.FromBase64String(stored.Substring(Prefix.Length));
        var data = ProtectedData.Unprotect(protectedBytes, Entropy, DataProtectionScope.CurrentUser);
        return Encoding.UTF8.GetString(data);
      }
      catch {
        return "";
      }
    }
  }
}
