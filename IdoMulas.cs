using UnityEngine;

public class IdoMulas : MonoBehaviour
{
	private bool lassit;

	private bool gyorsit;

	private float jelenlegi;

	private float fixedDeltaTime;

	private void Awake()
	{
		fixedDeltaTime = Time.fixedDeltaTime;
	}

	private void Start()
	{
		lassit = false;
		gyorsit = false;
		jelenlegi = 1f;
	}

	private void Update()
	{
		if (Input.GetKeyDown("n"))
		{
			lassit = true;
		}
		if (Input.GetKeyDown("m"))
		{
			gyorsit = true;
		}
		if (Input.GetKeyDown("v"))
		{
			Time.timeScale = 1f;
			Time.fixedDeltaTime = fixedDeltaTime * Time.timeScale;
			jelenlegi = 1f;
			Debug.Log("alap");
		}
		if (Input.GetKeyDown("p"))
		{
			if (jelenlegi != 0f)
			{
				Time.timeScale = 0f;
				jelenlegi = 0f;
			}
			else
			{
				Time.timeScale = 1f;
				jelenlegi = 1f;
			}
		}
	}

	private void FixedUpdate()
	{
		if (lassit)
		{
			if (jelenlegi == 3f)
			{
				Time.timeScale = 2f;
				Time.fixedDeltaTime = fixedDeltaTime * Time.timeScale;
				jelenlegi = 2f;
				lassit = false;
			}
			else if (jelenlegi == 2f)
			{
				Time.timeScale = 1.5f;
				Time.fixedDeltaTime = fixedDeltaTime * Time.timeScale;
				jelenlegi = 1.5f;
				lassit = false;
			}
			else if (jelenlegi == 1.5f)
			{
				Time.timeScale = 1f;
				Time.fixedDeltaTime = fixedDeltaTime * Time.timeScale;
				jelenlegi = 1f;
				lassit = false;
			}
			else if (jelenlegi == 1f)
			{
				Time.timeScale = 0.5f;
				Time.fixedDeltaTime = fixedDeltaTime * Time.timeScale;
				jelenlegi = 0.5f;
				lassit = false;
			}
			else if (jelenlegi == 0.5f)
			{
				Time.timeScale = 0.25f;
				Time.fixedDeltaTime = fixedDeltaTime * Time.timeScale;
				jelenlegi = 0.25f;
				lassit = false;
			}
			Debug.Log("lassit" + jelenlegi);
		}
		if (gyorsit)
		{
			if (jelenlegi == 0.25f)
			{
				Time.timeScale = 0.5f;
				Time.fixedDeltaTime = fixedDeltaTime * Time.timeScale;
				jelenlegi = 0.5f;
				gyorsit = false;
			}
			else if (jelenlegi == 0.5f)
			{
				Time.timeScale = 1f;
				Time.fixedDeltaTime = fixedDeltaTime * Time.timeScale;
				jelenlegi = 1f;
				gyorsit = false;
			}
			else if (jelenlegi == 1f)
			{
				Time.timeScale = 1.5f;
				Time.fixedDeltaTime = fixedDeltaTime * Time.timeScale;
				jelenlegi = 1.5f;
				gyorsit = false;
			}
			else if (jelenlegi == 1.5f)
			{
				Time.timeScale = 2f;
				Time.fixedDeltaTime = fixedDeltaTime * Time.timeScale;
				jelenlegi = 2f;
				gyorsit = false;
			}
			else if (jelenlegi == 2f)
			{
				Time.timeScale = 3f;
				Time.fixedDeltaTime = fixedDeltaTime * Time.timeScale;
				jelenlegi = 3f;
				gyorsit = false;
			}
			Debug.Log("gyorsit" + jelenlegi);
		}
	}
}