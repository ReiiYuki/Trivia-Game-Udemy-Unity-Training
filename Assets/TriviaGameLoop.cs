using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class TriviaGameLoop : MonoBehaviour {

	public struct Question{
		public string questionText;
		public string[] answers;
		public int correctAnswerIndex;
		public Question(string questionText, string[] answers,int correctAnswerIndex){
			this.questionText = questionText;
			this.answers = answers;
			this.correctAnswerIndex = correctAnswerIndex;
		}
	}
	public Question currentQuestion = new Question("What's your favourite color?",new string[]{"blue","red","yellow","white","black"},0);	
	public Button[] answerButtons;
	public Text questionText;
	// Use this for initialization
	void Start () {
		AssignQuestion ();
	}

	// Update is called once per frame
	void Update () {
	
	}

	void AssignQuestion(){
		questionText.text = currentQuestion.questionText;
		for (int i = 0; i<answerButtons.Length; i++) {
			answerButtons [i].GetComponentInChildren<Text>().text = currentQuestion.answers [i];
		}
	}

	public void checkAnswer(int buttonNum){
		if (buttonNum == currentQuestion.correctAnswerIndex) {
			print ("correct");
		} else {
			print ("incorrect");
		}
	}
}
