using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Location : BaseGameEntity
{

	public string prefix;

	[SerializeField] private int _totalGold;

	public int TotalGold
	{
		get { return _totalGold; }
		private set { _totalGold = value; }
	}

	public override string EntityName()
	{
		string _name = entityName == "" ? this.GetType().Name : entityName;
		string _prefix = prefix == "" ? "the " : prefix + " ";
		return $"{_prefix}{_name}";
	}

	#region Location
	public void DepositGold(int amount)
	{
		TotalGold += amount;
	}
	#endregion
}
