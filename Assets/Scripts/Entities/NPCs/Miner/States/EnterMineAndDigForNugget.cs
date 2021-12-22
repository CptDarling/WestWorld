using System;
using UnityEngine;

class EnterMineAndDigForNugget : MobileState<Miner>
{
	#region Singleton
	public static EnterMineAndDigForNugget Instance
	{
		get;
	} = new EnterMineAndDigForNugget();
	#endregion

	public override GameObject Target
	{
		get
		{
			return Directory.instance.mine;
		}
	}

	public override void BeginTravel(Miner entity)
	{
		entity.Think($"Walkin' to {entity.GetLocationName(Target)}");
	}

	public override void Enter(Miner entity)
	{
		entity.Think("'ave arrived at the mine so will dig, dig, dig!  Now where's ma shovel?");
	}

	public override void Execute(Miner entity)
	{
		entity.AddToGoldCarried(1);
		entity.IncreaseFatigue();
		entity.IncreaseThirst();
		entity.Think("Pickin' up a nugget");
		if (entity.PocketsFull())
		{
			entity.stateMachine.TravelTo(VisitBankAndDepositGold.Instance);
		}
		if (entity.FeelingThirsty())
		{
			entity.stateMachine.TravelTo(QuenchThirst.Instance);
		}
		if (entity.FeelingTired())
		{
			entity.stateMachine.TravelTo(GoHomeAndSleepTillRested.Instance);
		}
	}

	public override void Exit(Miner entity)
	{
		entity.Think("Ah'm leavin' the gold mine with mah pockets full o' sweet gold");
	}
}

