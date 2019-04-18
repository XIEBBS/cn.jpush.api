// Decompiled with JetBrains decompiler
// Type: cn.jpush.api.device.DeviceClient
// Assembly: cn.jpush.api, Version=3.3.3.0, Culture=neutral, PublicKeyToken=null
// MVID: 8C64A4D9-F1B2-4309-8DF5-ACE3B9A5E7DC
// Assembly location: E:\Administrator\Desktop\NET.Reflector\dot\cn.jpush.api.dll

using System;
using cn.jpush.api.common;
using cn.jpush.api.common.resp;
using cn.jpush.api.util;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Diagnostics;

namespace cn.jpush.api.device
{
  public class DeviceClient : BaseHttpClient
  {
    public const string HOST_NAME_SSL = "https://device.jpush.cn";
    public const string DEVICES_PATH = "/v3/devices";
    public const string TAGS_PATH = "/v3/tags";
    public const string ALIASES_PATH = "/v3/aliases";
    public const string STATUS_PATH = "/status/";
    private string appKey;
    private string masterSecret;
    private JsonSerializerSettings jSetting;

    public DeviceClient(string appKey, string masterSecret)
    {
      Preconditions.checkArgument(!string.IsNullOrEmpty(appKey), (object) "appKey should be set");
      Preconditions.checkArgument(!string.IsNullOrEmpty(masterSecret), (object) "masterSecret should be set");
      this.appKey = appKey;
      this.masterSecret = masterSecret;
    }

    public TagAliasResult getDeviceTagAlias(string registrationId)
    {
      Preconditions.checkArgument(!string.IsNullOrEmpty(registrationId), (object) "registrationId should be set");
      return TagAliasResult.fromResponse(this.sendGet("https://device.jpush.cn/v3/devices/" + registrationId, Base64.getBase64Encode(this.appKey + ":" + this.masterSecret), (string) null));
    }

    public DefaultResult updateDevice(
      string registrationId,
      string alias,
      string mobile,
      HashSet<string> tagsToAdd,
      HashSet<string> tagsToRemove)
    {
            //throw new NotImplementedException();
            string url = "https://device.jpush.cn/v3/devices/" + registrationId;
            JObject jobject1 = new JObject();
            if (alias != null)
                jobject1.Add(nameof(alias), JToken.FromObject(alias));
            if (mobile != null)
                jobject1.Add(nameof(mobile), JToken.FromObject(mobile));
            JObject jobject2 = new JObject();
            if (tagsToAdd != null)
            {
                JArray jarray = JArray.FromObject((object)tagsToAdd);
                if (((JContainer)jarray).Count > 0)
                    jobject2.Add("add", (JToken)jarray);
            }
            if (tagsToRemove != null)
            {
                JArray jarray = JArray.FromObject((object)tagsToRemove);
                if (((JContainer)jarray).Count > 0)
                    jobject2.Add("remove", (JToken)jarray);
            }
            if (((JContainer)jobject2).Count > 0)
                jobject1.Add("tags", (JToken)jobject2);
            return DefaultResult.fromResponse(this.sendPost(url, this.Authorization(), ((object)jobject1).ToString()));
        }

    public DefaultResult updateDeviceTagAlias(
      string registrationId,
      string alias,
      HashSet<string> tagsToAdd,
      HashSet<string> tagsToRemove)
    {
            //throw new NotImplementedException();
            string url = "https://device.jpush.cn/v3/devices/" + registrationId;
            JObject jobject1 = new JObject();
            if (alias != null)
                jobject1.Add(nameof(alias), JToken.FromObject(alias));
            JObject jobject2 = new JObject();
            if (tagsToAdd != null)
            {
                JArray jarray = JArray.FromObject((object)tagsToAdd);
                if (((JContainer)jarray).Count > 0)
                    jobject2.Add("add", (JToken)jarray);
            }
            if (tagsToRemove != null)
            {
                JArray jarray = JArray.FromObject((object)tagsToRemove);
                if (((JContainer)jarray).Count > 0)
                    jobject2.Add("remove", (JToken)jarray);
            }
            if (((JContainer)jobject2).Count > 0)
                jobject1.Add("tags", (JToken)jobject2);
            return DefaultResult.fromResponse(this.sendPost(url, this.Authorization(), ((object)jobject1).ToString()));
        }

