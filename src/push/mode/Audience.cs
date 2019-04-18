// Decompiled with JetBrains decompiler
// Type: cn.jpush.api.push.mode.Audience
// Assembly: cn.jpush.api, Version=3.3.3.0, Culture=neutral, PublicKeyToken=null
// MVID: 8C64A4D9-F1B2-4309-8DF5-ACE3B9A5E7DC
// Assembly location: E:\Administrator\Desktop\NET.Reflector\dot\cn.jpush.api.dll

using cn.jpush.api.push.audience;
using cn.jpush.api.util;
using System.Collections.Generic;
using System.Diagnostics;

namespace cn.jpush.api.push.mode
{
  public class Audience
  {
    private const string ALL = "all";
    public string allAudience;
    public Dictionary<string, HashSet<string>> dictionary;

    private void AddWithAudienceTarget(AudienceTarget target)
    {
      Debug.Assert(target != null && target.valueBuilder != null);
      if (target == null || target.valueBuilder == null)
        return;
      this.allAudience = (string) null;
      if (this.dictionary == null)
        this.dictionary = new Dictionary<string, HashSet<string>>();
      if (this.dictionary.ContainsKey(target.audienceType.ToString()))
      {
        HashSet<string> stringSet = this.dictionary[target.audienceType.ToString()];
        foreach (string str in target.valueBuilder)
          stringSet.Add(str);
      }
      else
        this.dictionary.Add(target.audienceType.ToString(), target.valueBuilder);
    }

    private Audience()
    {
      this.allAudience = "all";
      this.dictionary = (Dictionary<string, HashSet<string>>) null;
    }

    public static Audience all()
    {
      return new Audience()
      {
        allAudience = nameof (all),
        dictionary = ((Dictionary<string, HashSet<string>>) null)
      }.Check();
    }

    public static Audience s_tag(HashSet<string> values)
    {
      return new Audience().tag(values);
    }

    public static Audience s_tag(params string[] values)
    {
      return new Audience().tag(values);
    }

    public static Audience s_tag_and(HashSet<string> values)
    {
      return new Audience().tag_and(values);
    }

    public static Audience s_tag_and(params string[] values)
    {
      return new Audience().tag_and(values);
    }

    public static Audience s_alias(HashSet<string> values)
    {
      return new Audience().alias(values);
    }

    public static Audience s_alias(params string[] values)
    {
      return new Audience().alias(values);
    }

    public static Audience s_segment(HashSet<string> values)
    {
      return new Audience().segment(values);
    }

    public static Audience s_segment(params string[] values)
    {
      return new Audience().segment(values);
    }

    public static Audience s_registrationId(HashSet<string> values)
    {
      return new Audience().registrationId(values);
    }

    public static Audience s_registrationId(params string[] values)
    {
      return new Audience().registrationId(values);
    }

    public Audience tag(HashSet<string> values)
    {
      if (this.allAudience != null)
        this.allAudience = (string) null;
      this.AddWithAudienceTarget(AudienceTarget.tag(values));
      return this.Check();
    }

    public Audience tag(params string[] values)
    {
      if (this.allAudience != null)
        this.allAudience = (string) null;
      return this.tag(new HashSet<string>((IEnumerable<string>) values));
    }

    public Audience tag_and(HashSet<string> values)
    {
      if (this.allAudience != null)
        this.allAudience = (string) null;
      AudienceTarget audienceTarget = AudienceTarget.tag_and(values);
      this.allAudience = (string) null;
      if (this.dictionary == null)
        this.dictionary = new Dictionary<string, HashSet<string>>();
      Dictionary<string, HashSet<string>> dictionary1 = this.dictionary;
      AudienceType audienceType = audienceTarget.audienceType;
      string key1 = audienceType.ToString();
      if (dictionary1.ContainsKey(key1))
      {
        Dictionary<string, HashSet<string>> dictionary2 = this.dictionary;
        audienceType = audienceTarget.audienceType;
        string index = audienceType.ToString();
        HashSet<string> stringSet = dictionary2[index];
        foreach (string str in values)
          stringSet.Add(str);
      }
      else
      {
        Dictionary<string, HashSet<string>> dictionary2 = this.dictionary;
        audienceType = audienceTarget.audienceType;
        string key2 = audienceType.ToString();
        HashSet<string> stringSet = values;
        dictionary2.Add(key2, stringSet);
      }
      return this.Check();
    }

    public Audience tag_and(params string[] values)
    {
      if (this.allAudience != null)
        this.allAudience = (string) null;
      return this.tag_and(new HashSet<string>((IEnumerable<string>) values));
    }

    public Audience alias(HashSet<string> values)
    {
      if (this.allAudience != null)
        this.allAudience = (string) null;
      this.AddWithAudienceTarget(AudienceTarget.alias(values));
      return this.Check();
    }

    public Audience alias(params string[] values)
    {
      if (this.allAudience != null)
        this.allAudience = (string) null;
      return this.alias(new HashSet<string>((IEnumerable<string>) values));
    }

    public Audience segment(HashSet<string> values)
    {
      if (this.allAudience != null)
        this.allAudience = (string) null;
      this.AddWithAudienceTarget(AudienceTarget.segment(values));
      return this.Check();
    }

    public Audience segment(params string[] values)
    {
      if (this.allAudience != null)
        this.allAudience = (string) null;
      return this.segment(new HashSet<string>((IEnumerable<string>) values));
    }

    public Audience registrationId(HashSet<string> values)
    {
      if (this.allAudience != null)
        this.allAudience = (string) null;
      this.AddWithAudienceTarget(AudienceTarget.registrationId(values));
      return this.Check();
    }

    public Audience registrationId(params string[] values)
    {
      if (this.allAudience != null)
        this.allAudience = (string) null;
      return this.registrationId(new HashSet<string>((IEnumerable<string>) values));
    }

    public bool isAll()
    {
      return this.allAudience != null;
    }

    public Audience Check()
    {
      Preconditions.checkArgument(!this.isAll() || this.dictionary == null, (object) "Since all is enabled, any platform should not be set.");
      Preconditions.checkArgument(this.isAll() || this.dictionary != null, (object) "No any deviceType is set.");
      return this;
    }
  }
}
