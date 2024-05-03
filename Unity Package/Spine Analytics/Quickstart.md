# Unity Spine Analytics API Quickstart

1. Download The Package
We have created a unity package to easily use the Spine analytics API in Unity, you can downlaod it here: (soon a link)
2. Install the package into your project
Go to your project into Window->Package Manager and add the downloaded package from disk
3. Add the SpineAnalyticsAPI component to a gameobject
4. In your script, get the component and initialize
```C#
spineAnalyticsAPI = GetComponent<SpineAnalyticsAPI>();
spineAnalyticsAPI.initialize("APIKEYHERE", "GAMEID");
```
5. Add the data you want to send to the class
for example:
```C#
SpineAnalyticsAPI.StatisticData timeData = new SpineAnalyticsAPI.StatisticData
{
    title = "This Works",
    value = GameTime.Elapsed.Seconds.ToString()
};

spineAnalyticsAPI.gameSessionData.statistics.Add(timeData);
```
This code adds the a statistic which has the amount of time the player was playing the game
6. Send the information
```C#
spineAnalyticsAPI.SendSessionAsync();
```