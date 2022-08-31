using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class HttpLog
{
 
    /// <summary>
    /// 游戏APP唯一ID
    /// </summary>
    public static string m_game_guid = "game_bow";

    /// <summary>
    /// 服务器主机地址 末尾带斜杠/
    /// </summary>
    public static string m_server_host = "http://192.168.10.87:9088/";

    private static void Save(string debug_type, string game_log, Action<string> on_success=null, Action<string> on_error=null)
    {
        string apiurl = string.Format("{0}{1}", m_server_host, "save_game_dev_log");
        //
        C2S_HttpAPI_Log c2s = new C2S_HttpAPI_Log();

        c2s.send_guid = "log_photon_net";
        c2s.debug_type = debug_type;
        c2s.game_log = game_log;
        c2s.update_time = "";

        string json = JsonUtility.ToJson(c2s);
        APIGO.SendToAPIServer(apiurl, json, on_success, on_error);
    }

    public static void Log(string game_log)
    {
        Save("log",game_log,null,null);
    }

    public static void LogError(string game_log)
    {
        Save("log_error", game_log, null, null);
    }
}

[System.Serializable]
public class C2S_HttpAPI_Log
{
    public string send_guid;
    public string debug_type;
    public string game_log;
    public string update_time;
}

public class APIGO
{
    public static void SendToAPIServer(string url, string pjson, Action<string> on_success, Action<string> on_error)
    {
        using (WebClient wc = new WebClient())
        {
            wc.Headers[HttpRequestHeader.ContentType] = "application/json";

            wc.Encoding = System.Text.Encoding.UTF8;

            try
            {
                var txt = wc.UploadString(url, pjson);

                if (on_success != null)
                {
                    on_success(txt);
                }
            }
            catch (Exception ex)
            {
                if (on_error != null)
                {
                    on_error(ex.Message);
                }
            }
        }
    }

}