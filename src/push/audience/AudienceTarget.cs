// Decompiled with JetBrains decompiler
// Type: cn.jpush.api.push.audience.AudienceTarget
// Assembly: cn.jpush.api, Version=3.3.3.0, Culture=neutral, PublicKeyToken=null
// MVID: 8C64A4D9-F1B2-4309-8DF5-ACE3B9A5E7DC
// Assembly location: E:\Administrator\Desktop\NET.Reflector\dot\cn.jpush.api.dll

using cn.jpush.api.util;
using System.Collections.Generic;

namespace cn.jpush.api.push.audience
{
  public class AudienceTarget
  {
    public AudienceType audienceType { get; private set; }

    public HashSet<string> valueBuilder { get; private set; }

    private AudienceTarget(AudienceType audienceType, HashSet<string> values)
    {
      this.audienceType = audienceType;
      this.valueBuilder = values;
    }

    public static AudienceTarget tag(HashSet<string> values)
    {
      return new AudienceTarget(AudienceType.tag, values).Check();
    }

    public static AudienceTarget tag_and(HashSet<string> values)
    {
      return new AudienceTarget(AudienceType.tag_and, values).Check();
    }

    public static AudienceTarget alias(HashSet<string> values)
    {
      return new AudienceTarget(AudienceType.alias, values).Check();
    }

    public static AudienceTarget segment(HashSet<string> values)
    {
      return new AudienceTarget(AudienceType.segment, values).Check();
    }

    public static AudienceTarget registrationId(HashSet<string> values)
    {
      return new AudienceTarget(AudienceType.registration_id, values).Check();
    }

    public AudienceTarget Check()
    {
      Preconditions.checkArgument(this.valueBuilder != null, (object) "Target values should be set one at least.");
      return this;
    }
  }
}
