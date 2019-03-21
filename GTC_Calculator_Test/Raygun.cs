namespace Automation_Test
{
    public class Raygun
    {

        private int ammo = 3;

        public void FireAt(Bug bug)
        {
            if (HasAmmo())
            {
                if (bug.IsDodging())
                {
                    bug.Miss();
                }
                else
                {
                    bug.Hit();
                }
                ammo--;
            }
        }

        public void Recharge()
        {
            ammo = 3;
        }

        public bool HasAmmo()
        {
            return ammo > 0;
        }
    }
    public class Bug
    {

        private bool dodging;
        private bool dead;

        public void Dodge()
        {
            dodging = true;
        }

        public void Hit()
        {
            dead = true;
        }

        public void Miss()
        {
            dodging = false;
        }

        public bool IsDodging()
        {
            return dodging;
        }

        public bool IsDead()
        {
            return dead;
        }
    }
}
