﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FedeEvent : RandomEvent {

	public string Name     = "Fede";
	public string Avatar   = "nikita.jpg";
	public string Message  = "Fede's Russian clone strikes again";

	public override void Fire() {
		Debug.Log (string.Format("Firing {0}!", Name));

		var players = GameObject.FindObjectsOfType<PlayerMovement> ();

		Vector3 newPosition = players [players.Length - 1].transform.position;

		foreach (var player in players) {
			Vector3 oldPosition = player.transform.position;

			player.transform.position = newPosition;

			newPosition = oldPosition;
		}
	}
}