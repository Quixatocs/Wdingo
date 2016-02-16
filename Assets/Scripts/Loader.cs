using UnityEngine;
using System.Collections;

namespace Completed
{   
	public class Loader : MonoBehaviour 
	{
		public GameObject gameManager;
		public GameObject scoreManager;


		void Awake () {
			if (GameManager.instance == null)
				Instantiate(gameManager);
			if (ScoreManager.instance == null)
				Instantiate(scoreManager);
			
		}
	}
}