using System.Collections;

using System.Collections.Generic;

using UnityEngine;


using UnityEngine.AI;
public class Player : MonoBehaviour
{
    

	//create a variable to hold our navmeshagent
	private NavMeshAgent _agent;
	private Animator _anim;

	private Vector3 _target;
	public GameObject coinPrefab;
	public AudioClip coinSoundEffect;
	private bool _coinTossed;
	// Start is called before the first frame update
    
	void Start()
    
	{
    
    
    	//handle to navmesh agent
		_agent = GetComponent<NavMeshAgent> ();
		_anim = GetComponentInChildren<Animator>();
	}

    
	// Update is called once per frame
    
	void Update()
    
	{
  
      
  //if left click
	if(Input.GetMouseButtonDown(0))
		{
			Ray rayOrigin = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hitInfo;

			if (Physics.Raycast(rayOrigin, out hitInfo))
			{
				Debug.Log("Hit : "+ hitInfo.point);
				_agent.SetDestination(hitInfo.point);
				_anim.SetBool("Walk",true);
				_target = hitInfo.point;
				//GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
				//cube.transform.position = hitInfo.point;
			}
		}

	float distance = Vector3.Distance(transform.position,_target);
	if(distance < 3f)
		_anim.SetBool("Walk",false);

	if(Input.GetMouseButtonDown(1) && _coinTossed==false)
	{
		Ray rayOrigin = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hitInfo;
		if (Physics.Raycast(rayOrigin, out hitInfo))
		{
			_anim.SetTrigger("Throw");
			_coinTossed = true;
			Instantiate(coinPrefab,hitInfo.point,Quaternion.identity);
			AudioSource.PlayClipAtPoint(coinSoundEffect,Camera.main.transform.position);
			SendAIToCoinSpot(hitInfo.point);
		}
	}
	
	//cast a ray from mouse position
	//debug the floor position hit
	//create object at floor position
	}

	void SendAIToCoinSpot (Vector3 coinPos){
		GameObject[] guards = GameObject.FindGameObjectsWithTag("Guard1");
		foreach(var guard in guards)
		{
			NavMeshAgent currentAgent = guard.GetComponent<NavMeshAgent> ();
			GuardAI currentGuard = guard.GetComponent<GuardAI> ();
			Animator currentAnim = guard.GetComponent<Animator>();
			currentGuard.coinTossed = true;
			currentAgent.SetDestination (coinPos);
			currentAgent.stoppingDistance = 4f;
			currentAnim.SetBool("Walk",true);
			currentGuard.coinPos = coinPos;
		}
	}


}
