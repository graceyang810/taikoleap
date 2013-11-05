using UnityEngine;
using System.Collections;

public class AutoLoadMenuScene : MonoBehaviour
{
	public string levelName;
	public int timer;
	private int timeReal;
	void Start()
	{
//<<<<<<< .mine
		timeReal=timer;
//=======
		//timer=10;
//>>>>>>> .r36
		//print("start");
	}
	void Update()
	{
		//print(timer);
		timeReal--;
		if(timeReal==0)
			Application.LoadLevel(levelName);	
	}
}