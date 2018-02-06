using UnityEngine;
using System.Collections;

public class ScareTriggerEvent : MonoBehaviour {
    public GameObject ScarePlate;
	AudioSource audio;
	SphereCollider col;
	//MeshRenderer mesh;
	public AudioClip scareSound;
	public float scareTime = 3.0f;

	bool showScare = false;

	void Start()
	{
		audio = GetComponent<AudioSource>();
		//mesh = GetComponent<MeshRenderer> ();
	col = GetComponent<SphereCollider>();
	}

	void OnTriggerEnter (Collider Scare)
	{
		
		if (Scare.CompareTag("Player"))
		{
            GameManager.gm.currentTime = GameManager.gm.currentTime + 20;
            GameManager.gm.mainTimerDisplay.text = GameManager.gm.currentTime.ToString("0");

            ScarePlate.SetActive(true);
            //mesh.enabled  = true;
			audio.loop = false;
			audio.clip = scareSound;
			audio.volume = 1f;
			audio.Play();
		
			showScare = true;
			col.enabled = false;
		}
	
	}
	

	void Update () 
	{
		if (showScare) 
		{
				scareTime -= Time.deltaTime;
				if(scareTime<=0)
				{
					ScarePlate.SetActive (false);
					audio.Stop ();
				}
		}
	}
}
