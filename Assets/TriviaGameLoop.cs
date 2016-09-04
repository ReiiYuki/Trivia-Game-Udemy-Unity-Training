using UnityEngine;
using System.Collections;

public class TriviaGameLoop : MonoBehaviour {

	public struct Question{
		public string questionText;
		public Question(string questionText){
			this.questionText = questionText;
		}
	}
	public Question testQuestion = new Question("What's your favourite color?");	
	// Use this for initialization
	void Start () {
		print (testQuestion.questionText);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
