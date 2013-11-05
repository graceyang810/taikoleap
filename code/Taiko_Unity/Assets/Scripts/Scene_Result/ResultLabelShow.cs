using UnityEngine;
using System.Collections;

public class ResultLabelShow : MonoBehaviour {
	
	public enum ResultItem {
		Perfect,
		Cool,
		Miss,
		MaxCombo,
		Score,
		Rating,
	}
	
	public ResultItem resultItem;
	
	private UILabel label;
	
	// Use this for initialization
	void Start () {
		
		label = gameObject.GetComponent<UILabel>();
		
	}
	
	// Update is called once per frame
	void Update () {
		
		switch(resultItem) {
		case ResultItem.Perfect:
			label.text = ResultData.Count_Perfect.ToString();
			break;
		case ResultItem.Cool:
			label.text = ResultData.Count_Cool.ToString();
			break;
		case ResultItem.Miss:
			label.text = ResultData.Count_Miss.ToString();
			break;
		case ResultItem.MaxCombo:
			if(DrumBeaten.HitCount > ResultData.MaxCombo)
				ResultData.MaxCombo = DrumBeaten.HitCount;
			label.text = ResultData.MaxCombo.ToString();
			break;
		case ResultItem.Score:
			ResultData.getScore();
			label.text = ResultData.Score.ToString();
			break;
		case ResultItem.Rating:
			ResultData.getRating();
			label.text = ResultData.Rating.ToString();
			break;
		default:
			break;
			
		}
	
	}
}
