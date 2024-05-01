using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager.Requests;
using UnityEngine;
using UnityEngine.Networking;


public class SpineAnalyticsAPI : MonoBehaviour
{

    [Serializable]
    public class ErrorData
    {
        public string title;
        public string description;
        public string log;
        public string timestamp = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ssZ");
    }

    [Serializable]
    public class AchievementData
    {
        public string title;
        public string description;
        public string timestamp = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ssZ");
    }

    [Serializable]
    public class StatisticData
    {
        public string title;
        public string description;
        public string value;
        public string timestamp = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ssZ");
    }

    [Serializable]
    public class GameSessionData
    {
        public string gameId;
        public List<StatisticData> statistics = new List<StatisticData>();
        public List<AchievementData> achievements = new List<AchievementData>();
        public List<ErrorData> errors = new List<ErrorData>();
    }

    public class SessionResponse
    {
        public string sessionId;
    }

    string baseUrl = "https://app-ekrmeoi24a-uc.a.run.app";
    string apiKey;
    string gameId;
    string sessionId;
    public GameSessionData gameSessionData;

    public void initialize(string _ApiKey, string gameId)
    {
        this.apiKey = _ApiKey;
        this.gameId = gameId;
    }

    // These are here to avoid having to type StartCouroutine for the developers
    public void SendSessionAsync()
    {
        StartCoroutine(SendSessionCoroutable());
    }

    public IEnumerator SendSession()
    {
        yield return StartCoroutine(SendSessionCoroutable());
    }

    //public void ModifySession()
    //{
    //    StartCoroutine(ModifySessionCoroutable());
    //}

    // Method to add a game session
    public IEnumerator SendSessionCoroutable()
    {
        string url = $"{baseUrl}/statistics/newSession";
        gameSessionData.gameId = gameId;
        UnityWebRequest request = UnityWebRequest.Post(url, JsonUtility.ToJson(gameSessionData), "application/json");
        request.SetRequestHeader("x-api-key", apiKey);
        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            string responseText = request.downloadHandler.text;
            SessionResponse responseData = JsonUtility.FromJson<SessionResponse>(responseText);
            sessionId = responseData.sessionId;
            Debug.Log("Sucessfully sent session data");
        }
        else
        {
            Debug.Log("Error: " + request.error + "\n Request Body: " + JsonUtility.ToJson(gameSessionData));
        }
        yield break;
    }

    //// Method to add a game session
    //public IEnumerator SendStatCoroutable()
    //{
    //    string url = $"{baseUrl}/statistics/{}/new";
    //    UnityWebRequest request = UnityWebRequest.PostWwwForm(url, JsonUtility.ToJson(gameSessionData));
    //    request.SetRequestHeader("x-api-key", apiKey);
    //    yield return request.SendWebRequest();

    //    if (request.result == UnityWebRequest.Result.Success)
    //    {
    //        string responseText = request.downloadHandler.text;
    //        print(responseText);
    //    }
    //    else
    //    {
    //        print("Error: " + request.error);
    //    }
    //}
}
