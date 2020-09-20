using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    private void Awake()
    {
        Game.Initialize();
    }

    private void Update()
    {
        if (!Game.IsOver)
        {
            Game.AddScore(Time.deltaTime);
        }
    }
}
