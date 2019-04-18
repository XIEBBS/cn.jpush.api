// Decompiled with JetBrains decompiler
// Type: cn.jpush.api.push.mode.Platform
// Assembly: cn.jpush.api, Version=3.3.3.0, Culture=neutral, PublicKeyToken=null
// MVID: 8C64A4D9-F1B2-4309-8DF5-ACE3B9A5E7DC
// Assembly location: E:\Administrator\Desktop\NET.Reflector\dot\cn.jpush.api.dll

using cn.jpush.api.common;
using cn.jpush.api.util;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Diagnostics;

namespace cn.jpush.api.push.mode
{
  public class Platform
  {
    private const string ALL = "all";
    private HashSet<string> _deviceTypes;

    [JsonProperty(PropertyName = "winphone")]
    public string allPlatform { get; set; }

    public HashSet<string> deviceTypes
    {
      get
      {
        return this._deviceTypes;
      }
      set
      {
        if (value != null)
          this.allPlatform = (string) null;
        this._deviceTypes = value;
      }
    }

    private Platform()
    {
      this.allPlatform = "all";
      this.deviceTypes = (HashSet<string>) null;
    }

    private Platform(bool all, HashSet<string> deviceTypes)
    {
      Debug.Assert(all && deviceTypes == null || !all && deviceTypes != null);
      if (all)
        this.allPlatform = nameof (all);
      this.deviceTypes = deviceTypes;
    }

    public static Platform all()
    {
      return new Platform(true, (HashSet<string>) null).Check();
    }

    public static Platform ios()
    {
      return new Platform(false, new HashSet<string>()
      {
        DeviceType.ios.ToString()
      }).Check();
    }

    public static Platform android()
    {
      return new Platform(false, new HashSet<string>()
      {
        DeviceType.android.ToString()
      }).Check();
    }

    public static Platform winphone()
    {
      return new Platform(false, new HashSet<string>()
      {
        DeviceType.winphone.ToString()
      }).Check();
    }

    public static Platform android_ios()
    {
      return new Platform(false, new HashSet<string>()
      {
        DeviceType.android.ToString(),
        DeviceType.ios.ToString()
      }).Check();
    }

    public static Platform android_winphone()
    {
      return new Platform(false, new HashSet<string>()
      {
        DeviceType.android.ToString(),
        DeviceType.winphone.ToString()
      }).Check();
    }

    public static Platform ios_winphone()
    {
      return new Platform(false, new HashSet<string>()
      {
        DeviceType.ios.ToString(),
        DeviceType.winphone.ToString()
      }).Check();
    }

    public bool isAll()
    {
      return this.allPlatform != null;
    }

    public void setAll(bool all)
    {
      if (all)
        this.allPlatform = nameof (all);
      else
        this.allPlatform = (string) null;
    }

    public Platform Check()
    {
      Preconditions.checkArgument(!this.isAll() || this.deviceTypes == null, (object) "Since all is enabled, any platform should not be set.");
      Preconditions.checkArgument(this.isAll() || this.deviceTypes != null, (object) "No any deviceType is set.");
      return this;
    }
  }
}
