using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    [SerializeField] private Light flash;
    [SerializeField] private bool open;
    [SerializeField] private GameObject flashlightobje;

    [Header("Sound")]
    [SerializeField] private AudioSource flashAudioSource = default;
    [SerializeField] private AudioClip flashsound = default;

    [Header("Battery")]
    [SerializeField] private float flashEnergy;
    [SerializeField] private Slider batteryIndicator ;

    [Header("Doors")]
    [SerializeField] private float keys;

    private void Start()
    {
        flashAudioSource = GetComponent<AudioSource>();
        flashAudioSource.clip = flashsound;
    }

    private void Update()
    {
        batteryIndicator.value = flashEnergy;
        if (Input.GetKeyDown(KeyCode.F))
        {
            open = !open;
            flashAudioSource.Play();
        }

        if (open)
        {
            flash.enabled = true;
            flashEnergy -= 1 * Time.deltaTime;
        }

        else
        {
            flash.enabled = false;
        }

        if (flashEnergy <= 0)
        {
            flashEnergy = 0;
            flash.enabled = false;
        }

        if (flashEnergy >= 100)
        {
            flashEnergy = 100;
        }

    }

    public void FlashBattery()
    {
        flashEnergy += 25;
    }

    public void Keys()
    {
        keys += 1;
    }

}
