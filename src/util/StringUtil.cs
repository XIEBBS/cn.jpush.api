// Decompiled with JetBrains decompiler
// Type: cn.jpush.api.util.StringUtil
// Assembly: cn.jpush.api, Version=3.3.3.0, Culture=neutral, PublicKeyToken=null
// MVID: 8C64A4D9-F1B2-4309-8DF5-ACE3B9A5E7DC
// Assembly location: E:\Administrator\Desktop\NET.Reflector\dot\cn.jpush.api.dll

using System;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace cn.jpush.api.util
{
  public class StringUtil
  {
    public static bool IsNumber(string strNumber)
    {
      Regex regex1 = new Regex("[^0-9.-]");
      Regex regex2 = new Regex("[0-9]*[.][0-9]*[.][0-9]*");
      Regex regex3 = new Regex("[0-9]*[-][0-9]*[-][0-9]*");
      Regex regex4 = new Regex("(" + "^([-]|[.]|[-.]|[0-9])[0-9]*[.]*[0-9]+$" + ")|(" + "^([-]|[0-9])[0-9]*$" + ")");
      return !regex1.IsMatch(strNumber) && !regex2.IsMatch(strNumber) && !regex3.IsMatch(strNumber) && regex4.IsMatch(strNumber);
    }

    public static bool IsNumeric(string value)
    {
      return Regex.IsMatch(value, "^[+-]?\\d*[.]?\\d*$");
    }

    public static bool IsInt(string value)
    {
      return Regex.IsMatch(value, "^[+-]?\\d*$");
    }

    public static bool IsUnsign(string value)
    {
      return Regex.IsMatch(value, "^\\d*[.]?\\d*$");
    }

    public static string arrayToString(string[] values)
    {
      if (values == null)
        return "";
      StringBuilder stringBuilder = new StringBuilder(values.Length);
      for (int index = 0; index < values.Length; ++index)
        stringBuilder.Append(values[index]).Append(",");
      if (stringBuilder.Length > 0)
        return stringBuilder.ToString().Substring(0, stringBuilder.Length - 1);
      return "";
    }

    public static bool IsDateTime(string datetime)
    {
      bool flag;
      try
      {
        DateTime.ParseExact(datetime, "yyyy-MM-dd HH:mm:ss", (IFormatProvider) CultureInfo.InvariantCulture);
        flag = true;
      }
      catch
      {
        flag = false;
      }
      return flag;
    }

    public static bool IsTime(string time)
    {
      bool flag;
      try
      {
        DateTime.ParseExact(time, "HH:mm:ss", (IFormatProvider) CultureInfo.InvariantCulture);
        flag = true;
      }
      catch
      {
        flag = false;
      }
      return flag;
    }

    public static bool IsMobile(string mobile)
    {
      return Regex.IsMatch(mobile, "^(1[34578][0-9])(\\\\d{4})(\\\\d{4})$");
    }

    public static bool IsTimeunit(string time_unit)
    {
      return string.Equals(time_unit, "day", StringComparison.CurrentCultureIgnoreCase) || (string.Equals(time_unit, "week", StringComparison.CurrentCultureIgnoreCase) || string.Equals(time_unit, "month", StringComparison.CurrentCultureIgnoreCase));
    }

    public static bool IsValidName(string name)
    {
      return name.Length < 256;
    }

    public static bool IsValidTag(string tag)
    {
      return tag.Length < 41;
    }

    public static bool IsValidAlias(string alias)
    {
      return alias.Length < 41;
    }
  }
}
