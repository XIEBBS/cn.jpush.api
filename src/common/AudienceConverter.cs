// Decompiled with JetBrains decompiler
// Type: cn.jpush.api.common.AudienceConverter
// Assembly: cn.jpush.api, Version=3.3.3.0, Culture=neutral, PublicKeyToken=null
// MVID: 8C64A4D9-F1B2-4309-8DF5-ACE3B9A5E7DC
// Assembly location: E:\Administrator\Desktop\NET.Reflector\dot\cn.jpush.api.dll

using cn.jpush.api.push.mode;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace cn.jpush.api.common
{
  public class AudienceConverter : JsonConverter
  {
    public override bool CanConvert(Type objectType)
    {
      return objectType == typeof (Audience);
    }

    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    {
      Audience audience = value as Audience;
      if (audience == null)
        return;
      audience.Check();
      if (audience.isAll())
      {
        writer.WriteValue(audience.allAudience);
      }
      else
      {
        string str = JsonConvert.SerializeObject((object) audience.dictionary);
        writer.WriteRawValue(str);
      }
    }

    public override object ReadJson(
      JsonReader reader,
      Type objectType,
      object existingValue,
      JsonSerializer serializer)
    {
      Audience audience = Audience.all();
      if ((int)reader.TokenType == 11)
        return (object) null;
      if ((int)reader.TokenType == 9)
        audience.allAudience = reader.Value.ToString();
      else if ((int)reader.TokenType == 1)
      {
        audience.allAudience = (string) null;
        Dictionary<string, HashSet<string>> dictionary = new Dictionary<string, HashSet<string>>();
        string key = "key";
        HashSet<string> stringSet = (HashSet<string>) null;
        while (reader.Read())
        {
          Debug.WriteLine("Type:{0},Path:{1}", (object) reader.TokenType, (object) reader.Path);
          var tokenType = (int)reader.TokenType;
          if (tokenType <= 9)
          {
            switch (tokenType - 1)
            {
              case 0:
              case 2:
                break;
              case 1:
                stringSet = new HashSet<string>();
                break;
              case 3:
                key = reader.Value.ToString();
                break;
              default:
                if (tokenType == 9)
                {
                  stringSet.Add(reader.Value.ToString());
                  break;
                }
                break;
            }
          }
          else
          {
            if (tokenType == 13)
              return (object) audience;
            if (tokenType == 14)
              dictionary.Add(key, stringSet);
          }
        }
        audience.dictionary = dictionary;
      }
      return (object) audience;
    }
  }
}
