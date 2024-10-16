using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Visometry.VisionLib.SDK.Core;
using Visometry.VisionLib.SDK.Core.API;

public class SceneMainMenuMaganer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI sliderText = null;
    [SerializeField] private TextMeshProUGUI sliderText2 = null;
    [SerializeField] private float maxSliderAmount = 100.0f;
    public Slider slider;
    public Slider slider2;
    public static string type;
    public TrackingAnchor trackingAnchor;
    public Transform trackedVirtualObject; // O objeto virtual

    void Start()
    {
        Debug.Log("TESTE");
        // Opcional: Adicione um log para verificar se o slider é nulo
      //  Debug.Log("Valor do slider no Start: " + (slider != null ? slider.value.ToString() : "null"));
    }

    private void Update()
    {
        getPosition();
        getPositionVirtualObject();
    }

    public void getPosition()
    {
        if (trackingAnchor.IsTracking())
        {
            Debug.Log("RETORNOU TRUE!!!");

            // Obtendo a pose do objeto rastreado
            ModelTransform pose = (ModelTransform)trackingAnchor.GetLastTrackingPose();

            // Extraindo a posição (assumindo que a pose é válida)
            Vector3 posicaoReal = pose.t;

            // Converter para o sistema de coordenadas do Unity
            Vector3 posicaoNoUnity = trackingAnchor.transform.TransformPoint(posicaoReal);

            // Utilizando a posição convertida
            Debug.Log("Posição do objeto Real no Unity: X=" + posicaoNoUnity.x + ", Y=" + posicaoNoUnity.y + ", Z=" + posicaoNoUnity.z);
        }
        else
        {
            Debug.Log("RETORNOU FALSE :(");
        }
    }


    public void getPositionVirtualObject()
    {
        Vector3 posicaoVirtual = trackedVirtualObject.position;
        Debug.Log("Posição do objeto Virtual: X=" + posicaoVirtual.x + ", Y=" + posicaoVirtual.y + ", Z=" + posicaoVirtual.z);
    }


    public void SliderChange()
    {
        Debug.Log("Valor do slider: " + slider.value);
        float localValue = slider.value * maxSliderAmount;
        sliderText.text = localValue.ToString("0");
    }

    public void SliderChangeTwo()
    {
        Debug.Log("Valor do slider: " + slider2.value);
        float localValue = slider2.value * maxSliderAmount;
        sliderText2.text = localValue.ToString("0");
    }


    public void goMainMenu()
    {
        type = "";
        SceneManager.LoadScene(0);
    }
    
    public void goSelectAnimationScreen()
    {
        SceneManager.LoadScene(1);
    }
    //saudável
    public void goHeartEstructures()
    {
        SceneManager.LoadScene(2);
    }

    public void goSimpleHeart()
    {
        SceneManager.LoadScene(5);
    }

    public void goHeartTrackingFlow()
    {
        SceneManager.LoadScene(3);
    }

    public void goHeartbeat()
    {
        SceneManager.LoadScene(4);
    }
    //amiloidose
    public void goDescriptionAmiloidose()
    {
        type ="amiloidose";
        SceneManager.LoadScene(6);
    }

    public void goSimpleTrackingAmiloidose()
    {
        SceneManager.LoadScene(7);
    }

    public void goEstructuresTrackingAmiloidose()
    {
        SceneManager.LoadScene(9);
    }

    public void goHeartBeatTrackingAmiloidose()
    {
        SceneManager.LoadScene(8);
    }

    public void goFlowTrackingAmiloidose()
    {
        SceneManager.LoadScene(10);
    }


    //pseudoAneurisma

    public void goDescriptionPseudoAneurisma()
    {
        type = "pseudo-aneurisma";
        SceneManager.LoadScene(11);
    }

    public void goSimpleTrackingPseudoAneurisma()
    {
        SceneManager.LoadScene(14);
    }

    public void goEstructuresPseudoAneurisma()
    {
        SceneManager.LoadScene(12);
    }

    public void goHeartBeatPseudoAneurisma()
    {
        SceneManager.LoadScene(13);
    }

    public void goFlowPseudoAneurisma()
    {
        SceneManager.LoadScene(15);
    }

    //fibroelastoma
    public void goDescriptionFibroelastoma()
    {
        type = "fibro-elastoma";
        SceneManager.LoadScene(16);
    }
    public void goEstructuresFibroelastoma()
    {
       // SceneManager.LoadScene(14);
    }
    public void goHeartBeatFibroelastoma()
    {
      //  SceneManager.LoadScene(14);
    }
    public void goFlowFibroelastoma()
    {
       // SceneManager.LoadScene(14);
    }
    public void goSimpleTrackingFibroElastoma()
    {
        SceneManager.LoadScene(17);
    }

    //cardiomegalia
    public void goDescriptionCardiomegalia()
    {
        type = "cardiomegalia";
        SceneManager.LoadScene(22);
    }

    public void goSimpleTrackingCardiomegalia()
    {
        SceneManager.LoadScene(21);
    }

    public void goHeartBeatCardiomegalia()
    {
        SceneManager.LoadScene(20);
    }


    public void goFlowTrackingCardiomegalia()
    {
        SceneManager.LoadScene(19);
    }

    public void goEstructuresTrackingCardiomegalia()
    {
        SceneManager.LoadScene(18);
    }



    public void goToSimpleScene()
    {
        if (type == "amiloidose")
        {
           goSimpleTrackingAmiloidose();
           return;
        }
        if (type == "fibro-elastoma") 
        {
            goSimpleTrackingFibroElastoma();
            return;
        }
        if (type == "pseudo-aneurisma") 
        {
            goSimpleTrackingPseudoAneurisma();
            return;
        }
        if (type == "cardiomegalia")
        {
            goSimpleTrackingCardiomegalia();
            return;
        }
        else {
            goSimpleHeart();
            return;
        }
        
    }
    public void goToEstructuresScene()
    {
        if (type == "amiloidose")
        {
            goEstructuresTrackingAmiloidose();
            return;
        }
        if (type == "fibro-elastoma")
        {
            
            return;
        }
        if (type == "cardiomegalia")
        {
            goEstructuresTrackingCardiomegalia();
            return;
        }
        if (type == "pseudo-aneurisma")
        {
            goEstructuresPseudoAneurisma();
            return;
        }
        else
        {
            goHeartEstructures();
            return;
        }

    }
    public void goToHeartBeatScene()
    {
        if (type == "amiloidose")
        {
            goHeartBeatTrackingAmiloidose();
            return;
        }
        if (type == "fibro-elastoma")
        {
            
            return;
        }
        if (type == "cardiomegalia")
        {
            goHeartBeatCardiomegalia();
            return;
        }
        if (type == "pseudo-aneurisma")
        {
            goHeartBeatPseudoAneurisma();
            return;
        }
        else
        {
            goHeartbeat();
            return;
        }

    }
    public void goToBloodFlowScene()
    {
        if (type == "amiloidose")
        {
            goFlowTrackingAmiloidose();
            return;
        }
        if (type == "fibro-elastoma")
        {
            
            return;
        }
        if (type == "cardiomegalia")
        {
            goFlowTrackingCardiomegalia();
            return;
        }
        if (type == "pseudo-aneurisma")
        {
            goFlowPseudoAneurisma();
            return;
        }
        else
        {
            goHeartTrackingFlow();
            return;
        }

    }
    public void finish()
    {
        Application.Quit();
    }

}
