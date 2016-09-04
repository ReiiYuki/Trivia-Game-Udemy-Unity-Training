using UnityEngine;
using System.Collections;

public class TriviaGameLoop : MonoBehaviour {

	public struct Question{
		public string questionText;
		public string[] answers;
		public Question(string questionText, string[] answers){
			this.questionText = questionText;
			this.answers = answers;
		}
	}
	public Question testQuestion = new Question("What's your favourite color?",new string[]{"blue","red","yellow"});	
	// Use this for initialization
	void Start () {
		print (testQuestion.questionText+" "+testQuestion.answers[0]);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
