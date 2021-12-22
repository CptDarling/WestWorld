public class BankAcceptingDeposits : StaticState<BankLocation>
{
	#region Singleton
	public static BankAcceptingDeposits Instance
	{
		get;
	} = new BankAcceptingDeposits();
	#endregion

	private readonly int _maxGold = 1000;
	
	public override void Enter(BankLocation entity)
	{
		entity.Think($"is accepting deposits");
	}

	public override void Execute(BankLocation entity)
	{
		if (entity.TotalGold >= _maxGold)
		{
			entity.stateMachine.ChangeState(BankClosed.Instance);
		}
	}

	public override void Exit(BankLocation entity)
	{
		entity.Think("I will no longer accept deposits");
	}
}
