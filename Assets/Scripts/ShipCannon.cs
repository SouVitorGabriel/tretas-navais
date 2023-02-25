using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipCannon : MonoBehaviour
{
    [SerializeField] private ProjectileC projectile;
    [SerializeField] private Transform spawner;

    [Header("Configurações")]
    [SerializeField] private float tirosPorSegundo;
    private float timer = 0;

    void Update()
    {
        timer -= Time.deltaTime;
        if (Input.GetButton("Jump"))
        {
            if (timer <= 0)
            {
                Instantiate(projectile, spawner.position, spawner.rotation);
                timer = (1 / tirosPorSegundo);
            }

        }
    }


}
