using UnityEngine;

public class LoopingBackground : MonoBehaviour{
    [Range(-1f, 1f)]
    [SerializeField] private float loopSpeed = 0.5f;
    private float offSet;
    private bool isLooping = true;
    private Material mat;

    private void Awake()
    {
        mat = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        if(isLooping == false) return;
        offSet += (Time.deltaTime * loopSpeed) / 10f;
        mat.SetTextureOffset("_MainTex", new Vector2(offSet, 0));
    }

    public void SetLooping(bool isLooping){
        this.isLooping = isLooping;
    }
}
