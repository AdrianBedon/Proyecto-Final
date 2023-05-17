using UnityEngine;
using System.Collections;

public class ShotBehavior : MonoBehaviour {

	public Vector3 m_target;
	public GameObject collisionExplosion;
	public float speed;
	
	// Update is called once per frame
	void Update () {
		float step = speed * Time.deltaTime;
		if (m_target != null)
		{
			if (transform.position == m_target)
			{
				explode();
				return;
			}
			transform.position = Vector3.MoveTowards(transform.position, m_target, step);
		}
	}

	public void setTarget(Vector3 target)
	{
		m_target = target;
	}

	void explode()
	{
		if (collisionExplosion != null)
		{
			GameObject explosion = (GameObject)Instantiate(collisionExplosion, transform.position, transform.rotation);

			Collider[] colliders = Physics.OverlapSphere(transform.position, 50f);

			foreach (Collider closeObjects in colliders)
			{
				Rigidbody rigidbody = closeObjects.GetComponent<Rigidbody>();

				if (rigidbody != null)
				{
					rigidbody.AddExplosionForce(50f, transform.position, 50f);
				}
			}

			Destroy(gameObject);
			Destroy(explosion, 1f);
		}
	}
}
