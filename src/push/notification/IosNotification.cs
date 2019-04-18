// Decompiled with JetBrains decompiler
// Type: cn.jpush.api.push.notification.IosNotification
// Assembly: cn.jpush.api, Version=3.3.3.0, Culture=neutral, PublicKeyToken=null
// MVID: 8C64A4D9-F1B2-4309-8DF5-ACE3B9A5E7DC
// Assembly location: E:\Administrator\Desktop\NET.Reflector\dot\cn.jpush.api.dll

using cn.jpush.api.common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace cn.jpush.api.push.notification
{
  public class IosNotification : PlatformNotification
  {
    public const string NOTIFICATION_IOS = "ios";
    private const string DEFAULT_SOUND = "";
    private const string DEFAULT_BADGE = "+1";
    private const string BADGE = "badge";
    private const string SOUND = "sound";
    private const string CONTENT_AVAILABLE = "content-available";
    private const string CATEGORY = "category";
    private const string ALERT_VALID_BADGE = "Badge number should be 0~99999, and badgeDisabled property must be false";
    private const string SOUND_VALID_BADGE = "Sound should not be null or empty, and disableSound property must be false";
    private bool soundDisabled;
    private bool badgeDisabled;

    [JsonProperty]
    public string sound { get; private set; }

    [JsonProperty]
    public string badge { get; private set; }

    [JsonProperty(PropertyName = "content-available")]
    public bool contentAvailable { get; private set; }

    [JsonProperty(PropertyName = "mutable-content")]
    public bool mutableContent { get; private set; }

    [JsonProperty]
    public string category { get; private set; }

    public IosNotification()
    {
      this.alert = (object) null;
      this.extras = (Dictionary<string, object>) null;
      this.soundDisabled = false;
      this.badgeDisabled = false;
      this.contentAvailable = false;
      this.category = (string) null;
      this.badge = "+1";
      this.sound = "";
    }

    public IosNotification disableSound()
    {
      this.soundDisabled = true;
      this.sound = (string) null;
      return this;
    }

    public IosNotification disableBadge()
    {
      this.badgeDisabled = true;
      this.badge = (string) null;
      return this;
    }

    public IosNotification setSound(string sound)
    {
      if (sound == null || this.soundDisabled)
      {
        Console.WriteLine("Sound should not be null or empty, and disableSound property must be false");
        return this;
      }
      this.sound = sound;
      return this;
    }

    public IosNotification setBadge(int badge)
    {
      if (!ServiceHelper.isValidIntBadge(Math.Abs(badge)) || this.badgeDisabled)
      {
        Console.WriteLine("Badge number should be 0~99999, and badgeDisabled property must be false");
        return this;
      }
      this.badge = badge.ToString();
      return this;
    }

    public IosNotification autoBadge()
    {
      return this.incrBadge(1);
    }

    public IosNotification incrBadge(int badge)
    {
      if (!ServiceHelper.isValidIntBadge(Math.Abs(badge)) || this.badgeDisabled)
      {
        Console.WriteLine("Badge number should be 0~99999, and badgeDisabled property must be false");
        return this;
      }
      this.badge = badge < 0 ? string.Concat((object) badge) : "+" + (object) badge;
      return this;
    }

    public IosNotification setAlert(object alert)
    {
      this.alert = alert;
      return this;
    }

    public IosNotification setContentAvailable(bool contentAvailable)
    {
      this.contentAvailable = contentAvailable;
      return this;
    }

    public IosNotification setMutableContent(bool mutableContent)
    {
      this.mutableContent = mutableContent;
      return this;
    }

    public IosNotification setCategory(string category)
    {
      this.category = category;
      return this;
    }

    public IosNotification AddExtra(string key, string value)
    {
      if (this.extras == null)
        this.extras = new Dictionary<string, object>();
      if (value != null)
        this.extras.Add(key, (object) value);
      return this;
    }

    public IosNotification AddExtra(string key, int value)
    {
      if (this.extras == null)
        this.extras = new Dictionary<string, object>();
      this.extras.Add(key, (object) value);
      return this;
    }

    public IosNotification AddExtra(string key, bool value)
    {
      if (this.extras == null)
        this.extras = new Dictionary<string, object>();
      this.extras.Add(key, (object) value);
      return this;
    }

    public IosNotification AddExtra(string key, object value)
    {
      if (this.extras == null)
        this.extras = new Dictionary<string, object>();
      this.extras.Add(key, value);
      return this;
    }
  }
}
