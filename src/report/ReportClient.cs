// Decompiled with JetBrains decompiler
// Type: cn.jpush.api.report.ReportClient
// Assembly: cn.jpush.api, Version=3.3.3.0, Culture=neutral, PublicKeyToken=null
// MVID: 8C64A4D9-F1B2-4309-8DF5-ACE3B9A5E7DC
// Assembly location: E:\Administrator\Desktop\NET.Reflector\dot\cn.jpush.api.dll

using cn.jpush.api.common;
using cn.jpush.api.util;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text.RegularExpressions;

namespace cn.jpush.api.report
{
  internal class ReportClient : BaseHttpClient
  {
    private const string REPORT_HOST_NAME = "https://report.jpush.cn";
    private const string REPORT_RECEIVE_PATH = "/v2/received";
    private const string REPORT_RECEIVE_PATH_V3 = "/v3/received";
    private const string REPORT_MESSAGE_PATH_V3 = "/v3/messages";
    private const string REPORT_USER_PATH = "/v3/users";
    private string appKey;
    private string masterSecret;

    public ReportClient(string appKey, string masterSecret)
    {
      this.appKey = appKey;
      this.masterSecret = masterSecret;
    }

    public ReceivedResult getReceiveds(string msg_ids)
    {
      this.checkMsgids(msg_ids);
      return this.getReceiveds_common(msg_ids, "/v2/received");
    }

    public ReceivedResult getReceiveds_v3(string msg_ids)
    {
      this.checkMsgids(msg_ids);
      return this.getReceiveds_common(msg_ids, "/v3/received");
    }

    public ResponseWrapper getMessageSendStatus(
      string msgId,
      List<string> registrationIdList,
      string data)
    {
            this.checkMsgids(msgId);
            string url = "https://report.jpush.cn/v3/status/message";
            JObject jobject1 = new JObject();
            jobject1.Add("msg_id", JToken.FromObject(long.Parse(msgId)));
            jobject1.Add("registration_ids", (JToken)JArray.FromObject((object)registrationIdList));
            JObject jobject2 = jobject1;
            if (!string.IsNullOrEmpty(data))
                jobject2.Add(nameof(data), JToken.FromObject(data));
            string base64Encode = Base64.getBase64Encode(this.appKey + ":" + this.masterSecret);
            return this.sendPost(url, base64Encode, ((object)jobject2).ToString());
        }

    public UsersResult getUsers(TimeUnit timeUnit, string start, int duration)
    {
      return UsersResult.fromResponse(this.sendGet("https://report.jpush.cn/v3/users?time_unit=" + timeUnit.ToString() + "&start=" + start + "&duration=" + (object) duration, Base64.getBase64Encode(this.appKey + ":" + this.masterSecret), (string) null));
    }

    public MessagesResult getReportMessages(params string[] msgIds)
    {
      return this.getReportMessages(StringUtil.arrayToString(msgIds));
    }

    public string checkMsgids(string msgIds)
    {
      if (string.IsNullOrEmpty(msgIds))
        throw new ArgumentException("msgIds param is required.");
      if (new Regex("[^0-9, ]").IsMatch(msgIds))
        throw new ArgumentException("msgIds param format is incorrect. It should be msg_id (number) which response from JPush Push API. If there are many, use ',' as interval. ");
      msgIds = msgIds.Trim();
      if (msgIds.EndsWith(","))
        msgIds = msgIds.Substring(0, msgIds.Length - 1);
      string[] strArray = msgIds.Split(',');
      List<string> stringList = new List<string>();
      try
      {
        foreach (string str in strArray)
        {
          string s = str.Trim();
          if (!string.IsNullOrEmpty(s))
          {
            long.Parse(s);
            stringList.Add(s);
          }
        }
        return StringUtil.arrayToString(stringList.ToArray());
      }
      catch (Exception ex)
      {
        throw new Exception("Every msg_id should be valid Integer number which splits by ','");
      }
    }

    private ReceivedResult getReceiveds_common(string msg_ids, string path)
    {
      ResponseWrapper responseWrapper = this.sendGet("https://report.jpush.cn" + path + "?msg_ids=" + msg_ids, Base64.getBase64Encode(this.appKey + ":" + this.masterSecret), (string) null);
      ReceivedResult receivedResult = new ReceivedResult();
      List<ReceivedResult.Received> receivedList = new List<ReceivedResult.Received>();
      if (responseWrapper.responseCode == HttpStatusCode.OK)
      {
        receivedList = (List<ReceivedResult.Received>) JsonTool.JsonToObject(responseWrapper.responseContent, (object) receivedList);
        string responseContent = responseWrapper.responseContent;
      }
      receivedResult.ResponseResult = responseWrapper;
      receivedResult.ReceivedList = receivedList;
      return receivedResult;
    }

    private MessagesResult getReportMessages(string msgIds)
    {
      ResponseWrapper responseWrapper = this.sendGet("https://report.jpush.cn/v3/messages?msg_ids=" + this.checkMsgids(msgIds), Base64.getBase64Encode(this.appKey + ":" + this.masterSecret), (string) null);
      MessagesResult messagesResult = new MessagesResult();
      List<MessagesResult.Message> messageList = new List<MessagesResult.Message>();
      Console.WriteLine("recieve content==" + responseWrapper.responseContent);
      if (responseWrapper.responseCode == HttpStatusCode.OK)
      {
        messageList = (List<MessagesResult.Message>) JsonTool.JsonToObject(responseWrapper.responseContent, (object) messageList);
        string responseContent = responseWrapper.responseContent;
      }
      messagesResult.ResponseResult = responseWrapper;
      messagesResult.messages = messageList;
      return messagesResult;
    }
  }
}
