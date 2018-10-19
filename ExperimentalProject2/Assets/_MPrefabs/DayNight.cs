using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNight : MonoBehaviour {
    public enum TimeOfDay
    {
        Main,
        DarkForest

    };
    private struct TypeOfDay
    {
        public float maxI;
        public float minI;
        public float minP;

        public float maxA;
        public float minA;
        public float minAP;

        public Gradient FogColor;
        public AnimationCurve fogDensityCurve;
        public float fogS;

        public float dayAtmosThic;
        public float nihAtomsThic;
    };

    private TypeOfDay MAIN;
    private TypeOfDay SpookyForest;


    public TimeOfDay DayType;
    public Gradient nightDayColor;

    private float maxIntensity;
    private float minIntensity;
    private float minPoint;

    private float maxAmbient;
    private float minAmbient;
    private float minAmbientPoint;


    public Gradient nightDayFogColor;
    private AnimationCurve fogDensityCurve;
    private float fogScale;

    private float dayAtmosphereThickness;
    private float nightAtmosphereThickness;

    float skySpeed = 1;

    public Light mainLight;
    Skybox sky;
    Material skyMat;

    void Start()
    {
        skyMat = RenderSettings.skybox;

        MAIN.maxI = 0.84f;
        MAIN.minI = 0f;
        MAIN.minP = -0.25f;

        MAIN.maxA = 2.89f;
        MAIN.minA = 0f;
        MAIN.minAP = 0.65f;


        MAIN.FogColor = new Gradient();
        MAIN.fogDensityCurve = new AnimationCurve();
        MAIN.fogS = 1f;

        MAIN.dayAtmosThic = 0.4f;
        MAIN.nihAtomsThic = 0.87f;

        SpookyForest.maxI = 2.62f;
        SpookyForest.minI = -7.8f;
        SpookyForest.minP = -0.2f;

        SpookyForest.maxA = 1f;
        SpookyForest.minA = 0f;
        SpookyForest.minAP = -0.2f;

        SpookyForest.FogColor = new Gradient();
        SpookyForest.fogDensityCurve = new AnimationCurve();
        SpookyForest.fogDensityCurve.AddKey(0.120f, 0.0222f);
        SpookyForest.fogDensityCurve.AddKey(0.998f, 0.16f);
        SpookyForest.fogS = 1f;

        SpookyForest.dayAtmosThic = 8.65f;
        SpookyForest.nihAtomsThic = 0.69f;
    }

    void UpdateSkyBox(TypeOfDay S)
    {
     maxIntensity = S.maxI;
     minIntensity = S.minI;
     minPoint = S.minA;

     maxAmbient = S.maxA;
     minAmbient = S.minA;
     minAmbientPoint = S.minAP;


    nightDayFogColor = S.FogColor;
    fogDensityCurve = S.fogDensityCurve;
     fogScale = S.fogS;

     dayAtmosphereThickness = S.dayAtmosThic;
     nightAtmosphereThickness = S.nihAtomsThic;
}

    void Update()
    {
        if(DayType == TimeOfDay.Main)
        {
            UpdateSkyBox(MAIN);
        }else if(DayType == TimeOfDay.DarkForest)
        {
            UpdateSkyBox(SpookyForest);
        }
        float tRange = 1 - minPoint;
        float dot = Mathf.Clamp01((Vector3.Dot(mainLight.transform.forward, Vector3.down) - minPoint) / tRange);
        float i = ((maxIntensity - minIntensity) * dot) + minIntensity;

        mainLight.intensity = i;

        tRange = 1 - minAmbientPoint;
        dot = Mathf.Clamp01((Vector3.Dot(mainLight.transform.forward, Vector3.down) - minAmbientPoint) / tRange);
        i = ((maxAmbient - minAmbient) * dot) + minAmbient;
        RenderSettings.ambientIntensity = i;

        mainLight.color = nightDayColor.Evaluate(dot);
        RenderSettings.ambientLight = mainLight.color;
        RenderSettings.fogColor = nightDayFogColor.Evaluate(dot);
        RenderSettings.fogDensity = fogDensityCurve.Evaluate(dot) * fogScale;

        i = ((dayAtmosphereThickness - nightAtmosphereThickness) * dot) + nightAtmosphereThickness;
        skyMat.SetFloat("_AtmosphereThickness", i);


    }
}
