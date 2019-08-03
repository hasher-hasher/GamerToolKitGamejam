using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    public float speed;
    private void Update() {
        GetComponent<Rigidbody2D>().velocity = Vector2.left * speed * Time.deltaTime;
    }
}
