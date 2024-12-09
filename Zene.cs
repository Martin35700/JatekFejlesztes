using System;
using UnityEngine;

[Serializable]
public class Zene
{
	public string nev;

	public AudioClip zene;

	[Range(0f, 1f)]
	public float hangero;

	[Range(0.1f, 3f)]
	public float hangmagassag;

	public bool loop;

	[HideInInspector]
	public AudioSource forras;
}
