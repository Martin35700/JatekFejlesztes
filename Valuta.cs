using UnityEngine;

public class Valuta : MonoBehaviour
{
	public static int Penz;

	public int kezdoPenz = 1000000;

	public static int HpSzam;

	public int kezdoHp = 5;

	private void Start()
	{
		Penz = kezdoPenz;
		HpSzam = kezdoHp;
	}
}