using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BankLocation : Location
{

	[SerializeField] public StaticStateMachine<BankLocation> stateMachine;

	#region Unity
	private void Start()
	{
		stateMachine = new StaticStateMachine<BankLocation>(this, BankAcceptingDeposits.Instance, BankGlobalState.Instance);
	}
	protected void FixedUpdate()
	{
		stateMachine.Execute();
	}
	private void LateUpdate()
	{
		_currentState = stateMachine.CurrentState.GetType().Name;
	}
	#endregion

}
