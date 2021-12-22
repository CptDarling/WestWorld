using System;
using UnityEngine;

public static class Utilities
{

	public static bool Chance(float threshold) { return UnityEngine.Random.Range(0f, 1f) < threshold; }

}
