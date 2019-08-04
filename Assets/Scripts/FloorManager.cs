using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorManager : MonoBehaviour
{
    [SerializeField]
    private GameObject itemToSpawn;

    private void OnTriggerEnter2D(Collider2D other) {
        Vector2 targetPosition = new Vector2(
            transform.position.x + (transform.parent.GetComponent<BoxCollider2D>().size.x - 5f),
            transform.parent.parent.position.y
        );
        if (other.gameObject.tag == "Player") {
            Instantiate(itemToSpawn, targetPosition, Quaternion.identity);
            print("Tei");
        }
    }
}
