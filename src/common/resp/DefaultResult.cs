// Decompiled with JetBrains decompiler
// Type: cn.jpush.api.common.resp.DefaultResult
// Assembly: cn.jpush.api, Version=3.3.3.0, Culture=neutral, PublicKeyToken=null
// MVID: 8C64A4D9-F1B2-4309-8DF5-ACE3B9A5E7DC
// Assembly location: E:\Administrator\Desktop\NET.Reflector\dot\cn.jpush.api.dll

using System.Net;

namespace cn.jpush.api.common.resp
{
  public class DefaultResult : BaseResult
  {
    public static DefaultResult fromResponse(ResponseWrapper responseWrapper)
    {
      DefaultResult defaultResult = (DefaultResult) null;
      if (responseWrapper.isServerResponse())
        defaultResult = new DefaultResult();
      defaultResult.ResponseResult = responseWrapper;
      return defaultResult;
    }

    public override bool isResultOK()
    {
      return object.Equals((object) this.ResponseResult.responseCode, (object) HttpStatusCode.OK);
    }
  }
}
