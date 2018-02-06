using UnityEngine;
using System.Collections;

public class PlaySound : MonoBehaviour
{
    SphereCollider col;

    void Start()

    {
        col = GetComponent<SphereCollider>();

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GetComponent<AudioSource>().Play();
            col.enabled = false;
        }

    }
}