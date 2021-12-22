using System;
using UnityEngine;

public class MinerGlobalState : MobileState<Miner>
{
	#region Singleton
	public static MinerGlobalState Instance
	{
		get;
	} = new MinerGlobalState();
	#endregion

	public override GameObject Target
	{
		get
		{
			return null;
		}
	}

	public override void BeginTravel(Miner entity)
	{
	}

	public override void Enter(Miner entity)
	{
	}

	public override void Execute(Miner entity)
	{
	}

	public override void Exit(Miner entity)
	{
	}
}
