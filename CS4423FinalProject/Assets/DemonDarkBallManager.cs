using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonDarkBallManager : MonoBehaviour
{
    public DemonDarkBall darkBall;
    public List<DemonDarkBall> darkBallPool = new List<DemonDarkBall>();
    int maxPool = 10;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddBall(DemonDarkBall ball)
    {
        if (darkBallPool.Count > maxPool)
        {
            Destroy(ball.gameObject);
            return;
        }
        ball.transform.position = new Vector3(500,500);
        ball.gameObject.SetActive(false);
        darkBallPool.Add(ball);
    }

    public void ShootDarkBall(Vector3 aim, EyeballShooter shooter)
    {
        DemonDarkBall spell = null;
        DemonDarkBall newspell = null;
        if (darkBallPool.Count < 1)
            spell = Instantiate(darkBall, shooter.transform.position, Quaternion.identity);
        else
        {
            newspell = darkBallPool[darkBallPool.Count - 1];
            newspell.gameObject.SetActive(true);
            darkBallPool.RemoveAt(darkBallPool.Count - 1);

            if (newspell == null)
                newspell = Instantiate(darkBall, shooter.transform.position, Quaternion.identity);
            else
                newspell.transform.position = shooter.transform.position;
            
            newspell.manager = this;
            spell = newspell;
        }
        
        spell.transform.rotation = Quaternion.LookRotation(shooter.transform.forward, aim - shooter.transform.position);
        spell.GetComponent<Rigidbody2D>().velocity = spell.transform.up * darkBall.GetSpeed();
    }

}
