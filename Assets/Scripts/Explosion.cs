using UnityEngine;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(Animator))]
public class Explosion : MonoBehaviour
{
    [SerializeField] private AudioClip[] _explosionSounds;
    private AudioSource _audioSource;
    private Animator _animator;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _animator = GetComponent<Animator>();

        if (_explosionSounds.Length != 0)
        {
            int index = Random.Range(0, _explosionSounds.Length);
            _audioSource.clip = _explosionSounds[index];
            _audioSource.Play();
        }

        float soundDuration = _audioSource.clip.length;
        float animationDuration = _animator.GetCurrentAnimatorClipInfo(0)[0].clip.length;
        
        float lifetime = soundDuration > animationDuration ? soundDuration : animationDuration;

        Destroy(gameObject, lifetime);
    }
}
