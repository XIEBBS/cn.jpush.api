// Decompiled with JetBrains decompiler
// Type: cn.jpush.api.push.getScheduleResult
// Assembly: cn.jpush.api, Version=3.3.3.0, Culture=neutral, PublicKeyToken=null
// MVID: 8C64A4D9-F1B2-4309-8DF5-ACE3B9A5E7DC
// Assembly location: E:\Administrator\Desktop\NET.Reflector\dot\cn.jpush.api.dll

using cn.jpush.api.common;
using cn.jpush.api.schedule;
using System.Net;

namespace cn.jpush.api.push
{
  public class getScheduleResult : BaseResult
  {
    public SchedulePayload[] schedules;

    public int total_count { get; set; }

    public int total_pages { get; set; }

    public int page { get; set; }

    public override bool isResultOK()
    {
      return object.Equals((object) this.ResponseResult.responseCode, (object) HttpStatusCode.OK);
    }

    public override string ToString()
    {
      return string.Format("total_count:{0},total_pages:{1},page:{2}", (object) this.total_count, (object) this.total_pages, (object) this.page);
    }
  }
}
