using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System;

public static class DatabaseManager
{
    public static IEnumerator InsertData(string nama, int skor)
    {
        WWWForm form = new WWWForm();
        form.AddField("nama", nama);
        form.AddField("skor", skor); 
        UnityWebRequest request = UnityWebRequest.Post("http://localhost/tutorialunity/insert.php", form);
        yield return request.SendWebRequest();
        request.Dispose();
    }
    public static IEnumerator GetData()
    {
        UnityWebRequest request = UnityWebRequest.Get("http://localhost/tutorialunity/read.php");
        yield return request.SendWebRequest();
        string json = request.downloadHandler.text;
        Actions.OnResultGet.Invoke(json);
        request.Dispose();

    }
    public static IEnumerator UpdateData(string nama, int NEWskor)
    {
        WWWForm form = new WWWForm();
        form.AddField("nama", nama);
        form.AddField("skor", NEWskor);
        UnityWebRequest request = UnityWebRequest.Post("http://localhost/tutorialunity/update.php", form);
        yield return request.SendWebRequest();
        request.Dispose();
    }
    public static IEnumerator DeleteData(string nama)
    {
        WWWForm form = new WWWForm();
        form.AddField("nama", nama);
        UnityWebRequest request = UnityWebRequest.Post("http://localhost/tutorialunity/delete.php", form);
        yield return request.SendWebRequest(); 
        request.Dispose();
    }
}
