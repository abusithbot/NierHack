using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{

    //le gameobject utilisé pour le projectile
    public GameObject   bulletPrefab;
    //un transform utilisé pour localiser l'endroit d'apparition du projectile
    public Transform newBulletPositionTransform;
    //un transform pour regrouper les projectiles ensemble
    public Transform newBulletGroupTransform;

    void Update()
    {
        bool shootPressed = Input.GetButtonDown("Fire1");
        if (shootPressed)
        {
            Debug.Log("Shoot !");

            //1 création du clone
            GameObject newBulletRef = Object.Instantiate(bulletPrefab);

            //2 le parent est un transform qui sera utilisé pour la position
            newBulletRef.transform.parent = newBulletPositionTransform;

            //3 la position est mise à 0 0 0, par rapport à son parent
            //localPosition est la position relative au parent
            newBulletRef.transform.localPosition = Vector3.zero;

            //3.5  on s'aligne par rapport au parent
            newBulletRef.transform.rotation = transform.rotation;

            //4 on enlève le parent pour ne plus dans le "player"
            //(sinon le projectile bouge en même temps que le parent)
            newBulletRef.transform.parent = newBulletGroupTransform;
        }
    }
}