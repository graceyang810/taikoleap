using UnityEngine;
using System.Collections;

public class jumpLevel_about : MonoBehaviour {
	public int	time = 0;
	public string levelName;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		time++;
		if(time > 100){		
			Application.LoadLevel(levelName);
			jumpLevel.currentX = pxsLeapInput.GetHandAxis("Horizontal")*1.8f;
			jumpLevel.currentY = pxsLeapInput.GetHandAxis("Depth");
			}
		}
	}