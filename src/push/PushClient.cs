// Decompiled with JetBrains decompiler
// Type: cn.jpush.api.push.PushClient
// Assembly: cn.jpush.api, Version=3.3.3.0, Culture=neutral, PublicKeyToken=null
// MVID: 8C64A4D9-F1B2-4309-8DF5-ACE3B9A5E7DC
// Assembly location: E:\Administrator\Desktop\NET.Reflector\dot\cn.jpush.api.dll

using cn.jpush.api.common;
using cn.jpush.api.push.mode;
using cn.jpush.api.util;
using Newtonsoft.Json;
using System.Diagnostics;

namespace cn.jpush.api.push
{
  internal class PushClient : BaseHttpClient
  {
    private const string HOST_NAME_SSL = "https://api.jpush.cn";
    private const string PUSH_PATH = "/v3/push";
    private string appKey;
    private string masterSecret;

    public PushClient(string appKey, string masterSecret)
    {
      Preconditions.checkArgument(!string.IsNullOrEmpty(appKey), (object) "appKey should be set");
      Preconditions.checkArgument(!string.IsNullOrEmpty(masterSecret), (object) "masterSecret should be set");
      this.appKey = appKey;
      this.masterSecret = masterSecret;
    }

    public MessageResult sendPush(PushPayload payload)
    {
      Preconditions.checkArgument(payload != null, (object) "pushPayload should not be empty");
      payload.Check();
      return this.sendPush(payload.ToJson());
    }

    public MessageResult sendPush(string payloadString)
    {
      Preconditions.checkArgument(!string.IsNullOrEmpty(payloadString), (object) "payloadstring should not be empty");
      ResponseWrapper responseWrapper = this.sendPost("https://api.jpush.cn" + "/v3/push", this.Authorization(), payloadString);
      MessageResult messageResult1 = new MessageResult();
      messageResult1.ResponseResult = responseWrapper;
      MessageResult messageResult2 = messageResult1;
      JpushSuccess jpushSuccess = (JpushSuccess) JsonConvert.DeserializeObject<JpushSuccess>(responseWrapper.responseContent);
      messageResult2.sendno = long.Parse(jpushSuccess.sendno);
      messageResult2.msg_id = long.Parse(jpushSuccess.msg_id);
      return messageResult2;
    }

    private string Authorization()
    {
      Debug.Assert(!string.IsNullOrEmpty(this.appKey));
      Debug.Assert(!string.IsNullOrEmpty(this.masterSecret));
      return Base64.getBase64Encode(this.appKey + ":" + this.masterSecret);
    }
  }
}
