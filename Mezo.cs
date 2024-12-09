using UnityEngine;
using UnityEngine.EventSystems;

public class Mezo : MonoBehaviour
{
	public Color ujSzin;

	private Color kezdoSzin;

	public Vector3 offset;

	public GameObject torony;

	public Tornyok jelenlegi;

	private Renderer rend;

	private EpitesManager manager;

	private void Start()
	{
		rend = GetComponent<Renderer>();
		kezdoSzin = rend.material.color;
		manager = EpitesManager.hivatkozas;
	}

	public Vector3 seged()
	{
		return base.transform.position + offset;
	}

	private void OnMouseDown()
	{
		if (torony != null)
		{
			manager.KivalasztMezo(this);
		}
		else if (manager.LehetEpiteni)
		{
			ToronyEpit(manager.epiteniValoToronyAtad());
		}
	}

	private void ToronyEpit(Tornyok _torony)
	{
		if (Valuta.Penz >= _torony.Ar)
		{
			Valuta.Penz -= _torony.Ar;
			manager.penzMennyisegSzoveg.text = "$" + Valuta.Penz;
			GameObject gameObject = Object.Instantiate(_torony.Prefab, seged(), Quaternion.identity);
			torony = gameObject;
			jelenlegi = _torony;
		}
	}

	private void OnMouseEnter()
	{
		if (!EventSystem.current.IsPointerOverGameObject() && manager.LehetEpiteni)
		{
			if (manager.VanElegPenz)
			{
				rend.material.color = ujSzin;
			}
			else
			{
				rend.material.color = Color.red;
			}
		}
	}

	public void EladTorony()
	{
		Valuta.Penz += jelenlegi.EladasErtek();
		Object.Destroy(torony);
		jelenlegi = null;
	}

	private void OnMouseExit()
	{
		rend.material.color = kezdoSzin;
	}
}