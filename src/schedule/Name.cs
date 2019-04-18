// Decompiled with JetBrains decompiler
// Type: cn.jpush.api.schedule.Name
// Assembly: cn.jpush.api, Version=3.3.3.0, Culture=neutral, PublicKeyToken=null
// MVID: 8C64A4D9-F1B2-4309-8DF5-ACE3B9A5E7DC
// Assembly location: E:\Administrator\Desktop\NET.Reflector\dot\cn.jpush.api.dll

using cn.jpush.api.util;
using Newtonsoft.Json;

namespace cn.jpush.api.schedule
{
  public class Name
  {
    [JsonProperty]
    private string name;

    public void setName(string name)
    {
      Preconditions.checkArgument(!string.IsNullOrEmpty(name), (object) "The name must not be empty.");
      Preconditions.checkArgument(StringUtil.IsValidName(name), (object) "The name must be the right format.");
      Preconditions.checkArgument(name.Length < (int) byte.MaxValue, (object) "The name must be less than 255 bytes.");
      this.name = name;
    }

    public string getName()
    {
      return this.name;
    }
  }
}
