
using UnityEngine;
using System.Collections;

public class Footsteps : MonoBehaviour {

    public float footstepsRate = 0.8f;
    CharacterController cc;
	
	void Start ()	
 	{
		cc = GetComponent<CharacterController>();
        InvokeRepeating("Foots", 0, footstepsRate);
    }


    void Foots()

    {
        if (cc.isGrounded == true && GetComponent<AudioSource>().isPlaying == false && Input.GetButton("MoveForward"))
        {
            GetComponent<AudioSource>().volume = Random.Range(0.15f, 0.3f);
            GetComponent<AudioSource>().pitch = Random.Range(0.8f, 1.1f);
            GetComponent<AudioSource>().Play();
        }
        else if (cc.velocity.magnitude < 2f)
        {
            GetComponent<AudioSource>().Stop();
        }
    }



    /*void FixedUpdate ()	
 	{
		if(cc.isGrounded == true && cc.velocity.magnitude > 2f && GetComponent<AudioSource>().isPlaying == false)
		{
			GetComponent<AudioSource>().volume = Random.Range(0.8f, 1);
			GetComponent<AudioSource>().pitch = Random.Range(0.8f, 1.1f);
			GetComponent<AudioSource>().Play();
		}
	}*/
}
