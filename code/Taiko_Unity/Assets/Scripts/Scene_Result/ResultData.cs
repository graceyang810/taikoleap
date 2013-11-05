using UnityEngine;
using System.Collections;

public class ResultData : MonoBehaviour {
	
	public static int Count_Perfect = 0;
	public static int Count_Cool = 0;
	public static int Count_Miss = 0;
	public static int MaxCombo = 0;
	public static int Score = 0;
	public static int Rating = 0;
	
	public static int value_Perfect = 10;
	public static int value_Cool = 5;
	public static int value_Miss = -2;
	public static int value_unit_MaxCombo = 1;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public static void getScore() {
		Score = (Count_Perfect * value_Perfect) + 
				(Count_Cool * value_Cool) +
				(Count_Miss * value_Miss) +
				(MaxCombo * value_unit_MaxCombo);
	}
	
	public static void getRating() {
		
	}
	
	public static void clearData() {
		Count_Perfect = 0;
		Count_Cool = 0;
		Count_Miss = 0;
		MaxCombo = 0;
		Score = 0;
		Rating = 0;
		
		DrumBeaten.HitCount = 0;
	}
}
