using UnityEngine;
using System.Collections;

public class Player_Interview : MonoBehaviour 
{
	public static string sIntervieweeName;
	private bool bEndOfInterview;
	
	private GameObject goIntervieweeFace;
	private GameObject goClipboard;

	//private GUITexture GUI_IntervieweeFace;
	//private GUITexture GUI_Clipboard;

	private bool bFaceLoaded;
	private bool bClipLoaded;

	private Interviewee_Emotion script;
	
	void Start () 
	{
		bEndOfInterview = false;
		bFaceLoaded = false;
		bClipLoaded = false;
	}
	
	void Update () 
	{
		if(characterController.bInterviewing)
		{
			//Load up face picture
			//Load up notepad
			//Load up text options from .XML (Inerviewee's)
			//Save choices to "PLAYER-NAME".XML (Create file if non-exists already)
			//
			LoadIntervieweeFace();
			LoadClipBoard();
			FacialExpressions();
			if(bEndOfInterview)
			{
				characterController.bInterviewing = false;
				bEndOfInterview = false;
				
				bFaceLoaded = false;
				bClipLoaded = false;
				
				Destroy(goIntervieweeFace);
				Destroy(goClipboard);
			}
			//bEndOfInterview = true;
		}
	}
	
	private void LoadIntervieweeFace()
	{
		//May add a little darkness to it for effects
		//print("Loading_FACE");
		
		if(!bFaceLoaded)
		{
			//print(sIntervieweeName + "_Face");
			bFaceLoaded = true;
			goIntervieweeFace = Instantiate(Resources.Load(sIntervieweeName + "_Face")) as GameObject;
			//Instantiate(Resources.Load(sIntervieweeName + "_Face"));
			//goIntervieweeFace.transform.Translate(this.transform.position.x, this.transform.position.y, this.transform.position.z, Space.World);
		}	
	}
	
	private void LoadClipBoard()
	{
		if(!bClipLoaded)
		{
			//print ("Loading Clipboard");
			bClipLoaded = true;
			goClipboard = Instantiate(Resources.Load ("Clipboard")) as GameObject;
			//goClipboard.transform.Translate(this.transform.position.x, this.transform.position.y, this.transform.position.z, Space.World);
		}
	}

	private void FacialExpressions()
	{
		script = (Interviewee_Emotion) goIntervieweeFace.GetComponent(typeof(Interviewee_Emotion));
		if(SceneManager.iOption == 3) 
		{
			bEndOfInterview = true;
			SceneManager.iOption = -1;
		}
		else if(SceneManager.iOption >= 0 && SceneManager.iOption <=3) script.setMood(SceneManager.iOption);
	
		print(sIntervieweeName);
	}
}
