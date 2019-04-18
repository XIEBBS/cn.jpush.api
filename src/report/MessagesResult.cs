// Decompiled with JetBrains decompiler
// Type: cn.jpush.api.report.MessagesResult
// Assembly: cn.jpush.api, Version=3.3.3.0, Culture=neutral, PublicKeyToken=null
// MVID: 8C64A4D9-F1B2-4309-8DF5-ACE3B9A5E7DC
// Assembly location: E:\Administrator\Desktop\NET.Reflector\dot\cn.jpush.api.dll

using cn.jpush.api.common;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;

namespace cn.jpush.api.report
{
  public class MessagesResult : BaseResult
  {
    public List<MessagesResult.Message> messages = new List<MessagesResult.Message>();

    public static MessagesResult fromResponse(ResponseWrapper responseWrapper)
    {
      MessagesResult messagesResult = new MessagesResult();
      if (responseWrapper.responseCode == HttpStatusCode.OK)
        messagesResult.messages = (List<MessagesResult.Message>) JsonConvert.DeserializeObject<List<MessagesResult.Message>>(responseWrapper.responseContent);
      messagesResult.ResponseResult = responseWrapper;
      return messagesResult;
    }

    public override bool isResultOK()
    {
      return object.Equals((object) this.ResponseResult.responseCode, (object) HttpStatusCode.OK);
    }

    public class Message
    {
      public long? msg_id;
      public MessagesResult.Android android;
      public MessagesResult.Ios ios;

      public Message()
      {
        this.msg_id = new long?(0L);
        this.android = (MessagesResult.Android) null;
        this.ios = (MessagesResult.Ios) null;
      }
    }

    public class Android
    {
      public int? received;
      public int? target;
      public int? online_push;
      public int? click;

      public Android()
      {
        this.received = new int?(0);
        this.target = new int?(0);
        this.online_push = new int?(0);
        this.click = new int?(0);
      }
    }

    public class Ios
    {
      public int? apns_sent;
      public int? apns_target;
      public int? click;

      public Ios()
      {
        this.apns_sent = new int?(0);
        this.apns_target = new int?(0);
        this.click = new int?(0);
      }
    }
  }
}
