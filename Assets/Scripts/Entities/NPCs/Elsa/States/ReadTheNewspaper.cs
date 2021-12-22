using System;
using UnityEngine;

public class ReadTheNewsPaper : StaticState<Elsa>
{
	#region Singleton
	public static ReadTheNewsPaper Instance
	{
		get;
	} = new ReadTheNewsPaper();
	#endregion

	public override void Enter(Elsa entity)
	{
		entity.Think("Readin' the ole newspaper");
	}

	public override void Execute(Elsa entity)
	{
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
		entity.Think("Same ole crap!");
	}
}
