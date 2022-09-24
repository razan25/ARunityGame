using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MathProblem: MonoBehaviour {
  // Start is called before the first frame update

  public Text firstNumber;
  public Text secondNumber;
  public Text answer1;
  public Text answer2;
  public Text answer3;
  public Text answer4;

  public List < int > easyMathList = new List < int > ();

  public int randomFirstNumber;
  public int randomSecondNumber;

  int firstNumberInProblem;
  int secondNumberInProblem;
  int answerOne;
  int answerTwo;
  int answerThree;
  int answerFour;
  int displayRandomAnswer;
  int randomAnswerPlacement;
  public int currentAnswer;
  public Text rightOrWrong_Text;
  public int count = 10; //اذا طلعت 10 اسئلة يوقف

  //Scoring (counter)
  public int additionScore = 0;
  public Text score;
  public Text result;
  public GameObject displayWindow;
  
  //Result Window
  public Text completeText;
  //public Text resultScore;
  public Button replayButton;
  public Button backButton;
  public GameObject[] star ;
  private int countPoints;
  
  public Transform stars; //filled stars depends on the score
  protected const int fillStars = 100/3; //calculate how much we fill the star depends on the score
  public bool useFillAmount = false; //??
  
  private void Start() {
    DisplayMathProblem();
    // countPoints =GameObject.FindGameObjectsWithTag("Points").Length;

  }

public GameObject LevelDialog;
public Text LevelStatus;
public Text scoreText; 
public void ShowLevelDialog(string status,string scores){
  GetComponent<MathProblem>().starArcheived();
  LevelDialog.SetActive(true);
  LevelStatus.text=status;
  scoreText.text=scores;


}
  //The question generator method
  public void DisplayMathProblem() {

    //first number
    randomFirstNumber = Random.Range(0, easyMathList.Count + 1);
    //second number
    randomSecondNumber = Random.Range(0, easyMathList.Count + 1);
    firstNumberInProblem = randomFirstNumber;
    secondNumberInProblem = randomSecondNumber;

    //the correct answer option is to calculate the first and second number
    answerOne = firstNumberInProblem + secondNumberInProblem;

    displayRandomAnswer = Random.Range(0, 2);
    if (displayRandomAnswer == 0) {
      answerTwo = answerOne + Random.Range(1, 3);
      answerThree = answerOne + Random.Range(4, 6);
      answerFour = answerOne + Random.Range(7, 9);
    } else {

      answerTwo = answerOne - Random.Range(1, 3);

      answerThree = answerOne - Random.Range(4, 6);

      answerFour = answerOne - Random.Range(7, 9);

      // عشان نشيل الاعداد السالبة من الخيارات
      if (answerTwo < 0) {
        answerTwo = Mathf.Abs(answerTwo);
        answerTwo = answerOne + Random.Range(1, 3);
      }
      if (answerThree < 0) {
        answerThree = Mathf.Abs(answerThree);
        answerThree = answerOne + Random.Range(4, 6);
      }
      if (answerFour < 0) {
        answerFour = Mathf.Abs(answerFour);
        answerFour = answerOne + Random.Range(7, 9);
      }
    }
    firstNumber.text = "" + firstNumberInProblem;
    secondNumber.text = "" + secondNumberInProblem;
    randomAnswerPlacement = Random.Range(0, 4);

    //randomization to the correct answer to be displayed in different option place everytime

    //if the place is 0, place the correct answer at place (position/index) 0 (first option)...and so on
    if (randomAnswerPlacement == 0) {
      answer1.text = "" + answerOne;
      answer2.text = "" + answerTwo;
      answer3.text = "" + answerThree;
      answer4.text = "" + answerFour;
      currentAnswer = 0;
    } else if (randomAnswerPlacement == 1) {
      answer1.text = "" + answerTwo;
      answer2.text = "" + answerOne;
      answer3.text = "" + answerFour;
      answer4.text = "" + answerThree;
      currentAnswer = 1;

    } else if (randomAnswerPlacement == 2) {

      answer1.text = "" + answerThree;
      answer2.text = "" + answerFour;
      answer3.text = "" + answerOne;
      answer4.text = "" + answerTwo;
      currentAnswer = 2;
    } else {
      answer1.text = "" + answerThree;
      answer2.text = "" + answerFour;
      answer3.text = "" + answerTwo;
      answer4.text = "" + answerOne;
      currentAnswer = 3;
    }

  }






//method to calculate the score and print it on screen
public void AddScore(){
  additionScore+=1;
  score.text= "" + additionScore;
}


  // method to call when there is no questions to display to show the score    
  public void DisplayFinalScore() {

    //display message for excellent score   
    if (additionScore >= 7) {
      result.text = "Excellent! Your Score is " + additionScore;
    }

    //display message for good score
    if (additionScore >= 4 && additionScore <= 6) {
     result.text = "Good! Your Score is " + additionScore;
    }

    //display message for bad score
    if (additionScore <= 3) {
     result.text = "Try Again! Your Score is " + additionScore;
    }

  }
public void starArcheived(){
//  int starLeft = GameObject.FindGameObjectsWithTag("Points").Length;
//  int pointsCollected = additionScore-starLeft;
//  float percentage =float.Parse(pointsCollected.ToString())/float.Parse(additionScore.ToString())*100f;
 if(additionScore>= 1 && additionScore<4){
  //one star 
  star[0].SetActive(true);
 }
 else if (additionScore >= 4 && additionScore <7){
  //two stars
  star[0].SetActive(true);
  star[1].SetActive(true);
 }
 else if(additionScore >= 7 && additionScore <=10){
  //three stars
  star[0].SetActive(true);
  star[1].SetActive(true);
  star[2].SetActive(true);
 }

}



  //option answer 1
  public void ButtonAnswer1() {
    if (currentAnswer == 0) {
      rightOrWrong_Text.enabled = true;
      rightOrWrong_Text.color = Color.green;
      rightOrWrong_Text.text = ("✔");
      //additionScore++;
      AddScore();
      Invoke("TurnOffText", 1);
    } else {
      rightOrWrong_Text.enabled = true;
      rightOrWrong_Text.color = Color.red;
      rightOrWrong_Text.text = ("✕");
      Invoke("TurnOffText", 1);
    }
  }

  //option answer 2
  public void ButtonAnswer2() {
    if (currentAnswer == 1) {
      rightOrWrong_Text.enabled = true;
      rightOrWrong_Text.color = Color.green;
      rightOrWrong_Text.text = ("✔");
      //additionScore++;
      AddScore();
      Invoke("TurnOffText", 1);
    } else {
      rightOrWrong_Text.enabled = true;
      rightOrWrong_Text.color = Color.red;
      rightOrWrong_Text.text = ("✕");
      Invoke("TurnOffText", 1);
    }
  }

  //option answer 3
  public void ButtonAnswer3() {
    if (currentAnswer == 2) {
      rightOrWrong_Text.enabled = true;
      rightOrWrong_Text.color = Color.green;
      rightOrWrong_Text.text = ("✔");
      //additionScore++;
      AddScore();
      Invoke("TurnOffText", 1);
    } else {
      rightOrWrong_Text.enabled = true;
      rightOrWrong_Text.color = Color.red;
      rightOrWrong_Text.text = ("✕");
      Invoke("TurnOffText", 1);
    }
  }

  //option answer 4
  public void ButtonAnswer4() {
    if (currentAnswer == 3) {
      rightOrWrong_Text.enabled = true;
      rightOrWrong_Text.color = Color.green;
      rightOrWrong_Text.text = ("✔");
      //additionScore++;
      AddScore();
      Invoke("TurnOffText", 1);
    } else {
      rightOrWrong_Text.enabled = true;
      rightOrWrong_Text.color = Color.red;
      rightOrWrong_Text.text = ("✕");
      Invoke("TurnOffText", 1);
    }
  }

  public void TurnOffText() {
    if (rightOrWrong_Text != null) {
      rightOrWrong_Text.enabled = false;
    }
    //decreasing the counter till 0 so no more questions to display
    count = count - 1;

    //if counter (count) of questions is not 0 yet, display questions
    if (count > 0)
      DisplayMathProblem();

    //if the counter reaches 0 (no more questions), display the score
    else {
       displayWindow.SetActive(true);
      DisplayFinalScore();
      starArcheived();
    }
  }

}