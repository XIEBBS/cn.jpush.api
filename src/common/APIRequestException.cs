// Decompiled with JetBrains decompiler
// Type: cn.jpush.api.common.APIRequestException
// Assembly: cn.jpush.api, Version=3.3.3.0, Culture=neutral, PublicKeyToken=null
// MVID: 8C64A4D9-F1B2-4309-8DF5-ACE3B9A5E7DC
// Assembly location: E:\Administrator\Desktop\NET.Reflector\dot\cn.jpush.api.dll

using cn.jpush.api.push;
using System;
using System.Net;

namespace cn.jpush.api.common
{
  public class APIRequestException : Exception
  {
    private ResponseWrapper responseRequest;

    public APIRequestException(ResponseWrapper responseRequest)
      : base(responseRequest.exceptionString)
    {
      this.responseRequest = responseRequest;
    }

    public HttpStatusCode Status
    {
      get
      {
        return this.responseRequest.responseCode;
      }
    }

    public long MsgId
    {
      get
      {
        return this.responseRequest.jpushError.msg_id;
      }
    }

    public int ErrorCode
    {
      get
      {
        return this.responseRequest.jpushError.error.code;
      }
    }

    public string ErrorMessage
    {
      get
      {
        return this.responseRequest.jpushError.error.message;
      }
    }

    private JpushError ErrorObject()
    {
      return this.responseRequest.jpushError;
    }

    public int RateLimitQuota()
    {
      return this.responseRequest.rateLimitQuota;
    }

    public int RateLimitRemaining()
    {
      return this.responseRequest.rateLimitRemaining;
    }

    public int RateLimitReset()
    {
      return this.responseRequest.rateLimitReset;
    }
  }
}
