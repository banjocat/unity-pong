using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public static class GameData
{
	public static int LeftScore;
	public static int RightScore;
	public static KeyCode LeftUp = KeyCode.UpArrow;
	public static KeyCode LeftDown = KeyCode.DownArrow;
	public static KeyCode RightUp = KeyCode.A;
	public static KeyCode RightDown = KeyCode.Z;
	public static int LeftPlayerType = 0;
	public static int RightPlayerType = 1;
	public static int PointsToWin = 2;


	public static KeyCode[] GetKeyCodesForSide(string side)
	{
		if (side == "left")
		{
			return new KeyCode[] {LeftUp, LeftDown};
		}
		if (side == "right")
		{
			return new KeyCode[] {RightUp, RightDown};
		}
		throw new Exception("Invalide side");
	}

	public static void Score(string direction)
	{
		if (direction == "left")
		{
			RightScore += 1;
			Debug.Log("Right scored");
		}
		else
		{
			LeftScore += 1;
			Debug.Log("Left scored");
		}
		SetCountText();
		Ball.ResetBall();
		CheckWinner();
	}

	private static void SetCountText()
	{
		var countObject = GameObject.Find("Score");
		var countText = countObject.GetComponent<Text>();
		countText.text = LeftScore.ToString() + " " + RightScore.ToString();
	}

	static void SetGameMessage(string message)
	{
		var messageObject = GameObject.Find("Message");
		var messageText = messageObject.GetComponent<Text>();
		messageText.text = message;
	}
	static void CheckWinner()
	{
		bool gameOver = false;
		// TODO Add player message on who won
		if (LeftScore >= PointsToWin)
		{
			SetGameMessage("Left Player Wins!");
			gameOver = true;
		}
		else if (RightScore >= PointsToWin)
		{
			SetGameMessage("Right Player Wins!");
			gameOver = true;
		}
		if (gameOver)
		{
			Debug.Log("Gameover");
			LeftScore = 0;
			RightScore = 0;
			SetCountText();
			SceneManager.LoadScene("game");
		}
	}

}
