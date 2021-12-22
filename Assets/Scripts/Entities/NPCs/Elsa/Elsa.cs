using System;
using UnityEngine;

public class Elsa : BasePerson
{
	internal MobileStateMachine<Elsa> stateMachine;

	#region Unity
	private void Start()
	{
		stateMachine = new MobileStateMachine<Elsa>(this, DoHousework.Instance, ElsaGlobalState.Instance);
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

	#region BasePerson
	internal override void IncreaseFatigue()
	{
	}
	internal override void IncreaseThirst()
	{
	}

	#endregion

}
