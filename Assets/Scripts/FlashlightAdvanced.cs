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
    public float damage = 1f;

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
        Vector3 targetDir = target.position - transform.position;
        float angle = Vector3.Angle(targetDir, transform.forward);

        if (angle < 30f)
        {
            Debug.Log("Close");
        }
        
    }

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
    Vector3 reletiveNormalizedPos = (fpsCam.transform.position - transform.position).normalized;
    float dot = Vector3.Dot(reletiveNormalizedPos, );

    //angle difference between looking direction and direction to item (radians)
    float angle = Mathf.Acos(dot);

    if (angle < MAX_ANGLE)
    {
        //looking at target
    }
    */

    /*
    var nearestEnemy = GameObject.Find("Capsule");
    var dist = Vector3.Distance(transform.position, nearestEnemy.transform.position);

    var limit = 1;

    if (dist <= limit)
    {
        //enemy is close
        var aimPointDistance = 1;
        var aimPoint = transform.position + transform.forward * aimPointDistance;

    }
    */
}
