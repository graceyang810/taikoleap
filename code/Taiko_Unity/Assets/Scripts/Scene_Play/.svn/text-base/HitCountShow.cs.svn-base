using UnityEngine;
using System.Collections;

public class HitCountShow : MonoBehaviour {
	
	private int hit_Units;
	private int hit_Decades;
	
	private UISprite sp_units;
	private UISprite sp_decades;
	private UISprite sp_hit_hits;
	
	// Use this for initialization
	void Start () {
		
		sp_units = GameObject.Find("Sprite_unit").GetComponent<UISprite>();
		sp_decades = GameObject.Find("Sprite_decade").GetComponent<UISprite>();
		sp_hit_hits = GameObject.Find("Sprite_hit_hits").GetComponent<UISprite>();
	//	sp_decades.renderer = false;
		
	
	}
	
	// Update is called once per frame
	void Update () {
		
		
		if(DrumBeaten.HitCount != 0)
			sp_hit_hits.spriteName = "hits";
		else
			sp_hit_hits.spriteName = "hit";
		
		hit_Units = DrumBeaten.HitCount % 10;
		hit_Decades = (DrumBeaten.HitCount % 100 - hit_Units) / 10;
		
		
		sp_units.spriteName = DEFINE_NumberString.number[hit_Units];
//		if(hit_Decades == 0)
//			sp_decades.spriteName = "empty";
//		else
			sp_decades.spriteName = DEFINE_NumberString.number[hit_Decades];
	
	}
}
