using UnityEngine;
using System.Collections;
public class ReturnMenuScene : MonoBehaviour
{
	

	public string levelName;
	public AudioSource s1;
	public float volume = 1f;
	public float pitch = 1f;
	public int isDo=0;
	
	void Update(){

		if(Input.GetMouseButtonDown(0))
		{	
			play();
			isDo++;			
		}
		if(!s1.isPlaying && isDo>0)
				Application.LoadLevel(levelName);
		 
	}
	void play(){
		if(isDo==0)
		{
			s1.Play();
			
		}
	}
	
	
	
}