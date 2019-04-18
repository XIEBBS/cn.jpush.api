// Decompiled with JetBrains decompiler
// Type: cn.jpush.api.common.ResponseWrapper
// Assembly: cn.jpush.api, Version=3.3.3.0, Culture=neutral, PublicKeyToken=null
// MVID: 8C64A4D9-F1B2-4309-8DF5-ACE3B9A5E7DC
// Assembly location: E:\Administrator\Desktop\NET.Reflector\dot\cn.jpush.api.dll

using cn.jpush.api.push;
using cn.jpush.api.util;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Net;

namespace cn.jpush.api.common
{
  public class ResponseWrapper
  {
    public HttpStatusCode responseCode = HttpStatusCode.BadRequest;
    private const int RESPONSE_CODE_NONE = -1;
    private string _responseContent;
    public JpushError jpushError;
    public int rateLimitQuota;
    public int rateLimitRemaining;
    public int rateLimitReset;
    public string exceptionString;

    public string responseContent
    {
      get
      {
        return this._responseContent;
      }
      set
      {
        this._responseContent = value;
      }
    }

    public void setErrorObject()
    {
      if (string.IsNullOrEmpty(this._responseContent))
        return;
      this.jpushError = (JpushError) JsonConvert.DeserializeObject<JpushError>(this._responseContent);
    }

    public bool isServerResponse()
    {
      return this.responseCode == HttpStatusCode.OK;
    }

    public void setRateLimit(string quota, string remaining, string reset)
    {
      if (quota == null)
        return;
      try
      {
        if (quota != "" && StringUtil.IsInt(quota))
          this.rateLimitQuota = int.Parse(quota);
        if (remaining != "" && StringUtil.IsInt(remaining))
          this.rateLimitRemaining = int.Parse(remaining);
        if (reset != "" && StringUtil.IsInt(reset))
          this.rateLimitReset = int.Parse(reset);
        Console.WriteLine(string.Format("JPush API Rate Limiting params - quota:{0}, remaining:{1}, reset:{2} ", (object) quota, (object) remaining, (object) reset) + " " + (object) DateTime.Now);
      }
      catch (Exception ex)
      {
        Debug.Print(ex.Message);
      }
    }
  }
}
