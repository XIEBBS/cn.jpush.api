// Decompiled with JetBrains decompiler
// Type: cn.jpush.api.schedule.TriggerPayload
// Assembly: cn.jpush.api, Version=3.3.3.0, Culture=neutral, PublicKeyToken=null
// MVID: 8C64A4D9-F1B2-4309-8DF5-ACE3B9A5E7DC
// Assembly location: E:\Administrator\Desktop\NET.Reflector\dot\cn.jpush.api.dll

using cn.jpush.api.util;
using Newtonsoft.Json;
using System;

namespace cn.jpush.api.schedule
{
  public class TriggerPayload
  {
    [JsonProperty]
    private Periodical periodical;
    [JsonProperty]
    private Single single;
    private JsonSerializerSettings jSetting;

    public TriggerPayload()
    {
      this.periodical = new Periodical();
      this.single = new Single();
    }

    public TriggerPayload(Single single)
    {
      this.single = single;
      this.periodical = (Periodical) null;
      //throw new NotImplementedException();
    }

    public TriggerPayload(Periodical periodical)
    {
      this.periodical = periodical;
      this.single = (Single) null;
      //throw new NotImplementedException();
    }

    public TriggerPayload(string time)
    {
      Preconditions.checkArgument(!string.IsNullOrEmpty(time), (object) "The time must not be empty.");
      Preconditions.checkArgument(StringUtil.IsDateTime(time), (object) "the time is not valid");
      Single single = new Single();
      single.setTime(time);
      this.single = single;
      this.periodical = (Periodical) null;
    }

    public TriggerPayload(
      string start,
      string end,
      string time,
      string time_unit,
      int frequency,
      string[] point)
    {
      Preconditions.checkArgument(!string.IsNullOrEmpty(start), (object) "The start must not be empty.");
      Preconditions.checkArgument(!string.IsNullOrEmpty(end), (object) "The end must not be empty.");
      Preconditions.checkArgument(!string.IsNullOrEmpty(time), (object) "The time must not be empty.");
      Preconditions.checkArgument(!string.IsNullOrEmpty(time_unit), (object) "The time_unit must not be empty.");
      Preconditions.checkArgument(StringUtil.IsNumber(frequency.ToString()), (object) "The frequency must be number.");
      Preconditions.checkArgument(StringUtil.IsDateTime(start), (object) "The start is not valid.");
      Preconditions.checkArgument(StringUtil.IsDateTime(end), (object) "The end is not valid.");
      Preconditions.checkArgument(StringUtil.IsTime(time), (object) "The time must be the right format.");
      Preconditions.checkArgument(0 < frequency && frequency < 101, (object) "The frequency must be less than 100.");
      Preconditions.checkArgument(StringUtil.IsTimeunit(time_unit), (object) "The time_unit must be the right format.");
      this.single = (Single) null;
      this.periodical = new Periodical(start, end, time, time_unit, frequency, point);
    }

    public TriggerPayload setSingleTime(string time)
    {
      Preconditions.checkArgument(!string.IsNullOrEmpty(time), (object) "The time must not be empty.");
      Preconditions.checkArgument(!StringUtil.IsDateTime(time), (object) "The time must be the right format.");
      this.single.setTime(time);
      this.periodical = (Periodical) null;
      return this;
    }

    public string getSingleTime()
    {
      return this.single.getTime();
    }

    public TriggerPayload setTime(string time)
    {
      Preconditions.checkArgument(!string.IsNullOrEmpty(time), (object) "The time must not be empty.");
      Preconditions.checkArgument(StringUtil.IsTime(time), (object) "The time must be the right format.");
      this.periodical.setTime(time);
      this.single = (Single) null;
      return this;
    }

    public string getTime()
    {
      return this.periodical.getTime();
    }

    public void setStart(string start)
    {
      Preconditions.checkArgument(!string.IsNullOrEmpty(start), (object) "The time could not be empty.");
      Preconditions.checkArgument(StringUtil.IsDateTime(start), (object) "The start is not valid.");
      this.single = (Single) null;
      this.periodical.setStart(start);
    }

    public string getStart()
    {
      return this.periodical.getStart();
    }

    public TriggerPayload setEnd(string end)
    {
      Preconditions.checkArgument(!string.IsNullOrEmpty(end), (object) "The time could not be empty.");
      Preconditions.checkArgument(StringUtil.IsDateTime(end), (object) "The end is not valid.");
      this.periodical.setEnd(end);
      this.single = (Single) null;
      return this;
    }

    public string getEnd()
    {
      return this.periodical.getEnd();
    }

    public TriggerPayload setTime_unit(string time_unit)
    {
      this.periodical.setTime_unit(time_unit);
      this.single = (Single) null;
      return this;
    }

    public string getTime_unit()
    {
      return this.periodical.getTime_unit();
    }

    public TriggerPayload setFrequency(int frequency)
    {
      Preconditions.checkArgument(StringUtil.IsNumber(frequency.ToString()), (object) "The frequency must be number.");
      Preconditions.checkArgument(0 < frequency && frequency < 101, (object) "The name must be the right format.");
      this.periodical.setFrequency(frequency);
      this.single = (Single) null;
      return this;
    }

    public int getFrequency()
    {
      return this.periodical.getFrequency();
    }

    public TriggerPayload setPoint(string[] point)
    {
      this.periodical.setPoint(point);
      this.single = (Single) null;
      return this;
    }

    public string[] getPoint()
    {
      return this.periodical.getPoint();
    }

    public string ToJson()
    {
      JsonSerializerSettings serializerSettings = new JsonSerializerSettings();
      serializerSettings.NullValueHandling = NullValueHandling.Ignore;
      serializerSettings.DefaultValueHandling = DefaultValueHandling.Ignore;
      this.jSetting = serializerSettings;
      return JsonConvert.SerializeObject((object) this, this.jSetting);
    }
  }
}
