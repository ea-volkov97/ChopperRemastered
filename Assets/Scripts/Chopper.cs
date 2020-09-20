using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class Chopper : MonoBehaviour, IDamagable
{
    [SerializeField] AudioClip _rotorsNoiseSound;
    [SerializeField] Explosion _chopperExplosion;
    [SerializeField] float _maxHeight = 1f;
    [SerializeField] float _minHeigth = -1f;
    [SerializeField] float _velocity = 50f;
    
    public static bool isDowned { get; private set; }

    private bool _isDragged = false;

    private Rigidbody2D _rigidbody2D;
    private Animator _animator;
    private AudioSource _audioSource;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();

        _rigidbody2D.gravityScale = 0f;

        _audioSource.clip = _rotorsNoiseSound;
        _audioSource.loop = true;
        _audioSource.Play();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Ground>() != null)
        {
            Instantiate(_chopperExplosion, transform.position, Quaternion.identity);
            _rigidbody2D.gravityScale = 0f;
            _rigidbody2D.velocity = Vector2.zero;
        }
    }

    public void TakeDamage()
    {
        Game.OverGame();

        isDowned = true;
        _animator.SetTrigger("Downed");
        _audioSource.Stop();
        _rigidbody2D.gravityScale = 1f;
    }

    private void OnMouseDrag()
    {
        if (!Game.IsPaused && !Game.IsOver)
        {
            if (!_isDragged)
            {
                _isDragged = true;
                Game.StartNewGame();
            }

            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (CheckIfInFlightZone(mousePos))
                transform.position = Vector2.MoveTowards(transform.position, mousePos, _velocity * Time.deltaTime);
                    
        }
    }

    private bool CheckIfInFlightZone(Vector3 position)
    {
        if (position.y > _maxHeight || position.y < _minHeigth)
            return false;

        return true;
    }
}
