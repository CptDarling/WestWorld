using System;
using UnityEngine;

public class MakeTheBed : MobileState<Elsa>
{
	#region Singleton
	public static MakeTheBed Instance
	{
		get;
	} = new MakeTheBed();
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
		entity.Think("Gonna do my bedroom chores");
	}

	public override void Enter(Elsa entity)
	{
		entity.Think("Makin' the bed");
	}

	public override void Execute(Elsa entity)
	{
		if (Utilities.Chance(0.001f))
		{
			entity.stateMachine.TravelTo(VisitBathroom.Instance);
		}
		if (Utilities.Chance(0.001f))
		{
			entity.stateMachine.TravelTo(DoHousework.Instance);
		}
	}

	public override void Exit(Elsa entity)
	{
	}
}
