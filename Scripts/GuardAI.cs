using System.Collections;

using System.Collections.Generic;

using UnityEngine;


using UnityEngine.AI;

public class GuardAI : MonoBehaviour

{

	public List<Transform> wayPoints;
	private NavMeshAgent _agent;
	[SerializeField]
	private int currentTarget;
	private bool reverse;
	private bool _targetReached;
	private Animator _anim;
	public bool coinTossed;
	public Vector3 coinPos;
	// Start is called before the first frame update
 
	void Start()
    
	{
        
    
		_agent = GetComponent<NavMeshAgent> ();
		_anim = GetComponent<Animator> ();
		
	}

    
	// Update is called once per frame
    
	void Update()
    
	{
        
    
		if(wayPoints.Count > 0 && wayPoints[currentTarget]!=null && coinTossed == false)
		{
			_agent.SetDestination(wayPoints[currentTarget].position);
			float distance = Vector3.Distance(transform.position,wayPoints[currentTarget].position);

			if(distance<1 && (currentTarget==0 || currentTarget==wayPoints.Count-1))
				_anim.SetBool ("Walk",false);
			else
				_anim.SetBool ("Walk",true);
			if(distance < 1.0f && _targetReached == false)
			{	
				if (wayPoints.Count < 2)
					return;
				if((currentTarget == 0 || currentTarget==wayPoints.Count-1))
				{
					_targetReached = true;
					StartCoroutine(WaitBeforeMoving());	
				}
				else
				{
					if(reverse)
					{
						currentTarget--;
						if(currentTarget<=0)
						{
							currentTarget = 0;
							reverse = false;
						}
					}
					else
						currentTarget++;
				}			
			}
			
		}
		else
		{
			float distance = Vector3.Distance(transform.position,coinPos);
			if(distance < 4f)
				_anim.SetBool("Walk",false);
		}		
	}

	IEnumerator WaitBeforeMoving()
	{
		if(currentTarget==0 || currentTarget==wayPoints.Count-1){
			yield return new WaitForSeconds(2.0f);
		}
		else
			yield return null;
		if(reverse)
		{
			currentTarget--;
			if(currentTarget == 0)
			{
				reverse = false;
				currentTarget = 0;
			}
		}
		else
		{
			currentTarget++;
			if(currentTarget == wayPoints.Count)
			{
				reverse = true;
				currentTarget--;
			}
		}
		_targetReached = false;
	}

}
