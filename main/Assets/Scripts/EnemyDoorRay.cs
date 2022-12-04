using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEditor;
public class EnemyDoorRay : MonoBehaviour
{
    public Transform rayInteractPoint;
    float rayDistance = 3f;
    float tick = 1f;
    public LayerMask layer;

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        tick -= Time.deltaTime;
        if (tick <= 0f)
        {
            tick = 1f;
            if (Physics.Raycast(rayInteractPoint.position, rayInteractPoint.forward, out hit, rayDistance, layer))
            {
                print("Kapý görüldü");
                PressKeyOpenDoor openDoor = hit.transform.GetComponent<PressKeyOpenDoor>();

                if (openDoor.canEnemyOpenDoor())
                {
                    print("Enemy kapýyý açabilir");

                    openDoor.Pressed();

                }

            }
        }
    }
}
