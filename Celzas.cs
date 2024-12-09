using UnityEngine;

public class Celzas : MonoBehaviour
{
	private Transform ellenfel;

	private utvonalKovet ellenfelCelpont;

	private string kerestag = "Ellenfel";

	public float hatotav = 15f;

	public float tuzgyorsassag = 1f;

	private float visszaszamlalo;

	public GameObject lovedek;

	public Transform KiinduloHely;

	public Transform forogResz;

	public float forgassebbeseg = 10f;

	public bool forog;

	public bool lezertHasznal;

	public LineRenderer lineRenderer;

	public ParticleSystem lezerEffekt;

	public int sebzesIdoElteltevel = 30;

	public float lassitas = 0.3f;

	private void Start()
	{
		InvokeRepeating("EllenfelKeres", 0f, 0.5f);
	}

	private void EllenfelKeres()
	{
		GameObject[] array = GameObject.FindGameObjectsWithTag(kerestag);
		float num = float.PositiveInfinity;
		GameObject gameObject = null;
		GameObject[] array2 = array;
		foreach (GameObject gameObject2 in array2)
		{
			float num2 = Vector3.Distance(base.transform.position, gameObject2.transform.position);
			if (num2 < num)
			{
				num = num2;
				gameObject = gameObject2;
			}
		}
		if (num <= hatotav && gameObject != null)
		{
			ellenfel = gameObject.transform;
			ellenfelCelpont = gameObject.GetComponent<utvonalKovet>();
		}
		else
		{
			ellenfel = null;
		}
	}

	private void Update()
	{
		if (ellenfel == null)
		{
			if (lezertHasznal && lineRenderer.enabled)
			{
				lineRenderer.enabled = false;
				lezerEffekt.Stop();
			}
			return;
		}
		CelpontKovet();
		if (lezertHasznal)
		{
			Lezer();
			return;
		}
		if (visszaszamlalo <= 0f)
		{
			Loves();
			visszaszamlalo = 1f / tuzgyorsassag;
		}
		visszaszamlalo -= Time.deltaTime;
	}

	private void CelpontKovet()
	{
		if (forog)
		{
			Quaternion b = Quaternion.LookRotation(ellenfel.position - base.transform.position);
			Vector3 eulerAngles = Quaternion.Lerp(forogResz.rotation, b, Time.deltaTime * forgassebbeseg).eulerAngles;
			forogResz.rotation = Quaternion.Euler(0f, eulerAngles.y, 0f);
		}
	}

	private void Lezer()
	{
		ellenfelCelpont.Sebzodes((float)sebzesIdoElteltevel * Time.deltaTime);
		ellenfelCelpont.Lassit(lassitas);
		if (!lineRenderer.enabled)
		{
			lineRenderer.enabled = true;
			lezerEffekt.Play();
		}
		lineRenderer.SetPosition(0, KiinduloHely.position);
		lineRenderer.SetPosition(1, ellenfel.position);
		Vector3 forward = KiinduloHely.position - ellenfel.position;
		lezerEffekt.transform.position = ellenfel.position + forward.normalized;
		lezerEffekt.transform.rotation = Quaternion.LookRotation(forward);
	}

	private void Loves()
	{
		Lovedek component = Object.Instantiate(lovedek, KiinduloHely.position, KiinduloHely.rotation).GetComponent<Lovedek>();
		if (component != null)
		{
			component.Uldoz(ellenfel);
		}
	}

	private void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(base.transform.position, hatotav);
	}
}