using System;
using UnityEngine;

public abstract class MobileState<EntityType> : StaticState<EntityType> where EntityType : BasePerson
{
	public abstract GameObject Target { get; }
	public abstract void BeginTravel(EntityType entity);
}
