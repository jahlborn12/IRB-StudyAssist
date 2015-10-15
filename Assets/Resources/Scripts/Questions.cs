using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
public class IRBc
{
	public string name;
	public string description;
	public IRBq[] Qs = {new IRBq(), new IRBq()};
	public Color catC;

	public IRBc(string nm)
	{
		name = nm;

		if (name == "Research Subjects")
		{
			catC = new Color(1,1,1,.8f); //White
			description = "A research subject is a living individual about whom an investigator conducting research obtains (1) data through intervention or interaction with the individual, or (2) their identifiable private information.";
		}
		else if (name == "Research Investigators")
		{
			catC = new Color(.85f,.45f,0,.8f); //orange
			description = "Research Investigators use a systematic process to collect and analyze information to increase understanding of a topic or issue.";
		}
		else if (name == "IRB")
		{
			catC = new Color(.4f,.15f,.5f,.8f); //purple
			description = "An Institutional Review Board (IRB) is a committee that performs ethical review of proposed research with human subjects.";
		}
		else if (name == "Research Data")
		{
			catC = new Color(.6f,.6f,.6f,.8f); //grey
			description = "Research Data is information collected from or about research subjects that is personally identifiable.";
		}
		else if (name == "Consent")
		{
			catC = new Color(0,.3f,0,.8f); //green
			description = "Research Subjects must willingly consent to be participate in the research.";
		}
		else if (name == "Regulations")
		{
			catC = new Color(.55f,.06f,0,.8f); //dark red
			description = "Research Subjects must willingly consent to be participate in the research.";
		}
		else if (name == "Procedures")
		{
			catC =  new Color(1,.9f,.02f,.8f); //yellow
			description = "Research Subjects must willingly consent to be participate in the research.";
		}
		else if (name == "Research Ethics")
		{
			catC = new Color(0,.2f,.6f,.8f); //Blue
			description = "Research Subjects must willingly consent to be participate in the research.";
		}
		else 
		{
			description = "Error retriving description";
		}
	}
}
public class IRBq
{
	public string text = "placeholder";
	public string type = "M";
	public string answer = "A";
	public string difficulty= "1";
	public string[] choice = {"","","",""};
	
	public IRBq()
	{
	}
}
public class Questions: MonoBehaviour 
{
	//int correct = 1;
	public GameObject S;
	public Button A;
	public Button B;
	public Button C = null;
	public Button D = null;
	public Button O;
	public Text T;
	public Canvas iTxt;
	public GameObject aud;

	public static int activeC = 0;
	public static int activeN = 0;

	public static IRBc[] catagories = {new IRBc("Research Subjects"), new IRBc("Research Investigators"), new IRBc("IRB"), new IRBc("Procedures"), 
		new IRBc("Consent"), new IRBc("Regulations"), new IRBc( "Research Data"), new IRBc("Research Ethics")};
	//put chosen back in the class
	public static bool[] chosen = {false,false,false,false,false,false,false,false};

