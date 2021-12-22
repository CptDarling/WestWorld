using System;
using UnityEngine;

public class Miner : Person
{

	[SerializeField] private int _goldOnPerson;
	[SerializeField] private int _goldInBank;

	private readonly int _maxGoldOnPerson = 800;
	private readonly int _maxFatigue = 1000;
	private readonly int _maxThirst = 600;

	internal MobileStateMachine<Miner> stateMachine;

	private void Start()
	{
		stateMachine = new MobileStateMachine<Miner>(this, EnterMineAndDigForNugget.Instance, MinerGlobalState.Instance);
	}
	private void FixedUpdate()
	{
		if (!IsSleeping && !IsDrinking)
		{
			if (Utilities.Chance(0.1f))
			{
				IncreaseThirst();
			}
		}
		stateMachine.Execute();
	}

	private void LateUpdate()
	{
		_currentState = stateMachine.CurrentState.GetType().Name;
	}

	internal bool QuiteThirsty()
	{
		return base.QuiteThirsty(_maxThirst);
	}

	internal bool FeelingThirsty()
	{
		return base.FeelingThirsty(_maxThirst);
	}

	internal bool FeelingTired()
	{
		return base.FeelingTired(_maxFatigue);
	}

	internal int GoldOnPerson { get { return _goldOnPerson; } }
	public int GoldInBank { get { return _goldInBank; } }
	internal void AddToGoldCarried(int amount)
	{
		_goldOnPerson += amount;
	}
	internal void PayForGoodsAndSerices(Location place, int amount)
	{
		place.DepositGold(amount);
		_goldOnPerson -= amount;
	}
	internal bool PocketsFull()
	{
		return _goldOnPerson >= _maxGoldOnPerson * UnityEngine.Random.Range(0.95f, 1.05f);
	}
	internal void DepositGold(Location location)
	{
		location.DepositGold(GoldOnPerson);
		if (location.GetType().Name == typeof(BankLocation).Name)
		{
			_goldInBank += GoldOnPerson;
		}
		_goldOnPerson = 0;
	}

}
