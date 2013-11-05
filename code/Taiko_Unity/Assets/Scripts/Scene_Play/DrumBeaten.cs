using UnityEngine;
using System.Collections;

public class DrumBeaten : MonoBehaviour {
	
	public static int HitCount;
	
	public static bool beatenYellow;
	public static bool beatenRed;
	
	public static bool beatenHandled;//one beat
	
	public enum DrumType{
		init,
		Yellow,
		Red,
	}
	
	public DrumType drumType;
	
		
	// Use this for initialization
	void Start () {
		
		beatenYellow = false;
		beatenRed = false;
		beatenHandled = false;
	
	}
	
	// Update is called once per frame
	void Update () {
		
		if(beatenHandled)
		{
			beatenYellow = false;
			beatenRed = false;
			beatenHandled = false;
		}
	}
	
	void OnClick(){
		if(drumType == DrumType.Yellow){
			beatenYellow = true;
			Debug.Log("DrumBeaten_yellow");
		}
		else if(drumType == DrumType.Red){
			beatenRed = true;
			Debug.Log("DrumBeaten_red");
		}
		
		
	}
		
}
