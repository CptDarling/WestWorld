using UnityEngine;

public class ElsaGlobalState : MobileState<Elsa>
{
	#region Singleton
	public static ElsaGlobalState Instance
	{
		get;
	} = new ElsaGlobalState();
	#endregion

	public override GameObject Target
	{
		get
		{
			return null;
		}
	}

	public override void BeginTravel(Elsa entity)
	{
	}

	public override void Enter(Elsa entity)
	{
	}

	public override void Execute(Elsa entity)
	{
	}

	public override void Exit(Elsa entity)
	{
	}
}