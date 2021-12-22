using System;
using UnityEngine;

public class TendTheGarden : MobileState<Elsa>
{
	#region Singleton
	public static TendTheGarden Instance
	{
		get;
	} = new TendTheGarden();
	#endregion

	public override GameObject Target
	{
		get
		{
			return Directory.instance.garden;
		}
	}

	public override void BeginTravel(Elsa entity)
	{
		entity.Think("Them plants 'ul need some water");
	}

	public override void Enter(Elsa entity)
	{
		entity.Think($"Tendin' {entity.GetLocationName(Target)}");
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
			entity.stateMachine.TravelTo(DoHousework.Instance);
		}
	}

	public override void Exit(Elsa entity)
	{
	}
}
