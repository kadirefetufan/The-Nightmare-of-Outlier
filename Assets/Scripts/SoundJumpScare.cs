using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundJumpScare : MonoBehaviour
{   
    [SerializeField] public AudioSource source;
    [SerializeField] public AudioClip screamSound;
    [SerializeField] public int seconds;



    void Start()
    {
        source = GetComponent<AudioSource>();
        source.clip = screamSound;

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            StartCoroutine(playSound());
        }
    }

   IEnumerator playSound()
    {
        source.Play();
        yield return new WaitForSeconds(seconds);
        Destroy(gameObject);
    }
}
