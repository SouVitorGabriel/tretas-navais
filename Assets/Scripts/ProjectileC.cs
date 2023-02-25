using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileC : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private GameObject explosionAnim;

    void Start()
    {
        Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.AddForce(transform.up * speed, ForceMode2D.Impulse);
    }

    void OnCollisionStay2D(Collision2D other)
    {
        Instantiate(explosionAnim, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
