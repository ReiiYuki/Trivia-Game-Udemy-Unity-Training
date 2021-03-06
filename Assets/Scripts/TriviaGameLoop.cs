﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class TriviaGameLoop : MonoBehaviour {

	//This is struct which use for setup question
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
	//Current Question
	private Question currentQuestion;	
	public Button[] answerButtons;
	public Text questionText;

	private Question[] questions = new Question[10];
	private int currentQuestionIndex;
	private int[] questionNumbersChosen = new int[5];
	private int questionFinished;

	public GameObject[] TriviaPanels;
	public GameObject finalResultPanel;
	public Text resultText;
	private int numberOfCorrectAnswers;
	private bool allowSelection = true;
	public GameObject feedbackText;
	// Use this for initialization
	void Start () {
		for (int i = 0; i < questionNumbersChosen.Length; i++)
			questionNumbersChosen [i] = -1;
		questions [0] = new Question ("a", new string[]{"お","た","あ","ろ","の" },2);
		questions [1] = new Question ("も", new string[]{"chi","tsu","ha","ma","mo" },4);
		questions [2] = new Question ("wa", new string[]{"ね","れ","わ","か","ら" },2);
		questions [3] = new Question ("し", new string[]{ "chi","shi","mo","ho","no"},1);
		questions [4] = new Question ("ne", new string[]{"へ","ひ","め","ね","わ" },3);
		questions [5] = new Question ("ま", new string[]{"ma","chi","mo","to","ke" },0);
		questions [6] = new Question ("mi", new string[]{"ま","む","り","み","は" },3);
		questions [7] = new Question ("に", new string[]{"te","yu","re","ni","wa" },3);
		questions [8] = new Question ("ri", new string[]{"ね","ふ","よ","り","ろ" },3);
		questions [9] = new Question ("ぬ", new string[]{ "nu","me","ha","ni","ko"},0);
		ChooseQuestions ();
		AssignQuestion (questionNumbersChosen[0]);
	}

	// Update is called once per frame
	void Update () {
		quitGame ();
	}
	//Setting up the question to interface
	void AssignQuestion(int questionNum){
		currentQuestion = questions[questionNum];
		questionText.text = currentQuestion.questionText;
		for (int i = 0; i<answerButtons.Length; i++) {
			answerButtons [i].GetComponentInChildren<Text>().text = currentQuestion.answers [i];
		}
	}
	//Give feedback for answer
	//Move to next question
	public void checkAnswer(int buttonNum){
		if (allowSelection) {
			if (buttonNum == currentQuestion.correctAnswerIndex) {
				numberOfCorrectAnswers++;
				feedbackText.GetComponent<Text> ().text = "Correct!";
				feedbackText.GetComponent<Text> ().color = Color.green;
				print ("correct");
			} else {
				print ("incorrect");
				feedbackText.GetComponent<Text> ().text = "Wrong!";
				feedbackText.GetComponent<Text> ().color = Color.red;
			}
			StartCoroutine ("continueAfterFeedback");
		}
	}
	//Choosing number of the trivia game
	void ChooseQuestions(){
		for (int i = 0; i < questionNumbersChosen.Length; i++) {
			int questionNum = Random.Range (0, questions.Length);
			if (NumberNotContained (questionNumbersChosen, questionNum)) {
				questionNumbersChosen [i] = questionNum;
			} else {
				i--;
			}
		}
		currentQuestionIndex = Random.Range (0, questions.Length);
	}
	//checking see if random number already chosen
	bool NumberNotContained(int[] numbers,int num){	
		for (int i = 0; i < numbers.Length; i++) {
			if (numbers [i] == num)
				return false;
		}
		return true;
	}
	//assign new question using next question number
	public void  moveToNextQuestion(){
		AssignQuestion(questionNumbersChosen[questionNumbersChosen.Length-1-questionFinished]);
	}
	//set result of score to interface
	void DisplayResults(){
		switch (numberOfCorrectAnswers) {
		case 5:
			resultText.text = "5 / 5 GG EZ";
			break;
		case 4:
			resultText.text = "4 / 5 Close Enough";
			break;
		case 3:
			resultText.text = "3 / 5 At least you pass the half";
			break;
		case 2:
			resultText.text = "2 / 5 You shall not pass!!!";
			break;
		case 1:
			resultText.text = "1 / 5 Go to learn again...";
			break;
		case 0:
			resultText.text = "0 / 5 Please start hiragana T-T";
			break;
		default:
			resultText.text = "WTF happen!!!";
			break;
		}
	}
	//restart level
	public void restartLevel(){
		Application.LoadLevel (Application.loadedLevelName);
	}
	//pause before move to next question
	IEnumerator continueAfterFeedback(){
		allowSelection = false;
		feedbackText.SetActive (true);
		yield return new WaitForSeconds (1.0f);
		feedbackText.SetActive (false);
		if (questionFinished < questionNumbersChosen.Length - 1) {
			moveToNextQuestion ();
			questionFinished++;
		} else {
			foreach (GameObject p in TriviaPanels) {
				p.SetActive (false);
			}
			finalResultPanel.SetActive (true);
			DisplayResults ();
		}
		allowSelection = true;
	}
	//Check input quit game
	void quitGame(){
		if (Input.GetKeyDown (KeyCode.Escape)) {
			Application.Quit ();
		}
	}
}
