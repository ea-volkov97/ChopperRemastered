using UnityEngine;

public class Rocket : MonoBehaviour
{
    [SerializeField] private Explosion _rocketExplosion;
    [SerializeField] private float _linearVelocity = 1f;
    [SerializeField] private float _angularVelocity = 1f;
    
    private Transform _target;

    private float _operatingTime;
    private float _lifetime = 1f;

    public void SetCharacteristics(float linearVelocity = 1f, float angularVelocity = 1f, float lifetime = 1f)
    {
        _linearVelocity = linearVelocity;
        _angularVelocity = angularVelocity;
        _lifetime = lifetime;
    }

    private void Start()
    {
        _target = FindObjectOfType<Chopper>().transform;
        _operatingTime = 0f;
    }

    private void Update()
    {
        if (_operatingTime < _lifetime)
            FollowTarget();
        else
            Explode();

        _operatingTime += Time.deltaTime;        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        IDamagable damagable;
        if (collision.collider.TryGetComponent(out damagable))
        {
            damagable.TakeDamage();
            Explode();
        }
    }

    private void Explode()
    {
        Instantiate(_rocketExplosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    private void FollowTarget()
    {
        Vector2 direction = _target.transform.position - transform.position;
        direction.Normalize();
        transform.up = Vector2.Lerp(transform.up, direction, _angularVelocity * Time.deltaTime);
        transform.Translate(direction * _linearVelocity * Time.deltaTime, Space.World);
    }
}
