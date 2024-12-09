using UnityEngine;
using UnityEngine.UI;

public class Kezelo : MonoBehaviour
{
	public static bool jatekVege;

	public GameObject vegeVanUI;

	public Text cimSzoveg;

	public AudioManager manager;

	private void Start()
	{
		manager.HangeroModosit(BeallitasokMenu.jelenlegiHangero);
		jatekVege = false;
	}

	private void Update()
	{
		if (!jatekVege)
		{
			if (Valuta.HpSzam <= 0)
			{
				VegeVan();
			}
			if (UjKor.aktualisKor > 49)
			{
				VegeVan();
				cimSzoveg.text = "Nyertél!";
			}
		}
	}

	public void VegeVan()
	{
		jatekVege = true;
		vegeVanUI.SetActive(value: true);
	}
}
