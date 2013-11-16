using UnityEngine;
using System.Collections;

public class Interviewee_Emotion : MonoBehaviour 
{

	//public static string sIntervieweeName;
	public Material Happy;
	public Material Neutral;
	public Material Sad;

	public int mood;

	void Start () 
	{
		//mood = 0;
	}
	//Will need info on option selected and if it has made the interviewee
	//Angry, Happy, Sad
	void Update () 
	{
		if(mood == 0) renderer.material = Happy;
		else if(mood == 1) renderer.material = Neutral;
		else if(mood == 2) renderer.material = Sad;
	}

	public void setMood(int moodID)
	{
		mood = moodID;
	}
}
