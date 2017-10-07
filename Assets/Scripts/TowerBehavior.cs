using System.Collections;
using UnityEngine;

public class TowerBehavior : MonoBehaviour {

    public GameObject circle, GameControl, towerEnemy;
    private GameObject newCircle;
    bool enemyShot = false;
    
	void Update() {
		if (Input.GetKeyDown(KeyCode.Mouse0)) {
            StartCoroutine(MouseHold());
        }
        if(Input.GetKeyDown(KeyCode.Space)) {
            enemyShot = !enemyShot;
        }
	}

    private IEnumerator MouseHold() {

        newCircle = Instantiate(circle,(enemyShot ? towerEnemy.transform.position : transform.position), Quaternion.identity);

        newCircle.transform.parent = GameControl.transform;
    
        int holdTime = 0;


        while (Input.GetKeyDown(KeyCode.Mouse0))
        {
            holdTime++;
            yield return new WaitForSecondsRealtime(0.01f);
        }
        
        Vector3 mousePosition = Input.mousePosition;

        StartCircle(holdTime, mousePosition);
    }

    private void StartCircle(int holdTime, Vector3 mousePosition) {
        Vector3 force3 = new Vector3();
        Vector2 force2;
        force3 = Camera.main.ScreenToWorldPoint(mousePosition - ((enemyShot) ? towerEnemy.transform.localPosition : transform.localPosition));
        force2 = new Vector2(force3.x, force3.y);

        newCircle.GetComponent<CircleBehavior>().charge = Random.Range(-2, 2);

        newCircle.GetComponent<CircleBehavior>().SetForce(100*force2);
    }
}
