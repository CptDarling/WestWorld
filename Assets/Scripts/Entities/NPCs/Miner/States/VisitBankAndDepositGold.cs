using System;
using UnityEngine;

public class VisitBankAndDepositGold : MobileState<Miner>
{
	#region Singleton
	public static VisitBankAndDepositGold Instance
	{
		get;
	} = new VisitBankAndDepositGold();
	#endregion

	public override GameObject Target
	{
		get
		{
			return Directory.instance.bank;
		}
	}

	public override void BeginTravel(Miner entity)
	{
		BankLocation bank = Directory.instance.bank.GetComponent<BankLocation>();
		if (bank.stateMachine.IsInState(BankAcceptingDeposits.Instance))
		{
			entity.Think($"Goin' to {entity.GetLocationName(Target)}. Yes siree!");
		} else
		{
			entity.Think($"Oh no, {entity.GetLocationName(Target)} is closed!");
			entity.stateMachine.TravelTo(GoHomeAndStashGold.Instance);
		}

	}

	public override void Enter(Miner entity)
	{
		entity.Think("Arrived at the bank, 'ope ah don' get robbed!");
	}

	public override void Execute(Miner entity)
	{
		if (entity.GoldOnPerson > 0)
		{
			entity.DepositGold(Target.GetComponent<BankLocation>());
			entity.Think($"Depositin' gold. Total savings now: {entity.GoldInBank}");
			if (entity.GoldOnPerson == 0)
			{
				if (entity.FeelingTired())
				{
					entity.stateMachine.TravelTo(GoHomeAndSleepTillRested.Instance);
				}
				else if (entity.FeelingThirsty())
				{
					entity.stateMachine.TravelTo(QuenchThirst.Instance);
				}
				else
				{
					entity.stateMachine.TravelTo(EnterMineAndDigForNugget.Instance);
				}
			}
		}
	}

	public override void Exit(Miner entity)
	{
		entity.Think("Leavin' the bank");
	}

}
