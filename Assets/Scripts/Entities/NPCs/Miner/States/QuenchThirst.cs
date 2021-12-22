using System;
using UnityEngine;

public class QuenchThirst : MobileState<Miner>
{
	#region Singleton
	public static QuenchThirst Instance
	{
		get;
	} = new QuenchThirst();
	#endregion

	public override GameObject Target
	{
		get
		{
			return Directory.instance.saloon;
		}
	}

	public override void BeginTravel(Miner entity)
	{
		entity.Think($"Boy, ah sure is thirsty! Walkin' to {entity.GetLocationName(Target)}");
	}

	public override void Enter(Miner entity)
	{
		entity.Think("Drink! Girls! Beer! Arse!");
	}

	public override void Execute(Miner entity)
	{
		entity.Drink();
		entity.Think("That's mighty fine sippin' liquor");
		if (entity.FullyRefreshed())
		{
			int cost = Location().costOfDrink;
			entity.PayForGoodsAndSerices(Location(), cost);
			entity.Think($"Ah pays my way, that's {cost} gold spent");
			entity.stateMachine.TravelTo(EnterMineAndDigForNugget.Instance);
		}
		if (entity.FeelingTired())
		{
			entity.stateMachine.TravelTo(GoHomeAndSleepTillRested.Instance);
		}
	}

	private SaloonLocation Location()
	{
		return Target.GetComponent<SaloonLocation>();
	}

	public override void Exit(Miner entity)
	{
		entity.Think("Leavin' the saloon, feelin' good");
	}

}
