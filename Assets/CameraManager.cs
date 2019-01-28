using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public Transform roomTransform;
    public Transform publicTransform;

    public Image fadeImage;
    
    float animTime = 1f;

    float start = 1f;
    float end = 0f;
    float time = 0f;

    bool fade = true;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
	if(Input.GetKeyDown(KeyCode.A))
	{
	    time = 0f;
	    fade = true;
	}
	else if(Input.GetKeyDown(KeyCode.S))
	{
	    time = 0f;
	    fade = false;
	}
	PlayFadeIn(fade);
    }

    void PlayFadeIn(bool fade)	// fade가 true면 fadeout, false면 fadein
    {
	time += Time.deltaTime / animTime;

	Color color = fadeImage.color;
	if(fade)
	{
	    color.a = Mathf.Lerp(start, end, time);
	}
	else
	{
	    color.a = Mathf.Lerp(end, start, time);
	}
	fadeImage.color = color;
    }

    public void CameraMove() {
	Debug.Log("HI");
	StartCoroutine(FadeOut());
    }

    public IEnumerator FadeOut() {
	float fadeTime = 1.0f;

	Color color = fadeImage.color;

	if(fade)
	{
	    color.a = Mathf.Lerp(start, end, fadeTime);
	}
	else
	{
	    color.a = Mathf.Lerp(end, start, fadeTime);
	}
	
	if(color.a >= 1.0f)
	{
	    if(Camera.main.transform.position == roomTransform.position)
	    {
		Camera.main.transform.position = publicTransform.position;
	    }
	    else
	    {
		Camera.main.transform.position = roomTransform.position;
	    }

	    fade = !fade;
	}

	if(color.a <= 0.0f)
	{
	    yield return null;
	}
	yield return new WaitForSeconds(0.1f);
    }
}
