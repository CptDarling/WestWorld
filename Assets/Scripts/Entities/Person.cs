using UnityEngine;

public abstract class Person : BasePerson
{

	[SerializeField] private int _thirst;
	[SerializeField] private int _fatigue;
	[SerializeField] private bool _isDrinking = false;
	[SerializeField] private bool _isSleeping = false;

	private readonly int _swallow = 5;
	private readonly int _rest = 5;

	private void Awake()
	{
		modifiedSpeed = initialSpeed;
	}

	public int Thirst
	{
		get
		{
			return _thirst;
		}

		set
		{
			_thirst = value;
		}
	}
	public bool IsDrinking
	{
		get { return _isDrinking; }
		private set { _isDrinking = value; }
	}
	internal override void IncreaseThirst()
	{
		_thirst++;
	}
	internal bool QuiteThirsty(int maxThirst)
	{
		return Thirst >= maxThirst / 2;
	}
	internal bool FeelingThirsty(int maxThirst)
	{
		return Thirst >= maxThirst;
	}
	internal void Drink()
	{
		if (IsDrinking)
		{
			Thirst -= _swallow;
			if (Thirst <= 0)
			{
				Thirst = 0;
				IsDrinking = false;
			}
		}
		else
		{
			IsDrinking = Thirst > 0;
		}
	}
	public bool FullyRefreshed()
	{
		return Thirst == 0;
	}

	public int Fatigue
	{
		get
		{
			return _fatigue;
		}
		private set
		{
			_fatigue = value;
		}
	}
	public bool IsSleeping
	{
		get { return _isSleeping; }
		private set { _isSleeping = value; }
	}
	internal override void IncreaseFatigue()
	{
		_fatigue++;
	}
	internal bool FeelingTired(int maxFatigue)
	{
		return Fatigue >= maxFatigue;
	}
	internal void Sleep()
	{
		if (IsSleeping)
		{
			Fatigue -= _rest;
			if (Fatigue <= 0)
			{
				Fatigue = 0;
				IsSleeping = false;
			}
		}
		else
		{
			IsSleeping = Fatigue > 0;
		}
	}
	public bool FullyRested()
	{
		return Fatigue == 0;
	}
}
