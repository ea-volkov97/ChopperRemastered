using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] private string _privacyPolicyURL = "";

    [SerializeField] private GameObject _recordValueText;
    [SerializeField] private GameObject _scoreText;
    [SerializeField] private GameObject _quitButton;
    [SerializeField] private GameObject _pauseButton;
    [SerializeField] private GameObject _continueButton;
    [SerializeField] private GameObject _homeButton;
    [SerializeField] private GameObject _muteButton;
    [SerializeField] private GameObject _unmuteButton;
    [SerializeField] private GameObject _guideText;
    [SerializeField] private GameObject _privacyPolicyButton;

    private void OnEnable()
    {
        Game.GameStarted += OnNewGameStarted;
    }

    private void OnDisable()
    {
        Game.GameStarted -= OnNewGameStarted;
    }

    private void Start()
    {
        
    }

    public void OnNewGameStarted()
    {
        _recordValueText.SetActive(false);
        _guideText.SetActive(false);
        _privacyPolicyButton.SetActive(false);
        _quitButton.SetActive(false);

        _scoreText.SetActive(true);
        _pauseButton.SetActive(true);
        _homeButton.SetActive(true);
    }

    public void PauseGame()
    {
        Game.Pause();
        _pauseButton.SetActive(false);
        _continueButton.SetActive(true);
    }

    public void ContinueGame()
    {
        Game.Continue();
        _pauseButton.SetActive(true);
        _continueButton.SetActive(false);
    }

    public void GoHome()
    {
        Game.OverGame();
        SceneManager.LoadScene(0);
    }

    public void Mute()
    {
        Camera.main.GetComponent<AudioListener>().enabled = false;
        _muteButton.SetActive(false);
        _unmuteButton.SetActive(true);
    }

    public void Unmute()
    {
        Camera.main.GetComponent<AudioListener>().enabled = true;
        _unmuteButton.SetActive(false);
        _muteButton.SetActive(true);
    }

    public void OpenPrivacyPolicy()
    {
        if (_privacyPolicyURL != "")
            Application.OpenURL(_privacyPolicyURL);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
