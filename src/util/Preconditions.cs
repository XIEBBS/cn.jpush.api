// Decompiled with JetBrains decompiler
// Type: cn.jpush.api.util.Preconditions
// Assembly: cn.jpush.api, Version=3.3.3.0, Culture=neutral, PublicKeyToken=null
// MVID: 8C64A4D9-F1B2-4309-8DF5-ACE3B9A5E7DC
// Assembly location: E:\Administrator\Desktop\NET.Reflector\dot\cn.jpush.api.dll

using System;

namespace cn.jpush.api.util
{
  internal class Preconditions
  {
    public static void checkArgument(bool expression)
    {
      if (!expression)
        throw new ArgumentNullException();
    }

    public static void checkArgument(bool expression, object errorMessage)
    {
      if (!expression)
        throw new ArgumentException(errorMessage.ToString());
    }
  }
}
