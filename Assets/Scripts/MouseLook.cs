using UnityEngine;

public class MouseLook : MonoBehaviour
{

	[SerializeField] private Transform playerTransform;
	[SerializeField] private Vector2 sensitivity = new Vector2(1.5f, 1.5f);
	[SerializeField] private bool invertYAxis = false;

	private CharacterController _controller;
	private float _gravity = 9.81f;
	private float speed = 3.5f;

	private bool _mouselookEnabled;

	#region Singleton
	public static MouseLook instance = null;

	public bool MouselookEnabled
	{
		get { return _mouselookEnabled; }
		private set { _mouselookEnabled = value; }
	}

	private void Awake()
	{
		if (instance == null)
		{
			instance = this;
		}
		else if (instance != this)
		{
			Destroy(this.gameObject);
		}
	}
	#endregion

	private void Start()
	{
		_controller = playerTransform.GetComponent<CharacterController>();
		EnableMouselook(true);
	}

	private void Update()
	{
		InputControl();
		if (MouselookEnabled)
		{
			LookX();
			LookY();
			CalculateMovementUpdate();
		}
	}

	private void EnableMouselook(bool state)
	{
		if (state)
		{
			MouselookEnabled = true;
			Cursor.lockState = CursorLockMode.Locked;
		}
		else
		{
			MouselookEnabled = false;
			Cursor.lockState = CursorLockMode.None;
		}
	}

	private void InputControl()
	{
		if (Input.GetKeyDown(KeyCode.Escape) || Input.GetButtonDown("Fire2"))
		{
			if (MouselookEnabled)
			{
				EnableMouselook(false);
			}
			else
			{
				EnableMouselook(true);
			}
		}
	}

	/// <summary>
	/// Attaches to the player transform so X mouse rotates the player mesh.
	/// </summary>
	private void LookX()
	{
		float mouseX = Input.GetAxis("Mouse X");

		Vector3 newRotation = playerTransform.localEulerAngles;
		newRotation.y += mouseX * sensitivity.x;

		playerTransform.localEulerAngles = newRotation;
	}

	/// <summary>
	/// Attaches to the players camera pivot to rotate the camera.
	/// </summary>
	private void LookY()
	{
		float mouseY = Input.GetAxis("Mouse Y");

		Vector3 newRotation = transform.localEulerAngles;
		if (invertYAxis)
		{
			newRotation.x += mouseY * sensitivity.y;
		}
		else
		{
			newRotation.x -= mouseY * sensitivity.y;
		}
		transform.localEulerAngles = newRotation;
	}

	private void CalculateMovementUpdate()
	{
		if (MouseLook.instance.MouselookEnabled)
		{
			float horizontal = Input.GetAxis("Horizontal");
			float vertical = Input.GetAxis("Vertical");
			Vector3 direction = new Vector3(horizontal, 0f, vertical);

			Vector3 velocity = direction * speed;
			velocity.y -= _gravity;
			velocity = transform.TransformDirection(velocity);

			_controller.Move(velocity * Time.deltaTime);
		}
	}

}
