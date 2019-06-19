using UnityEngine;
using UnityEngine.SceneManagement;
//18 Errors
public class MainMenu1 : MonoBehaviour 
{	
	public bool loadScreen,playOptions, loadOptions, options, brightness, resolution, controls;
    public new bool audio;
	public GUIStyle logoTitleStyle;
    public float audioSlider, brightnessSlider;
	public bool res1,res2,res3,res4,res5,res6,res7,res8,fullScreen,windowed;
	public KeyCode forward,backward,right,left,jump,sprint,crouch;
	public KeyCode holdingKey;
	public AudioSource audi;
	void Start () 
	{
		loadScreen = true;
		res5 = true;
		fullScreen = true;
		forward = KeyCode.W;
		backward = KeyCode.S;
        left = KeyCode.A;
		right = KeyCode.D;
		jump = KeyCode.Space;
		sprint = KeyCode.LeftShift;
		crouch = KeyCode.LeftControl;
		audi = GameObject.Find("Audio").GetComponent<AudioSource>();
		audioSlider = audi.volume;
		brightnessSlider = RenderSettings.ambientIntensity;
	}
	
	void Update ()
	{
		if(loadScreen)	
		{			
			if(Input.anyKey)
			{
				Debug.Log("A key or mouse click has been detected");
				loadScreen = false;
			}
		}
		
		if(options)
		{
			audi.volume = audioSlider;
			RenderSettings.ambientIntensity = brightnessSlider;
		}		
	}	
	
