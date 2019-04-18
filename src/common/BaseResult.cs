// Decompiled with JetBrains decompiler
// Type: cn.jpush.api.common.BaseResult
// Assembly: cn.jpush.api, Version=3.3.3.0, Culture=neutral, PublicKeyToken=null
// MVID: 8C64A4D9-F1B2-4309-8DF5-ACE3B9A5E7DC
// Assembly location: E:\Administrator\Desktop\NET.Reflector\dot\cn.jpush.api.dll

namespace cn.jpush.api.common
{
  public abstract class BaseResult
  {
    public const int ERROR_CODE_NONE = -1;
    public const int ERROR_CODE_OK = 0;
    public const string ERROR_MESSAGE_NONE = "None error message";
    public const int RESPONSE_OK = 200;
    private ResponseWrapper responseResult;

    public ResponseWrapper ResponseResult
    {
      get
      {
        return this.responseResult;
      }
      set
      {
        this.responseResult = value;
      }
    }

    public abstract bool isResultOK();

    public int getRateLimitQuota()
    {
      if (this.responseResult != null)
        return this.responseResult.rateLimitQuota;
      return 0;
    }

    public int getRateLimitRemaining()
    {
      if (this.responseResult != null)
        return this.responseResult.rateLimitRemaining;
      return 0;
    }

    public int getRateLimitReset()
    {
      if (this.responseResult != null)
        return this.responseResult.rateLimitReset;
      return 0;
    }
  }
}
