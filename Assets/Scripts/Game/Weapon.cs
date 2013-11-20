using UnityEngine;
using System.Collections;

[System.Serializable]
public class Weapon
{
		/// <summary>
		/// The damage.
		/// </summary>
		public float damage;

		/// <summary>
		/// Attack the specified target.
		/// </summary>
		/// <param name="target">Target.</param>
		public float Attack (Monster target)
		{
				float attackDamage = damage;
				target.DoDamage (attackDamage);
				return attackDamage;
		}
}
