using UnityEngine;

public class Bolt : MonoBehaviour
{
	public Tornyok toronyEgy;

	public Tornyok toronyKetto;

	public Tornyok toronyHarom;

	public Tornyok toronyNegy;

	public Tornyok toronyOt;

	public Tornyok toronyHat;

	private EpitesManager manager;

	private void Start()
	{
		manager = EpitesManager.hivatkozas;
	}

	public void alapToronyKivalasztas()
	{
		manager.KivalasztottToronyEpit(toronyEgy);
	}

	public void raketaToronyKivalasztas()
	{
		manager.KivalasztottToronyEpit(toronyKetto);
	}

	public void ijaszToronyKivalasztas()
	{
		manager.KivalasztottToronyEpit(toronyHarom);
	}

	public void agyuToronyKivalasztas()
	{
		manager.KivalasztottToronyEpit(toronyNegy);
	}

	public void lezerToronyKivalasztas()
	{
		manager.KivalasztottToronyEpit(toronyOt);
	}

	public void varazsloToronyKivalasztas()
	{
		manager.KivalasztottToronyEpit(toronyHat);
	}
}
