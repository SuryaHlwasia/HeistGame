﻿using System.Collections;

using System.Collections.Generic;

using UnityEngine;


public class WInStateActivation : MonoBehaviour

{
            
 
	public GameObject winCutscene;

	{
		if(other.tag == "Player")
		{
			if(GameManager.Instance.HasCard)
				winCutscene.SetActive(true);
			else
				Debug.Log("You must grab the key card");
		}
	}
				



}