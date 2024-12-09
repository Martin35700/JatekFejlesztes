using UnityEngine;

public class KameraKezelo : MonoBehaviour
{
	public float sebbeseg = 30f;

	public float szegelyyvastagsag = 20f;

	public Vector3 kezdoPozicio;

	public float gorgetsebesseg = 5f;

	public float minY = 10f;

	public float maxY = 90f;

	private void Start()
	{
		kezdoPozicio = base.transform.position;
	}

	private void Update()
	{
		if (Kezelo.jatekVege)
		{
			base.transform.position = kezdoPozicio;
			base.enabled = false;
			return;
		}
		if (Input.GetKey("w") || Input.mousePosition.y >= (float)Screen.height - szegelyyvastagsag)
		{
			base.transform.Translate(Vector3.forward * sebbeseg * Time.deltaTime, Space.World);
		}
		if (Input.GetKey("s") || Input.mousePosition.y <= szegelyyvastagsag)
		{
			base.transform.Translate(Vector3.back * sebbeseg * Time.deltaTime, Space.World);
		}
		if (Input.GetKey("a") || Input.mousePosition.x <= szegelyyvastagsag)
		{
			base.transform.Translate(Vector3.left * sebbeseg * Time.deltaTime, Space.World);
		}
		if (Input.GetKey("d") || Input.mousePosition.x >= (float)Screen.width - szegelyyvastagsag)
		{
			base.transform.Translate(Vector3.right * sebbeseg * Time.deltaTime, Space.World);
		}
		if (Input.GetKey(KeyCode.Space))
		{
			base.transform.position = kezdoPozicio;
		}
		float axis = Input.GetAxis("Mouse ScrollWheel");
		Vector3 position = base.transform.position;
		position.y -= axis * 1000f * gorgetsebesseg * Time.deltaTime;
		position.y = Mathf.Clamp(position.y, minY, maxY);
		base.transform.position = position;
	}
}