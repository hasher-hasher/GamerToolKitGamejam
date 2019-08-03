using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    Transform player;
    Vector3 desiredPosition;

    private void Start() {
        player = GameObject.Find("Player").transform;
    }
    private void FixedUpdate() {
        desiredPosition = new Vector3(player.position.x, transform.position.y, transform.position.z);
        if (player.transform.position.x >= transform.position.x) {
            transform.position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime * 10f);
        }
    }
}
