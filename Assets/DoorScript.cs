using UnityEngine;
using System.Collections;

public class DoorScript : MonoBehaviour {

	public int index = -1;
	public bool open = false;
	public float doorOpenAngle = 90f; //Angle where the door is opened
	public float doorCloseAngle = 0f; //Start angle
	public float smooth = 2f;	//Speed/smooth of the rotation

	public void ChangeDoorState()
	{
		open = !open;
		GetComponent<AudioSource>().Play ();
	}

	void Update () 
	{
		if(open) //open == true
		{
			Quaternion targetRotation = Quaternion.Euler(0, doorOpenAngle, 0);
			transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, smooth * Time.deltaTime);
		}
		else
		{
			Quaternion targetRotation2 = Quaternion.Euler(0, doorCloseAngle, 0);
			transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation2, smooth * Time.deltaTime);
		}
	}
}
