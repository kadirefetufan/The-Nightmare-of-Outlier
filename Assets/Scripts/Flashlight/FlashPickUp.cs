using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashPickUp : MonoBehaviour
{
    [Header("Flashlight")]
    public Flashlight flashlightScript;
    [SerializeField] private float flashDistance;
    [SerializeField] private GameObject flash;
    [SerializeField] private GameObject battery;

    [Header("Doors")]
    [SerializeField] private Animation door;
    [SerializeField] private bool isOpen;
    [SerializeField] private float keys;

    void Update()
    {
        Vector3 flashDirection = transform.TransformDirection(Vector3.forward);
        RaycastHit hit;

        if (Physics.Raycast(transform.position, flashDirection, out hit, flashDistance))
        {
            if (hit.distance <= flashDistance && hit.collider.gameObject.tag == "Flashlight")
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    flash.SetActive(true);
                    Destroy(hit.collider.gameObject);
                }
            }

            if (hit.distance <= flashDistance && hit.collider.gameObject.tag == "Battery")
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    flashlightScript.FlashBattery();
                    Destroy(hit.collider.gameObject);
                }
            }

            if (hit.distance <= flashDistance && hit.collider.gameObject.tag == "Key")
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    Keys();
                    Destroy(hit.collider.gameObject);
                }
            }

            
            if (hit.distance <= flashDistance && hit.collider.gameObject.tag == "Door")
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (keys == 1)
                    {
                        if (!isOpen)
                        {
                            door.Play("door open");
                            isOpen = true;
                        }
                        else
                        {
                            door.Play("door close");
                            isOpen = false;
                        }
                    }

                    else
                    {
                        print("I need a key");
                    }
                    
                    
                }
            }
        }
    }

    public void Keys()
    {
        keys += 1;
    }
}
