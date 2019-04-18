// Decompiled with JetBrains decompiler
// Type: cn.jpush.api.push.notification.AndroidNotification
// Assembly: cn.jpush.api, Version=3.3.3.0, Culture=neutral, PublicKeyToken=null
// MVID: 8C64A4D9-F1B2-4309-8DF5-ACE3B9A5E7DC
// Assembly location: E:\Administrator\Desktop\NET.Reflector\dot\cn.jpush.api.dll

using Newtonsoft.Json;
using System.Collections.Generic;

namespace cn.jpush.api.push.notification
{
  public class AndroidNotification : PlatformNotification
  {
    public const string NOTIFICATION_ANDROID = "android";
    private const string TITLE = "title";
    private const string BUILDER_ID = "builder_id";

    [JsonProperty]
    public string title { get; private set; }

    [JsonProperty]
    public int builder_id { get; private set; }

    [JsonProperty]
    public int priority { get; private set; }

    [JsonProperty]
    public string category { get; private set; }

    [JsonProperty]
    public int style { get; private set; }

    [JsonProperty]
    public int alert_type { get; private set; }

    [JsonProperty]
    public string big_text { get; private set; }

    [JsonProperty]
    public string inbox { get; private set; }

    [JsonProperty]
    public string big_pic_path { get; private set; }

    [JsonProperty]
    public string uri_activity { get; private set; }

    [JsonProperty]
    public string url_flag { get; private set; }

    [JsonProperty]
    public string uri_action { get; private set; }

    public AndroidNotification()
    {
      this.title = (string) null;
      this.builder_id = 0;
    }

    public AndroidNotification setTitle(string title)
    {
      this.title = title;
      return this;
    }

    public AndroidNotification setBuilderID(int builder_id)
    {
      this.builder_id = builder_id;
      return this;
    }

    public AndroidNotification setAlert(string alert)
    {
      this.alert = (object) alert;
      return this;
    }

    public AndroidNotification setPriority(int priority)
    {
      this.priority = priority;
      return this;
    }

    public AndroidNotification setCategory(string category)
    {
      this.category = category;
      return this;
    }

    public AndroidNotification setStyle(int style)
    {
      this.style = style;
      return this;
    }

    public AndroidNotification setAlert_type(int alert_type)
    {
      this.alert_type = alert_type;
      return this;
    }

    public AndroidNotification setBig_text(string big_text)
    {
      this.big_text = big_text;
      return this;
    }

    public AndroidNotification setInbox(string inbox)
    {
      this.inbox = inbox;
      return this;
    }

    public AndroidNotification setBig_pic_path(string big_pic_path)
    {
      this.big_pic_path = big_pic_path;
      return this;
    }

    public AndroidNotification setUrlActivity(string url_activity)
    {
      this.uri_activity = url_activity;
      return this;
    }

    public AndroidNotification setUrlFlag(string url_flag)
    {
      this.url_flag = url_flag;
      return this;
    }

    public AndroidNotification setUriAction(string uri_action)
    {
      this.uri_action = uri_action;
      return this;
    }

    public AndroidNotification AddExtra(string key, string value)
    {
      if (this.extras == null)
        this.extras = new Dictionary<string, object>();
      if (value != null)
        this.extras.Add(key, (object) value);
      return this;
    }

    public AndroidNotification AddExtra(string key, int value)
    {
      if (this.extras == null)
        this.extras = new Dictionary<string, object>();
      this.extras.Add(key, (object) value);
      return this;
    }

    public AndroidNotification AddExtra(string key, bool value)
    {
      if (this.extras == null)
        this.extras = new Dictionary<string, object>();
      this.extras.Add(key, (object) value);
      return this;
    }

    public AndroidNotification AddExtra(string key, object value)
    {
      if (this.extras == null)
        this.extras = new Dictionary<string, object>();
      this.extras.Add(key, value);
      return this;
    }
  }
}
