// Decompiled with JetBrains decompiler
// Type: cn.jpush.api.report.ReceivedResult
// Assembly: cn.jpush.api, Version=3.3.3.0, Culture=neutral, PublicKeyToken=null
// MVID: 8C64A4D9-F1B2-4309-8DF5-ACE3B9A5E7DC
// Assembly location: E:\Administrator\Desktop\NET.Reflector\dot\cn.jpush.api.dll

using cn.jpush.api.common;
using System.Collections.Generic;
using System.Net;

namespace cn.jpush.api.report
{
  public class ReceivedResult : BaseResult
  {
    private List<ReceivedResult.Received> receivedList = new List<ReceivedResult.Received>();

    public List<ReceivedResult.Received> ReceivedList
    {
      get
      {
        return this.receivedList;
      }
      set
      {
        this.receivedList = value;
      }
    }

    public override bool isResultOK()
    {
      return object.Equals((object) this.ResponseResult.responseCode, (object) HttpStatusCode.OK);
    }

    public HttpStatusCode getErrorCode()
    {
      if (this.ResponseResult != null)
        return this.ResponseResult.responseCode;
      return (HttpStatusCode) 0;
    }

    public string getErrorMessage()
    {
      if (this.ResponseResult != null)
        return this.ResponseResult.exceptionString;
      return "";
    }

    public class Received
    {
      public long msg_id;
      public string android_received;
      public string ios_apns_sent;
    }
  }
}
