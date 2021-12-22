using System;
using UnityEngine;

public class GoHomeAndSleepTillRested : MobileState<Miner>
{
	#region Singleton
	public static GoHomeAndSleepTillRested Instance
	{
		get;
	} = new GoHomeAndSleepTillRested();
	#endregion

	public override GameObject Target
	{
		get
		{
			return Directory.instance.home;
		}
	}

	public override void BeginTravel(Miner entity)
	{
		entity.Think($"Phew! ah sure am bushed.  Goin' to mosey on back to {entity.GetLocationName(Target)} and get me some kip");
	}

	public override void Enter(Miner entity)
	{
		entity.Think("Back 'ome t' mah li'l ole lady, am off to bed");
	}

	public override void Execute(Miner entity)
	{
		entity.Sleep();
		entity.Think("ZZZZ...");
		if (entity.FullyRested())
		{
			if (entity.QuiteThirsty())
			{
				entity.stateMachine.TravelTo(QuenchThirst.Instance);
			}
			else if (entity.GoldOnPerson > 0)
			{
				entity.stateMachine.TravelTo(VisitBankAndDepositGold.Instance);
			}
			else
			{
				entity.stateMachine.TravelTo(EnterMineAndDigForNugget.Instance);
			}
		}
	}

	public override void Exit(Miner entity)
	{
		entity.Think("What a God-darn fantastic nap! Time to find more gold");
	}
}
