// Decompiled with JetBrains decompiler
// Type: cn.jpush.api.schedule.Enabled
// Assembly: cn.jpush.api, Version=3.3.3.0, Culture=neutral, PublicKeyToken=null
// MVID: 8C64A4D9-F1B2-4309-8DF5-ACE3B9A5E7DC
// Assembly location: E:\Administrator\Desktop\NET.Reflector\dot\cn.jpush.api.dll

using Newtonsoft.Json;

namespace cn.jpush.api.schedule
{
  public class Enabled
  {
    [JsonProperty]
    private bool enable;

    public void setEnable(bool enable)
    {
      this.enable = enable;
    }

    public bool getEnable()
    {
      return this.enable;
    }
  }
}
