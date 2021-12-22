using System;
using UnityEngine;

public class DoHousework : MobileState<Elsa>
{
	#region Singleton
	public static DoHousework Instance
	{
		get;
	} = new DoHousework();
	#endregion

	public override GameObject Target
	{
		get
		{
			return Directory.instance.home;
		}
	}

	public override void BeginTravel(Elsa entity)
	{
		entity.Think("Off to do ma chores");
	}

	public override void Enter(Elsa entity)
	{
		entity.Think("Moppin' the floor");
	}

	public override void Execute(Elsa entity)
	{
		if (Utilities.Chance(0.001f))
		{
			entity.stateMachine.TravelTo(VisitBathroom.Instance);
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
	}
}
