using UnityEngine;

public class Directory : MonoBehaviour
{

	public GameObject bank;
	public GameObject garden;
	public GameObject home;
	public GameObject mine;
	public GameObject outhouse;
	public GameObject saloon;

	#region Singleton
	public static Directory instance;

	private void Awake()
	{
		instance = this;
	}
	#endregion

}
