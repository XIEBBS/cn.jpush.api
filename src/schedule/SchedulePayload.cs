// Decompiled with JetBrains decompiler
// Type: cn.jpush.api.schedule.SchedulePayload
// Assembly: cn.jpush.api, Version=3.3.3.0, Culture=neutral, PublicKeyToken=null
// MVID: 8C64A4D9-F1B2-4309-8DF5-ACE3B9A5E7DC
// Assembly location: E:\Administrator\Desktop\NET.Reflector\dot\cn.jpush.api.dll

using cn.jpush.api.push.mode;
using cn.jpush.api.util;
using Newtonsoft.Json;
using System.Diagnostics;

namespace cn.jpush.api.schedule
{
  public class SchedulePayload
  {
    private JsonSerializerSettings jSetting;
    private const string NAME = "name";
    private const string ENABLED = "enabled";
    private const string TRIGGER = "trigger";
    private const string PUSH = "push";
    public string schedule_id;

    public PushPayload push { get; set; }

    public string name { get; set; }

    [JsonProperty]
    public bool enabled { get; set; }

    public TriggerPayload trigger { get; set; }

    public SchedulePayload()
    {
      this.name = (string) null;
      this.enabled = true;
      this.trigger = new TriggerPayload();
      this.push = new PushPayload();
      this.schedule_id = (string) null;
      JsonSerializerSettings serializerSettings = new JsonSerializerSettings();
      serializerSettings.NullValueHandling = NullValueHandling.Ignore;
      serializerSettings.DefaultValueHandling = DefaultValueHandling.Ignore;
      this.jSetting = serializerSettings;
    }

    public SchedulePayload(string name, bool enabled, TriggerPayload trigger, PushPayload push)
    {
      this.schedule_id = (string) null;
      Debug.Assert(name != null);
      Debug.Assert(enabled);
      Debug.Assert(trigger != null);
      Debug.Assert(push != null);
      this.name = name;
      this.enabled = enabled;
      this.trigger = trigger;
      this.push = push;
      JsonSerializerSettings serializerSettings = new JsonSerializerSettings();
      serializerSettings.NullValueHandling = NullValueHandling.Ignore;
      serializerSettings.DefaultValueHandling = DefaultValueHandling.Ignore;
      this.jSetting = serializerSettings;
    }

    public SchedulePayload(Name name, Enabled enabled, TriggerPayload trigger, PushPayload push)
    {
      this.schedule_id = (string) null;
      Debug.Assert(name != null);
      Debug.Assert(enabled.getEnable());
      Debug.Assert(trigger != null);
      Debug.Assert(push != null);
      this.name = name.getName();
      this.enabled = true;
      this.trigger = trigger;
      this.push = push;
      JsonSerializerSettings serializerSettings = new JsonSerializerSettings();
      serializerSettings.NullValueHandling = NullValueHandling.Ignore;
      serializerSettings.DefaultValueHandling = DefaultValueHandling.Ignore;
      this.jSetting = serializerSettings;
    }

    public SchedulePayload setName(string name)
    {
      Preconditions.checkArgument(StringUtil.IsValidName(name), (object) "The name must be the right format.");
      this.name = name;
      return this;
    }

    public SchedulePayload setEnabled(bool enabled)
    {
      this.enabled = enabled;
      return this;
    }

    public SchedulePayload setTrigger(TriggerPayload trigger)
    {
      this.trigger = trigger;
      return this;
    }

    public SchedulePayload setPushPayload(PushPayload push)
    {
      this.push = push;
      return this;
    }

    public string ToJson()
    {
      JsonSerializerSettings serializerSettings = new JsonSerializerSettings();
      serializerSettings.NullValueHandling = NullValueHandling.Ignore;
      serializerSettings.DefaultValueHandling = DefaultValueHandling.Ignore;
      this.jSetting = serializerSettings;
      return JsonConvert.SerializeObject((object) this, this.jSetting);
    }

    public SchedulePayload Check()
    {
      Preconditions.checkArgument(this.push != null, (object) "pushpayload should be set.");
      Preconditions.checkArgument(this.name != null, (object) "name should be set.");
      Preconditions.checkArgument(this.enabled, (object) "enabled should be true.");
      Preconditions.checkArgument(this.trigger != null, (object) "trigger should be set.");
      Preconditions.checkArgument(StringUtil.IsValidName(this.name), (object) "The name must be the right format.");
      Preconditions.checkArgument(this.name.Length < (int) byte.MaxValue, (object) "The name must be less than 255 bytes.");
      return this;
    }
  }
}
