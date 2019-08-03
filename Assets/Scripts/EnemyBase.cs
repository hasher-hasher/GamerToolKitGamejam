using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public abstract class EnemyBase : MonoBehaviour
{
    public enum Enemy
    {
        Spin,
        Go_Left
    }

    public Enemy enemyType;

    public float Speed;

    public virtual void FixedUpdate() {
        switch (enemyType) {
            case Enemy.Spin:
                transform.Rotate(0f, 0f, Time.deltaTime * Speed);
                break;
            case Enemy.Go_Left:
                GetComponent<Rigidbody2D>().velocity = Vector2.left * Speed * Time.deltaTime;
                break;
        }
    }
}
