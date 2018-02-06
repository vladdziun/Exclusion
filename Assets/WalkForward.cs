using UnityEngine;
using System.Collections;

public class WalkForward : MonoBehaviour {

	public float timer;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
      
            
         transform.position += transform.forward * 2 * Time.deltaTime;
        timer -= Time.deltaTime;
        if (timer <= 0)
            Destroy(gameObject);
    }
}
