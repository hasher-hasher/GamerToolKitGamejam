using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : Singleton<Manager>
{
    public int difficulty;

    private float timer;

    private void Start() {
        difficulty = 1;
    }

    private void Update() {
        timer += Time.deltaTime;

        if (timer >= 8f) {
            difficulty++;
            timer = 0;
        }
    }
}
