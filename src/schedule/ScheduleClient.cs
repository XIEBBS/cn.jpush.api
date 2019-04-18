// Decompiled with JetBrains decompiler
// Type: cn.jpush.api.schedule.ScheduleClient
// Assembly: cn.jpush.api, Version=3.3.3.0, Culture=neutral, PublicKeyToken=null
// MVID: 8C64A4D9-F1B2-4309-8DF5-ACE3B9A5E7DC
// Assembly location: E:\Administrator\Desktop\NET.Reflector\dot\cn.jpush.api.dll

using cn.jpush.api.common;
using cn.jpush.api.push;
using cn.jpush.api.push.mode;
using cn.jpush.api.util;
using Newtonsoft.Json;
using System;
using System.Diagnostics;

namespace cn.jpush.api.schedule
{
  public class ScheduleClient : BaseHttpClient
  {
    private const string HOST_NAME_SSL = "https://api.jpush.cn";
    private const string PUSH_PATH = "/v3/schedules";
    private const string DELETE_PATH = "/";
    private const string PUT_PATH = "/";
    private const string GET_PATH = "?page=";
    private JsonSerializerSettings jSetting;
    private string appKey;
    private string masterSecret;

    public ScheduleClient(string appKey, string masterSecret)
    {
      Preconditions.checkArgument(!string.IsNullOrEmpty(appKey), (object) "appKey should be set");
      Preconditions.checkArgument(!string.IsNullOrEmpty(masterSecret), (object) "masterSecret should be set");
      this.appKey = appKey;
      this.masterSecret = masterSecret;
    }

    public ScheduleResult sendSchedule(SchedulePayload schedulepayload)
    {
      Preconditions.checkArgument(schedulepayload != null, (object) "schedulepayload should not be empty");
      schedulepayload.Check();
      string json = schedulepayload.ToJson();
      Console.WriteLine(json);
      return this.sendSchedule(json);
    }

    public ScheduleResult sendSchedule(string schedulepayload)
    {
      Preconditions.checkArgument(!string.IsNullOrEmpty(schedulepayload), (object) "schedulepayload should not be empty");
      Console.WriteLine(schedulepayload);
      ResponseWrapper responseWrapper = this.sendPost("https://api.jpush.cn" + "/v3/schedules", this.Authorization(), schedulepayload);
      ScheduleResult scheduleResult = new ScheduleResult();
      scheduleResult.ResponseResult = responseWrapper;
      ScheduleSuccess scheduleSuccess = (ScheduleSuccess) JsonConvert.DeserializeObject<ScheduleSuccess>(responseWrapper.responseContent);
      scheduleResult.schedule_id = scheduleSuccess.schedule_id;
      scheduleResult.name = scheduleSuccess.name;
      return scheduleResult;
    }

    public getScheduleResult getSchedule(int pageid)
    {
      Preconditions.checkArgument(pageid > 0, (object) "page should more than 0.");
      this.jSetting = new JsonSerializerSettings();
      this.jSetting.NullValueHandling = NullValueHandling.Ignore;
      this.jSetting.DefaultValueHandling = DefaultValueHandling.Ignore;
      Console.WriteLine(pageid);
      ResponseWrapper responseWrapper = this.sendGet("https://api.jpush.cn" + "/v3/schedules" + "?page=" + pageid.ToString(), this.Authorization(), pageid.ToString());
      getScheduleResult getScheduleResult = new getScheduleResult();
      getScheduleResult.ResponseResult = responseWrapper;
      ScheduleListResult scheduleListResult = (ScheduleListResult) JsonConvert.DeserializeObject<ScheduleListResult>(responseWrapper.responseContent, this.jSetting);
      getScheduleResult.page = scheduleListResult.page;
      getScheduleResult.total_pages = scheduleListResult.total_pages;
      getScheduleResult.total_count = scheduleListResult.total_count;
      getScheduleResult.schedules = scheduleListResult.schedules;
      return getScheduleResult;
    }

    public SchedulePayload getScheduleById(string id)
    {
      Preconditions.checkArgument(!string.IsNullOrEmpty(id), (object) "id should be set.");
      this.jSetting = new JsonSerializerSettings();
      this.jSetting.NullValueHandling = NullValueHandling.Ignore;
            this.jSetting.DefaultValueHandling = DefaultValueHandling.Ignore;
            return (SchedulePayload) JsonConvert.DeserializeObject<SchedulePayload>(this.sendGet("https://api.jpush.cn" + "/v3/schedules" + "/" + id, this.Authorization(), id).responseContent, this.jSetting);
    }

    public ScheduleResult putSchedule(
      SchedulePayload schedulepayload,
      string schedule_id)
    {
      Preconditions.checkArgument(schedulepayload != null, (object) "schedulepayload should not be empty");
      Preconditions.checkArgument(schedule_id != null, (object) "schedule_id should not be empty");
      if (schedulepayload.push.audience == null || schedulepayload.push.platform == null)
        schedulepayload.push = (PushPayload) null;
      if (schedulepayload.trigger.getTime() == null && schedulepayload.trigger.getSingleTime() == null)
        schedulepayload.trigger = (TriggerPayload) null;
      string json = schedulepayload.ToJson();
      Console.WriteLine(json);
      return this.putSchedule(json, schedule_id);
    }

    public ScheduleResult putSchedule(string schedulepayload, string schedule_id)
    {
      Preconditions.checkArgument(!string.IsNullOrEmpty(schedulepayload), (object) "schedulepayload should not be empty");
      Console.WriteLine(schedulepayload);
      ResponseWrapper responseWrapper = this.sendPut("https://api.jpush.cn" + "/v3/schedules" + "/" + schedule_id, this.Authorization(), schedulepayload);
      ScheduleResult scheduleResult = new ScheduleResult();
      scheduleResult.ResponseResult = responseWrapper;
      ScheduleSuccess scheduleSuccess = (ScheduleSuccess) JsonConvert.DeserializeObject<ScheduleSuccess>(responseWrapper.responseContent);
      scheduleResult.schedule_id = scheduleSuccess.schedule_id;
      scheduleResult.name = scheduleSuccess.name;
      return scheduleResult;
    }

    public ScheduleResult deleteSchedule(string schedule_id)
    {
      Preconditions.checkArgument(schedule_id != null, (object) "schedule_id should not be empty");
      Console.WriteLine(schedule_id);
      ResponseWrapper responseWrapper = this.sendDelete("https://api.jpush.cn" + "/v3/schedules" + "/" + schedule_id, this.Authorization(), schedule_id);
      ScheduleResult scheduleResult = new ScheduleResult();
      scheduleResult.ResponseResult = responseWrapper;
      ScheduleSuccess scheduleSuccess = (ScheduleSuccess) JsonConvert.DeserializeObject<ScheduleSuccess>(responseWrapper.responseContent);
      return scheduleResult;
    }

    private string Authorization()
    {
      Debug.Assert(!string.IsNullOrEmpty(this.appKey));
      Debug.Assert(!string.IsNullOrEmpty(this.masterSecret));
      return Base64.getBase64Encode(this.appKey + ":" + this.masterSecret);
    }
  }
}
