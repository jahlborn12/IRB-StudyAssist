using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
public class Score : MonoBehaviour 
{
	private static int currentScore=0;
	private static float newScore;
	private static int totalScore=0;

	public Text S;
	public Text T;
	public Text tBonus;
	public Text level;
	public GameObject MultipleC;
	public GameObject TrueFalse;
	public Text Catagory;
	public Text Descript;
	public GameObject Email;

	public Image scoreBar;
	public Image NscoreBar;
	public GameObject Background;
	public Image[] levelC;
	public Canvas pop;

	public float levelScore = 110;
	public GameObject board;
	public static int levelnum = 1;
	private static float dTime = 0;

	private bool Q1 = false;
	private bool Q2 = false;
	public static bool ready = false;

	private bool bonus = false;
	private static int B = 1;
	private static bool E = false;
	private static int N = 1;
	private static int week = 1;
	private static int month = System.DateTime.Now.Month;
	private static bool scored = false;

		
	// Use this for initialization
	void Start () 
	{
		totalScore = 0;
		currentScore = 0;
		levelnum = 1;
		Instantiate(board);
		Q1 = false;
		Q2 = false;	
		ready = false;
		tBonus.text = "No Active Bonus";
		if(month == 10) 		//SET TO EACH TEST PERIOD
		{
			week = 1;
		}
		Catagory.text = Questions.pickCatagory (week);
		updateD ();
		levelC[0].color = Questions.catagories[Questions.activeC].catC;
		levelC[1].color = Questions.catagories[Questions.activeC].catC;
		levelC[2].color = Questions.catagories[Questions.activeC].catC;
		levelC[3].color = Questions.catagories[Questions.activeC].catC;
		
		//Descript = GameObject.FindGameObjectWithTag ("Respawn").GetComponent<Text>();

	}
	
	// Update is called once per frame
	void Update () 
	{

		if (scored)
		{
			popScore ();
			scored = false;
		}
		 S.text = ((int)(currentScore *100 / levelScore)).ToString() + "%";
		 //S.text = currentScore.ToString();
		 T.text = totalScore.ToString();


		 NscoreBar.fillAmount = (float)currentScore / levelScore;

		if ((Time.time > dTime + 2) && (scoreBar.fillAmount < (float)currentScore / levelScore))
			scoreBar.fillAmount += ((float)currentScore / levelScore)/100;



		if ((((currentScore >= levelScore / 3)&&(currentScore < levelScore / 2)) || ((currentScore >= levelScore *4 / 5) && (currentScore < levelScore))) && (bonus)) //reset bonuses
		{
			B = 1;
			E = false;
			bonus = false;
			Gem.B = 0;
			tBonus.text = "No Active Bonus";
			tBonus.fontSize = 14; 
			tBonus.fontStyle = FontStyle.Normal;
		}
		if ((currentScore >= levelScore / 2) && (!Q1) && (levelnum <=5)) 
		{
			Q1 = true;
			//Questions.SpawnQ(MultipleC);
			Questions.SpawnQ(1,MultipleC,TrueFalse);
		}
		if ((currentScore >= levelScore) && (!Q2)) 
		{
			Q2 = true;
			Questions.SpawnQ(2,MultipleC,TrueFalse);

		}
		if((currentScore < levelScore*3/4))
		{
			ready = false;
		}
		if(ready && (currentScore >= levelScore))
		{
			newLevel();
		}
	}

	public static void Scoring (int gTemp)
	{
		int gems = gTemp;
		if (gTemp > 6) 
		{
			gTemp = 6;
		}

		if(E)
			gems = (int) Mathf.Pow (gems, 2) / 3;

		if (gems > 7) //Limit infinite scoring
		{
			gems -= 5;
		}
		if (gems > 7)
			gems = 7;


		newScore = B * N * (8+levelnum*2) * Mathf.Pow (1.5f, gems - 3);
		N = 1;

		currentScore += (int) (5*Mathf.Pow (1.25f, gTemp - 3)); // Seperate level progress from overall score
		totalScore += (int) newScore;

		scored = true;

		dTime = Time.time;
	}

	public void newLevel()
	{
		currentScore = 0;
		Destroy (GameObject.Find ("Board(Clone)"));
		Instantiate(board);

		levelnum++;
		levelScore = 150;
		scoreBar.fillAmount = 0;


		if(levelnum == 6) 
		{
			totalScore += 200;
			Email.GetComponent<Send>().SendEmailF();
			Application.LoadLevel("Win");
		}
		
		if (levelnum <= 5) 
		{
			Catagory.text = Questions.pickCatagory (week);
			level.text = "Category " + levelnum;
			levelC[0].color = Questions.catagories[Questions.activeC].catC;
			levelC[1].color = Questions.catagories[Questions.activeC].catC;
			levelC[2].color = Questions.catagories[Questions.activeC].catC;
			levelC[3].color = Questions.catagories[Questions.activeC].catC;
		}
		else
		{
			//Chose random colors/background
		}

		Q1 = false;
		Q2 = false;
		updateD ();
	}
	
	public void calcBonus()
	{
		float x = Random.Range (0, 7.5f);

				if (x < 1)
						B = 2;
				else if (x < 3)
						E = true;
				else if (x < 4)
						B = 3;
				else if (x < 5)
						Scoring (4+levelnum);
				else if (x < 6) 
						Scoring (6+levelnum);
				else if (x <= 7)
						N = 5;
				else if (x > 7)
						Gem.B = 3;

		if (x < 1)
			tBonus.text = "Score is being doubled.";
		else if (x < 3)
			tBonus.text = "Matches of 4+ are worth more.";
		else if (x < 4)
			tBonus.text = "Score is being tripled!";
		else if (x < 5)
			tBonus.text = "You got some bonus points.";
		else if (x < 6) 
			tBonus.text = "You got a lot of bonus points.";
		else if (x <= 7)
			tBonus.text = "Next match is quadrupled!";
		else if (x > 7)
			tBonus.text = "Less coin types will appear!";

		tBonus.fontSize = 20; 

		bonus = true;
	
	}

	public void updateD()
	{
		string s = 	Questions.catagories [Questions.activeC].description;
		Descript.text = s;
	}

	public void popScore()
	{
		pop.GetComponent<Text>().color = Color.green;
		pop.GetComponent<Text>().text = "+" + (int)newScore;
		Instantiate(pop, T.transform.position+new Vector3(0,-1,0), Quaternion.identity);
	}


		
}

