// Decompiled with JetBrains decompiler
// Type: cn.jpush.api.push.mode.SmsMessage
// Assembly: cn.jpush.api, Version=3.3.3.0, Culture=neutral, PublicKeyToken=null
// MVID: 8C64A4D9-F1B2-4309-8DF5-ACE3B9A5E7DC
// Assembly location: E:\Administrator\Desktop\NET.Reflector\dot\cn.jpush.api.dll

using cn.jpush.api.util;
using Newtonsoft.Json;

namespace cn.jpush.api.push.mode
{
  public class SmsMessage
  {
    public string content { get; set; }

    [JsonProperty]
    public int delay_time { get; set; }

    public SmsMessage()
    {
    }

    public SmsMessage(string content, int delay_time)
    {
      Preconditions.checkArgument(content != null, (object) "sms_message Content should be set");
      Preconditions.checkArgument(this.content.Length <= 480, (object) "sms_message's length should be less than 480 bytes");
      this.Check();
      this.setContent(content);
      this.setDelayTime(delay_time);
    }

    public SmsMessage setDelayTime(int delay_time)
    {
      this.delay_time = delay_time;
      return this;
    }

    public SmsMessage setContent(string content)
    {
      this.content = content;
      return this;
    }

    public SmsMessage Check()
    {
      Preconditions.checkArgument(this.content != null, (object) "sms_message Content should be set");
      Preconditions.checkArgument(this.content.Length <= 480, (object) "sms_message's length should be less than 480 bytes");
      return this;
    }
  }
}
