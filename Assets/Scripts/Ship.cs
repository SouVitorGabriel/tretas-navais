using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private Rigidbody2D rigidbody;

    [Header("Configurações")]
    [SerializeField] private float moveAcceleration;
    [SerializeField] private float maxMoveSpeed;
    [SerializeField] private float rotationSpeed;

    [Header("Física de arrasto:")]
    [SerializeField] private bool useHardDrag = false;
    [SerializeField][Range(0, 1)] private float driftFactor = 1;

    private Vector2 movementDirection;
    private float rotationAngle;
    void Start()
    {

    }

    void Update()
    {
        movementDirection.y = Input.GetAxis("Vertical");
        movementDirection.x = Input.GetAxis("Horizontal");
    }

    void FixedUpdate()
    {
        if (movementDirection.y == 0)
        {
            rigidbody.drag = Mathf.Lerp(rigidbody.drag, 4, Time.fixedDeltaTime);
        }
        else
        {
            ApplyDrift();
        }


        if (Vector2.Dot(transform.up, rigidbody.velocity) > maxMoveSpeed || Vector2.Dot(transform.up, rigidbody.velocity) < (-maxMoveSpeed * 0.5f))
        {

        }
        else
        {
            rigidbody.AddForce(transform.up * movementDirection.y * moveAcceleration, ForceMode2D.Force);

        }

        rotationAngle -= (movementDirection.x * rotationSpeed);
        rigidbody.MoveRotation(rotationAngle);


    }

    void ApplyDrift()
    {
        if (useHardDrag)
        {
            rigidbody.drag = 0;
            rigidbody.angularDrag = 1f;
            Vector2 velUp = transform.up * Vector2.Dot(rigidbody.velocity, transform.up);
            Vector2 velRight = transform.right * Vector2.Dot(rigidbody.velocity, transform.right);
            rigidbody.velocity = velUp + velRight * driftFactor;
        }
        else
        {
            rigidbody.drag = 2;
            rigidbody.angularDrag = 1;
        }

    }
}
