using UnityEngine;

public class RocketGenerator : MonoBehaviour
{
    [SerializeField] private Rocket _rocket;
    [SerializeField] private float _interval;
    [SerializeField] private float _generationZoneRadius;

    private bool _isWorking = false;
    private float _passedTime;

    private void OnEnable()
    {
        Game.GameStarted += StartGeneration;
    }

    private void OnDisable()
    {
        Game.GameStarted -= StartGeneration;
    }

    private void StartGeneration()
    {
        _isWorking = true;
    }

    private void Update()
    {
        if (_isWorking && !Game.IsOver)
        {
            if (_passedTime > _interval)
            {
                Instantiate(_rocket);
                _rocket.SetCharacteristics(GetRocketLinearSpeed(), GetRocketAngularSpeed(), GetRocketLifetime());
                _rocket.transform.position = GetRandomPosition();

                _passedTime = 0f;
            }

            _passedTime += Time.deltaTime;
        }
    }

    private Vector2 GetRandomPosition()
    {
        float alpha = Random.Range(0f, Mathf.PI);
        float x = _generationZoneRadius * Mathf.Cos(alpha);
        float y = _generationZoneRadius * Mathf.Sin(alpha);
        Vector2 position = new Vector2(x, y);
        return position;
    }

    private float GetRocketLinearSpeed()
    {
        return 8f + Game.Score * 0.0001f;
    }

    private float GetRocketAngularSpeed()
    {
        return 10f;
    }

    private float GetRocketLifetime()
    {
        return 10f + Game.Score * 0.0001f;
    }
}
