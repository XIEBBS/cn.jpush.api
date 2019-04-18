// Decompiled with JetBrains decompiler
// Type: cn.jpush.api.util.Md5
// Assembly: cn.jpush.api, Version=3.3.3.0, Culture=neutral, PublicKeyToken=null
// MVID: 8C64A4D9-F1B2-4309-8DF5-ACE3B9A5E7DC
// Assembly location: E:\Administrator\Desktop\NET.Reflector\dot\cn.jpush.api.dll

using System.Security.Cryptography;
using System.Text;

namespace cn.jpush.api.util
{
  internal class Md5
  {
    public static string getMD5Hash(string str)
    {
      byte[] hash = MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(str));
      StringBuilder stringBuilder = new StringBuilder();
      foreach (byte num in hash)
        stringBuilder.Append(num.ToString("x2"));
      return stringBuilder.ToString();
    }
  }
}
