using System;
using System.Collections.Generic;
using System.Text;

namespace EpicRPG.Util
{
    public class RNG : Singleton<RNG>
    {
        public static int RandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }

        //will pick how maany enemies are on the screen
        public static int EnemyOnScreen()
        {
            return RNG.getInstance().RandomNumber(0, 2);
        }

        //will pick the enemies location
        //need to work on this later
        /*public static Vector2 EnemyPos()
        {
            int x = this.RandomNumber(min, max);
            int y = this.RandomNumber(min, max);
            
        }*/

        //sees if regular attack crits
        //will have to add in crit chance modifier (luck?) later
        public static bool CritAttack()
        {
            int hit = RNG.getInstance().RandomNumber(0, 100);
            //int hit = this.RandomNumber(0, 100) + character.getLuck()
            if (hit >= 90)
                return (true);
            else
                return (false);
        }

        //if weapon unleashes an ability, sees if ability is unleash
        //same as crit chance, need to add 
        public static bool WeaponAbility()
        {
            int use = RNG.getInstance().RandomNumber(0, 100);
            if (use >= 90)
                return (true);
            else
                return (false);
        }

        //see if you run away
        public static bool RunAway()
        {
            int run = RNG.getInstance().RandomNumber(1,4);
            if(run >= 4);
                return(false);   
        }
    }
}
