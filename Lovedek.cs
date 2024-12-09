using UnityEngine;

public class Lovedek : MonoBehaviour
{
	private Transform celpont;

	public float sebbeseg = 70f;

	public float robbanasTavolsag;

	public int sebzes = 20;

	public GameObject effect;

	public void Uldoz(Transform _celpont)
	{
		celpont = _celpont;
	}

	private void Update()
	{
		if (celpont == null)
		{
			Object.Destroy(base.gameObject);
			return;
		}
		Vector3 vector = celpont.position - base.transform.position;
		float num = sebbeseg * Time.deltaTime;
		if (vector.magnitude <= num)
		{
			Talalt();
			Object.Destroy(base.gameObject);
		}
		else
		{
			base.transform.Translate(vector.normalized * num, Space.World);
			base.transform.LookAt(celpont);
		}
	}

	private void Talalt()
	{
		Object.Destroy(Object.Instantiate(effect, base.transform.position, base.transform.rotation), 1f);
		if (robbanasTavolsag > 0f)
		{
			Robban();
		}
		else
		{
			Sebzes(celpont);
		}
	}

	private void Robban()
	{
		Collider[] array = Physics.OverlapSphere(base.transform.position, robbanasTavolsag);
		foreach (Collider collider in array)
		{
			if (collider.tag == "Ellenfel")
			{
				Sebzes(collider.transform);
			}
		}
	}

	private void Sebzes(Transform ellenfel)
	{
		utvonalKovet component = ellenfel.GetComponent<utvonalKovet>();
		if (component != null)
		{
			component.Sebzodes(sebzes);
		}
	}

	private void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(base.transform.position, robbanasTavolsag);
	}
}