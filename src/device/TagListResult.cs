// Decompiled with JetBrains decompiler
// Type: cn.jpush.api.device.TagListResult
// Assembly: cn.jpush.api, Version=3.3.3.0, Culture=neutral, PublicKeyToken=null
// MVID: 8C64A4D9-F1B2-4309-8DF5-ACE3B9A5E7DC
// Assembly location: E:\Administrator\Desktop\NET.Reflector\dot\cn.jpush.api.dll

using cn.jpush.api.common;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;

namespace cn.jpush.api.device
{
  public class TagListResult : BaseResult
  {
    public List<string> tags;

    public TagListResult()
    {
      this.tags = (List<string>) null;
    }

    public override bool isResultOK()
    {
      return object.Equals((object) this.ResponseResult.responseCode, (object) HttpStatusCode.OK);
    }

    public static TagListResult fromResponse(ResponseWrapper responseWrapper)
    {
      TagListResult tagListResult = new TagListResult();
      if (responseWrapper.isServerResponse())
        tagListResult = (TagListResult) JsonConvert.DeserializeObject<TagListResult>(responseWrapper.responseContent);
      tagListResult.ResponseResult = responseWrapper;
      return tagListResult;
    }
  }
}
