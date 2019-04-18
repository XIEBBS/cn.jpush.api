// Decompiled with JetBrains decompiler
// Type: cn.jpush.api.push.mode.PushPayload
// Assembly: cn.jpush.api, Version=3.3.3.0, Culture=neutral, PublicKeyToken=null
// MVID: 8C64A4D9-F1B2-4309-8DF5-ACE3B9A5E7DC
// Assembly location: E:\Administrator\Desktop\NET.Reflector\dot\cn.jpush.api.dll

using cn.jpush.api.common;
using cn.jpush.api.util;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace cn.jpush.api.push.mode
{
  public class PushPayload
  {
    private JsonSerializerSettings jSetting;
    private const string PLATFORM = "platform";
    private const string AUDIENCE = "audience";
    private const string NOTIFICATION = "notification";
    private const string MESSAGE = "message";
    private const string SMS_MESSAGE = "sms_message";
    private const string OPTIONS = "options";
    private const int MAX_IOS_ENTITY_LENGTH = 6144;
    private const int MAX_IOS_PAYLOAD_LENGTH = 2048;
    private const int MAX_ANDROID_ENTITY_LENGTH = 4096;

    [JsonConverter(typeof (PlatformConverter))]
    public Platform platform { get; set; }

    [JsonConverter(typeof (AudienceConverter))]
    public Audience audience { get; set; }

    public Notification notification { get; set; }

    public Message message { get; set; }

    public SmsMessage sms_message { get; set; }

    public Options options { get; set; }

    public PushPayload()
    {
      this.platform = (Platform) null;
      this.audience = (Audience) null;
      this.notification = (Notification) null;
      this.message = (Message) null;
      this.sms_message = (SmsMessage) null;
      this.options = new Options();
      JsonSerializerSettings serializerSettings = new JsonSerializerSettings();
      serializerSettings.NullValueHandling=NullValueHandling.Ignore;
      serializerSettings.DefaultValueHandling = DefaultValueHandling.Ignore;
      this.jSetting = serializerSettings;
    }

    public PushPayload(
      Platform platform,
      Audience audience,
      Notification notification,
      Message message = null,
      SmsMessage sms_message = null,
      Options options = null)
    {
      Debug.Assert(platform != null);
      Debug.Assert(audience != null);
      Debug.Assert(notification != null || message != null);
      this.platform = platform;
      this.audience = audience;
      this.notification = notification;
      this.message = message;
      this.sms_message = sms_message;
      this.options = options;
      JsonSerializerSettings serializerSettings = new JsonSerializerSettings();
      serializerSettings.NullValueHandling = NullValueHandling.Ignore;
      serializerSettings.DefaultValueHandling = DefaultValueHandling.Ignore;
      this.jSetting = serializerSettings;
    }

    public static PushPayload AlertAll(string alert)
    {
      return new PushPayload(Platform.all(), Audience.all(), new Notification().setAlert(alert), (Message) null, (SmsMessage) null, new Options());
    }

    public static PushPayload MessageAll(string msgContent)
    {
      return new PushPayload(Platform.all(), Audience.all(), (Notification) null, Message.content(msgContent), (SmsMessage) null, new Options());
    }

    public static PushPayload FromJSON(string payloadString)
    {
      try
      {
        JsonSerializerSettings serializerSettings = new JsonSerializerSettings();
        serializerSettings.NullValueHandling = NullValueHandling.Ignore;
        serializerSettings.DefaultValueHandling = DefaultValueHandling.Ignore;
        return ((PushPayload) JsonConvert.DeserializeObject<PushPayload>(payloadString, serializerSettings)).Check();
      }
      catch (Exception ex)
      {
        Console.WriteLine("JSON to PushPayLoad occur error:" + ex.Message);
        return (PushPayload) null;
      }
    }

    public void ResetOptionsApnsProduction(bool apnsProduction)
    {
      if (this.options == null)
        this.options = new Options();
      this.options.apns_production = apnsProduction;
    }

    public void ResetOptionsTimeToLive(long timeToLive)
    {
      if (this.options == null)
        this.options = new Options();
      this.options.time_to_live = timeToLive;
    }

    public int GetSendno()
    {
      if (this.options != null)
        return this.options.sendno;
      return 0;
    }

    public bool IsGlobalExceedLength()
    {
      return this.IsAndroidExceedLength() && this.IsiOSExceedLength();
    }

    public bool IsiOSExceedLength()
    {
      int num1 = 0;
      if (this.message != null)
      {
        string s = JsonConvert.SerializeObject((object) this.message, this.jSetting);
        num1 += Encoding.UTF8.GetBytes(s).Length;
      }
      if (this.notification == null)
        return num1 > 6144;
      string s1 = JsonConvert.SerializeObject((object) this.notification);
      if (s1 != null)
      {
        int num2 = 0;
        if (this.notification.IosNotification != null)
        {
          string s2 = JsonConvert.SerializeObject((object) this.notification.IosNotification, this.jSetting);
          if (s2 != null)
            num2 = Encoding.UTF8.GetBytes(s2).Length;
        }
        num1 = num1 + Encoding.UTF8.GetBytes(s1).Length - num2;
      }
      return num1 > 6144;
    }

    public bool IsAndroidExceedLength()
    {
      int num1 = 0;
      if (this.message != null)
      {
        string s = JsonConvert.SerializeObject((object) this.message, this.jSetting);
        num1 += Encoding.UTF8.GetBytes(s).Length;
      }
      if (this.notification == null)
        return num1 > 4096;
      string s1 = JsonConvert.SerializeObject((object) this.notification.AndroidNotification);
      if (s1 != null)
      {
        int num2 = 0;
        if (this.notification.AndroidNotification != null)
        {
          string s2 = JsonConvert.SerializeObject((object) this.notification.AndroidNotification, this.jSetting);
          if (s2 != null)
            num2 = Encoding.UTF8.GetBytes(s2).Length;
        }
        num1 = num1 + Encoding.UTF8.GetBytes(s1).Length - num2;
      }
      return num1 > 4096;
    }

    public bool IsIosExceedLength()
    {
      if (this.notification != null)
      {
        if (this.notification.IosNotification != null)
        {
          string s = JsonConvert.SerializeObject((object) this.notification.IosNotification, this.jSetting);
          if (s != null)
            return Encoding.UTF8.GetBytes(s).Length > 2048;
        }
        else if (this.notification.alert != null)
        {
          string s;
          using (StringWriter stringWriter = new StringWriter())
          {
            JsonWriter jsonWriter = (JsonWriter) new JsonTextWriter((TextWriter) stringWriter);
            jsonWriter.WriteValue(this.notification.alert);
            jsonWriter.Flush();
            s = stringWriter.GetStringBuilder().ToString();
          }
          return Encoding.UTF8.GetBytes(s).Length > 2048;
        }
      }
      return false;
    }

    public string ToJson()
    {
      return JsonConvert.SerializeObject((object) this, this.jSetting);
    }

    public PushPayload Check()
    {
      Preconditions.checkArgument(this.audience != null && this.platform != null, (object) "audience and platform both should be set.");
      Preconditions.checkArgument(this.notification != null || this.message != null, (object) "notification or message should be set at least one.");
      if (this.audience != null)
        this.audience.Check();
      if (this.platform != null)
        this.platform.Check();
      if (this.message != null)
        this.message.Check();
      if (this.notification != null)
        this.notification.Check();
      return this;
    }
  }
}
