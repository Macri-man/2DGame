using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardEnemyAI : MonoBehaviour {

	public Transform[] PatrolPoints;
	public float patrolSpeed;
	public float chaseSpeed;
	public float patrolPauseAtPointTime;
	public Animator animatorController;

	private bool isChasing;
	private Transform currentPatrolPoint;
	private int currentPatrolIndex;
	private bool patrolPointIsToRight;
	private float currentPatrolPauseAtPointTime;
	// Use this for initialization
	void Start () {
		if(PatrolPoints.Length > 1)
		{
			currentPatrolIndex = 1;
		}
		else currentPatrolIndex = 0;
		currentPatrolPoint = PatrolPoints[currentPatrolIndex];
		if(transform.position.x < currentPatrolPoint.position.x)
		{
			patrolPointIsToRight = true;
		}
		else patrolPointIsToRight = false;
		isChasing = false;
	}

	// Update is called once per frame
	void Update () {
		currentPatrolPauseAtPointTime-=1;
		if(currentPatrolPauseAtPointTime > 0)
		{
			return;
		}
		if(currentPatrolPauseAtPointTime == 0)
		{
			Vector3 theScale = transform.localScale;
			theScale.x *= -1;
			transform.localScale = theScale;
		}
		bool dCheck;
		if(patrolPointIsToRight)
		{
			dCheck = (transform.position.x >= currentPatrolPoint.position.x);
		}
		else dCheck = (transform.position.x <= currentPatrolPoint.position.x);
		if(dCheck)
		{
			//Debug.Log("We have reached the patrol point");
			currentPatrolIndex = ((currentPatrolIndex+1) >= PatrolPoints.Length)?(0):(currentPatrolIndex+1);
			currentPatrolPoint = PatrolPoints[currentPatrolIndex];
			if(transform.position.x < currentPatrolPoint.position.x)
			{
				patrolPointIsToRight = true;
			}
			else
			{
				patrolPointIsToRight = false;
			}
			animatorController.Play("Rogue_idle_01");

			currentPatrolPauseAtPointTime = patrolPauseAtPointTime;
			//Debug.Log("New patrol point: "+currentPatrolIndex);
		}
		else
		{
			if(transform.position.x < currentPatrolPoint.position.x)
			{
				transform.Translate(new Vector3(1,0,0) * Time.deltaTime * patrolSpeed);
				animatorController.Play("Rogue_walk_01");
			}
			else
			{
				transform.Translate(new Vector3(-1,0,0) * Time.deltaTime * patrolSpeed);
				animatorController.Play("Rogue_walk_01");
			}
		}
	}
}
