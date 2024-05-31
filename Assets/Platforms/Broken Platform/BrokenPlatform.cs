using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenPlatform : MonoBehaviour
{
    public float jumpForce = 10f;
    public int jumpAmount = 1;

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.relativeVelocity.y <= 0f) {
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
            if(rb != null) {
                Vector3 velocity = rb.velocity;
                velocity.y = jumpForce;
                rb.velocity = velocity;
                jumpAmount++;
                if(jumpAmount >= 1)
                {
                    Destroy(this.gameObject);
                }
            }
        }
    }
}
