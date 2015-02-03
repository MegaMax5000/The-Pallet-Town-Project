using UnityEngine;
using System.Collections;

public class Utility 
{
	private static Utility _instance;
	public static Utility Instance
	{
		get
		{
			if (_instance == null) 
			{
				_instance = new Utility ();
			}
			return _instance;
		}
	}



	public void DrawHealthbar()
	{
		Debug.Log ("Whatever");

	}

}
