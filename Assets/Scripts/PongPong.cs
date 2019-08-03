using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PongPong : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "Floor") {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-0.3f, 1f) * 350f * Time.deltaTime;
        }
    }
}
