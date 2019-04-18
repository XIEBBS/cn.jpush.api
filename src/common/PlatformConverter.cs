// Decompiled with JetBrains decompiler
// Type: cn.jpush.api.common.PlatformConverter
// Assembly: cn.jpush.api, Version=3.3.3.0, Culture=neutral, PublicKeyToken=null
// MVID: 8C64A4D9-F1B2-4309-8DF5-ACE3B9A5E7DC
// Assembly location: E:\Administrator\Desktop\NET.Reflector\dot\cn.jpush.api.dll

using cn.jpush.api.push.mode;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace cn.jpush.api.common
{
  public class PlatformConverter : JsonConverter
  {
    public override bool CanConvert(Type objectType)
    {
      return objectType == typeof (Platform);
    }

    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    {
      Platform platform = value as Platform;
      if (platform == null)
        return;
      platform.Check();
      if (platform.isAll())
      {
        writer.WriteValue(platform.allPlatform);
      }
      else
      {
        writer.WriteStartArray();
        foreach (string deviceType in platform.deviceTypes)
          writer.WriteValue(deviceType);
        writer.WriteEndArray();
      }
    }

    public override object ReadJson(
      JsonReader reader,
      Type objectType,
      object existingValue,
      JsonSerializer serializer)
    {
      Platform platform = Platform.all();
      if ((int)reader.TokenType == 11)
        return (object) null;
      if ((int)reader.TokenType == 2)
      {
        platform.allPlatform = (string) null;
        platform.deviceTypes = this.ReadArray(reader);
      }
      else
      {
        if ((int)reader.TokenType != 9)
          return (object) null;
        platform.allPlatform = reader.Value.ToString();
      }
      return (object) platform;
    }

    private HashSet<string> ReadArray(JsonReader reader)
    {
      HashSet<string> stringSet = new HashSet<string>();
      while (reader.Read())
      {
        var tokenType = (int)reader.TokenType;
        if (tokenType != 5)
        {
          if (tokenType != 9)
          {
            if (tokenType == 14)
              return stringSet;
            return (HashSet<string>) null;
          }
          stringSet.Add(Convert.ToString(reader.Value, (IFormatProvider) CultureInfo.InvariantCulture));
        }
      }
      return (HashSet<string>) null;
    }
  }
}