    public DefaultResult addDeviceAlias(string registrationId, string alias)
    {
      string mobile = (string) null;
      HashSet<string> tagsToAdd = (HashSet<string>) null;
      HashSet<string> tagsToRemove = (HashSet<string>) null;
      return this.updateDevice(registrationId, alias, mobile, tagsToAdd, tagsToRemove);
    }

    public DefaultResult addDeviceMobile(string registrationId, string mobile)
    {
      string alias = (string) null;
      HashSet<string> tagsToAdd = (HashSet<string>) null;
      HashSet<string> tagsToRemove = (HashSet<string>) null;
      return this.updateDevice(registrationId, alias, mobile, tagsToAdd, tagsToRemove);
    }

    public DefaultResult addDeviceTags(string registrationId, HashSet<string> tags)
    {
      string alias = (string) null;
      string mobile = (string) null;
      HashSet<string> tagsToAdd = tags;
      HashSet<string> tagsToRemove = (HashSet<string>) null;
      return this.updateDevice(registrationId, alias, mobile, tagsToAdd, tagsToRemove);
    }

    public DefaultResult removeDeviceTags(string registrationId, HashSet<string> tags)
    {
      string alias = (string) null;
      string mobile = (string) null;
      HashSet<string> tagsToAdd = (HashSet<string>) null;
      HashSet<string> tagsToRemove = tags;
      return this.updateDevice(registrationId, alias, mobile, tagsToAdd, tagsToRemove);
    }

    public DefaultResult updateDeviceTags(
      string registrationId,
      HashSet<string> tagsToAdd,
      HashSet<string> tagsToRemove)
    {
            string url = "https://device.jpush.cn/v3/devices/" + registrationId;
            JObject jobject1 = new JObject();
            JObject jobject2 = new JObject();
            if (tagsToAdd != null)
            {
                JArray jarray = JArray.FromObject((object)tagsToAdd);
                if (((JContainer)jarray).Count > 0)
                  jobject2.Add("add", (JToken)jarray);
            }
            if (tagsToRemove != null)
            {
                JArray jarray = JArray.FromObject((object)tagsToRemove);
                if (((JContainer)jarray).Count > 0)
                  jobject2.Add("remove", (JToken)jarray);
            }
            if (((JContainer)jobject2).Count > 0)
              jobject1.Add("tags", (JToken)jobject2);
            return DefaultResult.fromResponse(this.sendPost(url, this.Authorization(), ((object)jobject1).ToString()));
        }

    public DefaultResult updateDeviceTagAlias(
      string registrationId,
      bool clearAlias,
      bool clearTag)
    {
            Preconditions.checkArgument(clearAlias | clearTag, (object)"It is not meaningful to do nothing.");
            string url = "https://device.jpush.cn/v3/devices/" + registrationId;
            JObject jobject = new JObject();
            if (clearAlias)
                jobject.Add("alias", JToken.FromObject(""));
            if (clearTag)
                jobject.Add("tags", JToken.FromObject(""));
            return DefaultResult.fromResponse(this.sendPost(url, this.Authorization(), ((object)jobject).ToString()));
        }

    public TagListResult getTagList()
    {
      return TagListResult.fromResponse(this.sendGet("https://device.jpush.cn/v3/tags/", Base64.getBase64Encode(this.appKey + ":" + this.masterSecret), (string) null));
    }

    public BooleanResult isDeviceInTag(string tag, string registrationID)
    {
      Preconditions.checkArgument(!string.IsNullOrEmpty(tag), (object) "theTag should be set");
      Preconditions.checkArgument(!string.IsNullOrEmpty(registrationID), (object) "registrationID should be set");
      return BooleanResult.fromResponse(this.sendGet("https://device.jpush.cn/v3/tags/" + tag + "/registration_ids/" + registrationID, this.Authorization(), (string) null));
    }

