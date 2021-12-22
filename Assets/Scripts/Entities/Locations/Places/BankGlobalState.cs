using UnityEngine;

public class BankGlobalState : StaticState<BankLocation>
{
	#region Singleton
	public static BankGlobalState Instance
	{
		get;
	} = new BankGlobalState();
	#endregion

	public override void Enter(BankLocation entity)
	{
	}

	public override void Execute(BankLocation entity)
	{
	}

	public override void Exit(BankLocation entity)
	{
	}
}