// Decompiled with JetBrains decompiler
// Type: cn.jpush.api.push.mode.Options
// Assembly: cn.jpush.api, Version=3.3.3.0, Culture=neutral, PublicKeyToken=null
// MVID: 8C64A4D9-F1B2-4309-8DF5-ACE3B9A5E7DC
// Assembly location: E:\Administrator\Desktop\NET.Reflector\dot\cn.jpush.api.dll

using cn.jpush.api.util;
using Newtonsoft.Json;
using System.ComponentModel;

namespace cn.jpush.api.push.mode
{
  public class Options
  {
    private const long NONE_TIME_TO_LIVE = -1;
    private int _sendno;
    private long _override_msg_id;
    private long _time_to_live;
    private long _big_push_duration;

    public Options()
    {
      this.sendno = 0;
      this.override_msg_id = 0L;
      this.time_to_live = -1L;
      this.big_push_duration = 0L;
      this.apns_production = false;
    }

    public Options(
      int sendno,
      long overrideMsgId,
      long timeToLive,
      int bigPushDuration,
      bool apnsProduction = false)
    {
      this.sendno = sendno;
      this.override_msg_id = overrideMsgId;
      this.time_to_live = timeToLive;
      this.big_push_duration = (long) bigPushDuration;
      this.apns_production = apnsProduction;
    }

    [DefaultValue(0)]
    public int sendno
    {
      get
      {
        return this._sendno;
      }
      set
      {
        Preconditions.checkArgument(value >= 0, (object) "sendno should be greater than 0.");
        this._sendno = value;
      }
    }

    [DefaultValue(0)]
    public long override_msg_id
    {
      get
      {
        return this._override_msg_id;
      }
      set
      {
        Preconditions.checkArgument(value >= 0L, (object) "override_msg_id should be greater than 0.");
        this._override_msg_id = value;
      }
    }

    [DefaultValue(-1)]
    public long time_to_live
    {
      get
      {
        return this._time_to_live;
      }
      set
      {
        Preconditions.checkArgument(value >= -1L, (object) "time_to_live should be greater than 0.");
        this._time_to_live = value;
      }
    }

    [DefaultValue(0)]
    public long big_push_duration
    {
      get
      {
        return this._big_push_duration;
      }
      set
      {
        Preconditions.checkArgument(value >= 0L, (object) "big_push_duration should be greater than 0.");
        this._big_push_duration = value;
      }
    }

    [JsonProperty]
    public bool? apns_production {
        get;
        set;
    } = false;
  }
}
