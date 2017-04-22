﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelectScript : MonoBehaviour {

	private int worldIndex;   
	private int levelIndex;   

	void Start()
	{
		// loop thorugh each world
		for(int i = 1; i <= LockLevel.worlds; i++) 
		{
			if(SceneManager.GetActiveScene().name == "World" + i) 
			{
				worldIndex = i;
				CheckLockedLevels(); 
			}
		}
	}

	// Level to load on button click. Will be used for Level button click event 
	public void Selectlevel(string worldLevel) 
	{
		SceneManager.LoadScene("Level" + worldLevel); //load the level
	}

	// check for the levels locked
	void CheckLockedLevels ()
	{
		// loop through the levels of a particular world
		for(int j = 1; j < LockLevel.levels; j++) 
		{
			levelIndex = (j+1);
			if((PlayerPrefs.GetInt("level" + worldIndex.ToString() + ":" + levelIndex.ToString())) == 1)
			{
				GameObject.Find("LockedLevel"+(j + 1)).SetActive(false);
				Debug.Log ("Unlocked");
			}
		}
	}
}