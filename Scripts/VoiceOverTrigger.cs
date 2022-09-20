using System.Collections;

using System.Collections.Generic;

using UnityEngine;


public class VoiceOverTrigger : MonoBehaviour

{
   
	public AudioClip clipToPlay;
	private bool isTriggered;
	void OnTriggerEnter(Collider other)
	{
		if(other.tag=="Player" && !isTriggered){
				AudioManager.Instance.PlayVoiceOver(clipToPlay);
				isTriggered = true;
		}
	}  


}
