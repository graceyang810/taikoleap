using UnityEngine;
using System.Collections;

public class Result_LoadScene : MonoBehaviour {

	public string levelName;
	
	void Start()
	{
		
	}
	
	void Update()
	{
		if(Input.GetMouseButtonDown(0))
		{			
			Application.LoadLevel(levelName);
			ResultData.clearData();
			DrumBeaten.HitCount = 0;
		}
		
	}
}
