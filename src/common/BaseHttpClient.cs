// Decompiled with JetBrains decompiler
// Type: cn.jpush.api.common.BaseHttpClient
// Assembly: cn.jpush.api, Version=3.3.3.0, Culture=neutral, PublicKeyToken=null
// MVID: 8C64A4D9-F1B2-4309-8DF5-ACE3B9A5E7DC
// Assembly location: E:\Administrator\Desktop\NET.Reflector\dot\cn.jpush.api.dll

using cn.jpush.api.common.resp;
using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text;

namespace cn.jpush.api.common
{
  public class BaseHttpClient
  {
    private const string CHARSET = "UTF-8";
    private const string RATE_LIMIT_QUOTA = "X-Rate-Limit-Limit";
    private const string RATE_LIMIT_Remaining = "X-Rate-Limit-Remaining";
    private const string RATE_LIMIT_Reset = "X-Rate-Limit-Reset";
    protected const int RESPONSE_OK = 200;
    private const int DEFAULT_CONNECTION_TIMEOUT = 100000;
    private const int DEFAULT_SOCKET_TIMEOUT = 100000;

    public ResponseWrapper sendPost(string url, string auth, string reqParams)
    {
      return this.sendRequest("POST", url, auth, reqParams);
    }

    public ResponseWrapper sendDelete(string url, string auth, string reqParams)
    {
      return this.sendRequest("DELETE", url, auth, reqParams);
    }

    public ResponseWrapper sendGet(string url, string auth, string reqParams)
    {
      return this.sendRequest("GET", url, auth, reqParams);
    }

    public ResponseWrapper sendPut(string url, string auth, string reqParams)
    {
      return this.sendRequest("PUT", url, auth, reqParams);
    }

    public ResponseWrapper sendRequest(
      string method,
      string url,
      string auth,
      string reqParams)
    {
      Console.WriteLine("Send request - " + method.ToString() + " " + url + " " + (object) DateTime.Now);
      if (reqParams != null)
        Console.WriteLine("Request Content - " + reqParams + " " + (object) DateTime.Now);
      ResponseWrapper responseRequest = new ResponseWrapper();
      HttpWebRequest httpWebRequest = (HttpWebRequest) null;
      HttpWebResponse httpWebResponse = (HttpWebResponse) null;
      try
      {
        httpWebRequest = (HttpWebRequest) WebRequest.Create(url);
        httpWebRequest.Method = method;
        httpWebRequest.ContentType = "application/json";
        httpWebRequest.KeepAlive = false;
        if (!string.IsNullOrEmpty(auth))
          httpWebRequest.Headers.Add("Authorization", "Basic " + auth);
        if (method == "POST" || method == "PUT")
        {
          byte[] bytes = Encoding.UTF8.GetBytes(reqParams);
          httpWebRequest.ContentLength = (long) bytes.Length;
          using (Stream requestStream = httpWebRequest.GetRequestStream())
          {
            requestStream.Write(bytes, 0, bytes.Length);
            requestStream.Close();
          }
        }
        httpWebResponse = (HttpWebResponse) httpWebRequest.GetResponse();
        HttpStatusCode statusCode = httpWebResponse.StatusCode;
        responseRequest.responseCode = statusCode;
        if (object.Equals((object) httpWebResponse.StatusCode, (object) HttpStatusCode.OK))
        {
          using (StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream(), Encoding.UTF8))
            responseRequest.responseContent = streamReader.ReadToEnd();
          string responseHeader1 = httpWebResponse.GetResponseHeader("X-Rate-Limit-Limit");
          string responseHeader2 = httpWebResponse.GetResponseHeader("X-Rate-Limit-Remaining");
          string responseHeader3 = httpWebResponse.GetResponseHeader("X-Rate-Limit-Reset");
          responseRequest.setRateLimit(responseHeader1, responseHeader2, responseHeader3);
          Console.WriteLine("Succeed to get response - 200 OK " + (object) DateTime.Now);
          Console.WriteLine("Response Content - {0}", (object) (responseRequest.responseContent + " " + (object) DateTime.Now));
        }
      }
      catch (WebException ex)
      {
        if (ex.Status == WebExceptionStatus.ProtocolError)
        {
          HttpStatusCode statusCode = ((HttpWebResponse) ex.Response).StatusCode;
          string statusDescription = ((HttpWebResponse) ex.Response).StatusDescription;
          using (StreamReader streamReader = new StreamReader(ex.Response.GetResponseStream(), Encoding.UTF8))
            responseRequest.responseContent = streamReader.ReadToEnd();
          responseRequest.responseCode = statusCode;
          responseRequest.exceptionString = ex.Message;
          string responseHeader1 = ((HttpWebResponse) ex.Response).GetResponseHeader("X-Rate-Limit-Limit");
          string responseHeader2 = ((HttpWebResponse) ex.Response).GetResponseHeader("X-Rate-Limit-Remaining");
          string responseHeader3 = ((HttpWebResponse) ex.Response).GetResponseHeader("X-Rate-Limit-Reset");
          responseRequest.setRateLimit(responseHeader1, responseHeader2, responseHeader3);
          Debug.Print(ex.Message);
          responseRequest.setErrorObject();
          Console.WriteLine(string.Format("fail  to get response - {0}", (object) statusCode) + " " + (object) DateTime.Now);
          Console.WriteLine(string.Format("Response Content - {0}", (object) responseRequest.responseContent) + " " + (object) DateTime.Now);
          throw new APIRequestException(responseRequest);
        }
        string info = method + url + auth + reqParams;
        Console.WriteLine(info);
        throw new APIConnectionException(ex.Message, info);
      }
      finally
      {
        if (httpWebResponse != null)
          httpWebResponse.Close();
        if (httpWebRequest != null)
          httpWebRequest.Abort();
      }
      return responseRequest;
    }
  }
}
