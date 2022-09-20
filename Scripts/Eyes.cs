using System.Collections;

using System.Collections.Generic;

using UnityEngine;


public class Eyes : MonoBehaviour

{
    
	public GameObject gameOverCutscene;
	// Start is called before the first frame update
    
	void OnTriggerEnter(Collider other)
    
	{
        
    
		if(other.tag == "Player")
			gameOverCutscene.SetActive(true);
		
	}

    
}
