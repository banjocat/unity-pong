using System;
using UnityEngine;
using UnityEngine.UI;

public class SettingMovement : MonoBehaviour
{

	public string Side;

	private string _captureText = "";
	private Text _moveUp;
	private Text _moveDown;
	private KeyCode[] _keycodes;

	// Use this for initialization
	void Start ()
	{
		_keycodes = GameData.GetKeyCodesForSide(Side);
		_moveUp = transform.Find("MoveUp").Find("Text").GetComponent<Text>();
		_moveDown = transform.Find("MoveDown").Find("Text").GetComponent<Text>();
		SetKeysValues();
	}

	public void StartCapture(string direction)
	{
		if (_captureText != "") return;
		var message = "Press key to capture";
		if (direction == "up")
		{
			_moveUp.text = message;
		}
		else
		{
			_moveDown.text = message;
		}
		_captureText = direction;
	}
	public void SetKeysValues()
	{
		_moveUp.text = "Up: " + _keycodes[0].ToString();
		_moveDown.text = "Down: " + _keycodes[1].ToString();
	}

	KeyCode GetFirstKeyPressed()
	{
		KeyCode found = KeyCode.Delete;
		foreach (KeyCode kcode in Enum.GetValues(typeof(KeyCode)))
		{
			if (!Input.GetKeyDown(kcode)) continue;
			found = kcode;
			break;
		}
		Debug.Log("Found key: " + found.ToString());
		return found;
	}
	// Update is called once per frame
	void Update ()
	{
		if (_captureText == "") return;
		if (!Input.anyKey) return;
		if (_captureText == "up")
		{
			_keycodes[0] = GetFirstKeyPressed();
		}
		else if (_captureText == "down")
		{
			_keycodes[1] = GetFirstKeyPressed();
		}
		else
			throw new Exception("Invalid _capture text: " + _captureText);
		if (Side == "left")
		{
			GameData.LeftUp = _keycodes[0];
			GameData.LeftDown = _keycodes[1];
		}
		else if (Side == "right")
		{
			GameData.RightUp = _keycodes[0];
			GameData.RightDown = _keycodes[1];
		}
		else
			throw new Exception("Invalide Side: " + Side);
		SetKeysValues();
		_captureText = "";
	}
}
