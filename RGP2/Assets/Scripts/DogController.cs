using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DogController : MonoBehaviour
{
    public List<Transform> spawnPoints;
    private Transform currentTransform;
    private Transform applyTransform;

    public List<Mesh> dogMesh;
    private Mesh applyMesh;
    private MeshFilter currentMesh;

    public List<Material> dogMat;
    private MeshRenderer currentMat;
    private Material applyMat;

    public List<AudioClip> dogLines;
    public List<AudioClip> dogBarks;
    private AudioClip currentClip;
    private AudioClip applyClip;
    public AudioSource childSource;
    public GameObject myArrow;

    public GameObject dogControl;

    public List<string> dogNames;


    public List<string> dogBreeds;

    public List<Sprite> dogPics;

    private string dogsName;
    private string dogsBreed;
    private Sprite dogsPic;
    private int age;
    private float weight;

    public Text nameText;
    public Text ageText;
    public Text weightText;
    public Text breedText;
    public Image dogPhoto;


    int index;
    int soundIndex;
    int soundWait;

    private bool nearPlayer;



    // Start is called before the first frame update
    void Start()
    {
        childSource = gameObject.GetComponentInChildren<AudioSource>();
        nearPlayer = false;
        ApplySpawnPoint();
        ApplyNewMesh();
        ApplyNewMat();
        ApplyDogIdentity();
        age = Random.Range(1, 20);
        weight = Random.Range(5.0f, 30.0f);
        dogNoiseFunction();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void dogNoiseFunction()
    {
        if (nearPlayer == true)
        {
            soundWait = Random.Range(2, 6);
            Invoke("NearPlayerVoice", soundWait);
        }

    }

    private void FixedUpdate()
    {
       

    }

    void NearPlayerVoice()
    {
        soundIndex = Random.Range(0, dogLines.Count);
        applyClip = dogLines[soundIndex];
        childSource.clip = applyClip;
        childSource.Play();
        soundIndex = 0;
        soundWait = Random.Range(1, 3);
        Invoke("Barking", soundWait);

    }

    void Barking()
    {
        soundIndex = Random.Range(0, dogBarks.Count);
        applyClip = dogBarks[soundIndex];
        
        childSource.clip = applyClip;
        childSource.Play();
        soundIndex = 0;
        dogNoiseFunction();
    }

    void ApplyNewMesh()
    {
        index = Random.Range(0, dogMesh.Count);
        applyMesh = dogMesh[index];
        currentMesh = gameObject.GetComponentInChildren<MeshFilter>();
        currentMesh.mesh = applyMesh;
        index = 0;
    }

    void ApplySpawnPoint()
    {
        index = Random.Range(0, spawnPoints.Count);
        currentTransform = spawnPoints[index];
        this.transform.position = currentTransform.position;
        spawnPoints.Remove(currentTransform);
        index = 0;

    }

    void ApplyNewMat()
    {
        index = Random.Range(0, dogMat.Count);
        applyMat = dogMat[index];
        currentMat = gameObject.GetComponentInChildren<MeshRenderer>();
        currentMat.material = applyMat;
        index = 0;
    }

    void ApplyDogIdentity()
    {
        index = Random.Range(0, dogNames.Count);
        dogsName = dogNames[index];

        index = 0;
        index = Random.Range(0, dogBreeds.Count);
        dogsBreed = dogBreeds[index];

        dogsPic = dogPics[index];

        index = 0;

    }


    public void FillIdentity()
    {
        nameText.text = dogsName;
        breedText.text = dogsBreed;
        dogPhoto.sprite = dogsPic;
        weightText.text = weight.ToString();
        ageText.text = age.ToString();
        dogControl.SetActive(true);
        nearPlayer = true;
    }

    public void ClearIdentity()
    {

        nameText.text = " ";
        breedText.text = " ";
        dogPhoto.sprite = null;
        weightText.text = " ";
        ageText.text = " ";
        dogControl.SetActive(false);
        nearPlayer = false;
    }


    
}
