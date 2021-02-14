using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitiatePlayField : MonoBehaviour
{
    //Größe des Spielfelds. bei geraden Zahlen kann diese beliebig geändert werden
    //ACHTUNG: Sollten auch ungerade Anzaheln der maximalen Felder(auf x- oder z-Achse) gewünscht sein, muss der Code angepasst werden
    public float playfieldHeight = 8;
    public double playfieldLength = 8;
    //in diesen GameObjects sind die Prefabs aus Unity abgelegt
    public GameObject vicPlane;
    public GameObject dmgPlane;
    public GameObject PlaneC1;
    public GameObject PlaneC2;
    //Vektoren zum Aneinanderreihen der Spielfeldplanes via automatische Generierung
    //zwei Anfangs- und Referenzpunkte, da das Spielfeld gleichzeitig von links oben und recht unten aus generiert wird
    private Vector3 startPointA = new Vector3(5, 0, 5);
    private Vector3 startPointB;
    private Vector3 anchorPointA;
    private Vector3 anchorPointB;
    //boolsche Werte zur Erzeugung eines Checkpattern auf dem eigentlichen Battlefield
    private bool startPlaneLastRowC1UP;
    private bool startPlaneLastRowC1DOWN;
    private bool lastPlaneColC1UP;
    private bool lastPlaneColC1DOWN;

    // Start is called before the first frame update
    void Start()
    {
        //Erstellung Spielfeld
        for (int x = 1; x<= playfieldHeight/2; x++)
        {
            //Erstellung der VictoryRows(z-Achse)
            if (x == 1)
            {
                for (int z = 1; z <= playfieldLength; z++)
                {
                    if (z == 1)
                    {
                        //Startpunkt VictoryRow oben
                        Instantiate(vicPlane, startPointA, Quaternion.identity);
                        anchorPointA = startPointA;

                        //Startpunkt VictoryRow unten
                        startPointB.x = (playfieldHeight * 10) - 5;
                        startPointB.z = (playfieldHeight * 10) - 5;
                        anchorPointB = startPointB;
                        Instantiate(vicPlane, startPointB, Quaternion.identity);
                    }

                    //immer ein Feld weiter, bis maximale Anzahl erreicht
                    if (z > 1)
                    {
                        Instantiate(vicPlane, startPointA += new Vector3(0, 0, 10), Quaternion.identity);
                        Instantiate(vicPlane, startPointB -= new Vector3(0, 0, 10), Quaternion.identity);
                    }

                    //Wenn Row fertig generiert, wird hier Referenzpunkt für nächste Row in der Zwischenvariable abgelegt
                    if (z == playfieldLength)
                    {
                        anchorPointA.x += 10;
                        anchorPointB.x -= 10;
                    }
                }
            }

            //Erstellung der DMGRows(z-Achse)
            if (x == 2)
            {
                for (int z = 1; z <= playfieldLength; z++)
                {
                    if (z == 1)
                    {
                        //Startpunkt DMGRow oben
                        startPointA = anchorPointA;
                        Instantiate(dmgPlane, startPointA, Quaternion.identity);

                        //Startpunkt DMGRow unten
                        startPointB = anchorPointB;
                        Instantiate(dmgPlane, startPointB, Quaternion.identity);
                    }

                    //immer ein Feld weiter, bis maximale Anzahl erreicht
                    if (z > 1)
                    {
                        Instantiate(dmgPlane, startPointA += new Vector3(0, 0, 10), Quaternion.identity);
                        Instantiate(dmgPlane, startPointB -= new Vector3(0, 0, 10), Quaternion.identity);
                    }

                    //Wenn Row fertig generiert, wird hier Referenzpunkt für nächste Row in der Zwischenvariable abgelegt
                    if (z == playfieldLength)
                    {
                        anchorPointA.x += 10;
                        anchorPointB.x -= 10;
                    }
                }
            }

            //Erstellung Battlefield
            if (x > 2)
            {
                for (int z = 1; z <= playfieldLength; z++)
                {
                    if (z == 1)
                    {
                        //If-Abfrage erzeugt ein Checkpattern
                        if (startPlaneLastRowC1UP == false && startPlaneLastRowC1DOWN == false)
                        {
                            //Startpunkt Battlefieldrow oben
                            startPointA = anchorPointA;
                            Instantiate(PlaneC1, startPointA, Quaternion.identity);
                            startPlaneLastRowC1UP = true;
                            lastPlaneColC1UP = true;

                            //Startpunkt Battlefieldrow unten
                            startPointB = anchorPointB;
                            Instantiate(PlaneC1, startPointB, Quaternion.identity);
                            startPlaneLastRowC1DOWN = true;
                            lastPlaneColC1DOWN = true;
                        }
                        else if (startPlaneLastRowC1UP == true && startPlaneLastRowC1DOWN == true)
                        {
                            //Startpunkt Battlefieldrow oben
                            startPointA = anchorPointA;
                            Instantiate(PlaneC2, startPointA, Quaternion.identity);
                            startPlaneLastRowC1UP = false;
                            lastPlaneColC1UP = false;

                            //Startpunkt Battlefieldrow unten
                            startPointB = anchorPointB;
                            Instantiate(PlaneC2, startPointB, Quaternion.identity);
                            startPlaneLastRowC1DOWN = false;
                            lastPlaneColC1DOWN = false;
                        }
                    }

                    //immer ein Feld weiter, bis maximale Anzahl erreicht
                    if (z > 1)
                    {
                        //If-Abfrage erzeugt ein Checkpattern
                        if (lastPlaneColC1UP == false && lastPlaneColC1DOWN == false)
                        {
                            Instantiate(PlaneC1, startPointA += new Vector3(0, 0, 10), Quaternion.identity);
                            Instantiate(PlaneC1, startPointB -= new Vector3(0, 0, 10), Quaternion.identity);
                            lastPlaneColC1UP = true;
                            lastPlaneColC1DOWN = true;
                        }

                        else if (lastPlaneColC1UP == true && lastPlaneColC1DOWN == true)
                        {
                            Instantiate(PlaneC2, startPointA += new Vector3(0, 0, 10), Quaternion.identity);
                            Instantiate(PlaneC2, startPointB -= new Vector3(0, 0, 10), Quaternion.identity);
                            lastPlaneColC1UP = false;
                            lastPlaneColC1DOWN = false;
                        }
                    }
                    //Wenn Row fertig generiert, wird hier Referenzpunkt für nächste Row in der Zwischenvariable abgelegt
                    if (z == playfieldLength)
                    {
                        anchorPointA.x += 10;
                        anchorPointB.x -= 10;
                    }
                }
            }
        }

           
    }

 
}