	void OnGUI()
	{
		float scrW = Screen.width/16;
		float scrH = Screen.height/9;
        if (loadScreen)
		{			
			GUI.Box(new Rect(0,0,Screen.width,Screen.height),"");
            GUI.Box(new Rect(2 * scrW, 0.5f * scrH, 12 * scrW, 3 * scrH), "Logo / Title");
			GUI.Box(new Rect(4*scrW,4.5f*scrH,8*scrW,1*scrH),"Press AnyKey");
		}

        if (!loadScreen)
        {
            if (!(playOptions || options))
            {
                GUI.Box(new Rect(0, 0, Screen.width, Screen.height), "");
                GUI.Box(new Rect(2 * scrW, 0.5f * scrH, 12 * scrW, 3 * scrH), "Logo / Title");

                if (GUI.Button(new Rect(4 * scrW, 4.5f * scrH, 8 * scrW, 1 * scrH), "Play"))
                {
                    playOptions = true;
                }

                if (GUI.Button(new Rect(4 * scrW, 5.5f * scrH, 8 * scrW, 1 * scrH), "Options"))
                {
                    options = true;
                }
                if (GUI.Button(new Rect(4 * scrW, 6.5f * scrH, 8 * scrW, 1 * scrH), "Exit"))
                {
                    SceneManager.LoadScene(1);
                    Application.Quit();
                    Debug.Log("Exit was pressed");
                }
            }

            if (playOptions && !loadOptions)
            {
                GUI.Box(new Rect(0, 0, Screen.width, Screen.height), "");

                GUI.Box(new Rect(2 * scrW, 0.5f * scrH, 12 * scrW, 3 * scrH), "Logo / Title");

                if (GUI.Button(new Rect(4 * scrW, 4.5f * scrH, 8 * scrW, 1 * scrH), "New Game"))
                {
                    SceneManager.LoadScene(1);
                }

                if (GUI.Button(new Rect(4 * scrW, 6.5f * scrH, 8 * scrW, 1 * scrH), "Back"))
                {
                    playOptions = false;
                }

                if (PlayerPrefs.HasKey("SavedGame"))
                {
                    if (GUI.Button(new Rect(4 * scrW, 3.5f * scrH, 8 * scrW, 1 * scrH), "Continue"))
                    {
                        string curCharacterSave = PlayerPrefs.GetString("LastCharacter");
                        int level = PlayerPrefs.GetInt(curCharacterSave + "levelNo");
                        SceneManager.LoadScene(level);
                    }
                    if (GUI.Button(new Rect(4 * scrW, 5.5f * scrH, 8 * scrW, 1 * scrH), "Load"))
                    {
                        loadOptions = true;
                    }
                }

                if (loadOptions)
                {
                    GUI.Box(new Rect(0, 0, Screen.width, Screen.height), "");
                    GUI.Box(new Rect(2 * scrW, 0.5f * scrH, 12 * scrW, 3 * scrH), "Logo / Title");

                    int saveAmount = 4;
                    string[] savedGameName = new string[saveAmount];

                    for (int i = 0; i < saveAmount; i++)
                    {
                        savedGameName[i] = PlayerPrefs.GetString("Character_" + i.ToString());
                        if (GUI.Button(new Rect(4 * scrW, 4.5f * scrH + (i * (1 * scrH)), 8 * scrW, 1 * scrH), savedGameName[i]))
                        {
                            int level = PlayerPrefs.GetInt(savedGameName[i] + "levelNo");
                            SceneManager.LoadScene(level);
                        }
                    }
                    if (GUI.Button(new Rect(4 * scrW, 6.5f * scrH, 8 * scrW, 1 * scrH), "Back"))
                    {
                        loadOptions = false;
                    }
                }
            }
        }
			
			if(options)	
			{
                GUI.Box(new Rect(0,0,Screen.width,Screen.height),"");
				GUI.Box(new Rect(0.25f*scrW,0.25f*scrH,7.625f*scrW,8.5f*scrH),"");
				GUI.Box(new Rect(8.125f*scrW,0.25f*scrH,7.625f*scrW,8.5f*scrH),"");
				GUI.Box(new Rect(0.5f*scrW,0.5f*scrH,7.125f*scrW,1f*scrH),"Audio");
				audioSlider = GUI.HorizontalSlider(new Rect(0.5f*scrW,1f*scrH,7.125f*scrW,0.25f*scrH), audioSlider, 0.0F, 1.0F);
				GUI.Label(new Rect(4f*scrW,1.125f*scrH,0.75f*scrW,0.25f*scrH),Mathf.FloorToInt(audioSlider*100).ToString());			
				GUI.Box(new Rect(0.5f*scrW,1.5f*scrH,7.125f*scrW,1f*scrH),"Brightness");
				brightnessSlider = GUI.HorizontalSlider(new Rect(0.5f*scrW,2f*scrH,7.125f*scrW,0.25f*scrH), brightnessSlider, 0.0F, 1.0F);		
				GUI.Label(new Rect(4f*scrW,2.125f*scrH,0.75f*scrW,0.25f*scrH),Mathf.FloorToInt(brightnessSlider*100).ToString());
				GUI.Box(new Rect(0.5f*scrW,2.5f*scrH,7.125f*scrW,6f*scrH),"Resolutions");
				
				#region Resolution types
				if(GUI.Toggle(new Rect(1.5f*scrW,3.5f*scrH,2f*scrW,0.5f*scrH), res1, "1024 x 576"))
				{					
					Screen.SetResolution(1024, 576,fullScreen);
					res1 = true;
					res2 = false;					
					res3 = false;					
					res4 = false;					
					res5 = false;					
					res6 = false;					
					res7 = false;					
					res8 = false;					
				}				
				if(GUI.Toggle(new Rect(1.5f*scrW,4f*scrH,2f*scrW,0.5f*scrH), res2, "1152 x 648"))
				{					
					Screen.SetResolution(1152, 648,fullScreen);
					res2 = true;
					res1 = false;					
					res3 = false;					
					res4 = false;					
					res5 = false;					
					res6 = false;					
					res7 = false;					
					res8 = false;					
				}				
				if(GUI.Toggle(new Rect(1.5f*scrW,4.5f*scrH,2*scrW,0.5f*scrH), res3, "1280 x 720"))
				{					
					Screen.SetResolution(1280, 720,fullScreen);
					res3 = true;
					res1 = false;					
					res2 = false;					
					res4 = false;					
					res5 = false;					
					res6 = false;					
					res7 = false;					
					res8 = false;					
				}
				if(GUI.Toggle(new Rect(1.5f*scrW,5f*scrH,2f*scrW,0.5f*scrH), res4, "1366 x 768"))
				{					
					Screen.SetResolution(1366, 768,fullScreen);
					res4 = true;
					res1 = false;					
					res2 = false;					
					res3 = false;					
					res5 = false;					
					res6 = false;					
					res7 = false;					
					res8 = false;					
				}				
				if(GUI.Toggle(new Rect(1.5f*scrW,5.5f*scrH,2f*scrW,0.5f*scrH), res5, "1600 x 900"))
				{
					Screen.SetResolution(1600, 900,fullScreen);
					res5 = true;
					res1 = false;					
					res2 = false;					
					res3 = false;					
					res4 = false;					
					res6 = false;					
					res7 = false;					
					res8 = false;					
				}
				if(GUI.Toggle(new Rect(1.5f*scrW,6f*scrH,2*scrW,0.5f*scrH), res6, "1920 x 1080"))
				{
					Screen.SetResolution(1920, 1080,fullScreen);
					res6 = true;
					res1 = false;					
					res2 = false;					
					res3 = false;					
					res4 = false;					
					res5 = false;					
					res7 = false;					
					res8 = false;					
				}				
				if(GUI.Toggle(new Rect(1.5f*scrW,6.5f*scrH,2f*scrW,0.5f*scrH), res7, "2560 x 1440"))
				{					
					Screen.SetResolution(2560, 1440,fullScreen);
					res7 = true;
					res1 = false;					
					res2 = false;					
					res3 = false;					
					res4 = false;					
					res5 = false;					
					res6 = false;					
					res8 = false;					
				}				
				if(GUI.Toggle(new Rect(1.5f*scrW,7f*scrH,2f*scrW,0.5f*scrH), res8, "3840 x 2160"))
				{					
					Screen.SetResolution(3840, 2160,fullScreen);
					res8 = true;
					res1 = false;					
					res2 = false;					
					res3 = false;					
					res4 = false;					
					res5 = false;					
					res6 = false;					
					res7 = false;					
				}				
				#endregion
	
				if(GUI.Toggle(new Rect(5.5f*scrW,4.5f*scrH,2*scrW,0.5f*scrH), fullScreen, "FullScreen")) 
				{
					Screen.fullScreen = true;
					fullScreen = true;
					windowed = false;
				}
				
				if(GUI.Toggle(new Rect(5.5f*scrW,6f*scrH,2*scrW,0.5f*scrH), windowed, "Windowed"))
				{					
					Screen.fullScreen = false;
					fullScreen = false;
					windowed = true;
				}
				
				GUI.Box(new Rect(8.4f*scrW,0.5f*scrH,7.125f*scrW,8f*scrH),"Controls");
				
				Event e = Event.current;
								
				#region GUI BUTTONS FOR CONTROL CHANGE				
				if(!(backward == KeyCode.None || left == KeyCode.None || right == KeyCode.None || jump == KeyCode.None || crouch == KeyCode.None || sprint == KeyCode.None))
				{
					if(GUI.Button(new Rect(14f*scrW,1f*scrH,1f*scrW,1f*scrH),forward.ToString()))
                    {
						holdingKey = forward;
						forward = KeyCode.None;
					}					
				}				
				else					
				{					
					GUI.Box(new Rect(14f*scrW,1f*scrH,1f*scrW,1f*scrH),forward.ToString());
				}
                
				if(!(forward == KeyCode.None || left == KeyCode.None || right == KeyCode.None || jump == KeyCode.None || crouch == KeyCode.None || sprint == KeyCode.None))	
				{
					
					if(GUI.Button(new Rect(14f*scrW,2f*scrH,1f*scrW,1f*scrH),backward.ToString()))
					{						
						holdingKey = backward;
						backward = KeyCode.None;
					}					
				}				
				else					
				{					
					GUI.Box(new Rect(14f*scrW,2f*scrH,1f*scrW,1f*scrH),backward.ToString());
				} 
			
				if(!(forward == KeyCode.None || backward == KeyCode.None || right == KeyCode.None || jump == KeyCode.None || crouch == KeyCode.None || sprint == KeyCode.None))	
				{
					
					if(GUI.Button(new Rect(14f*scrW,3f*scrH,1f*scrW,1f*scrH),left.ToString()))	
					{						
						holdingKey = left;
						left = KeyCode.None;
					}					
				}				
				else					
				{					
					GUI.Box(new Rect(14f*scrW,3f*scrH,1f*scrW,1f*scrH),left.ToString());
				}

				if(!(forward == KeyCode.None || left == KeyCode.None || backward == KeyCode.None || jump == KeyCode.None || crouch == KeyCode.None || sprint == KeyCode.None))
				{					
					if(GUI.Button(new Rect(14f*scrW,4f*scrH,1f*scrW,1f*scrH),right.ToString()))						
					{						
						holdingKey = right;
						right = KeyCode.None;
					}					
				}				
				else					
				{					
					GUI.Box(new Rect(14f*scrW,4f*scrH,1f*scrW,1f*scrH),right.ToString());
				}
				
				if(!(forward == KeyCode.None || left == KeyCode.None || right == KeyCode.None || backward == KeyCode.None || crouch == KeyCode.None || sprint == KeyCode.None))
				{					
					if(GUI.Button(new Rect(14f*scrW,5f*scrH,1f*scrW,1f*scrH),jump.ToString()))
                    {						
						holdingKey = jump;
						jump = KeyCode.None;
					}					
				}				
				else					
				{					
					GUI.Box(new Rect(14f*scrW,5f*scrH,1f*scrW,1f*scrH),jump.ToString());
				}
				
				if(!(forward == KeyCode.None || left == KeyCode.None || right == KeyCode.None || jump == KeyCode.None || crouch == KeyCode.None || backward == KeyCode.None))
				{					
					if(GUI.Button(new Rect(14f*scrW,6f*scrH,1f*scrW,1f*scrH),sprint.ToString()))	
					{						
						holdingKey = sprint;
						sprint = KeyCode.None;
					}					
				}				
				else					
				{					
					GUI.Box(new Rect(14f*scrW,6f*scrH,1f*scrW,01f*scrH),sprint.ToString());					
				}
								
				if(!(forward == KeyCode.None || left == KeyCode.None || right == KeyCode.None || jump == KeyCode.None || backward == KeyCode.None || sprint == KeyCode.None))
			    {					
					if(GUI.Button(new Rect(14f*scrW,7f*scrH,1f*scrW,1f*scrH),crouch.ToString()))	
					{						
						holdingKey = crouch;
						crouch = KeyCode.None;
					}					
				}				
				else					
				{					
					GUI.Box(new Rect(14f*scrW,7f*scrH,1f*scrW,1f*scrH),crouch.ToString());
				}				
				#endregion	
				#region Key Change				
				if(forward == KeyCode.None)	
				{					
					if (e.isKey)
                    {						
						Debug.Log("Detected key code: " + e.keyCode);
						if(!(e.keyCode == backward || e.keyCode == left || e.keyCode == right || e.keyCode == jump ||e.keyCode == sprint || e.keyCode == crouch))
						{							
							forward = e.keyCode;							
							holdingKey = KeyCode.None;							
						}						
						else 							
						{							
							forward = holdingKey;
							holdingKey = KeyCode.None;
						}						
					}					
				}				
				if(backward == KeyCode.None)					
				{					
					if (e.isKey)						
					{						
						Debug.Log("Detected key code: " + e.keyCode);						
						if(!(e.keyCode == forward || e.keyCode == left || e.keyCode == right || e.keyCode == jump ||e.keyCode == sprint || e.keyCode == crouch))
						{							
							backward = e.keyCode;							
							holdingKey = KeyCode.None;							
						}						
						else							
						{							
							backward = holdingKey;
							holdingKey = KeyCode.None;
						}						
					}					
				}				
				if(left == KeyCode.None)
				{					
					if (e.isKey)
					{						
						Debug.Log("Detected key code: " + e.keyCode);
						if(!(e.keyCode == forward || e.keyCode == backward || e.keyCode == right || e.keyCode == jump ||e.keyCode == sprint || e.keyCode == crouch))
						{							
							left = e.keyCode;
							holdingKey = KeyCode.None;
						}						
						else
						{							
							left = holdingKey;
							holdingKey = KeyCode.None;
						}		
					}
				}				
				if(right == KeyCode.None)
				{
					if (e.isKey)
					{						
						Debug.Log("Detected key code: " + e.keyCode);
						if(!(e.keyCode == forward || e.keyCode == backward || e.keyCode == left || e.keyCode == jump ||e.keyCode == sprint || e.keyCode == crouch))
						{							
							right = e.keyCode;
							holdingKey = KeyCode.None;
						}
						else
						{							
							right = holdingKey;
							holdingKey = KeyCode.None;
						}						
					}					
				}				
				if(jump == KeyCode.None)
				{				
					if (e.isKey)
					{						
						Debug.Log("Detected key code: " + e.keyCode);
						if(!(e.keyCode == forward || e.keyCode == backward || e.keyCode == left || e.keyCode == sprint ||e.keyCode == right || e.keyCode == crouch))
						{							
							jump = e.keyCode;
							holdingKey = KeyCode.None;
						}
						else
						{							
							jump = holdingKey;
							holdingKey = KeyCode.None;
						}						
					}					
				}				
				if(sprint == KeyCode.None)
				{					
					if (e.isKey)
					{						
						Debug.Log("Detected key code: " + e.keyCode);
						if(!(e.keyCode == forward || e.keyCode == backward || e.keyCode == left || e.keyCode == jump ||e.keyCode == right || e.keyCode == crouch))
						{							
							sprint = e.keyCode;
							holdingKey = KeyCode.None;
						}						
						else
						{							
							sprint = holdingKey;
							holdingKey = KeyCode.None;		
						}
					}
				}				
				if(crouch == KeyCode.None)
				{
					if (e.isKey)
					{
						Debug.Log("Detected key code: " + e.keyCode);
						if(!(e.keyCode == forward || e.keyCode == backward || e.keyCode == left || e.keyCode == jump ||e.keyCode == right || e.keyCode == sprint))
						{							
							crouch = e.keyCode;
							holdingKey = KeyCode.None;
						}						
						else
						{
							crouch = holdingKey;
							holdingKey = KeyCode.None;
						}						
					}					
				}				
				#endregion				

				GUI.Box(new Rect(8.75f*scrW,1f*scrH,6.25f*scrW,1f*scrH),"Forward");
				GUI.Box(new Rect(8.75f*scrW,2f*scrH,6.25f*scrW,1f*scrH),"Backward");
				GUI.Box(new Rect(8.75f*scrW,3f*scrH,6.25f*scrW,1f*scrH),"Left");
				GUI.Box(new Rect(8.75f*scrW,4f*scrH,6.25f*scrW,1f*scrH),"Right");
				GUI.Box(new Rect(8.75f*scrW,5f*scrH,6.25f*scrW,1f*scrH),"Jump");
    			GUI.Box(new Rect(8.75f*scrW,6f*scrH,6.25f*scrW,1f*scrH),"Sprint");
                GUI.Box(new Rect(8.75f * scrW, 7f * scrH, 6.25f * scrW, 1f * scrH), "Crouch");

                if (!(forward == KeyCode.None  || backward == KeyCode.None || left == KeyCode.None || right == KeyCode.None || jump == KeyCode.None || crouch == KeyCode.None || sprint == KeyCode.None))
				{					
					if(GUI.Button(new Rect(12.5f*scrW,8f*scrH,3*scrW,0.5f*scrH),"Back"))
					{						
						options = false;						
					}					
				}				
			}			
    }		
}	