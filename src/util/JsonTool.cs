// Decompiled with JetBrains decompiler
// Type: cn.jpush.api.util.JsonTool
// Assembly: cn.jpush.api, Version=3.3.3.0, Culture=neutral, PublicKeyToken=null
// MVID: 8C64A4D9-F1B2-4309-8DF5-ACE3B9A5E7DC
// Assembly location: E:\Administrator\Desktop\NET.Reflector\dot\cn.jpush.api.dll

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;
using cn.jpush.api.report;
using Newtonsoft.Json;

namespace cn.jpush.api.util
{
  public class JsonTool
  {
    public static string ObjectToJson(object obj)
    {
      DataContractJsonSerializer contractJsonSerializer = new DataContractJsonSerializer(obj.GetType());
      MemoryStream memoryStream = new MemoryStream();
      contractJsonSerializer.WriteObject((Stream) memoryStream, obj);
      byte[] numArray = new byte[memoryStream.Length];
      memoryStream.Position = 0L;
      memoryStream.Read(numArray, 0, (int) memoryStream.Length);
      return Encoding.UTF8.GetString(numArray).Replace("\\", "");
    }

    public static object JsonToObject(string jsonString, object obj)
    {
      return new DataContractJsonSerializer(obj.GetType()).ReadObject((Stream) new MemoryStream(Encoding.UTF8.GetBytes(jsonString)));
    }

    public static string DictionaryToJson(Dictionary<string, object> dict)
    {
      StringBuilder stringBuilder = new StringBuilder();
      foreach (KeyValuePair<string, object> keyValuePair in dict)
        stringBuilder.Append("\"").Append(keyValuePair.Key).Append("\"").Append(":").Append(JsonTool.ValueToJson(keyValuePair.Value)).Append(",");
      if (stringBuilder.Length > 0)
        stringBuilder.Remove(stringBuilder.Length - 1, 1);
      stringBuilder.Append("}");
      stringBuilder.Insert(0, "{");
      return stringBuilder.ToString();
    }

    public static List<ReceivedResult.Received> JsonList(string jsonString)
    {
      return JsonConvert.DeserializeObject<List<ReceivedResult.Received>>(jsonString);
    }

    private static string ValueToJson(object value)
    {
      Type type = value.GetType();
      if (type == typeof (int))
        return value.ToString();
      if (type == typeof (string))
        return "\"" + value + "\"";
      if (type == typeof (List<int>) || type == typeof (List<string>))
        return JsonTool.ObjectToJson(value);
      if (type == typeof (Dictionary<string, object>))
        return JsonTool.DictionaryToJson((Dictionary<string, object>) value);
      Debug.WriteLine("Type in Dictionary is error!");
      return "type erro";
    }
  }
}
