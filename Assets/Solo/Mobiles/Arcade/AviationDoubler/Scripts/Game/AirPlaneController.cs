using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirPlaneController : MonoBehaviour
{
    private Transform airPlaneTransform;

    public static bool isDoubled;

    private GameObject myClone;

    private Coroutine moveForward;

    public Transform forwardPosition;

    private float timer;

    private bool clicked;

    private AirPlaneComponent planeComponent;

    private void Start()
    {
        planeComponent = GetComponent<AirPlaneComponent>();
        airPlaneTransform = GetComponent<Transform>();

        GetComponent<AirPlaneMovement>().Move();
    }

    private void LateUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (clicked)
                return;
            clicked = true;
            isDoubled = !isDoubled;
            if (isDoubled && myClone == null)
            {
                myClone = Instantiate(gameObject, transform.position, transform.rotation);
                AirPlaneComponent cloneComponent = myClone.GetComponent<AirPlaneComponent>();
                cloneComponent.TOLKOYA = false;
                cloneComponent.airPlaneStars.Clear();
                if (planeComponent.airPlaneStars.Count > 1)
                {
                    int middle = planeComponent.airPlaneStars.Count / 2;

                    for (int i = middle; i < planeComponent.airPlaneStars.Count; i++)
                    {
                        cloneComponent.airPlaneStars.Add(planeComponent.airPlaneStars[i]);
                        planeComponent.airPlaneStars.Remove(planeComponent.airPlaneStars[i]);
                    }

                    if (cloneComponent.airPlaneStars.Count < 1)
                    {
                        cloneComponent.AddNewStar(planeComponent.airPlaneStars[0].gameObject);
                    }
                }
                Destroy(myClone.GetComponent<AirPlaneController>());
                GetComponent<AirPlaneMovement>().DontMove();
                StartCoroutine(MoveToPos(new Vector3(15f, -18.3f,myClone.transform.position.z + 7),myClone, false));
                StartCoroutine(MoveToPos(new Vector3(-15f, -18.3f, transform.position.z + 7), gameObject, false));
            }
            else
            {

                myClone.GetComponent<AirPlaneMovement>().DontMove();
                GetComponent<AirPlaneMovement>().DontMove();
                StartCoroutine(MoveToPos(new Vector3(0, -18.3f, myClone.transform.position.z + 7), myClone,true));
                StartCoroutine(MoveToPos(new Vector3(0, -18.3f, transform.position.z + 7), gameObject,false));
            }
        }

        if (clicked) 
        {
            timer += Time.deltaTime;
            if (timer >= 0.3f)
            {
                clicked = false;
                timer = 0;
            }
        }
    }

    private IEnumerator MoveToPos(Vector3 needPos, GameObject whoMove,bool destroyer) 
    {
        while (whoMove.transform.position != needPos)
        {
            whoMove.transform.position = Vector3.MoveTowards(whoMove.transform.position, needPos, 70 * Time.deltaTime);
            yield return null;
        }
        whoMove.GetComponent<AirPlaneMovement>().Move();
        if (destroyer)
        {
            foreach (var item in myClone.GetComponent<AirPlaneComponent>().airPlaneStars)
            {
                planeComponent.airPlaneStars.Add(item);
            }
            Destroy(whoMove);
        }
    }
}
