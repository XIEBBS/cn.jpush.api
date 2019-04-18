// Decompiled with JetBrains decompiler
// Type: cn.jpush.api.schedule.ScheduleListResult
// Assembly: cn.jpush.api, Version=3.3.3.0, Culture=neutral, PublicKeyToken=null
// MVID: 8C64A4D9-F1B2-4309-8DF5-ACE3B9A5E7DC
// Assembly location: E:\Administrator\Desktop\NET.Reflector\dot\cn.jpush.api.dll

using cn.jpush.api.common;
using System;

namespace cn.jpush.api.schedule
{
  internal class ScheduleListResult : BaseResult
  {
    public int total_count;
    public int total_pages;
    public int page;
    public SchedulePayload[] schedules;

    public override bool isResultOK()
    {
      throw new NotImplementedException();
    }

    public SchedulePayload[] getSchedules()
    {
      return this.schedules;
    }

    public int getTotal_count()
    {
      return this.total_count;
    }

    public int getTotal_pages()
    {
      return this.total_pages;
    }

    public int getPage()
    {
      return this.page;
    }
  }
}
