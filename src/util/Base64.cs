// Decompiled with JetBrains decompiler
// Type: cn.jpush.api.util.Base64
// Assembly: cn.jpush.api, Version=3.3.3.0, Culture=neutral, PublicKeyToken=null
// MVID: 8C64A4D9-F1B2-4309-8DF5-ACE3B9A5E7DC
// Assembly location: E:\Administrator\Desktop\NET.Reflector\dot\cn.jpush.api.dll

using System;
using System.Text;

namespace cn.jpush.api.util
{
  internal class Base64
  {
    public static string getBase64Encode(string str)
    {
      return Convert.ToBase64String(Encoding.Default.GetBytes(str));
    }
  }
}
