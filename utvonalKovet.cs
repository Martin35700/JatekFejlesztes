using UnityEngine;
using UnityEngine.UI;

public class utvonalKovet : MonoBehaviour
{
	public float kezdoSebbeseg = 10f;

	[HideInInspector]
	public float sebbeseg;

	public Transform forogResz;

	public float forgassebbeseg = 100f;

	public float kezdoEletero;

	public float eletero = 100f;

	public int ertek;

	private Transform kovetkezo;

	private int jelenlegi;

	public Image EletCsik;

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
		base.transform.Translate(vector.normalized * sebbeseg * Time.deltaTime, Space.World);
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
			if (Valuta.HpSzam != 0)
			{
				Valuta.HpSzam--;
			}
		}
		else
		{
			Vector3 forward = base.transform.position - IranyjelzokScript.iranyjelzok[jelenlegi + 1].position;
			forogResz.rotation = Quaternion.LookRotation(forward);
			jelenlegi++;
			kovetkezo = IranyjelzokScript.iranyjelzok[jelenlegi];
		}
	}

	public void Sebzodes(float sebzesMennyiseg)
	{
		eletero -= sebzesMennyiseg;
		EletCsik.fillAmount = eletero / kezdoEletero;
		if (eletero <= 0f)
		{
			Megsemmisul();
		}
	}

	private void Megsemmisul()
	{
		Object.Destroy(base.gameObject);
		Valuta.Penz += ertek;
		UjKor.ellenfelSzam--;
		Debug.Log("Remaining enemies: " + UjKor.ellenfelSzam);
	}

	public void Lassit(float mertek)
	{
		sebbeseg = kezdoSebbeseg * (1f - mertek);
	}
}