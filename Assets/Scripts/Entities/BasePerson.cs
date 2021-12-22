using UnityEngine;

public abstract class BasePerson : BaseGameEntity
{

	[SerializeField] public float initialSpeed = 1f;
	[HideInInspector] public float modifiedSpeed = 1f;
	[SerializeField] public bool isWalking = false;

	public override string EntityName()
	{
		return entityName == "" ? this.GetType().Name : entityName;
	}

	internal abstract void IncreaseFatigue();
	internal abstract void IncreaseThirst();

}
