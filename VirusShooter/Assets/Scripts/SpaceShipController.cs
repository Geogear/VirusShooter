using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipController : MonoBehaviour
{
    [SerializeField]
    float spaceShip_Speed = 10f;

    public Bullet bulletPrefab;
    public float attackDelay = 0.2f;
    float curDelay = 0.0f;
    private int lives = 3;
    public UIStuff script; 
    private Animator anim; 
    public Transform spawnPos;
    float wait = 0.0f;
    bool animSet = false;
     SceneUtilizer m_Scene;

    public Color flashColor;
    public float flashDuration;
    private bool flash = false;
    public float flashCD;
    private float flashCDC = 0.0f;
    public int flashCount;
    private int flashCounter = 0;
    private bool invulnerable = false; 

    public bool[] canGo = new bool [4];

    Material mat;

    private IEnumerator flashCoroutine;

    /*  [SerializeField]
      private float rotationSpeed = 5000f;

      private float rotationValue = 0f;

      [SerializeField]
      public float smoothingTime = 6f;

      [SerializeField]
      private float smoothingRatio = 1.2f;

      [SerializeField]
      [Range(0.1f, 3f)]
      private float toleranceValue = 3f;*/

    private InputDriver m_InputDriver;

    private Vector3 lastPosition;

    void Start()
    {
        for (int i = 0; i < canGo.Length; i++)
        {
            canGo[i] = true;
        }
        flashCounter = flashCount + 1;
        mat = GetComponent<SpriteRenderer>().material;
        mat.SetColor("_FlashColor", flashColor);
        m_InputDriver = GetComponent<InputDriver>(); 
        m_InputDriver.Init_Input();
        anim = GetComponent<Animator>();
        m_Scene = SceneUtilizer.GetInstance;
    }

    private void Flash()
    {
        if (flashCoroutine != null)
            StopCoroutine(flashCoroutine);

        flashCoroutine = DoFlash();
        StartCoroutine(flashCoroutine);
    }

    private IEnumerator DoFlash()
    {
        float lerpTime = 0;

        while (lerpTime < flashDuration)
        {
            lerpTime += Time.deltaTime;
            float perc = lerpTime / flashDuration;

            SetFlashAmount(1f - perc);
            yield return null;
        }
        SetFlashAmount(0);
    }

    private void SetFlashAmount(float flashAmount)
    {
        mat.SetFloat("_FlashAmount", flashAmount);
    }

    void Update()
    {
        m_InputDriver.CheckInputs();
        SpaceShipMove();
        curDelay += Time.deltaTime;
        if (animSet)
        {
            wait += Time.deltaTime; 
            if(wait >= 0.8f)
            {
                AnimStateHandle2();
                Respawn();
                invulnerable = true;
                flash = true;
                flashCDC = 0.0f;
                flashCounter = 0;
            }
        }

        if (flash)
        {
            Flash();
            ++flashCounter;
            flash = false;
            if (flashCounter == flashCount)
                invulnerable = false;
        }
        else if(flashCounter < flashCount)
        {
            flashCDC += Time.deltaTime; 
            if(flashCDC >= flashCD)
            {
                flash = true;
                flashCDC = 0.0f;
            }
        }
    }

    void SpaceShipMove()
    {
        if (m_InputDriver.m_Input._left && canGo[2])
        {
            //lastPosition = transform.position;
            transform.position = new Vector2(transform.position.x-(spaceShip_Speed * Time.deltaTime), transform.position.y);
            //lastPosition = transform.position - lastPosition;
            //lastPosition.x = -1;
            //transform.rotation = Quaternion.Euler(Vector2.up * lastPosition.x * rotationSpeed * Mathf.Deg2Rad);
            //RotateSpaceShip(lastPosition);
        }
        if (m_InputDriver.m_Input._right && canGo[3])
        {
            //lastPosition = transform.position;
            transform.position = new Vector2(transform.position.x + (spaceShip_Speed * Time.deltaTime), transform.position.y);
            //lastPosition = transform.position - lastPosition;
            //lastPosition.x = +1;
           // transform.rotation = Quaternion.Euler(Vector2.up *lastPosition.x *rotationSpeed * Mathf.Deg2Rad);
        }
        if (m_InputDriver.m_Input._up && canGo[1])
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + (spaceShip_Speed * Time.deltaTime));
        }
        if (m_InputDriver.m_Input._down && canGo[0])
        {
            transform.position = new Vector2(transform.position.x, transform.position.y - (spaceShip_Speed * Time.deltaTime));
        }
        if (m_InputDriver.m_Input._fire)
        {
            if (curDelay >= attackDelay) {
                bulletPrefab.transform.position = new Vector2(transform.position.x - 0.01f, transform.position.y + 0.45f);
                Instantiate(bulletPrefab);
                curDelay = 0;
            } 
        }
    } 

    private void updateLives(int update)
    {
        lives += update;
        script.updateLives(lives);
    } 

    private void Death()
    {
        updateLives(-1); 
        if(lives == 0)
        {
            //TODO end game, return to main menu somthing
            m_Scene.LoadTargetScene("MainMenu");
        }
        else
        {
            //wait for anim to execute
            //StartCoroutine(ExampleCoroutine());

            AnimStateHandle1();
        }

    }

    IEnumerator ExampleCoroutine()
    {
        yield return new WaitForSeconds(1.0f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    { 
        if(other.tag == "Enemy" && !invulnerable && !other.GetComponent<Enemy>().isDead())
        { 
          other.GetComponent<Enemy>().beforeDeath();
          Death();
        }
    }  

    private void AnimStateHandle1()
    {
        anim.SetBool("respawn", false);
        anim.SetBool("beforeDead", true);
        animSet = true;

    }

    private void AnimStateHandle2()
    {
        anim.SetBool("beforeDead", false);
        anim.SetBool("respawn", true);
        animSet = false;
        wait = 0.0f;
    }

    private void Respawn()
    {
        transform.position = new Vector2(spawnPos.position.x, spawnPos.position.y - 4.0f);
    }

    /*
     * Rotation
    public void RotateSpaceShip(Vector3 delta)
    {
        //TO DO **SOME INTERPOLATION COULD BE ADDED HERE
        rotationValue = Mathf.Lerp(rotationValue, delta.x * rotationSpeed * Mathf.Deg2Rad, smoothingTime * Time.deltaTime);
        transform.Rotate(Vector2.up, -rotationValue);
        if (rotationValue > rotationSpeed * Mathf.Deg2Rad * toleranceValue)
        {
            ResetRotationValue();
        }
    }

    public bool ResetRotationValue()
    {
        return (rotationValue = 0) == 0;
    }
    */ 
    public InputDriver GetInputStatus()
    {
        return m_InputDriver;
    }

}
