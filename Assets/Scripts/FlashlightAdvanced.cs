using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FlashlightAdvanced : MonoBehaviour
{
    public new Light light;
    public TMP_Text percent;

    public TMP_Text batteryText;

    public TMP_Text keycardText;


    public float lifetime;

    public int batteries;
    public int numOfBatteries;

    public float range = 50f;

    public float keycards;

    public Camera fpsCam;

    public BatteryBar batteryBar;

    public Image[] battery;
    public Sprite fullBattery;
    public Sprite emptyBattery;

    //public AudioSource flashON;
    //public AudioSource flashOFF;

    private bool on;
    private bool off;

    private float timeLeftToShoot;
    public float initialIntensity;

    void Start()
    {
        light = GetComponent<Light>();

        off = true;
        light.enabled = false;

        keycards = 0;

        batteryBar.SetMaxPerc(100);

        initialIntensity = light.intensity;
    }

    void Update()
    {
        if (!PauseMenu.isPaused)
        {
            if (batteries > numOfBatteries)
            {
                batteries = numOfBatteries;
            }

            for (int i = 0; i < battery.Length; i++)
            {
                if (i < batteries)
                {
                    battery[i].sprite = fullBattery;
                }
                else
                {
                    battery[i].sprite = emptyBattery;
                }

                if (i < numOfBatteries)
                {
                    battery[i].enabled = true;
                }
                else
                {
                    battery[i].enabled = false;
                }
            }

            percent.text = lifetime.ToString("0") + "%";
            batteryText.text = batteries.ToString();
            keycardText.text = keycards.ToString() + " / 6";
            batteryBar.SetPerc(lifetime);

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
                light.intensity = initialIntensity;
            }

            if (on)
            {
                lifetime -= 1 * Time.deltaTime;
                light.intensity = lifetime / 100;
            }

            if (lifetime <= 0 && batteries > 0)
            {
                batteries -= 1;
                lifetime += 100 - 0.1f;
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

            if (Input.GetButtonDown("Fire1") && on && batteries > 0 && timeLeftToShoot <=0)
            {
                batteries -= 1;
                Shoot();
                lifetime = 100;
                timeLeftToShoot = 5f;
            }

            if(timeLeftToShoot > 0)
            {
                timeLeftToShoot -= Time.deltaTime;
            }

            if (lifetime == 100)
            {
                light.intensity = 100;
            }

            if (light.intensity != 100)
            {
                light.intensity = 1;
            }
        }
    }

    Ray CreateRay(float spreadAngle, Vector3 axis)
    {
        float distance = 250f;
        Vector3 noAngle = transform.forward;
        Quaternion spreadRotation = Quaternion.AngleAxis(spreadAngle, axis);
        Vector3 spreadDirection = spreadRotation * noAngle;
        Ray ray = new(transform.position, spreadDirection * distance);
        return ray;
    }


    void RayHit(Ray ray, float range)
    {
        if (Physics.Raycast(ray, out RaycastHit hit, range))
        {
            if (hit.collider.CompareTag("FakeEnemy"))
            {
                Target fakeTarget = hit.collider.gameObject.GetComponent<FakeTarget>();
                fakeTarget.TakeDamage();
            }
            else if (hit.collider.CompareTag("Enemy"))
            {
                Target target = hit.collider.gameObject.GetComponent<Target>();
                target.TakeDamage();
            }
        }
    }

    void Shoot()
    {
        RaycastHit hit;
        float currentRange = range;

        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            currentRange = hit.distance;
        }

        // center ray
        RayHit(new Ray(fpsCam.transform.position, fpsCam.transform.forward), currentRange);

        float angleStep = 1f; // krok úhlu pro raye
        for (float angle = angleStep; angle <= 25f; angle += angleStep)
        {
            Vector3 upperRayDirection = Quaternion.AngleAxis(angle, fpsCam.transform.right) * fpsCam.transform.forward;
            RayHit(new Ray(fpsCam.transform.position, upperRayDirection), currentRange);

            Vector3 lowerRayDirection = Quaternion.AngleAxis(-angle, fpsCam.transform.right) * fpsCam.transform.forward;
            RayHit(new Ray(fpsCam.transform.position, lowerRayDirection), currentRange);

            Vector3 leftRayDirection = Quaternion.AngleAxis(angle, fpsCam.transform.up) * fpsCam.transform.forward;
            RayHit(new Ray(fpsCam.transform.position, leftRayDirection), currentRange);

            Vector3 rightRayDirection = Quaternion.AngleAxis(-angle, fpsCam.transform.up) * fpsCam.transform.forward;
            RayHit(new Ray(fpsCam.transform.position, rightRayDirection), currentRange);

            Vector3 upperRightRayDirection = Quaternion.AngleAxis(angle, fpsCam.transform.right) * Quaternion.AngleAxis(-angle, fpsCam.transform.up) * fpsCam.transform.forward;
            RayHit(new Ray(fpsCam.transform.position, upperRightRayDirection), currentRange);

            Vector3 upperLeftRayDirection = Quaternion.AngleAxis(angle, fpsCam.transform.right) * Quaternion.AngleAxis(angle, fpsCam.transform.up) * fpsCam.transform.forward;
            RayHit(new Ray(fpsCam.transform.position, upperLeftRayDirection), currentRange);

            Vector3 lowerRightRayDirection = Quaternion.AngleAxis(-angle, fpsCam.transform.right) * Quaternion.AngleAxis(-angle, fpsCam.transform.up) * fpsCam.transform.forward;
            RayHit(new Ray(fpsCam.transform.position, lowerRightRayDirection), currentRange);

            Vector3 lowerLeftRayDirection = Quaternion.AngleAxis(-angle, fpsCam.transform.right) * Quaternion.AngleAxis(angle, fpsCam.transform.up) * fpsCam.transform.forward;
            RayHit(new Ray(fpsCam.transform.position, lowerLeftRayDirection), currentRange);

            Vector3 lowerLeftLeftRayDirection = Quaternion.AngleAxis(angle / 2, fpsCam.transform.right) * Quaternion.AngleAxis(-angle, fpsCam.transform.up) * fpsCam.transform.forward;
            RayHit(new Ray(fpsCam.transform.position, lowerLeftLeftRayDirection), currentRange);

            Vector3 lowerLowerLeftRayDirection = Quaternion.AngleAxis(angle, fpsCam.transform.right) * Quaternion.AngleAxis(-angle / 2, fpsCam.transform.up) * fpsCam.transform.forward;
            RayHit(new Ray(fpsCam.transform.position, lowerLowerLeftRayDirection), currentRange);

            Vector3 idk1 = Quaternion.AngleAxis(angle / 2, fpsCam.transform.right) * Quaternion.AngleAxis(angle, fpsCam.transform.up) * fpsCam.transform.forward;
            RayHit(new Ray(fpsCam.transform.position, idk1), currentRange);

            Vector3 idk2 = Quaternion.AngleAxis(angle, fpsCam.transform.right) * Quaternion.AngleAxis(angle / 2, fpsCam.transform.up) * fpsCam.transform.forward;
            RayHit(new Ray(fpsCam.transform.position, idk2), currentRange);

            Vector3 idk3 = Quaternion.AngleAxis(-angle / 2, fpsCam.transform.right) * Quaternion.AngleAxis(angle, fpsCam.transform.up) * fpsCam.transform.forward;
            RayHit(new Ray(fpsCam.transform.position, idk3), currentRange);

            Vector3 idk4 = Quaternion.AngleAxis(-angle, fpsCam.transform.right) * Quaternion.AngleAxis(angle / 2, fpsCam.transform.up) * fpsCam.transform.forward;
            RayHit(new Ray(fpsCam.transform.position, idk4), currentRange);

            Vector3 idk5 = Quaternion.AngleAxis(-angle / 2, fpsCam.transform.right) * Quaternion.AngleAxis(-angle, fpsCam.transform.up) * fpsCam.transform.forward;
            RayHit(new Ray(fpsCam.transform.position, idk5), currentRange);

            Vector3 idk6 = Quaternion.AngleAxis(-angle, fpsCam.transform.right) * Quaternion.AngleAxis(-angle / 2, fpsCam.transform.up) * fpsCam.transform.forward;
            RayHit(new Ray(fpsCam.transform.position, idk6), currentRange);

        }
    }



 }
