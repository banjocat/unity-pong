using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSelector : MonoBehaviour
{

	private Dropdown _dropdown;
	private GameObject _keysettings;

	void Start()
	{
		var dropdownTransform = transform.Find("Keysettings");
		_dropdown = GetComponent<Dropdown>();
		_keysettings = dropdownTransform.gameObject;
		_dropdown.value = _dropdown.value;
		TogglePlayerKeys();
	}

	public void TogglePlayerKeys ()
	{
		if (_dropdown.value == 0)
		{
			_keysettings.SetActive(true);
		}
		else
		{
			_keysettings.SetActive(false);
		}
	}
}
