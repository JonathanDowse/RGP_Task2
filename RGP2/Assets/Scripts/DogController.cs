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



    public List<string> dogNames;


    public List<string> dogBreeds;

    public List<Sprite> dogPics;


    private int age;
    private float weight;


    int index;





    // Start is called before the first frame update
    void Start()
    {
        ApplySpawnPoint();
        ApplyNewMesh();
        ApplyNewMat();
        age = Random.Range(1, 20);
        weight = Random.Range(5.0f, 30.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
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


}