    public DefaultResult addRemoveDevicesFromTag(
      string tag,
      HashSet<string> toAddUsers,
      HashSet<string> toRemoveUsers)
    {
      string url = "https://device.jpush.cn/v3/tags/" + tag;
      JObject jobject1 = new JObject();
      JObject jobject2 = new JObject();
      if (toAddUsers != null && toAddUsers.Count > 0)
      {
        JArray jarray = new JArray();
        foreach (string toAddUser in toAddUsers)
          jarray.Add(JToken.FromObject((object) toAddUser));
        jobject2.Add("add", (JToken) jarray);
      }
      if (toRemoveUsers != null && toRemoveUsers.Count > 0)
      {
        JArray jarray = new JArray();
        foreach (string toRemoveUser in toRemoveUsers)
          jarray.Add(JToken.FromObject((object) toRemoveUser));
        jobject2.Add("remove", (JToken) jarray);
      }
      jobject1.Add("registration_ids", (JToken) jobject2);
      return DefaultResult.fromResponse(this.sendPost(url, this.Authorization(), ((object) jobject1).ToString()));
    }

    public DefaultResult addDevicesFromTag(string tag, HashSet<string> toAddUsers)
    {
      HashSet<string> toRemoveUsers = (HashSet<string>) null;
      return this.addRemoveDevicesFromTag(tag, toAddUsers, toRemoveUsers);
    }

    public DefaultResult removeDevicesFromTag(
      string tag,
      HashSet<string> toRemoveUsers)
    {
      HashSet<string> toAddUsers = (HashSet<string>) null;
      return this.addRemoveDevicesFromTag(tag, toAddUsers, toRemoveUsers);
    }

    public DefaultResult deleteTag(string tag, string platform)
    {
      Preconditions.checkArgument(!string.IsNullOrEmpty(tag), (object) "tag should be set");
      Preconditions.checkArgument(StringUtil.IsValidTag(tag), (object) "tag should be the right format");
      string url = "https://device.jpush.cn/v3/tags/" + tag;
      if (platform != null)
        url = url + "?platform=" + platform;
      return DefaultResult.fromResponse(this.sendDelete(url, this.Authorization(), (string) null));
    }

    public AliasDeviceListResult getAliasDeviceList(
      string alias,
      string platform)
    {
      Preconditions.checkArgument(!string.IsNullOrEmpty(alias), (object) "alias should be set");
      Preconditions.checkArgument(StringUtil.IsValidAlias(alias), (object) "alias should be the right format");
      string url = "https://device.jpush.cn/v3/aliases/" + alias;
      if (platform != null)
        url = url + "?platform=" + platform;
      return AliasDeviceListResult.fromResponse(this.sendGet(url, this.Authorization(), (string) null));
    }

    public DefaultResult deleteAlias(string alias, string platform)
    {
      Preconditions.checkArgument(StringUtil.IsValidAlias(alias), (object) "alias should be the right format");
      Preconditions.checkArgument(!string.IsNullOrEmpty(alias), (object) "alias should be set");
      string url = "https://device.jpush.cn/v3/aliases/" + alias;
      if (platform != null)
        url = url + "?platform=" + platform;
      return DefaultResult.fromResponse(this.sendDelete(url, this.Authorization(), (string) null));
    }

    public DefaultResult getDeviceStatus(string[] registrationId)
    {
      return DefaultResult.fromResponse(this.sendPost("https://device.jpush.cn/v3/devices/status/", this.Authorization(), this.ToJson(new Dictionary<string, string[]>()
      {
        {
          "registration_ids",
          registrationId
        }
      })));
    }

    public string ToJson(Dictionary<string, string[]> registration)
    {
      JsonSerializerSettings serializerSettings = new JsonSerializerSettings();
      serializerSettings.NullValueHandling = NullValueHandling.Ignore;
      serializerSettings.DefaultValueHandling = DefaultValueHandling.Ignore;
      this.jSetting = serializerSettings;
      return JsonConvert.SerializeObject((object) registration, this.jSetting);
    }

    private string Authorization()
    {
      Debug.Assert(!string.IsNullOrEmpty(this.appKey));
      Debug.Assert(!string.IsNullOrEmpty(this.masterSecret));
      return Base64.getBase64Encode(this.appKey + ":" + this.masterSecret);
    }
  }
}
