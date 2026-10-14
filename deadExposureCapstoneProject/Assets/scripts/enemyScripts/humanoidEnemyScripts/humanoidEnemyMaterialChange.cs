using UnityEngine;


public class humanoidEnemyMaterialChange : MonoBehaviour
{
    public Material baseMaterial;
    public Material aggroMaterial;
    public SkinnedMeshRenderer skinMeshRenderer;

    //Other scripts
    public humanoidAIMovement humnanAIMovement;

    void Start()
    {
        skinMeshRenderer = GetComponent<SkinnedMeshRenderer>();

    }

    void Update()
    {
        switchMaterials();
    }

    public void switchMaterials()
    {
        if (humnanAIMovement.isAggro == true)
        {
            skinMeshRenderer.sharedMaterial = aggroMaterial;

        }
        else if (humnanAIMovement.isAggro == false)
        {
            skinMeshRenderer.sharedMaterial = baseMaterial;
        } 
        
    }
}
