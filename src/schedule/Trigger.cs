// Decompiled with JetBrains decompiler
// Type: cn.jpush.api.schedule.Trigger
// Assembly: cn.jpush.api, Version=3.3.3.0, Culture=neutral, PublicKeyToken=null
// MVID: 8C64A4D9-F1B2-4309-8DF5-ACE3B9A5E7DC
// Assembly location: E:\Administrator\Desktop\NET.Reflector\dot\cn.jpush.api.dll

using cn.jpush.api.util;
using System;

namespace cn.jpush.api.schedule
{
  public class Trigger
  {
    private const string TRIGGER = "trigger";
    private const string SINGLE = "single";
    public Periodical periodical;
    public Single single;

    public Trigger()
    {
      this.periodical = new Periodical();
      this.single = new Single();
    }

    public Trigger(Single single)
    {
      this.single = single;
      this.periodical = (Periodical) null;
      //throw new NotImplementedException();
    }

    public Trigger(Periodical periodical)
    {
      this.periodical = periodical;
      this.single = (Single) null;
      //throw new NotImplementedException();
    }

    public Trigger(string time)
    {
      Preconditions.checkArgument(!string.IsNullOrEmpty(time), (object) "The time must not be empty.");
      Preconditions.checkArgument(StringUtil.IsDateTime(time), (object) "the time is not valid");
      Single single = new Single();
      single.setTime(time);
      this.single = single;
    }

    public Trigger(
      string start,
      string end,
      string time,
      string time_unit,
      int frequency,
      string[] point)
    {
      Preconditions.checkArgument(!string.IsNullOrEmpty(start), (object) "The start time must not be empty.");
      Preconditions.checkArgument(!string.IsNullOrEmpty(end), (object) "The end time must not be empty.");
      Preconditions.checkArgument(!string.IsNullOrEmpty(time), (object) "The time must not be empty.");
      Preconditions.checkArgument(!string.IsNullOrEmpty(time_unit), (object) "The time_unit must not be empty.");
      Preconditions.checkArgument(StringUtil.IsNumber(frequency.ToString()), (object) "The frequency must be number.");
      Preconditions.checkArgument(StringUtil.IsDateTime(start), (object) "The start time is not valid.");
      Preconditions.checkArgument(StringUtil.IsDateTime(end), (object) "The end time is not valid.");
      Preconditions.checkArgument(StringUtil.IsTime(time), (object) "The time must be the right format.");
      this.periodical = new Periodical(start, end, time, time_unit, frequency, point);
    }

    public Trigger setSingleTime(string time)
    {
      Preconditions.checkArgument(!string.IsNullOrEmpty(time), (object) "The time must not be empty.");
      Preconditions.checkArgument(!StringUtil.IsDateTime(time), (object) "The time must be the right format.");
      this.single.setTime(time);
      return this;
    }

    public string getSingleTime()
    {
      return this.single.getTime();
    }

    public Trigger setTime(string time)
    {
      Preconditions.checkArgument(!string.IsNullOrEmpty(time), (object) "The time must not be empty.");
      Preconditions.checkArgument(StringUtil.IsTime(time), (object) "The time must be the right format.");
      this.periodical.setTime(time);
      return this;
    }

    public string getTime()
    {
      return this.periodical.getTime();
    }

    public void setStart(string start)
    {
      Preconditions.checkArgument(!string.IsNullOrEmpty(start), (object) "The time must not be empty.");
      Preconditions.checkArgument(StringUtil.IsDateTime(start), (object) "The start is not valid.");
      this.periodical.setStart(start);
    }

    public string getStart()
    {
      return this.periodical.getStart();
    }

    public Trigger setEnd(string end)
    {
      Preconditions.checkArgument(!string.IsNullOrEmpty(end), (object) "The time must not be empty.");
      Preconditions.checkArgument(StringUtil.IsDateTime(end), (object) "The end is not valid.");
      this.periodical.setEnd(end);
      return this;
    }

    public string getEnd()
    {
      return this.periodical.getEnd();
    }

    public Trigger setTime_unit(string time_unit)
    {
      Preconditions.checkArgument(!string.IsNullOrEmpty(time_unit), (object) "The time_unit must not be empty.");
      Preconditions.checkArgument(StringUtil.IsTimeunit(time_unit), (object) "The time_unit must be the right format.");
      this.periodical.setTime_unit(time_unit);
      return this;
    }

    public string getTime_unit()
    {
      return this.periodical.getTime_unit();
    }

    public Trigger setFrequency(int frequency)
    {
      Preconditions.checkArgument(StringUtil.IsNumber(frequency.ToString()), (object) "The frequency must be number.");
      Preconditions.checkArgument(0 < frequency && frequency < 101, (object) "The frequency must be less than 100.");
      this.periodical.setFrequency(frequency);
      return this;
    }

    public int getFrequency()
    {
      return this.periodical.getFrequency();
    }

    public Trigger setPoint(string[] point)
    {
      this.periodical.setPoint(point);
      return this;
    }

    public string[] getPoint()
    {
      return this.periodical.getPoint();
    }
  }
}
