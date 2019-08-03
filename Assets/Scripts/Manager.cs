using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : Singleton<Manager>
{
    public int difficulty;

    private void Start() {
        difficulty = 1;
    }
}
