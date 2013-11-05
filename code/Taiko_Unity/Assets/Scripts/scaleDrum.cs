using UnityEngine;
using System.Collections;

public class scaleDrum : MonoBehaviour {
public GameObject cursor;
	private float distanceX;
	private float distanceY;
	public AudioSource drum;
	public float volume = 1f;
	public float pitch = 1f;
	
	public enum DrumType{
		init,
		Yellow,
		Red,
	}
	public DrumType drumType;
	
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	if(sticks.leapIsEnabled)  
        { 
			cursor = GameObject.Find("stick");
			//Debug.Log("find stick in leapstate");
			leaphover();
			//Debug.LogError(pxsLeapInput.GetHandAxis("Vertical"));
		} else{
			cursor = GameObject.Find("stick");
			//Debug.Log("find stick in mousestate");
		}
	if(DrumBeaten.beatenHandled)
		{
			DrumBeaten.beatenYellow = false;
			DrumBeaten.beatenRed = false;
			DrumBeaten.beatenHandled = false;
		}
		
	}		

	void leaphover(){
		distanceX = Mathf.Abs(transform.position.x - pxsLeapInput.GetHandAxis("Horizontal")+0.1f) -0.2f;
		distanceY = Mathf.Abs(transform.position.y - pxsLeapInput.GetHandAxis("Depth")+ 0.1f)- 0.12f;
		
		if(distanceY <= 0.1f && distanceX <= 0.1f){
			//Debug.Log ("leap is hover");	
			transform.localScale = new Vector3(0.99f, 3.63f, 0);
			drum.Play();
			
			
			if(drumType == DrumType.Yellow){
				DrumBeaten.beatenYellow = true;
			}
			else if(drumType == DrumType.Red){
				DrumBeaten.beatenRed  = true;
			}
			
			
			
		}
		else{
			transform.localScale = new Vector3(0.9f, 3.3f, 0);
		}
	}
}
