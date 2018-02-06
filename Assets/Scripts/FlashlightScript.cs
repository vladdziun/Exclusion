using UnityEngine;
using System.Collections;

public class FlashlightScript : MonoBehaviour {

    public float Charge;

    private Light Flashlight;
    

	void Start()
	{
	
		Flashlight = GetComponent<Light>();
        InvokeRepeating("FlashCharge", 0, 2);
    }

    void FlashCharge()
    {
        if (Flashlight.enabled)
        {
            GameManager.gm.FlashChargeAmount.text = Charge.ToString("0") + "%";
            Charge -= 5;
        }
        else if (!Flashlight.enabled)
        {
            GameManager.gm.FlashChargeAmount.text = Charge.ToString("0") + "%";
            Charge += 3;
        }

    }

	void Update () 
	{
	
		if (Input.GetButtonDown("Light"))
		{
			Flashlight.enabled = !Flashlight.enabled;
            GetComponent<AudioSource>().Play(); 

        }

      


        if (Charge < 0)
        { 
            Flashlight.enabled = false;
        Charge = 0.0f;
        }

        if (Charge > 100)
        {
            Flashlight.enabled = false;
            Charge = 100.0f;
        }
    }

}