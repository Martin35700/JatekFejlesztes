using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UjKor : MonoBehaviour
{
	public Transform EllenfelEgy;

	public Transform EllenfelKetto;

	public Transform EllenfelHarom;

	public Transform EllenfelNegy;

	public Transform EllenfelOt;

	public Transform EllenfelHat;

	public Transform EllenfelHet;

	public Transform KezdoPont;

	public static int ellenfelSzam;

	public static int aktualisKor;

	private float idozito = 2f;

	public static bool spawnVege;

	public float korokKozottiIdo = 5f;

	public Text idozitoSzoveg;

	private void Start()
	{
		ellenfelSzam = 0;
		aktualisKor = -1;
		spawnVege = true;
	}

	private void Update()
	{
		if (ellenfelSzam <= 0 && spawnVege)
		{
			if (idozito <= 0f)
			{
				StartCoroutine(KorInditas());
				spawnVege = false;
				idozito = korokKozottiIdo;
			}
			else
			{
				idozito -= Time.deltaTime;
				idozito = Mathf.Clamp(idozito, 0f, float.PositiveInfinity);
				idozitoSzoveg.text = $"{idozito:00.00}";
			}
		}
	}

	private IEnumerator KorInditas()
	{
		aktualisKor++;
		ellenfelSzam = aktualisKor + 1;
		for (int i = 0; i <= aktualisKor; i++)
		{
			UjEllenfel(i);
			yield return new WaitForSeconds(0.5f);
		}
		spawnVege = true;
	}

	private void UjEllenfel(int ellenfelid)
	{
		if (ellenfelid < 5)
		{
			Object.Instantiate(EllenfelEgy, new Vector3(7f, 2.25f, 5f), KezdoPont.rotation);
		}
		else if (ellenfelid > 4 && ellenfelid < 10)
		{
			Object.Instantiate(EllenfelKetto, new Vector3(7f, 2.25f, 5f), KezdoPont.rotation);
		}
		else if (ellenfelid > 9 && ellenfelid < 15)
		{
			Object.Instantiate(EllenfelHarom, new Vector3(7f, 2.25f, 5f), KezdoPont.rotation);
		}
		else if (ellenfelid > 14 && ellenfelid < 25)
		{
			Object.Instantiate(EllenfelNegy, new Vector3(7f, 2.25f, 5f), KezdoPont.rotation);
		}
		else if (ellenfelid > 24 && ellenfelid < 40)
		{
			Object.Instantiate(EllenfelOt, new Vector3(7f, 2.25f, 5f), KezdoPont.rotation);
		}
		else if (ellenfelid < 49)
		{
			Object.Instantiate(EllenfelNegy, new Vector3(7f, 2.25f, 5f), KezdoPont.rotation);
		}
		else if (ellenfelid > 48 && ellenfelid < 68)
		{
			Object.Instantiate(EllenfelHat, new Vector3(7f, 2.25f, 5f), KezdoPont.rotation);
		}
		else
		{
			Object.Instantiate(EllenfelHet, new Vector3(7f, 2.25f, 5f), KezdoPont.rotation);
		}
	}
}