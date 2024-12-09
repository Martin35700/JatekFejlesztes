using System;
using UnityEngine;

[Serializable]
public class Tornyok
{
	public GameObject Prefab;

	public int Ar;

	public int EladasErtek()
	{
		return Ar / 2;
	}
}
