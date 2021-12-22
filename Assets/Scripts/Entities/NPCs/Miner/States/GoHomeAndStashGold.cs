using UnityEngine;

internal class GoHomeAndStashGold : MobileState<Miner>
{
	#region Singleton
	public static GoHomeAndStashGold Instance
	{
		get;
	} = new GoHomeAndStashGold();
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
		entity.Think($"I'm going to {entity.GetLocationName(Target)} to stash this gold before it makes a hole in ma pocket");
	}

	public override void Enter(Miner entity)
	{
		entity.Think("Now to stash this gold");
	}

	public override void Execute(Miner entity)
	{
		HomeLocation home = Target.GetComponent<HomeLocation>();
		entity.DepositGold(home);
		entity.stateMachine.TravelTo(EnterMineAndDigForNugget.Instance);
	}

	public override void Exit(Miner entity)
	{
		entity.Think("Ma gold is stashed");
	}
}