using System;
using UnityEngine;

public abstract class StateMachine<EntityType>
{

}

public class StaticStateMachine<EntityType> : StateMachine<EntityType> where EntityType : BaseGameEntity
{
	protected EntityType _owner;
	protected StaticState<EntityType> _currentState;
	protected StaticState<EntityType> _nextState;
	protected StaticState<EntityType> _globalState;

	public StaticStateMachine(EntityType owner, StaticState<EntityType> currentState, StaticState<EntityType> globalState)
	{
		_owner = owner;
		_currentState = currentState;
		_globalState = globalState;
	}
	public StaticState<EntityType> CurrentState
	{
		get { return _currentState; }
		set { _currentState = value; }
	}
	public StaticState<EntityType> NextState
	{
		get { return _nextState; }
		private set { _nextState = value; }
	}
	public void ChangeState(StaticState<EntityType> newState)
	{
		//Debug.Log(newState.GetType());
		_nextState = newState;
		_currentState?.Exit(_owner);
		_currentState = newState;
		_currentState?.Enter(_owner);
	}
	public void Execute()
	{
		if (_globalState != null)
		{
			_globalState.Execute(_owner);
		}
		if (_currentState != null)
		{
			_currentState.Execute(_owner);
		}
	}

	public bool IsInState(StaticState<EntityType> state)
	{
		return _currentState.GetType().Name == state.GetType().Name;
	}
}
