using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class GameManager : MonoBehaviour {
	
	// make game manager public static so can access this from other scripts
	public static GameManager gm;
	
	// public variables
	public int score=0;
	
	public float startTime=0.0f;

	public Text mainTimerDisplay;
    public Text FlashChargeAmount;

    public GameObject gameOverScoreOutline;
	
	public AudioSource musicAudioSource;
	public bool gameIsOver = false;
	
	public GameObject playAgainButtons;
	public string playAgainLevelToLoad;
	
	public GameObject nextLevelButtons;
	public string nextLevelToLoad;

    public GameObject Ghoul;

    public AudioSource audio;
    public AudioClip Breathe;
    public AudioClip Whispering;
    public AudioClip Scream;
    public AudioClip iseeu;
    private bool issu = true;
 



    public float currentTime;
	
	// setup the game
	void Start () {
		
		// set the current time to the startTime specified
		currentTime = startTime;
		
		// get a reference to the GameManager component for use by other scripts
		if (gm == null) 
			gm = this.gameObject.GetComponent<GameManager>();
		
		// init scoreboard to 0


		
		// inactivate the playAgainButtons gameObject, if it is set
		if (playAgainButtons)
			playAgainButtons.SetActive (false);
		
		// inactivate the nextLevelButtons gameObject, if it is set
		if (nextLevelButtons)
			nextLevelButtons.SetActive (false);

        
        InvokeRepeating ("stressRate", 0, 15);
	}


    public void Collect(int amount)
    {
        currentTime -= 15;
        mainTimerDisplay.text = currentTime.ToString("0");
    }
        void stressRate()

	{
		mainTimerDisplay.text = currentTime.ToString ("0");
		currentTime += 1;
	}
	


void Update () 
	{

		
		if (!gameIsOver) 
		{

		}

			 if (currentTime >= 101.0f) 
			{ // check to see if timer has run out
				EndGame ();
			}
             if (currentTime > 100.0f)
             { // check to see if timer has run out
            currentTime = 100;
             }
       

        if (currentTime > 20.0f && GetComponent<AudioSource>().isPlaying == false)
		{
            audio.clip = Breathe;
            audio.priority = 5;
            audio.Play();

        }

        if (currentTime > 40.0f && issu == true)
        {
            Ghoul.SetActive(true);
            audio.priority = 10;
            audio.PlayOneShot(iseeu , 0.3f);
            issu = false;

        }

       /* if (currentTime > 100.0f && issu1 == true)
        {
            Ghoul.SetActive(true);
            audio.priority = 30;
            audio.clip = Scream;
            audio.Play();
            issu1 = false;

        }*/




    }	

	
	void EndGame() {
		// game is over
		gameIsOver = true;

		


		if (playAgainButtons)
			playAgainButtons.SetActive (true);


		if (musicAudioSource)
			musicAudioSource.pitch = 0.5f; // slow down the music
	}
	
	public void BeatLevel() {
	
		gameIsOver = true;
		
		
		
		
		
		// activate the nextLevelButtons gameObject, if it is set 
		if (nextLevelButtons)
			nextLevelButtons.SetActive (true);

		
		
		// reduce the pitch of the background music, if it is set 
		if (musicAudioSource)
			musicAudioSource.pitch = 0.5f; // slow down the music
	}
    /*
	
	public void AddShot()
	{
		shotsFired++;
	}
	
	// public function that can be called to update the score or time
	public void targetHit (int scoreAmount, float timeAmount)
	{

		// increase the score by the scoreAmount and update the text UI
		score += scoreAmount;
		
		// increase the time by the timeAmount
		currentTime += timeAmount;
		hits++;
		// don't let it go negative
		if (currentTime < 0)
			currentTime = 0.0f;
		
		// update the text UI
		mainTimerDisplay.text = currentTime.ToString ("0.00");
	}



*/


    // public function that can be called to restart the game
    public void RestartGame ()
	{
		// we are just loading a scene (or reloading this scene)
		// which is an easy way to restart the level
		Application.LoadLevel (playAgainLevelToLoad);
	}
	
	// public function that can be called to go to the next level of the game
	public void NextLevel ()
	{
		// we are just loading the specified next level (scene)
		Application.LoadLevel (nextLevelToLoad);
	}
	
	
}
