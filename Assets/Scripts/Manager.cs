using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : Singleton<Manager>
{
    public int difficulty;

    private float timer;

    private void Start() {
        difficulty = 1;

        if (!PlayerPrefs.HasKey("Best")) {
            print("creating hi-score");
            PlayerPrefs.SetString("Best", 0.ToString());
        }

        if (!PlayerPrefs.HasKey("Score")) {
            print("creating score");
            PlayerPrefs.SetString("Score", 0.ToString());
        }
    }

    private void Update() {
        timer += Time.deltaTime;

        if (timer >= 8f) {
            difficulty++;
            timer = 0;
        }
    }
}
