using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundGenerator : MonoBehaviour
{
    [SerializeField] private Background _background;

    private Background _currentBackground;
    private Background _previousBackground;

    private void Start()
    {
        _currentBackground = Instantiate(_background);
        _currentBackground.transform.position = transform.position;
        _currentBackground.transform.rotation = Quaternion.identity;
    }

    private void FixedUpdate()
    {
        if (_currentBackground.transform.position.x < 0f)
        {
            _previousBackground = _currentBackground;

            _currentBackground = Instantiate(_background);
            _currentBackground.transform.position = new Vector3(_previousBackground.transform.position.x + _previousBackground.Width, 0f, 0f);
        }
    }
}
