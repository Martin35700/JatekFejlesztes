using UnityEngine;
using UnityEngine.UI;

public class MezoUI : MonoBehaviour
{
	private Mezo celpont;

	public GameObject ui;

	public Text eladasErtek;

	public void celpontBeallit(Mezo _celpont)
	{
		celpont = _celpont;
		base.transform.position = celpont.seged();
		eladasErtek.text = "<b>Eladás</b> $" + celpont.jelenlegi.EladasErtek();
		ui.SetActive(value: true);
	}

	public void Elrejt()
	{
		ui.SetActive(value: false);
	}

	public void Elad()
	{
		celpont.EladTorony();
		EpitesManager.hivatkozas.KivalasztasEltavolit();
	}
}