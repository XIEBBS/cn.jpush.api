// Decompiled with JetBrains decompiler
// Type: cn.jpush.api.JPushClient
// Assembly: cn.jpush.api, Version=3.3.3.0, Culture=neutral, PublicKeyToken=null
// MVID: 8C64A4D9-F1B2-4309-8DF5-ACE3B9A5E7DC
// Assembly location: E:\Administrator\Desktop\NET.Reflector\dot\cn.jpush.api.dll

using cn.jpush.api.common;
using cn.jpush.api.common.resp;
using cn.jpush.api.device;
using cn.jpush.api.push;
using cn.jpush.api.push.mode;
using cn.jpush.api.report;
using cn.jpush.api.util;
using System.Collections.Generic;

namespace cn.jpush.api
{
  public class JPushClient
  {
    private PushClient _pushClient;
    private ReportClient _reportClient;
    private DeviceClient _deviceClient;

    public JPushClient(string app_key, string masterSecret)
    {
      this._pushClient = new PushClient(app_key, masterSecret);
      this._reportClient = new ReportClient(app_key, masterSecret);
      this._deviceClient = new DeviceClient(app_key, masterSecret);
    }

    public MessageResult SendPush(PushPayload payload)
    {
      Preconditions.checkArgument(payload != null, (object) "pushPayload should not be empty");
      return this._pushClient.sendPush(payload);
    }

    public MessageResult SendPush(string payloadString)
    {
      Preconditions.checkArgument(!string.IsNullOrEmpty(payloadString), (object) "payloadString should not be empty");
      return this._pushClient.sendPush(payloadString);
    }

    public ReceivedResult getReceivedApi(string msg_ids)
    {
      return this._reportClient.getReceiveds(msg_ids);
    }

    public ReceivedResult getReceivedApi_v3(string msg_ids)
    {
      return this._reportClient.getReceiveds_v3(msg_ids);
    }

    public ResponseWrapper getMessageSendStatus(
      string msgId,
      List<string> registrationIdList,
      string data)
    {
      return this._reportClient.getMessageSendStatus(msgId, registrationIdList, data);
    }

    public UsersResult getReportUsers(TimeUnit timeUnit, string start, int duration)
    {
      return this._reportClient.getUsers(timeUnit, start, duration);
    }

    public MessagesResult getReportMessages(params string[] msgIds)
    {
      return this._reportClient.getReportMessages(msgIds);
    }

    public TagAliasResult getDeviceTagAlias(string registrationId)
    {
      return this._deviceClient.getDeviceTagAlias(registrationId);
    }

    public DefaultResult updateDeviceTagAlias(
      string registrationId,
      bool clearAlias,
      bool clearTag)
    {
      return this._deviceClient.updateDeviceTagAlias(registrationId, clearAlias, clearTag);
    }

    public DefaultResult updateDeviceTagAlias(
      string registrationId,
      string alias,
      string mobile,
      HashSet<string> tagsToAdd,
      HashSet<string> tagsToRemove)
    {
      return this._deviceClient.updateDevice(registrationId, alias, mobile, tagsToAdd, tagsToRemove);
    }

    public TagListResult getTagList()
    {
      return this._deviceClient.getTagList();
    }

    public BooleanResult isDeviceInTag(string theTag, string registrationID)
    {
      return this._deviceClient.isDeviceInTag(theTag, registrationID);
    }

    public DefaultResult addRemoveDevicesFromTag(
      string theTag,
      HashSet<string> toAddUsers,
      HashSet<string> toRemoveUsers)
    {
      return this._deviceClient.addRemoveDevicesFromTag(theTag, toAddUsers, toRemoveUsers);
    }

    public DefaultResult deleteTag(string theTag, string platform)
    {
      return this._deviceClient.deleteTag(theTag, platform);
    }

    public AliasDeviceListResult getAliasDeviceList(
      string alias,
      string platform)
    {
      return this._deviceClient.getAliasDeviceList(alias, platform);
    }

    public DefaultResult deleteAlias(string alias, string platform)
    {
      return this._deviceClient.deleteAlias(alias, platform);
    }
  }
}
