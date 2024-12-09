using UnityEngine;
using UnityEngine.UI;

public class UiHelper : MonoBehaviour
{
	public Text penzMennyisegSzoveg;

	public Text hpMennyisegSzoveg;

	public Text korMennyisegSzoveg;

	private void Start()
	{
	}

	private void Update()
	{
		penzMennyisegSzoveg.text = "$" + Valuta.Penz;
		hpMennyisegSzoveg.text = "HP: " + Valuta.HpSzam;
		korMennyisegSzoveg.text = "Kör: " + (UjKor.aktualisKor + 1);
	}
}
