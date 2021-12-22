using UnityEngine;

internal class Travel<EntityType> : MobileState<EntityType> where EntityType : BasePerson
{
	internal readonly MobileState<EntityType> _newState;

	public Travel(MobileState<EntityType> newState)
	{
		this._newState = newState;
	}

	public override GameObject Target
	{
		get
		{
			throw new System.NotImplementedException();
		}
	}

	public override void BeginTravel(EntityType entity)
	{
		entity.Think($"Travelling to {Target?.GetComponent<Location>().prefix} {Target?.name}");
	}

	public override void Enter(EntityType entity)
	{
		entity.isWalking = true;
	}

	public override void Execute(EntityType entity)
	{
		if (Utilities.Chance(0.1f))
		{
			entity.IncreaseFatigue();
		}
		if (Utilities.Chance(0.1f))
		{
			entity.IncreaseThirst();
		}
	}

	public override void Exit(EntityType entity)
	{
		entity.isWalking = false;
	}
}