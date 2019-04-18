// Decompiled with JetBrains decompiler
// Type: cn.jpush.api.push.mode.Message
// Assembly: cn.jpush.api, Version=3.3.3.0, Culture=neutral, PublicKeyToken=null
// MVID: 8C64A4D9-F1B2-4309-8DF5-ACE3B9A5E7DC
// Assembly location: E:\Administrator\Desktop\NET.Reflector\dot\cn.jpush.api.dll

using cn.jpush.api.util;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace cn.jpush.api.push.mode
{
  public class Message
  {
    public string title { get; set; }

    public string msg_content { get; set; }

    public string content_type { get; set; }

    [JsonProperty]
    private Dictionary<string, object> extras { get; set; }

    private Message()
    {
    }

    private Message(string msgContent)
    {
      Preconditions.checkArgument(msgContent != null, (object) "msgContent should be set");
      this.title = (string) null;
      this.msg_content = msgContent;
      this.content_type = (string) null;
      this.extras = (Dictionary<string, object>) null;
    }

    private Message(string msgContent, string title, string contentType)
    {
      Preconditions.checkArgument(msgContent != null, (object) "msgContent should be set");
      this.title = title;
      this.msg_content = msgContent;
      this.content_type = contentType;
    }

    public static Message content(string msgContent)
    {
      return new Message(msgContent).Check();
    }

    public Message setTitle(string title)
    {
      this.title = title;
      return this;
    }

    public Message setContentType(string ContentType)
    {
      this.content_type = ContentType;
      return this;
    }

    public Message AddExtras(string key, string value)
    {
      if (this.extras == null)
        this.extras = new Dictionary<string, object>();
      if (value != null)
        this.extras.Add(key, (object) value);
      return this;
    }

    public Message AddExtras(string key, int value)
    {
      if (this.extras == null)
        this.extras = new Dictionary<string, object>();
      this.extras.Add(key, (object) value);
      return this;
    }

    public Message AddExtras(string key, bool value)
    {
      if (this.extras == null)
        this.extras = new Dictionary<string, object>();
      this.extras.Add(key, (object) value);
      return this;
    }

    public Message Check()
    {
      Preconditions.checkArgument(this.msg_content != null, (object) "msgContent should be set");
      return this;
    }
  }
}
