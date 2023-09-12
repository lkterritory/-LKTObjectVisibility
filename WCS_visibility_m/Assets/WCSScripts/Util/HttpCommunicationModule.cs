using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using WCSScripts.Model.HTTP.Base;
using Newtonsoft.Json;

using System;
using WCSScripts.Model.HTTP.Test;

public class HttpCommunicationModule : MonoBehaviour
{
    // GET 요청을 수행하는 메서드
    // 이벤트 정의
    public delegate void OnResponseReceived(BaseService response);
    public event OnResponseReceived ResponseReceived;

    public List<BaseService> arrService;

    private void Awake()
    {
        //arrService = new List<BaseService>();
    }

    // GET 요청을 수행하는 메서드
    public IEnumerator GetRequest(BaseService svcBase)
    {
        if(arrService == null)
        {
            arrService = new List<BaseService>();
        }

        string json = JsonConvert.SerializeObject(svcBase.payload);
        string base64EncodedJson = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(json));
        //byte[] bodyData = System.Text.Encoding.UTF8.GetBytes(base64EncodedJson);

        svcBase.strUrl += ("?id=" + base64EncodedJson);
        Debug.Log("reqeq: " + json);

        //yield return null;

        //using (UnityWebRequest www = UnityWebRequest.Post(url, "POST"))
        //{
        //    www.uploadHandler = new UploadHandlerRaw(bodyData);
        //    www.downloadHandler = new DownloadHandlerBuffer();
        //    www.SetRequestHeader("Content-Type", "application/json");

        //    yield return www.SendWebRequest();

        //    if (www.result != UnityWebRequest.Result.Success)
        //    {
        //        Debug.LogError("Error: " + www.error);
        //    }
        //    else
        //    {
        //        string responseData = www.downloadHandler.text;
        //        ResponseReceived?.Invoke(responseData);
        //    }
        //}


        arrService.Add(svcBase);
        using (UnityWebRequest www = UnityWebRequest.Get(svcBase.strUrl))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError("Error: " + www.error);
            }
            else
            {
                svcBase.strResData = www.downloadHandler.text;
                // 이벤트 호출

                Debug.Log("resres: " + svcBase.strResData);


                ResponseReceived?.Invoke(svcBase);

                arrService.Remove(svcBase);
            }
        }
    }


    // POST 요청을 수행하는 메서드
    public IEnumerator PostRequest(string url, string jsonData)
    {
        byte[] bodyData = System.Text.Encoding.UTF8.GetBytes(jsonData);

        using (UnityWebRequest www = UnityWebRequest.Post(url, "POST"))
        {
            www.uploadHandler = new UploadHandlerRaw(bodyData);
            www.downloadHandler = new DownloadHandlerBuffer();
            www.SetRequestHeader("Content-Type", "application/json");

            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError("Error: " + www.error);
            }
            else
            {
                Debug.Log("Received: " + www.downloadHandler.text);
            }
        }
    }
}