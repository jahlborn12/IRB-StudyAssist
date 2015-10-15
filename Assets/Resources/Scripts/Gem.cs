using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Gem : MonoBehaviour 
{
	public GameObject gemHolder;
	public GameObject sphere;
	string[] gemMats ={"Red","Blue","Green","Grey","Yellow","Purple","White","Orange"};
	public string color="";
	public List<Gem> Neighbors = new List<Gem>();
	public bool isSelected =false;
	public bool isMatched = false;
	public static int B = 0;
	public int XCoord
	{
		get
		{
			return Mathf.RoundToInt(transform.localPosition.x);
		}
	}
	public int YCoord
	{
		get
		{
			return Mathf.RoundToInt(transform.localPosition.y);
		}
	}

	// Use this for initialization
	void Start () 
	{
		CreateGem();
	}
	
	// Update is called once per frame
	void Update () 
	{
	}
	public void ToggleSelector()
	{
		isSelected =  !isSelected;
		sphere.transform.FindChild("Selector").gameObject.SetActive(isSelected);
	}
	public void CreateGem() //edit difficulty on levels here
	{
		Destroy(sphere);

		if(Score.levelnum < 3)
			color = gemMats[Random.Range(0,gemMats.Length-3-B)];
		if(Score.levelnum > 2)
			color = gemMats[Random.Range(2,gemMats.Length-B)];
		if (Score.levelnum > 4) 
		{
			do {
					color = gemMats [Random.Range (0, gemMats.Length-B)];
			} while(color == "Grey");
		}
		if(Score.levelnum >= 6)
			color = gemMats[Random.Range(0,gemMats.Length-B)];

		GameObject gemPrefab = Resources.Load("Prefabs/"+color) as GameObject;
		sphere = (GameObject) Instantiate(gemPrefab,Vector3.zero,Quaternion.identity);
		sphere.transform.parent = gemHolder.transform;
		sphere.transform.localPosition = Vector3.zero;
		isMatched = false;
	}
	public void AddNeighbor(Gem g)
	{
		if(!Neighbors.Contains(g))
			Neighbors.Add(g);
	}
	public bool IsNeighborWith(Gem g)
	{
		if(Neighbors.Contains(g))
		{
			return true;
		}
		return false;
	}
	public void RemoveNeighbor(Gem g)
	{
		Neighbors.Remove(g);
	}
	void OnMouseDown()
	{
		if (GameObject.Find ("Board(Clone)").GetComponent<Board> ().DetermineBoardState())
						return;
		if(!GameObject.Find("Board(Clone)").GetComponent<Board>().isSwapping)
		{
			ToggleSelector();
			GameObject.Find("Board(Clone)").GetComponent<Board>().SwapGems(this);
		}
	}
}
