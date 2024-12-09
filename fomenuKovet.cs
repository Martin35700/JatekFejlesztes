using UnityEngine;

public class fomenuKovet : MonoBehaviour
{
	public float kezdoSebbeseg = 10f;

	[HideInInspector]
	public float sebbeseg;

	public Transform forogResz;

	private Transform kovetkezo;

	private int jelenlegi;

	private void Start()
	{
		sebbeseg = kezdoSebbeseg;
		kovetkezo = IranyjelzokScript.iranyjelzok[0];
		Vector3 forward = base.transform.position - IranyjelzokScript.iranyjelzok[jelenlegi].position;
		forogResz.rotation = Quaternion.LookRotation(forward);
	}

	private void Update()
	{
		Vector3 vector = kovetkezo.position - base.transform.position;
		base.transform.Translate(sebbeseg * Time.deltaTime * vector.normalized, Space.World);
		if (Vector3.Distance(base.transform.position, kovetkezo.position) <= 0.5f)
		{
			UjIrany();
		}
		sebbeseg = kezdoSebbeseg;
	}

	private void UjIrany()
	{
		if (jelenlegi >= IranyjelzokScript.iranyjelzok.Length - 1)
		{
			Megsemmisul();
		}
	}

	private void Megsemmisul()
	{
		Object.Destroy(base.gameObject);
	}
}
