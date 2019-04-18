// Decompiled with JetBrains decompiler
// Type: cn.jpush.api.push.notification.WinphoneNotification
// Assembly: cn.jpush.api, Version=3.3.3.0, Culture=neutral, PublicKeyToken=null
// MVID: 8C64A4D9-F1B2-4309-8DF5-ACE3B9A5E7DC
// Assembly location: E:\Administrator\Desktop\NET.Reflector\dot\cn.jpush.api.dll

using Newtonsoft.Json;
using System.Collections.Generic;

namespace cn.jpush.api.push.notification
{
  public class WinphoneNotification : PlatformNotification
  {
    [JsonProperty]
    private string title;
    [JsonProperty(PropertyName = "_open_page")]
    public string openPage;

    public WinphoneNotification()
    {
      this.title = (string) null;
      this.openPage = (string) null;
    }

    public WinphoneNotification setAlert(string alert)
    {
      this.alert = (object) alert;
      return this;
    }

    public WinphoneNotification setOpenPage(string openPage)
    {
      this.openPage = openPage;
      return this;
    }

    public WinphoneNotification setTitle(string title)
    {
      this.title = title;
      return this;
    }

    public WinphoneNotification AddExtra(string key, string value)
    {
      if (this.extras == null)
        this.extras = new Dictionary<string, object>();
      if (value != null)
        this.extras.Add(key, (object) value);
      return this;
    }

    public WinphoneNotification AddExtra(string key, int value)
    {
      if (this.extras == null)
        this.extras = new Dictionary<string, object>();
      this.extras.Add(key, (object) value);
      return this;
    }

    public WinphoneNotification AddExtra(string key, bool value)
    {
      if (this.extras == null)
        this.extras = new Dictionary<string, object>();
      this.extras.Add(key, (object) value);
      return this;
    }

    public WinphoneNotification AddExtra(string key, object value)
    {
      if (this.extras == null)
        this.extras = new Dictionary<string, object>();
      this.extras.Add(key, value);
      return this;
    }
  }
}
