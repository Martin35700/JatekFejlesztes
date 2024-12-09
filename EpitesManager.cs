using UnityEngine;
using UnityEngine.UI;

public class EpitesManager : MonoBehaviour
{
	public static EpitesManager hivatkozas;

	private Tornyok epiteniValoTorony;

	private Mezo kivalasztottMezo;

	public Text penzMennyisegSzoveg;

	public MezoUI mezoUI;

	public bool LehetEpiteni => epiteniValoTorony != null;

	public bool VanElegPenz => Valuta.Penz >= epiteniValoTorony.Ar;

	private void Awake()
	{
		if (!(hivatkozas != null))
		{
			hivatkozas = this;
		}
	}

	public void KivalasztMezo(Mezo mezo)
	{
		if (kivalasztottMezo == mezo)
		{
			KivalasztasEltavolit();
			return;
		}
		kivalasztottMezo = mezo;
		epiteniValoTorony = null;
		mezoUI.celpontBeallit(mezo);
	}

	public void KivalasztasEltavolit()
	{
		kivalasztottMezo = null;
		mezoUI.Elrejt();
	}

	public void KivalasztottToronyEpit(Tornyok torony)
	{
		epiteniValoTorony = torony;
		KivalasztasEltavolit();
	}

	public Tornyok epiteniValoToronyAtad()
	{
		return epiteniValoTorony;
	}
}