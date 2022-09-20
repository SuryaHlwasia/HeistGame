using System.Collections;

using System.Collections.Generic;

using UnityEngine;


public class SecurityCameras : MonoBehaviour

{
    	
	public GameObject gameOverCutscene;
	public Animator anim;
	void OnTriggerEnter(Collider other)
	{
		if(other.tag=="Player")
		{
			MeshRenderer render = GetComponent<MeshRenderer> ();
			Color color = new Color(0.6f,0.11f,0.11f,0.1f);
			render.material.SetColor("_TintColor",color);
			anim.enabled = false;
			StartCoroutine(AlertRoutine());
			
		}	
	}
	IEnumerator AlertRoutine(){
	yield return new WaitForSeconds(0.5f);
	gameOverCutscene.SetActive(true);
	}



}
