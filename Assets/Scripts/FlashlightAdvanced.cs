using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FlashlightAdvanced : MonoBehaviour
{
    public new Light light;
    public TMP_Text text;

    public TMP_Text batteryText;

    public float lifetime;
    public float batteries;
    public float FDuration;
    public float range = 100f;

    public Camera fpsCam;
    public Transform target;

    //public AudioSource flashON;
    //public AudioSource flashOFF;

    private bool on;
    private bool off;


    void Start()
    {
        light = GetComponent<Light>();

        off = true;
        light.enabled = false;
    }

    void Update()
    {
        text.text = lifetime.ToString("0") + "%";
        batteryText.text = batteries.ToString();

        if (Input.GetButtonDown("flashlight") && off)
        {
            //flashON.Play();
            light.enabled = true;
            on = true;
            off = false;
        }

        else if (Input.GetButtonDown("flashlight") && on)
        {
            //flashOFF.Play();
            light.enabled = false;
            on = false;
            off = true;
        }

        if (on)
        {
            lifetime -= 1 * Time.deltaTime;
            light.intensity = lifetime / 200;
        }

        if (lifetime <= 0 && batteries > 0)
        {
            batteries -= 1;
            lifetime += 100 - FDuration;
        }

        if (lifetime <= 0 && batteries <= 0)
        {
            light.enabled = false;
            on = false;
            off = true;
            lifetime = 0;
        }

        if (batteries <= 0)
        {
            batteries = 0;
        }

        if (Input.GetButtonDown("Fire1") && on && batteries > 0)
        {
            batteries -= 1;
            Shoot();
            lifetime = 100;
        }

        if (lifetime >= 100 - FDuration)
        {
            light.intensity = 100;
        }
    }

    void Shoot()
    {
        var nearestEnemy = GameObject.FindGameObjectWithTag("Enemy");
        var nearestFakeEnemy = GameObject.FindGameObjectWithTag("FakeEnemy");
        var dist = Vector3.Distance(transform.position, nearestEnemy.transform.position);
        var distFE = Vector3.Distance(transform.position, nearestFakeEnemy.transform.position);
        var limit = 100f;
        if (dist <= limit )
        {
            //enemy is close
            var aimPointDistance = limit;
            var aimPoint = transform.position + transform.forward * aimPointDistance;
            var angle = Vector3.Angle(nearestEnemy.transform.position, aimPoint);

            Target target = nearestEnemy.transform.GetComponent<Target>();
            if (angle <= 25f)
            {
                //enemy is in angle of the flashlight
                if (target != null)
                {
                    //enemy takes damage
                    target.TakeDamage();
                    Debug.Log("target");
                }
            }
        }

        if (dist <= limit)
        {
            var aimPointDistance = limit;
            var aimPoint = transform.position + transform.forward * aimPointDistance;
            var angleFE = Vector3.Angle(nearestFakeEnemy.transform.position, aimPoint);

            Target fakeTarget = nearestFakeEnemy.transform.GetComponent<FakeTarget>();

            if (angleFE <= 25f)
            {
                //enemy is in angle of the flashlight
                if (fakeTarget != null)
                {
                    //enemy takes damage
                    fakeTarget.TakeDamage();
                    Debug.Log("Fake Target");
                }
            }
        }
    }
        /*
        Vector3 targetDir = target.position - transform.position;
        float angle = Vector3.Angle(targetDir, transform.forward);

        if (angle < 30f)
        {
            Debug.Log("Close");
        }*/
    

    /*
    RaycastHit hit;

    if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
    {
        Debug.Log(hit.transform.name);

        Target target = hit.transform.GetComponent<Target>();

        if (target != null)
        {
            target.TakeDamage(damage);
        }
    }
    */
    
    /*
    var nearestEnemy = GameObject.Find("Capsule");
    var dist = Vector3.Distance(transform.position, nearestEnemy.transform.position);

    var limit = 5;

    if (dist <= limit)
    {
        //enemy is close
        var aimPointDistance = limit;
        var aimPoint = transform.position + transform.forward * aimPointDistance;
        

        if (aimPoint < angle)
    }
    */
}
