using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FlashlightAdvanced : MonoBehaviour
{
    public new Light light;
    public TMP_Text text;

    public TMP_Text batteryText;

    public TMP_Text keycardText;

    public float lifetime;
    public float batteries;
    public float FDuration;
    public float range = 100f;

    public float keycards;

    public Camera fpsCam;

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
    }

    void Update()
    {
        text.text = lifetime.ToString("0") + "%";
        batteryText.text = batteries.ToString();
        keycardText.text = keycards.ToString();

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
        var distance = 15f;
        Vector3 noAngle = transform.forward;

        Quaternion spreadAngleU = Quaternion.AngleAxis(25, new Vector3(1, 0, 0));
        Vector3 newVectorU = spreadAngleU * noAngle;
        Ray ray0 = new Ray(transform.position, newVectorU * distance);

        Quaternion spreadAngleR = Quaternion.AngleAxis(25, new Vector3(0, -1, 0));
        Vector3 newVectorR = spreadAngleR * noAngle;
        Ray ray1 = new Ray(transform.position, newVectorR * distance);

        Quaternion spreadAngleD = Quaternion.AngleAxis(25, new Vector3(-1, 0, 0));
        Vector3 newVectorD = spreadAngleD * noAngle;
        Ray ray2 = new Ray(transform.position, newVectorD * distance);

        Quaternion spreadAngleL = Quaternion.AngleAxis(25, new Vector3(0, 1, 0));
        Vector3 newVectorL = spreadAngleL * noAngle;
        Ray ray3 = new Ray(transform.position, newVectorL * distance);

        Quaternion spreadAngleUUR = Quaternion.AngleAxis(25, new Vector3(85, -5, 0));
        Vector3 newVectorUUR = spreadAngleUUR * noAngle;
        Ray ray4 = new Ray(transform.position, newVectorUUR * distance);

        Quaternion spreadAngleURR = Quaternion.AngleAxis(25, new Vector3(5, -85, 0));
        Vector3 newVectorURR = spreadAngleURR * noAngle;
        Ray ray5 = new Ray(transform.position, newVectorURR * distance);

        Quaternion spreadAngleDRR = Quaternion.AngleAxis(25, new Vector3(-5, -85, 0));
        Vector3 newVectorDRR = spreadAngleDRR * noAngle;
        Ray ray6 = new Ray(transform.position, newVectorDRR * distance);

        Quaternion spreadAngleDDR = Quaternion.AngleAxis(25, new Vector3(-85, -5, 0));
        Vector3 newVectorDDR = spreadAngleDDR * noAngle;
        Ray ray7 = new Ray(transform.position, newVectorDDR * distance);

        Quaternion spreadAngleDDL = Quaternion.AngleAxis(25, new Vector3(-85, 5, 0));
        Vector3 newVectorDDL = spreadAngleDDL * noAngle;
        Ray ray8 = new Ray(transform.position, newVectorDDL * distance);

        Quaternion spreadAngleDLL = Quaternion.AngleAxis(25, new Vector3(-5, 85, 0));
        Vector3 newVectorDLL = spreadAngleDLL * noAngle;
        Ray ray9 = new Ray(transform.position, newVectorDLL * distance);

        Quaternion spreadAngleULL = Quaternion.AngleAxis(25, new Vector3(5, 85, 0));
        Vector3 newVectorULL = spreadAngleULL * noAngle;
        Ray ray10 = new Ray(transform.position, newVectorULL * distance);

        Quaternion spreadAngleUUL = Quaternion.AngleAxis(25, new Vector3(85, 5, 0));
        Vector3 newVectorUUL = spreadAngleUUL * noAngle;
        Ray ray11 = new Ray(transform.position, newVectorUUL * distance);

        #region small_raycast

        Quaternion spreadAngleSU = Quaternion.AngleAxis(25, new Vector3(5, 0, 0));
        Vector3 newVectorSU = spreadAngleSU * noAngle;
        Ray ray12 = new Ray(transform.position, newVectorSU * distance);

        Quaternion spreadAngleSR = Quaternion.AngleAxis(25, new Vector3(0, -5, 0));
        Vector3 newVectorSR = spreadAngleSR * noAngle;
        Ray ray13 = new Ray(transform.position, newVectorSR * distance);

        Quaternion spreadAngleSD = Quaternion.AngleAxis(25, new Vector3(-5, 0, 0));
        Vector3 newVectorSD = spreadAngleSD * noAngle;
        Ray ray14 = new Ray(transform.position, newVectorSD * distance);

        Quaternion spreadAngleSL = Quaternion.AngleAxis(25, new Vector3(0, 5, 0));
        Vector3 newVectorSL = spreadAngleSL * noAngle;
        Ray ray15 = new Ray(transform.position, newVectorSL * distance);

        Quaternion spreadAngleSUR = Quaternion.AngleAxis(25, new Vector3(35, -35, 0));
        Vector3 newVectorSUR = spreadAngleSUR * noAngle;
        Ray ray16 = new Ray(transform.position, newVectorSUR * distance);

        Quaternion spreadAngleSDR = Quaternion.AngleAxis(25, new Vector3(-35, -35, 0));
        Vector3 newVectorSDR = spreadAngleSDR * noAngle;
        Ray ray17 = new Ray(transform.position, newVectorSDR * distance);

        Quaternion spreadAngleSDL = Quaternion.AngleAxis(25, new Vector3(-35, 35, 0));
        Vector3 newVectorSDL = spreadAngleSDL * noAngle;
        Ray ray18 = new Ray(transform.position, newVectorSDL * distance);

        Quaternion spreadAngleSUL = Quaternion.AngleAxis(25, new Vector3(35, 35, 0));
        Vector3 newVectorSUL = spreadAngleSUL * noAngle;
        Ray ray19 = new Ray(transform.position, newVectorSUL * distance);

        Ray ray20 = new Ray(transform.position, noAngle * distance);

        #endregion small_raycast


        if (Physics.Raycast( ray0, out RaycastHit hit0, range))
        {
            if(hit0.collider.tag == "FakeEnemy")
            {
                var nearestFakeEnemy = GameObject.FindGameObjectWithTag("FakeEnemy");
                Target fakeTarget = nearestFakeEnemy.transform.GetComponent<FakeTarget>();
                fakeTarget.TakeDamage();
            } else if (hit0.collider.tag == "Enemy"){
                var nearestEnemy = GameObject.FindGameObjectWithTag("Enemy");
                Target target = nearestEnemy.transform.GetComponent<Target>();
                target.TakeDamage();
            }
        }

        if (Physics.Raycast(ray1, out RaycastHit hit1, range))
        {
            if (hit1.collider.tag == "FakeEnemy")
            {
                var nearestFakeEnemy = GameObject.FindGameObjectWithTag("FakeEnemy");
                Target fakeTarget = nearestFakeEnemy.transform.GetComponent<FakeTarget>();
                fakeTarget.TakeDamage();
            }
            else if (hit1.collider.tag == "Enemy")
            {
                var nearestEnemy = GameObject.FindGameObjectWithTag("Enemy");
                Target target = nearestEnemy.transform.GetComponent<Target>();
                target.TakeDamage();
            }
        }

        if (Physics.Raycast(ray2, out RaycastHit hit2, range))
        {
            if (hit2.collider.tag == "FakeEnemy")
            {
                var nearestFakeEnemy = GameObject.FindGameObjectWithTag("FakeEnemy");
                Target fakeTarget = nearestFakeEnemy.transform.GetComponent<FakeTarget>();
                fakeTarget.TakeDamage();
            }
            else if (hit2.collider.tag == "Enemy")
            {
                var nearestEnemy = GameObject.FindGameObjectWithTag("Enemy");
                Target target = nearestEnemy.transform.GetComponent<Target>();
                target.TakeDamage();
            }
        }

        if (Physics.Raycast(ray3, out RaycastHit hit3, range))
        {
            if (hit3.collider.tag == "FakeEnemy")
            {
                var nearestFakeEnemy = GameObject.FindGameObjectWithTag("FakeEnemy");
                Target fakeTarget = nearestFakeEnemy.transform.GetComponent<FakeTarget>();
                fakeTarget.TakeDamage();
            }
            else if (hit3.collider.tag == "Enemy")
            {
                var nearestEnemy = GameObject.FindGameObjectWithTag("Enemy");
                Target target = nearestEnemy.transform.GetComponent<Target>();
                target.TakeDamage();
            }
        }

        if (Physics.Raycast(ray4, out RaycastHit hit4, range))
        {
            if (hit4.collider.tag == "FakeEnemy")
            {
                var nearestFakeEnemy = GameObject.FindGameObjectWithTag("FakeEnemy");
                Target fakeTarget = nearestFakeEnemy.transform.GetComponent<FakeTarget>();
                fakeTarget.TakeDamage();
            }
            else if (hit4.collider.tag == "Enemy")
            {
                var nearestEnemy = GameObject.FindGameObjectWithTag("Enemy");
                Target target = nearestEnemy.transform.GetComponent<Target>();
                target.TakeDamage();
            }
        }

        if (Physics.Raycast(ray5, out RaycastHit hit5, range))
        {
            if (hit5.collider.tag == "FakeEnemy")
            {
                var nearestFakeEnemy = GameObject.FindGameObjectWithTag("FakeEnemy");
                Target fakeTarget = nearestFakeEnemy.transform.GetComponent<FakeTarget>();
                fakeTarget.TakeDamage();
            }
            else if (hit5.collider.tag == "Enemy")
            {
                var nearestEnemy = GameObject.FindGameObjectWithTag("Enemy");
                Target target = nearestEnemy.transform.GetComponent<Target>();
                target.TakeDamage();
            }
        }

        if (Physics.Raycast(ray6, out RaycastHit hit6, range))
        {
            if (hit6.collider.tag == "FakeEnemy")
            {
                var nearestFakeEnemy = GameObject.FindGameObjectWithTag("FakeEnemy");
                Target fakeTarget = nearestFakeEnemy.transform.GetComponent<FakeTarget>();
                fakeTarget.TakeDamage();
            }
            else if (hit6.collider.tag == "Enemy")
            {
                var nearestEnemy = GameObject.FindGameObjectWithTag("Enemy");
                Target target = nearestEnemy.transform.GetComponent<Target>();
                target.TakeDamage();
            }
        }

        if (Physics.Raycast(ray7, out RaycastHit hit7, range))
        {
            if (hit7.collider.tag == "FakeEnemy")
            {
                var nearestFakeEnemy = GameObject.FindGameObjectWithTag("FakeEnemy");
                Target fakeTarget = nearestFakeEnemy.transform.GetComponent<FakeTarget>();
                fakeTarget.TakeDamage();
            }
            else if (hit7.collider.tag == "Enemy")
            {
                var nearestEnemy = GameObject.FindGameObjectWithTag("Enemy");
                Target target = nearestEnemy.transform.GetComponent<Target>();
                target.TakeDamage();
            }
        }

        if (Physics.Raycast(ray8, out RaycastHit hit8, range))
        {
            if (hit8.collider.tag == "FakeEnemy")
            {
                var nearestFakeEnemy = GameObject.FindGameObjectWithTag("FakeEnemy");
                Target fakeTarget = nearestFakeEnemy.transform.GetComponent<FakeTarget>();
                fakeTarget.TakeDamage();
            }
            else if (hit8.collider.tag == "Enemy")
            {
                var nearestEnemy = GameObject.FindGameObjectWithTag("Enemy");
                Target target = nearestEnemy.transform.GetComponent<Target>();
                target.TakeDamage();
            }
        }

        if (Physics.Raycast(ray9, out RaycastHit hit9, range))
        {
            if (hit9.collider.tag == "FakeEnemy")
            {
                var nearestFakeEnemy = GameObject.FindGameObjectWithTag("FakeEnemy");
                Target fakeTarget = nearestFakeEnemy.transform.GetComponent<FakeTarget>();
                fakeTarget.TakeDamage();
            }
            else if (hit9.collider.tag == "Enemy")
            {
                var nearestEnemy = GameObject.FindGameObjectWithTag("Enemy");
                Target target = nearestEnemy.transform.GetComponent<Target>();
                target.TakeDamage();
            }
        }

        if (Physics.Raycast(ray10, out RaycastHit hit10, range))
        {
            if (hit10.collider.tag == "FakeEnemy")
            {
                var nearestFakeEnemy = GameObject.FindGameObjectWithTag("FakeEnemy");
                Target fakeTarget = nearestFakeEnemy.transform.GetComponent<FakeTarget>();
                fakeTarget.TakeDamage();
            }
            else if (hit10.collider.tag == "Enemy")
            {
                var nearestEnemy = GameObject.FindGameObjectWithTag("Enemy");
                Target target = nearestEnemy.transform.GetComponent<Target>();
                target.TakeDamage();
            }
        }

        if (Physics.Raycast(ray11, out RaycastHit hit11, range))
        {
            if (hit11.collider.tag == "FakeEnemy")
            {
                var nearestFakeEnemy = GameObject.FindGameObjectWithTag("FakeEnemy");
                Target fakeTarget = nearestFakeEnemy.transform.GetComponent<FakeTarget>();
                fakeTarget.TakeDamage();
            }
            else if (hit11.collider.tag == "Enemy")
            {
                var nearestEnemy = GameObject.FindGameObjectWithTag("Enemy");
                Target target = nearestEnemy.transform.GetComponent<Target>();
                target.TakeDamage();
            }
        }

        if (Physics.Raycast(ray12, out RaycastHit hit12, range))
        {
            if (hit12.collider.tag == "FakeEnemy")
            {
                var nearestFakeEnemy = GameObject.FindGameObjectWithTag("FakeEnemy");
                Target fakeTarget = nearestFakeEnemy.transform.GetComponent<FakeTarget>();
                fakeTarget.TakeDamage();
            }
            else if (hit12.collider.tag == "Enemy")
            {
                var nearestEnemy = GameObject.FindGameObjectWithTag("Enemy");
                Target target = nearestEnemy.transform.GetComponent<Target>();
                target.TakeDamage();
            }
        }

        if (Physics.Raycast(ray13, out RaycastHit hit13, range))
        {
            if (hit13.collider.tag == "FakeEnemy")
            {
                var nearestFakeEnemy = GameObject.FindGameObjectWithTag("FakeEnemy");
                Target fakeTarget = nearestFakeEnemy.transform.GetComponent<FakeTarget>();
                fakeTarget.TakeDamage();
            }
            else if (hit13.collider.tag == "Enemy")
            {
                var nearestEnemy = GameObject.FindGameObjectWithTag("Enemy");
                Target target = nearestEnemy.transform.GetComponent<Target>();
                target.TakeDamage();
            }
        }

        if (Physics.Raycast(ray14, out RaycastHit hit14, range))
        {
            if (hit14.collider.tag == "FakeEnemy")
            {
                var nearestFakeEnemy = GameObject.FindGameObjectWithTag("FakeEnemy");
                Target fakeTarget = nearestFakeEnemy.transform.GetComponent<FakeTarget>();
                fakeTarget.TakeDamage();
            }
            else if (hit14.collider.tag == "Enemy")
            {
                var nearestEnemy = GameObject.FindGameObjectWithTag("Enemy");
                Target target = nearestEnemy.transform.GetComponent<Target>();
                target.TakeDamage();
            }
        }

        if (Physics.Raycast(ray15, out RaycastHit hit15, range))
        {
            if (hit15.collider.tag == "FakeEnemy")
            {
                var nearestFakeEnemy = GameObject.FindGameObjectWithTag("FakeEnemy");
                Target fakeTarget = nearestFakeEnemy.transform.GetComponent<FakeTarget>();
                fakeTarget.TakeDamage();
            }
            else if (hit15.collider.tag == "Enemy")
            {
                var nearestEnemy = GameObject.FindGameObjectWithTag("Enemy");
                Target target = nearestEnemy.transform.GetComponent<Target>();
                target.TakeDamage();
            }
        }

        if (Physics.Raycast(ray16, out RaycastHit hit16, range))
        {
            if (hit16.collider.tag == "FakeEnemy")
            {
                var nearestFakeEnemy = GameObject.FindGameObjectWithTag("FakeEnemy");
                Target fakeTarget = nearestFakeEnemy.transform.GetComponent<FakeTarget>();
                fakeTarget.TakeDamage();
            }
            else if (hit16.collider.tag == "Enemy")
            {
                var nearestEnemy = GameObject.FindGameObjectWithTag("Enemy");
                Target target = nearestEnemy.transform.GetComponent<Target>();
                target.TakeDamage();
            }
        }

        if (Physics.Raycast(ray17, out RaycastHit hit17, range))
        {
            if (hit17.collider.tag == "FakeEnemy")
            {
                var nearestFakeEnemy = GameObject.FindGameObjectWithTag("FakeEnemy");
                Target fakeTarget = nearestFakeEnemy.transform.GetComponent<FakeTarget>();
                fakeTarget.TakeDamage();
            }
            else if (hit17.collider.tag == "Enemy")
            {
                var nearestEnemy = GameObject.FindGameObjectWithTag("Enemy");
                Target target = nearestEnemy.transform.GetComponent<Target>();
                target.TakeDamage();
            }
        }

        if (Physics.Raycast(ray18, out RaycastHit hit18, range))
        {
            if (hit18.collider.tag == "FakeEnemy")
            {
                var nearestFakeEnemy = GameObject.FindGameObjectWithTag("FakeEnemy");
                Target fakeTarget = nearestFakeEnemy.transform.GetComponent<FakeTarget>();
                fakeTarget.TakeDamage();
            }
            else if (hit18.collider.tag == "Enemy")
            {
                var nearestEnemy = GameObject.FindGameObjectWithTag("Enemy");
                Target target = nearestEnemy.transform.GetComponent<Target>();
                target.TakeDamage();
            }
        }

        if (Physics.Raycast(ray19, out RaycastHit hit19, range))
        {
            if (hit19.collider.tag == "FakeEnemy")
            {
                var nearestFakeEnemy = GameObject.FindGameObjectWithTag("FakeEnemy");
                Target fakeTarget = nearestFakeEnemy.transform.GetComponent<FakeTarget>();
                fakeTarget.TakeDamage();
            }
            else if (hit19.collider.tag == "Enemy")
            {
                var nearestEnemy = GameObject.FindGameObjectWithTag("Enemy");
                Target target = nearestEnemy.transform.GetComponent<Target>();
                target.TakeDamage();
            }
        }

        if (Physics.Raycast(ray20, out RaycastHit hit20, range))
        {
            if (hit20.collider.tag == "FakeEnemy")
            {
                var nearestFakeEnemy = GameObject.FindGameObjectWithTag("FakeEnemy");
                Target fakeTarget = nearestFakeEnemy.transform.GetComponent<FakeTarget>();
                fakeTarget.TakeDamage();
            }
            else if (hit20.collider.tag == "Enemy")
            {
                var nearestEnemy = GameObject.FindGameObjectWithTag("Enemy");
                Target target = nearestEnemy.transform.GetComponent<Target>();
                target.TakeDamage();
            }
        }
    }
}
