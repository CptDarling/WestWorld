using System;
using UnityEngine;

public class BankClosed : StaticState<BankLocation>
{
	#region Singleton
	public static BankClosed Instance
	{
		get;
	} = new BankClosed();
	#endregion

	public override void Enter(BankLocation entity)
	{
		entity.Think("I am closed");
	}

	public override void Execute(BankLocation entity)
	{
	}

	public override void Exit(BankLocation entity)
	{
		entity.Think("Opening up for business");
	}
}
