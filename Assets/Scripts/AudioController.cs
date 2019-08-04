using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public GameObject audioController;
    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.FindWithTag("Audio") == null) {
            Instantiate(audioController);
        }
    }
}
