using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Threading;
using System.Diagnostics;

public class GameManager : MonoBehaviour
{
    public bool onTransition;
    Stopwatch GameTime;
    Stopwatch LevelTime;

    public static GameManager instance;
    private SpineAnalyticsAPI spineAnalyticsAPI;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Don't destroy this object when loading new scenes
        }

        GameTime = new Stopwatch();
        LevelTime = new Stopwatch();
        GameTime.Start();
        LevelTime.Start();
        onTransition = true;

        spineAnalyticsAPI = GetComponent<SpineAnalyticsAPI>();
        spineAnalyticsAPI.initialize("API-KEY", "GAME-ID", "DEV-ID");
    }

    void Update()
    {
        checkLose();
        checkWin();
    }

    private void checkLose()
    {
        if (GameObject.FindGameObjectsWithTag("Player").Length == 0 && !onTransition) {
            onTransition = true;
            //player.RemoveLife();
            if ((PlayerPrefs.GetInt("Lives") - 1) <= 0) StartCoroutine(LoseAndEnd());
            else StartCoroutine(LoseAndRetry());
        }
    }

    private void checkWin()
    {
        if (GameObject.FindGameObjectsWithTag("AI").Length == 0 && !onTransition) {
            onTransition = true;
            int newLevel = PlayerPrefs.GetInt("Level") + 1;
            UnityEngine.Debug.Log(newLevel);
            string newLevelPath = "Scenes/Levels/Level" + newLevel;
            UnityEngine.Debug.Log(newLevelPath);
            if (!IsSceneInBuildSettings(newLevelPath)) StartCoroutine(WinAndEnd());
            else {
                PlayerPrefs.SetInt("Level", newLevel);
                StartCoroutine(WinAndNext());
            }
        }
    }

    IEnumerator LoseAndRetry()
    {
        yield return new WaitForSeconds(2f); // Attendre 1 seconde
        PlayerPrefs.SetInt("Lives", PlayerPrefs.GetInt("Lives") - 1);
        UnityEngine.SceneManagement.SceneManager.LoadScene("Scenes/Menus/Transition");
    }

    IEnumerator LoseAndEnd()
    {
        yield return new WaitForSeconds(2f); // Attendre 1 seconde
        PlayerPrefs.SetInt("Lives", PlayerPrefs.GetInt("Lives") - 1);
        UnityEngine.Debug.Log("Player lost at level" + PlayerPrefs.GetInt("Level"));
        UnityEngine.SceneManagement.SceneManager.LoadScene("Scenes/Menus/LoseMenu");
        SendData();
    }

    IEnumerator WinAndNext()
    {
        //winMessage.gameObject.SetActive(true);
        yield return new WaitForSeconds(2f); // Attendre 1 seconde
        UnityEngine.Debug.Log("Finished Level in " + LevelTime.Elapsed);
        UnityEngine.SceneManagement.SceneManager.LoadScene("Scenes/Menus/Transition");
    }

    IEnumerator WinAndEnd()
    {
        //winMessage.gameObject.SetActive(true);
        yield return new WaitForSeconds(2f); // Attendre 1 seconde
        UnityEngine.SceneManagement.SceneManager.LoadScene("Scenes/Menus/WinMenu");
    }

    bool IsSceneInBuildSettings(string sceneName)
    {
        for (int i = 0; i < SceneManager.sceneCountInBuildSettings; i++)
        {
            string scenePath = SceneUtility.GetScenePathByBuildIndex(i);
            if (scenePath.Contains(sceneName))
            {
                return true;
            }
        }
        return false;
    }

    public void SendData()
    {
        SpineAnalyticsAPI.StatisticData deathData = new SpineAnalyticsAPI.StatisticData
        {
            title = "Player deaths",
            value = "1"
        };
        spineAnalyticsAPI.gameSessionData.statistics.Add(deathData);
        spineAnalyticsAPI.SendSession();
    }

    private void OnDestroy()
    {
        UnityEngine.Debug.Log("Total Game Time: " +  GameTime.Elapsed);
    }
}
