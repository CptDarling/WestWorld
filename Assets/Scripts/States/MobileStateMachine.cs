using System;
using UnityEngine;

public class MobileStateMachine<EntityType> : StaticStateMachine<EntityType> where EntityType : BasePerson
{

	private GameObject _target;
	private MobileState<EntityType> _destinationState;

	public MobileStateMachine(EntityType owner, MobileState<EntityType> currentState, MobileState<EntityType> globalState) : base(owner, currentState, globalState)
	{
		_currentState = null;
		TravelTo(currentState);
	}

	internal GameObject Target
	{
		get
		{
			return _target;
		}

		set
		{
			_target = value;
		}
	}

	public new void Execute()
	{
		base.Execute();

		// This is movement of the entity.
		if (_target != null)
		{
			if (_owner.transform.position == _target.transform.position)
			{
				_target = null;
				ChangeState(_destinationState);
			}
			else
			{
				_owner.transform.position = Vector3.MoveTowards(_owner.transform.position,
					_target.transform.position,
					_owner.modifiedSpeed * Time.deltaTime);
			}
		}
	}

	public void TravelTo(MobileState<EntityType> destinationState)
	{
		_destinationState = destinationState;
		_target = _destinationState.Target;
		ChangeState(new Travel<EntityType>(_destinationState));
		_destinationState.BeginTravel(_owner);
	}

}
