using UnityEngine;
using System.Collections;

namespace Completed
{   
	public class Loader : MonoBehaviour {
		public GameObject randomSeedManager;
		public GameObject gameManager;
		public GameObject soundManager;
		public GameObject scoreManager;


		void Awake () {
			if (RandomSeedManager.instance == null)
				Instantiate(randomSeedManager);
			if (GameManager.instance == null)
				Instantiate(gameManager);
			if (SoundManager.instance == null)
				Instantiate(soundManager);
			if (ScoreManager.instance == null)
				Instantiate(scoreManager);
			
		}
	}
}