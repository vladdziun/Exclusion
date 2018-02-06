using UnityEngine;
using System.Collections;

public class LightTurnOffEvent : MonoBehaviour {

    public GameObject[] allLights;

    SphereCollider col;

    void Start ()
    {

        col = GetComponent<SphereCollider>();
    }

    void OnTriggerEnter(Collider LightsTriggerEvent)
    {


        if (LightsTriggerEvent.CompareTag("Player"))

        {
            StartCoroutine(LightEvent());
            Debug.Log("xuy");
        }
        //col.enabled = false;
    }
    


    private IEnumerator LightEvent()
    {
        GameObject[] allLights = GameObject.FindGameObjectsWithTag("LightTurnOff");

        // foreach (GameObject i in allLights)
        for (int i = 0; i < allLights.Length; i++)
        {

            
            yield return new WaitForSeconds(2);
            allLights[i].GetComponent<Light>().enabled = false;
            allLights[i].GetComponent<AudioSource>().Play();
            
            Debug.Log("xuy");
        }
     
       
    }
}
