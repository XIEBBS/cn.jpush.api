// Decompiled with JetBrains decompiler
// Type: cn.jpush.api.push.MessageResult
// Assembly: cn.jpush.api, Version=3.3.3.0, Culture=neutral, PublicKeyToken=null
// MVID: 8C64A4D9-F1B2-4309-8DF5-ACE3B9A5E7DC
// Assembly location: E:\Administrator\Desktop\NET.Reflector\dot\cn.jpush.api.dll

using cn.jpush.api.common;
using System.Net;

namespace cn.jpush.api.push
{
  public class MessageResult : BaseResult
  {
    public long msg_id { get; set; }

    public long sendno { get; set; }

    public override bool isResultOK()
    {
      return object.Equals((object) this.ResponseResult.responseCode, (object) HttpStatusCode.OK);
    }

    public override string ToString()
    {
      return string.Format("sendno:{0},message_id:{1}", (object) this.sendno, (object) this.msg_id);
    }
  }
}
