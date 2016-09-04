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
	private Question currentQuestion;	
	public Button[] answerButtons;
	public Text questionText;

	private Question[] questions = new Question[10];
	private int currentQuestionIndex;
	// Use this for initialization
	void Start () {

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
		currentQuestion = questions [currentQuestionIndex];
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

	void ChooseQuestions(){
		currentQuestionIndex = Random.Range (0, questions.Length);
	}
}
