using UnityEngine;
using System.Collections;

public class LightFlickering : MonoBehaviour {

    public float maxTime;
    public float minTime;

    private float timer;
    private Light light;


	void Start ()
    {
        light = GetComponent<Light>();
        timer = Random.Range(minTime, maxTime);
	}
	
	// Update is called once per frame
	void Update ()
    {
        timer -= Time.deltaTime;
        if (timer <=0)
        {
            light.enabled = !light.enabled;
            GetComponent<AudioSource>().Play();
            timer = Random.Range(minTime, maxTime);
            

        }
	}
}
