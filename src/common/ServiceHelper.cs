// Decompiled with JetBrains decompiler
// Type: cn.jpush.api.common.ServiceHelper
// Assembly: cn.jpush.api, Version=3.3.3.0, Culture=neutral, PublicKeyToken=null
// MVID: 8C64A4D9-F1B2-4309-8DF5-ACE3B9A5E7DC
// Assembly location: E:\Administrator\Desktop\NET.Reflector\dot\cn.jpush.api.dll

using System;

namespace cn.jpush.api.common
{
  public class ServiceHelper
  {
    private const int MAX_BADGE_NUMBER = 99999;
    private const int MIN = 100000;
    private const int MAX = 2147483647;

    public static int generateSendno()
    {
      return new Random().Next(2147383648) + 100000;
    }

    public static bool isValidIntBadge(int intBadge)
    {
      return intBadge >= 0 && intBadge <= 99999;
    }
  }
}
