using System;
using UnityEngine;

public abstract class State<EntityType>
{

}

public abstract class StaticState<EntityType> : State<EntityType> where EntityType : BaseGameEntity
{
	public abstract void Enter(EntityType entity);
	public abstract void Execute(EntityType entity);
	public abstract void Exit(EntityType entity);
}
