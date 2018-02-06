using UnityEngine;
using System.Collections;

public class InteractScript : MonoBehaviour {

	public float interactDistance = 5f;
    public GameObject PressE;

    public Transform target;
    public float distance;


       

    void Update () 
	{
        
        transform.position = new Vector3(target.position.x, 3, target.position.z);


        Ray ray = new Ray(transform.position, transform.forward);
			RaycastHit hit;

        
		
			
			if(Physics.Raycast(ray, out hit, interactDistance))
			{
				if(hit.collider.CompareTag("Door"))
				{
                     PressE.SetActive(true);
					DoorScript doorScript = hit.collider.transform.GetComponent<DoorScript>();
					if(doorScript == null) return;
                    if (Input.GetButtonDown("Opendoors"))
                        doorScript.ChangeDoorState();
                
            }
            else PressE.SetActive(false);







        }
	}
}
