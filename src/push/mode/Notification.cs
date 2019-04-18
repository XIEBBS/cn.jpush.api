// Decompiled with JetBrains decompiler
// Type: cn.jpush.api.push.mode.Notification
// Assembly: cn.jpush.api, Version=3.3.3.0, Culture=neutral, PublicKeyToken=null
// MVID: 8C64A4D9-F1B2-4309-8DF5-ACE3B9A5E7DC
// Assembly location: E:\Administrator\Desktop\NET.Reflector\dot\cn.jpush.api.dll

using cn.jpush.api.push.notification;
using cn.jpush.api.util;
using Newtonsoft.Json;

namespace cn.jpush.api.push.mode
{
  public class Notification
  {
    public string alert { get; set; }

    [JsonProperty(PropertyName = "ios")]
    public IosNotification IosNotification { get; set; }

    [JsonProperty(PropertyName = "android")]
    public AndroidNotification AndroidNotification { get; set; }

    [JsonProperty(PropertyName = "winphone")]
    public WinphoneNotification WinphoneNotification { get; set; }

    public Notification()
    {
      this.alert = (string) null;
      this.IosNotification = (IosNotification) null;
      this.AndroidNotification = (AndroidNotification) null;
      this.WinphoneNotification = (WinphoneNotification) null;
    }

    public Notification setAlert(string alert)
    {
      this.alert = alert;
      return this;
    }

    public Notification setAndroid(AndroidNotification android)
    {
      this.AndroidNotification = android;
      return this;
    }

    public Notification setIos(IosNotification ios)
    {
      this.IosNotification = ios;
      return this;
    }

    public Notification setWinphone(WinphoneNotification winphone)
    {
      this.WinphoneNotification = winphone;
      return this;
    }

    public static Notification android(string alert, string title)
    {
      AndroidNotification androidNotification = new AndroidNotification().setAlert(alert).setTitle(title);
      Notification notification = new Notification().setAlert(alert);
      notification.AndroidNotification = androidNotification;
      return notification;
    }

    public static Notification ios(string alert)
    {
      IosNotification iosNotification = new IosNotification().setAlert((object) alert);
      Notification notification = new Notification().setAlert(alert);
      notification.IosNotification = iosNotification;
      return notification;
    }

    public static Notification ios_auto_badge()
    {
      IosNotification iosNotification = new IosNotification();
      iosNotification.autoBadge();
      Notification notification = new Notification().setAlert("");
      notification.IosNotification = iosNotification;
      return notification;
    }

    public static Notification ios_set_badge(int badge)
    {
      IosNotification iosNotification = new IosNotification();
      iosNotification.setBadge(badge);
      return new Notification()
      {
        IosNotification = iosNotification
      };
    }

    public static Notification ios_incr_badge(int badge)
    {
      IosNotification iosNotification = new IosNotification();
      iosNotification.incrBadge(badge);
      return new Notification()
      {
        IosNotification = iosNotification
      };
    }

    public static Notification winphone(string alert)
    {
      WinphoneNotification winphoneNotification = new WinphoneNotification().setAlert(alert);
      Notification notification = new Notification().setAlert(alert);
      notification.WinphoneNotification = winphoneNotification;
      return notification;
    }

    public Notification Check()
    {
      Preconditions.checkArgument(!this.isPlatformEmpty() || this.alert != null, (object) "No notification payload is set.");
      if (this.IosNotification != null)
        Preconditions.checkArgument(this.IosNotification.alert != null || this.alert != null, (object) "No notification payload is set.");
      if (this.AndroidNotification != null)
        Preconditions.checkArgument(this.AndroidNotification.alert != null || this.alert != null, (object) "No notification payload is set.");
      if (this.WinphoneNotification != null)
        Preconditions.checkArgument(this.WinphoneNotification.alert != null || this.alert != null, (object) "No notification payload is set.");
      return this;
    }

    private bool isPlatformEmpty()
    {
      return this.IosNotification == null && this.AndroidNotification == null && this.WinphoneNotification == null;
    }
  }
}
