using UnityEngine;

public class IranyjelzokScript : MonoBehaviour
{
	public static Transform[] iranyjelzok;

	private void Awake()
	{
		iranyjelzok = new Transform[base.transform.childCount];
		for (int i = 0; i < iranyjelzok.Length; i++)
		{
			iranyjelzok[i] = base.transform.GetChild(i);
		}
	}
}
