using UnityEngine;

public class Background : MonoBehaviour
{
    [SerializeField] private float _velocity = 0f;
    [SerializeField] private float _width = 1f;

    public float Width => _width;

    private void OnEnable()
    {
        Game.GameLosed += OnGameOver;    
    }

    private void OnDisable()
    {
        Game.GameLosed -= OnGameOver;
    }

    private void Update()
    {
        transform.position += _velocity * Time.deltaTime * Vector3.left;

        if (transform.position.x < -2 * _width)
            Destroy(gameObject);
    }

    private void OnGameOver()
    {
        StopMovement();
    }

    private void StopMovement()
    {
        _velocity = 0f;
    }
}