	// Use this for initialization
	void Start () 
	{
		S = GameObject.Find ("Canvas");
		O.GetComponentInChildren<Text>().text = "Select an Answer";
		
		T.GetComponent<Text>().text = catagories[activeC].Qs[activeN].text;
		A.GetComponentInChildren<Text>().text = catagories[activeC].Qs[activeN].choice[0];
		B.GetComponentInChildren<Text>().text = catagories[activeC].Qs[activeN].choice[1];

		if(catagories[activeC].Qs[activeN].type == "M")
		{
			C.GetComponentInChildren<Text>().text = catagories[activeC].Qs[activeN].choice[2];
			D.GetComponentInChildren<Text>().text = catagories[activeC].Qs[activeN].choice[3];
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	public void clickA()
	{
		
		O.GetComponentInChildren<Text>().text = "Continue";
		if (catagories [activeC].Qs [activeN].answer == "A") 
		{
			iTxt.GetComponent<Text>().color = Color.green;
			iTxt.GetComponent<Text>().text = "Correct";
			aud.GetComponent<AudioSource>().Play ();
			Instantiate(iTxt, S.transform.position+new Vector3(2,3,0), Quaternion.identity);
			S.GetComponent<Score> ().calcBonus ();
		}
		else
		{
			iTxt.GetComponent<Text>().text = "Incorrect";
			iTxt.GetComponent<Text>().color = Color.red;
			Instantiate(iTxt, S.transform.position+new Vector3(2,3,0), Quaternion.identity);
		}
	}
	public void clickB()
	{
		O.GetComponentInChildren<Text>().text = "Continue";
		if (catagories [activeC].Qs [activeN].answer == "B") 
		{
			iTxt.GetComponent<Text>().color = Color.green;
			iTxt.GetComponent<Text>().text = "Correct";
			
			aud.GetComponent<AudioSource>().Play ();
			Instantiate(iTxt, S.transform.position+new Vector3(2,3,0), Quaternion.identity);
			S.GetComponent<Score> ().calcBonus ();
		}
		else
		{
			iTxt.GetComponent<Text>().text = "Incorrect";
			iTxt.GetComponent<Text>().color = Color.red;
			Instantiate(iTxt, S.transform.position+new Vector3(2,3,0), Quaternion.identity);
		}
	}
	public void clickC()
	{
		O.GetComponentInChildren<Text>().text = "Continue";
		if (catagories [activeC].Qs [activeN].answer == "C") 
		{ 
			iTxt.GetComponent<Text>().color = Color.green;
			iTxt.GetComponent<Text>().text = "Correct";
			aud.GetComponent<AudioSource>().Play ();
			Instantiate(iTxt, S.transform.position+new Vector3(2,3,0), Quaternion.identity);
			S.GetComponent<Score> ().calcBonus ();
		}
		else
		{
			iTxt.GetComponent<Text>().color = Color.green;
			iTxt.GetComponent<Text>().text = "Incorrect";
			iTxt.GetComponent<Text>().color = Color.red;
			Instantiate(iTxt, S.transform.position+new Vector3(2,3,0), Quaternion.identity);
		}
	}
	public void clickD()
	{
		O.GetComponentInChildren<Text>().text = "Continue";
		if (catagories [activeC].Qs [activeN].answer == "D") 
		{ 
			iTxt.GetComponent<Text>().color = Color.green;
			iTxt.GetComponent<Text>().text = "Correct";
			aud.GetComponent<AudioSource>().Play ();
			Instantiate(iTxt, S.transform.position+new Vector3(2,3,0), Quaternion.identity);
			S.GetComponent<Score> ().calcBonus ();

		}
		else
		{
			iTxt.GetComponent<Text>().text = "Incorrect";
			iTxt.GetComponent<Text>().color = Color.red;
			Instantiate(iTxt, S.transform.position+new Vector3(2,3,0), Quaternion.identity);
		}

	}
	public void click()
	{
		A.image.color = Color.red;
		B.image.color = Color.red;
		C.image.color = Color.red;
		D.image.color = Color.red;
		O.image.color = Color.white;


		if(catagories[activeC].Qs[activeN].answer == "A")
			A.image.color = Color.green;
		if(catagories[activeC].Qs[activeN].answer == "B")
			B.image.color = Color.green;
		if(catagories[activeC].Qs[activeN].answer == "C")
			C.image.color = Color.green;
		if(catagories[activeC].Qs[activeN].answer == "D")
			D.image.color = Color.green;

		A.interactable = false;
		B.interactable = false;
		C.interactable = false;
		D.interactable = false;
		
		O.GetComponentInChildren<Text>().text = "Continue";
		O.interactable = true;
		Score.ready = true;

	}


	public static void SpawnQ(int n, GameObject qm,GameObject qt)
	{
		activeN = n - 1;
			if(catagories[activeC].Qs[activeN].type == "T")
			{
				Instantiate (qt);
			}
			else
				Instantiate (qm);

	}
	public void endQ(GameObject q)
	{
		Destroy (q);
	}

	public static string pickCatagory(int week)
	{
		int num, r1=5,r2=6,r3=7; 

		//Time based catagory choosing
		//two of each except one 4
		if(week == 1)
		{
			r1 = 5; r2=3; r3=7;
		}
		if(week == 2)
		{
			r1 = 5; r2=2; r3=4;
		}
		if(week == 3)
		{
			r1 = 7; r2=1; r3=0;
		}
		if(week == 4)
		{
			r1 = 6; r2=2; r3=0;
		}
		if(week == 5)
		{
			r1 = 3; r2=1; r3=6;
		}




		do
		{
			num = Random.Range (0,8);
		}while(chosen[num] || num == r1 || num == r2 || num == r3);

		//num = 0;
		chosen[num] = true;
		buildQ(catagories[num].name,num,week);
		activeC = num;



		return catagories [num].name;
	}
	public static void buildQ(string C,int num, int week)
	{
		int temp;
		//string text = System.IO.File.ReadAllText(@"C:\Users\Josh\Desktop\MatchThree1\Assets\Source Files\QuestionsW1.txt");
		string text = weekQs(week);
		//string text = callQuestions();

		int start1 = text.IndexOf(C+"|") + C.Length;
		int start2 = text.IndexOf(C+"|",start1+1) + C.Length;

		catagories [num].Qs[0].type = text.Substring (start1 + 1, 1);
		catagories [num].Qs[0].text = text.Substring (start1 + 3, text.IndexOf("|",start1+4)-start1-3);

		temp = text.IndexOf ("|", start1 + 4)+1;
		catagories [num].Qs[0].choice[0] = text.Substring (temp, text.IndexOf("|",temp)-temp);
		temp = text.IndexOf("|",temp+1)+1;
		catagories [num].Qs[0].choice[1] = text.Substring (temp, text.IndexOf("|",temp)-temp);

		if(catagories [num].Qs[0].type == "M")
		{
			temp = text.IndexOf("|",temp+1)+1;
			catagories [num].Qs[0].choice[2] = text.Substring (temp, text.IndexOf("|",temp)-temp);
			temp = text.IndexOf("|",temp+1)+1;
			catagories [num].Qs[0].choice[3] = text.Substring (temp, text.IndexOf("|",temp)-temp);
		}

		temp = text.IndexOf("|",temp+1)+1;
		catagories[num].Qs[0].difficulty =  text.Substring (temp, 1);
		temp = text.IndexOf("|",temp+1)+1;
		catagories[num].Qs[0].answer =  text.Substring (temp, 1);

		//Build Question 2

		catagories [num].Qs[1].type = text.Substring (start2 + 1, 1);
		catagories [num].Qs[1].text = text.Substring (start2 + 3, text.IndexOf("|",start2+4)-start2-3);
		
		temp = text.IndexOf ("|", start2 + 4)+1;
		catagories [num].Qs[1].choice[0] = text.Substring (temp, text.IndexOf("|",temp)-temp);
		temp = text.IndexOf("|",temp+1)+1;
		catagories [num].Qs[1].choice[1] = text.Substring (temp, text.IndexOf("|",temp)-temp);
		
		if(catagories [num].Qs[1].type == "M")
		{
			temp = text.IndexOf("|",temp+1)+1;
			catagories [num].Qs[1].choice[2] = text.Substring (temp, text.IndexOf("|",temp)-temp);
			temp = text.IndexOf("|",temp+1)+1;
			catagories [num].Qs[1].choice[3] = text.Substring (temp, text.IndexOf("|",temp)-temp);
		}
		
		temp = text.IndexOf("|",temp+1)+1;
		catagories[num].Qs[1].difficulty =  text.Substring (temp, 1);
		temp = text.IndexOf("|",temp+1)+1;
		catagories[num].Qs[1].answer =  text.Substring (temp, 1);
		
			
		//int first = text.IndexOf("methods") + "methods".Length;
		//int next = text.IndexOf("methods",first);
		//string str2 = text.Substring(first, next - first);
	}

	public static string weekQs(int week)
	{
		if(week == 1)
			return ("Research Subjects|T|A vulnerable subject is a person who has diminished capacity to give consent.|True|False|1|A\n " +
				"Research Subjects|M|Vulnerable subjects require special protection.  A vulnerable subject may be:|A person who has limited intellectual capacity|A person under the age of consent|A person who has limited purchasing power|All of the above|1|D\n " +
				"Research Investigators|T|The Principal Investigator (PI) develops the research methodology  but is rarely responsible for all activities associated with the conduct of a research project.|True|False|1|B\n " +
				"Research Investigators|T|All investigators on the study team are required to have current certification in the PEERRS training in human subjects protection.|True|False|1|A\n " +
				"IRB|M|The role of the IRB is to:|Protect research subjects and their well being|Protect students from unethical faculty|Protect faculty from university administration|Protect the world from devastation |1|A\n " +
				"IRB|M|The UM online application system is called:|eIRBapply|eSubjectProtection|PEERRS|eResearch|1|D\n " +
				"Research Data|T|If a travel drive with personally identifiable data stored on it is lost the PI must notify the IRB immediately.|True|False|1|A\n " +
				"Research Data|T|File encryption is difficult and therefore optional in most cases.|True|False|1|B\n " +
				"Consent|T|Obtaining consent...|Is the process of signing a document|Is a process of discussion and a chance to ask questions|1|B\n " +
				"Consent|T|The consent form should be written with the reading level of the potential subjects in mind.|True|False|1|A\n " +
				"Regulations|M|HIPAA is....|the plural of hippocampus|a set of regulations for hospital experimental drugs|a set of regulations for patient record confidentiality|what happens when your hips grow too large|1|C\n " +
			    "Regulations|M| To meet the federal definition for research the study must|Use a systematic approach to data collection|Use as many collection methods as possible|Use federal funds|Have Research in the title|2|A");

		return("");
	}
	public static string callQuestions()
	{
		Debug.Log("Loader Script started");

		string url = "http://61802877-972133719396329314.preview.editmysite.com/uploads/6/1/8/0/61802877/questionsw1.txt";
		WWW request = new WWW(url);
		
		while(!request.isDone) {
			Debug.Log("Loading...");
		}
		Debug.Log (request.text);
		return request.text;
	}
	
}

