using System;
using UnityEngine;

public class VisitBathroom : MobileState<Elsa>
{
	#region Singleton
	public static VisitBathroom Instance
	{
		get;
	} = new VisitBathroom();
	#endregion

	public override GameObject Target
	{
		get
		{
			return Directory.instance.outhouse;
		}
	}

	public override void BeginTravel(Elsa entity)
	{
		entity.Think($"Walkin' to {entity.GetLocationName(Target)}. Need to powda mah pretty li'l nose");
		entity.modifiedSpeed *= 3f;
	}

	public override void Enter(Elsa entity)
	{
		entity.Think("Ahhhhhh! Sweet relief!");
	}

	public override void Execute(Elsa entity)
	{
		if (Utilities.Chance(1f/2f))
		{
			entity.stateMachine.ChangeState(ReadTheNewsPaper.Instance);
		}
		if (Utilities.Chance(0.001f))
		{
			entity.stateMachine.TravelTo(DoHousework.Instance);
		}
		if (Utilities.Chance(0.001f))
		{
			entity.stateMachine.TravelTo(MakeTheBed.Instance);
		}
		if (Utilities.Chance(0.001f))
		{
			entity.stateMachine.TravelTo(TendTheGarden.Instance);
		}
	}

	public override void Exit(Elsa entity)
	{
		if (entity.stateMachine.NextState.GetType() != typeof(ReadTheNewsPaper))
		{
			entity.Think("Leaving the john");
		}
		entity.modifiedSpeed = entity.initialSpeed;
	}
}
