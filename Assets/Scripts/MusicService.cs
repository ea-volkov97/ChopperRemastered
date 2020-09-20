using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MusicService : MonoBehaviour
{
    [SerializeField] private AudioClip _mainTheme;

    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        Game.GameStarted += OnGameStarted;
    }

    private void OnDisable()
    {
        Game.GameStarted -= OnGameStarted;
    }

    private void OnGameStarted()
    {
        PlayMainTheme();
    }

    private void PlayMainTheme()
    {
        _audioSource.clip = _mainTheme;
        _audioSource.loop = true;
        _audioSource.Play();
    }
}
