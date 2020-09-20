using System.Collections;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdsService : MonoBehaviour
{
    [SerializeField] private string _gameId = "2721354";
    private void Start()
    {
        if (Advertisement.isSupported)
            Advertisement.Initialize(_gameId, false);

        Game.GameLosed += OnGameOver;
    }

    public void OnGameOver()
    {
        StartCoroutine(ShowAds());
    }

    IEnumerator ShowAds()
    {
        yield return new WaitForSeconds(1f);

        while (!Advertisement.IsReady())
        {
            yield return null;
        }
        Advertisement.Show();

        yield return new WaitForSeconds(30f);
    }
}
