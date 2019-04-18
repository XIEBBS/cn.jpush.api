// Decompiled with JetBrains decompiler
// Type: cn.jpush.api.schedule.Periodical
// Assembly: cn.jpush.api, Version=3.3.3.0, Culture=neutral, PublicKeyToken=null
// MVID: 8C64A4D9-F1B2-4309-8DF5-ACE3B9A5E7DC
// Assembly location: E:\Administrator\Desktop\NET.Reflector\dot\cn.jpush.api.dll

using cn.jpush.api.util;
using Newtonsoft.Json;

namespace cn.jpush.api.schedule
{
  public class Periodical
  {
    [JsonProperty]
    private string start;
    [JsonProperty]
    private string end;
    [JsonProperty]
    private string time;
    [JsonProperty]
    private string time_unit;
    [JsonProperty]
    private int frequency;
    [JsonProperty]
    private string[] point;

    public Periodical(
      string start,
      string end,
      string time,
      string time_unit,
      int frequency,
      string[] point)
    {
      Preconditions.checkArgument(!string.IsNullOrEmpty(start), (object) "The time must not be empty.");
      Preconditions.checkArgument(!string.IsNullOrEmpty(end), (object) "The time must not be empty.");
      Preconditions.checkArgument(!string.IsNullOrEmpty(time), (object) "The time must not be empty.");
      Preconditions.checkArgument(!string.IsNullOrEmpty(time_unit), (object) "The time_unit must not be empty.");
      Preconditions.checkArgument(StringUtil.IsNumber(frequency.ToString()), (object) "The frequency must be number.");
      Preconditions.checkArgument(StringUtil.IsDateTime(start), (object) "The start is not valid.");
      Preconditions.checkArgument(StringUtil.IsDateTime(end), (object) "The end is not valid.");
      Preconditions.checkArgument(StringUtil.IsTime(time), (object) "The time must be the right format.");
      this.start = start;
      this.end = end;
      this.time = time;
      this.time_unit = time_unit;
      this.frequency = frequency;
      this.point = point;
    }

    public Periodical()
    {
      this.start = (string) null;
      this.end = (string) null;
      this.time = (string) null;
      this.time_unit = (string) null;
      this.frequency = 0;
      this.point = (string[]) null;
    }

    public Periodical setStart(string start)
    {
      Preconditions.checkArgument(!string.IsNullOrEmpty(start), (object) "The time must not be empty.");
      Preconditions.checkArgument(StringUtil.IsDateTime(start), (object) "The start is not valid.");
      this.start = start;
      return this;
    }

    public string getStart()
    {
      return this.start;
    }

    public Periodical setEnd(string end)
    {
      Preconditions.checkArgument(!string.IsNullOrEmpty(end), (object) "The time must not be empty.");
      Preconditions.checkArgument(StringUtil.IsDateTime(end), (object) "The end is not valid.");
      this.end = end;
      return this;
    }

    public string getEnd()
    {
      return this.end;
    }

    public Periodical setTime(string time)
    {
      Preconditions.checkArgument(!string.IsNullOrEmpty(time), (object) "The time must not be empty.");
      Preconditions.checkArgument(StringUtil.IsTime(time), (object) "The time must be the right format.");
      this.time = time;
      return this;
    }

    public string getTime()
    {
      return this.time;
    }

    public Periodical setTime_unit(string time_unit)
    {
      Preconditions.checkArgument(!string.IsNullOrEmpty(time_unit), (object) "The time_unit must not be empty.");
      Preconditions.checkArgument(StringUtil.IsTimeunit(time_unit), (object) "The time_unit must be the right format.");
      this.time_unit = time_unit;
      return this;
    }

    public string getTime_unit()
    {
      return this.time_unit;
    }

    public Periodical setFrequency(int frequency)
    {
      Preconditions.checkArgument(StringUtil.IsNumber(frequency.ToString()), (object) "The frequency must be number.");
      Preconditions.checkArgument(0 < frequency && frequency < 101, (object) "The frequency must be less than 100.");
      this.frequency = frequency;
      return this;
    }

    public int getFrequency()
    {
      return this.frequency;
    }

    public Periodical setPoint(string[] point)
    {
      this.point = point;
      return this;
    }

    public string[] getPoint()
    {
      return this.point;
    }
  }
}
