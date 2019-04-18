// Decompiled with JetBrains decompiler
// Type: cn.jpush.api.common.resp.APIConnectionException
// Assembly: cn.jpush.api, Version=3.3.3.0, Culture=neutral, PublicKeyToken=null
// MVID: 8C64A4D9-F1B2-4309-8DF5-ACE3B9A5E7DC
// Assembly location: E:\Administrator\Desktop\NET.Reflector\dot\cn.jpush.api.dll

using System;

namespace cn.jpush.api.common.resp
{
  public class APIConnectionException : Exception
  {
    public string message;
    public string info;

    public APIConnectionException(string message, string info)
      : base(message)
    {
      this.message = message;
      this.info = info;
    }
  }
}
