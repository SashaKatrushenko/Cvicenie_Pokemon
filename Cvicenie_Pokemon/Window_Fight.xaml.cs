using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Cvicenie_Pokemon
{
    /// <summary>
    /// Interaction logic for Window_Fight.xaml
    /// </summary>
    public partial class Window_Fight : Window
    {
        public Hero MyActualHero { get; set; }
        public Enemy Enemy { get; set; }
        private int heroStartupHealth;
        private int heroStartupEnergy;
        private int enemyStartupHealth;
        public Window_Fight(Hero hero, Enemy enemy)
        {
            InitializeComponent();

            MyActualHero = hero;
            Enemy = enemy;

            heroStartupHealth = hero.Health;
            heroStartupEnergy = hero.Energy_Max;
            enemyStartupHealth = enemy.Health_Max;

            ProgressBar_Hero.Maximum = hero.Health_Max;
            ProgressBar_Hero.Value = hero.Health;

            ProgressBar_Enemy.Maximum = enemy.Health_Max;
            ProgressBar_Enemy.Value = Enemy.Health;

            ProgressBar_Energy.Maximum = hero.Energy_Max;
            ProgressBar_Energy.Value = hero.Energy_Max;

        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            HeroAttackEnemy(1, 10);
            EnemyAttackHero();
            CheckHeathStatus();
            EnergyLost(0);
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            HeroAttack1Enemy(2);
            EnemyAttackHero();
            CheckHeathStatus();
            EnergyLost(2);
        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            HeroAttack2Enemy(5);
            EnemyAttackHero();
            CheckHeathStatus();
            EnergyLost(3);
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Heal(20, 15);
            CheckHeathStatus();
        }
        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            //RESTART
            MyActualHero.Health = heroStartupHealth;
            MyActualHero.Energy = heroStartupEnergy;
            Enemy.Health_Max = enemyStartupHealth;

            ProgressBar_Hero.Value = MyActualHero.Health;
            ProgressBar_Energy.Value = MyActualHero.Energy;
            ProgressBar_Enemy.Value = Enemy.Health_Max;

            Label_GameStatus.Content = "RESTART";
        }

        //METODY
        private Random random = new Random();
        private void HeroAttackEnemy(int damageScale, int energyCost)
        {
            if (MyActualHero.Energy < energyCost)
            {
                Label_GameStatus.Content = "Neni energia";
            }
            Label_GameStatus.Content = "";
            MyActualHero.Energy -= energyCost;
            ProgressBar_Energy.Value = MyActualHero.Energy;
            //miss
            bool isMiss = random.Next(0, 100) < MyActualHero.MissChance;
            if (isMiss)
            {
                Label_GameStatus.Content = "miss!";
                return;
            }
            int damage = MyActualHero.Damage * damageScale;

            

            int baseDamage = MyActualHero.Damage * damageScale;

            //crit        
            bool isCrit = random.Next(0, 100) < MyActualHero.CritChance;
            if (isCrit)
            {
                baseDamage *= 2;
                Label_GameStatus.Content = "kriticka ataka!";
            }
            else
            {
                Label_GameStatus.Content = "Hit!";
            }
            Enemy.Health -= damage;
            if (Enemy.Health < 0)
            {
                Enemy.Health = 0;
            }
            UpdateHeroHpLabel();
            ChangeColorHeroBar();
            CheckHeathStatus();
        }
        private void EnemyAttackHero()
        {
            MyActualHero.Health -= Enemy.Damage;
            if (MyActualHero.Health < 0)
            {
                MyActualHero.Health = 0;
            }
            UpdateEnemyHPLabel();
            ChangeColorHeroBar();
            CheckHeathStatus();
        }
        private void HeroAttack1Enemy(int damageScale)
        {
            Label_GameStatus.Content = "";
            //miss
            int missChange = 15;
            bool isMiss = random.Next(0, 100) < missChange;
            //  Label_GameStatus.Content = isMiss ? "MISS" : "HIT";
            if (isMiss)
            {
                Label_GameStatus.Content = "miss";
                return;
            }

            int baseDamage = MyActualHero.Damage * damageScale;

            //crit        
            int critChance = 10;
            bool isCrit = random.Next(0, 100) < critChance;
            if (isCrit)
            {
                baseDamage *= 2;
                Label_GameStatus.Content = "kriticka ataka";
            }
            Enemy.Health_Max -= baseDamage;
            ProgressBar_Enemy.Value = Enemy.Health_Max;
        }
        private void HeroAttack2Enemy(int damageScale)
        {
            Label_GameStatus.Content = "";
            //miss
            int missChange = 20;
            bool isMiss = random.Next(0, 100) < missChange;
            //  Label_GameStatus.Content = isMiss ? "MISS" : "HIT";
            if (isMiss)
            {
                Label_GameStatus.Content = "miss";
                return;
            }
            int baseDamage = MyActualHero.Damage * damageScale;

            //crit        
            int critChance = 5;
            bool isCrit = random.Next(0, 100) < critChance;
            if (isCrit)
            {
                baseDamage *= 2;
                Label_GameStatus.Content = "kriticka ataka";
            }
            Enemy.Health_Max -= baseDamage;
            ProgressBar_Enemy.Value = Enemy.Health_Max;
        }
        private void CheckHeathStatus()
        {
            if (MyActualHero.Health <= 0)
            {
                Label_GameStatus.Content = "Loser =(";
            }
            if (Enemy.Health_Max <= 0)
            {
                Label_GameStatus.Content = "Winner =D";
            }
        }
        private void EnergyLost(int damageScale)
        {
            MyActualHero.Energy_Max -= MyActualHero.Energy * damageScale;
            ProgressBar_Energy.Value = MyActualHero.Energy_Max;
        }
        private void Heal(int healAmount, int energyCost)
        {
            if (MyActualHero.Energy_Max <= energyCost)
            {
                Label_GameStatus.Content = "Nemas energiu";
                return;
            }
            MyActualHero.Energy_Max -= energyCost;
            MyActualHero.Health += healAmount;

            if (MyActualHero.Health > MyActualHero.Health_Max)
            { MyActualHero.Health = MyActualHero.Health_Max; }

            ProgressBar_Hero.Value = MyActualHero.Health;
            ProgressBar_Energy.Value = MyActualHero.Energy_Max;
        }

        private void ChangeColorHeroBar()
        {
            double healthPercent = (double)MyActualHero.Health / MyActualHero.Health_Max;
            if (healthPercent > 0.6)
            {
                ProgressBar_Hero.Foreground = Brushes.Green;
            }
            else if (healthPercent > 0.3)
            {
                ProgressBar_Hero.Foreground = Brushes.Yellow;
            }
            else
            {
                ProgressBar_Hero.Foreground = Brushes.Red;
            }
        }
        private void UpdateHeroHpLabel()
        {
            Label_HeroHP.Content = $"{MyActualHero.Health}/{MyActualHero.Health_Max}";
        }
        private void UpdateEnemyHPLabel()
        {
            Label_EnemyHP.Content = $"{Enemy.Health}/{Enemy.Health_Max}";
        }
    }
}
          

