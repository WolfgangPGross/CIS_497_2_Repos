using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    public PlayerModifier playerModifier;

    public Rigidbody rigidbody;
    public GameObject projectile;
    private Rigidbody projectile_Rigidbody;

    /// <summary>
    /// Is the left mouse button down?
    /// </summary>
    private bool isFiring = false;
    private bool cooledDown = true;

    //this reference is set in the inspector
    public TextDisplay textDisplay;

    private void Awake()
    {
        playerModifier = new PlayerModifier();
        
        rigidbody = GetComponent<Rigidbody>();
        //projectile_Rigidbody = projectile.Rigidbody;
    }

    private void Start()
    {
        UpdateDisplayText();
    }

    private void OnTriggerEnter(Collider other)
    {
        Modifier modifier = other.gameObject.GetComponent<Modifier>();
        if (modifier != null)
        {
            AddPlayerCharacterDecorator(modifier);
        }
    }

    private void AddPlayerCharacterDecorator(Modifier modifier)
    {

        switch (modifier.modifierType)
        {
            case Modifier.ModifierType.MODIFIERSPEEDUP:
                playerModifier = new ModifierSpeedUp(playerModifier);
                break;
            case Modifier.ModifierType.MODIFIERSPEEDDOWN:
                playerModifier = new ModifierSpeedDown(playerModifier);
                break;
            case Modifier.ModifierType.MODIFIERDAMAGEUP:
                playerModifier = new ModifierDamageUp(playerModifier);
                break;
            case Modifier.ModifierType.MODIFIERDAMAGEDOWN:
                playerModifier = new ModifierDamageDown(playerModifier);
                break;
            case Modifier.ModifierType.MODIFIERKNOCKBACKUP:
                playerModifier = new ModifierKnockbackUp(playerModifier);
                break;
            case Modifier.ModifierType.MODIFIERKNOCKBACKDOWN:
                playerModifier = new ModifierKnockbackDown(playerModifier);
                break;
            default:
                break;
        }

        UpdateDisplayText();

    }

    public void UpdateDisplayText()
    {
        textDisplay.Display(playerModifier);
    }

    void Update()
    {
        Move();
        AttackCheck();
        if (isFiring && cooledDown)
        {
            StartCoroutine(Attack());
        }
    }

    //The player speed has been changed to playerPowerups.speed
    #region Movement

    private float horiztonalInput;
    private float verticalInput;

    private void Move()
    {
        //Get Input
        horiztonalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        //Transform with input

        transform.Translate(Vector3.forward * verticalInput * Time.deltaTime * playerModifier.speed);
        transform.Translate(Vector3.right * horiztonalInput * Time.deltaTime * playerModifier.speed);

        //rigidbody.AddForce(Vector3.forward * verticalInput * Time.deltaTime * playerModifier.speed * 5);
        //rigidbody.AddForce(Vector3.right * horiztonalInput * Time.deltaTime * playerModifier.speed * 5);

    }
    #endregion

    #region Attacks

    //Check to see if the leftMouse is clicked, and if the attack is cooled down
    private void AttackCheck()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isFiring = true;
        }
        else
        {
            isFiring = false;
        }
    }

    //Spawn projectile and give it attack/travel script w/specified damage & knockback
    IEnumerator Attack()
    {       
        cooledDown = false;
        
        GameObject clone;
        
        // Instantiate the projectile at the position and rotation of this transform
        clone = Instantiate(projectile, transform.position, transform.rotation);

        //Add the damaging attack script with parameters in the constructor
        DamagingAttack Attacker = clone.AddComponent<DamagingAttack>();
        Attacker.damage = playerModifier.damage;
        Attacker.knockback_Strength = playerModifier.knockback;

        yield return new WaitForSeconds(.25f);                    
        cooledDown = true;
    }

    #endregion
}