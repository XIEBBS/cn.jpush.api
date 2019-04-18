// Decompiled with JetBrains decompiler
// Type: cn.jpush.api.schedule.Single
// Assembly: cn.jpush.api, Version=3.3.3.0, Culture=neutral, PublicKeyToken=null
// MVID: 8C64A4D9-F1B2-4309-8DF5-ACE3B9A5E7DC
// Assembly location: E:\Administrator\Desktop\NET.Reflector\dot\cn.jpush.api.dll

using cn.jpush.api.util;
using Newtonsoft.Json;

namespace cn.jpush.api.schedule
{
  public class Single
  {
    [JsonProperty]
    private string time;

    public void setTime(string time)
    {
      Preconditions.checkArgument(!string.IsNullOrEmpty(time), (object) "The time must not be empty.");
      Preconditions.checkArgument(StringUtil.IsDateTime(time), (object) "the time is not valid");
      this.time = time;
    }

    public string getTime()
    {
      return this.time;
    }
  }
}
