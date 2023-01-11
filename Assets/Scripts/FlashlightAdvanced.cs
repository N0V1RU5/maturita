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

    public float FDuration;
    public float range = 100f;

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


    void Start()
    {
        light = GetComponent<Light>();

        off = true;
        light.enabled = false;

        keycards = 0;

        batteryBar.SetMaxPerc(100);
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
            }

            if (on)
            {
                lifetime -= 1 * Time.deltaTime;
                light.intensity = lifetime / 100;
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

            if (light.intensity < 99)
            {
                light.intensity = 1;
            }
        }
    }

    Ray CreateRay(float spreadAngle, Vector3 axis)
    {
        float distance = 15f;
        Vector3 noAngle = transform.forward;
        Quaternion spreadRotation = Quaternion.AngleAxis(spreadAngle, axis);
        Vector3 spreadDirection = spreadRotation * noAngle;
        Ray ray = new Ray(transform.position, spreadDirection * distance);
        return ray;
    }


    void RayHit(Ray ray, float range)
    {
        if (Physics.Raycast(ray, out RaycastHit hit, range))
        {
            if (hit.collider.tag == "FakeEnemy")
            {
                Target fakeTarget = hit.collider.gameObject.GetComponent<FakeTarget>();
                fakeTarget.TakeDamage();
            }
            else if (hit.collider.tag == "Enemy")
            {
                Target target = hit.collider.gameObject.GetComponent<Target>();
                target.TakeDamage();
            }
        }
    }


    void Shoot()
    {
        Vector3 noAngle = transform.forward;

        Ray ray0 = CreateRay(25, new Vector3(1, 0, 0));
        RayHit(ray0, range);

        Ray ray1 = CreateRay(25, new Vector3(0, -1, 0));
        RayHit(ray1, range);

        Ray ray2 = CreateRay(25, new Vector3(-1, 0, 0));
        RayHit(ray2, range);

        Ray ray3 = CreateRay(25, new Vector3(0, 1, 0));
        RayHit(ray3, range);

        Ray ray4 = CreateRay(25, new Vector3(85, -5, 0));
        RayHit(ray4, range);

        Ray ray5 = CreateRay(25, new Vector3(5, -85, 0));
        RayHit(ray5, range);

        Ray ray6 = CreateRay(25, new Vector3(-5, -85, 0));
        RayHit(ray6, range);

        Ray ray7 = CreateRay(25, new Vector3(-85, -5, 0));
        RayHit(ray7, range);

        Ray ray8 = CreateRay(25, new Vector3(-85, 5, 0));
        RayHit(ray8, range);

        Ray ray9 = CreateRay(25, new Vector3(-5, 85, 0));
        RayHit(ray9, range);

        Ray ray10 = CreateRay(25, new Vector3(5, 85, 0));
        RayHit(ray10, range);

        Ray ray11 = CreateRay(25, new Vector3(85, 5, 0));
        RayHit(ray11, range);

        Ray ray12 = CreateRay(25, new Vector3(5, 0, 0));
        RayHit(ray12, range);

        Ray ray13 = CreateRay(25, new Vector3(0, -5, 0));
        RayHit(ray13, range);

        Ray ray14 = CreateRay(25, new Vector3(-5, 0, 0));
        RayHit(ray14, range);

        Ray ray15 = CreateRay(25, new Vector3(0, 5, 0));
        RayHit(ray15, range);

        Ray ray16 = CreateRay(25, new Vector3(35, -35, 0));
        RayHit(ray16, range);

        Ray ray17 = CreateRay(25, new Vector3(-35, -35, 0));
        RayHit(ray17, range);

        Ray ray18 = CreateRay(25, new Vector3(-35, 35, 0));
        RayHit(ray18, range);

        Ray ray19 = CreateRay(25, new Vector3(35, 35, 0));
        RayHit(ray19, range);

        Ray ray20 = CreateRay(25, noAngle);
        RayHit(ray20, range);
    }
}
