using UnityEngine;
using System.Collections;

public class TriviaGameLoop : MonoBehaviour {

	public struct Question{
		public string questionText;
	}
	public Question testQuestion;	
	public test varTest;
	// Use this for initialization
	void Start () {
		testQuestion.questionText = "What's your name ?";
		varTest.age = 10;
		test tempTest = varTest;
		Question tempQuestion = testQuestion;
		tempTest.age = 12;
		tempQuestion.questionText = "What's your age?";
		 print (testQuestion.questionText+varTest.age);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
