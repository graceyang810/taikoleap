using UnityEngine;
using System.Collections;

public class Result_returnScene : MonoBehaviour {

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
		}
		
	}
}
