using UnityEngine;
using System.Collections;

public class roomMan : Photon.MonoBehaviour {

	public string verNum = "0.1";
	public string roomName = "room01";
	public Transform spawnPoint;
	public GameObject playerPref; 
	public bool isConnected = false;


	void Start() {
		PhotonNetwork.ConnectUsingSettings (verNum);
		Debug.Log ("Olha como ele vai conectado em rede");
	}

	public void OnJoinedLobby() {
		PhotonNetwork.JoinOrCreateRoom (roomName, null, null); //ver esses 2 nulls
		Debug.Log ("Olha como ele inicia o server...");
	}

	public void OnJoinedRoom() {
		isConnected = true;
		spawnPlayer ();
		Debug.Log ("Entrando em sala...");
	}

	public void spawnPlayer() {
		GameObject pl = PhotonNetwork.Instantiate (playerPref.name, spawnPoint.position, spawnPoint.rotation, 0) as GameObject; //depois ver esse 0
		pl.GetComponent<RigidBodyFPSWalker> ().enabled = true;
		pl.GetComponent<RigidBodyFPSWalker> ().fpsCam.SetActive (true);
		Debug.Log ("Rodou a sala e carregou os components");
	}

}
