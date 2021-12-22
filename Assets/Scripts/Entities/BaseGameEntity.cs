#define DEBUG_THOUGHTS

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseGameEntity : MonoBehaviour
{

	[SerializeField] public string _currentState;
	[SerializeField] public string entityName;
	[SerializeField] private string _currentThought;

	internal void Think(string thought)
	{
		if (thought != _currentThought)
		{
			_currentThought = thought;
#if DEBUG_THOUGHTS
			Debug.Log($"{EntityName()}: {thought}");
#endif
		}
	}
	public abstract string EntityName();
	public string GetLocationName(GameObject target) { return target.GetComponent<Location>().EntityName(); }

}
