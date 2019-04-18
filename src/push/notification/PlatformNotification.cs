// Decompiled with JetBrains decompiler
// Type: cn.jpush.api.push.notification.PlatformNotification
// Assembly: cn.jpush.api, Version=3.3.3.0, Culture=neutral, PublicKeyToken=null
// MVID: 8C64A4D9-F1B2-4309-8DF5-ACE3B9A5E7DC
// Assembly location: E:\Administrator\Desktop\NET.Reflector\dot\cn.jpush.api.dll

using Newtonsoft.Json;
using System.Collections.Generic;

namespace cn.jpush.api.push.notification
{
  public abstract class PlatformNotification
  {
    public const string ALERT = "alert";
    private const string EXTRAS = "extras";

    [JsonProperty]
    public object alert { get; protected set; }

    [JsonProperty]
    public Dictionary<string, object> extras { get; protected set; }

    public PlatformNotification()
    {
      this.alert = (object) null;
      this.extras = (Dictionary<string, object>) null;
    }
  }
}
