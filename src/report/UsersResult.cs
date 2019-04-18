// Decompiled with JetBrains decompiler
// Type: cn.jpush.api.report.UsersResult
// Assembly: cn.jpush.api, Version=3.3.3.0, Culture=neutral, PublicKeyToken=null
// MVID: 8C64A4D9-F1B2-4309-8DF5-ACE3B9A5E7DC
// Assembly location: E:\Administrator\Desktop\NET.Reflector\dot\cn.jpush.api.dll

using cn.jpush.api.common;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;

namespace cn.jpush.api.report
{
  public class UsersResult : BaseResult
  {
    public List<UsersResult.User> items = new List<UsersResult.User>();
    public TimeUnit time_unit;
    public string start;
    public int duration;

    public UsersResult()
    {
      this.time_unit = TimeUnit.DAY;
      this.start = (string) null;
      this.duration = 0;
    }

    public static UsersResult fromResponse(ResponseWrapper responseWrapper)
    {
      UsersResult usersResult = new UsersResult();
      if (responseWrapper.isServerResponse())
        usersResult = (UsersResult) JsonConvert.DeserializeObject<UsersResult>(responseWrapper.responseContent);
      usersResult.ResponseResult = responseWrapper;
      return usersResult;
    }

    public override bool isResultOK()
    {
      return object.Equals((object) this.ResponseResult.responseCode, (object) HttpStatusCode.OK);
    }

    public class User
    {
      public string time;
      public UsersResult.Android android;
      public UsersResult.Ios ios;

      public User()
      {
        this.time = (string) null;
        this.android = (UsersResult.Android) null;
        this.ios = (UsersResult.Ios) null;
      }
    }

    public class Android
    {
      [JsonProperty(PropertyName = "new")]
      public long add;
      public int online;
      public int active;

      public Android()
      {
        this.add = 0L;
        this.online = 0;
        this.active = 0;
      }
    }

    public class Ios
    {
      [JsonProperty(PropertyName = "new")]
      public long add;
      public int online;
      public int active;

      public Ios()
      {
        this.add = 0L;
        this.online = 0;
        this.active = 0;
      }
    }
  }
}
