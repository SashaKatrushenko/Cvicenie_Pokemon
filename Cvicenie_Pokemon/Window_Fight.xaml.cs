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
        public Window_Fight(Hero hero, Enemy enemy)
        {
            InitializeComponent();
            //  Label_myText.Content = myText;
            MyActualHero = hero;
            Enemy = enemy;

            ProgressBar_Hero.Maximum = hero.Health_Max;
            ProgressBar_Hero.Value = hero.Health;

            ProgressBar_Enemy.Maximum = enemy.Health_Max;
            ProgressBar_Enemy.Value = Enemy.Health_Max;

            ProgressBar_Energy.Maximum = hero.Energy_Max;
            ProgressBar_Energy.Value = hero.Energy_Max;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            HeroAttackEnemy(1);
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

        //METODY
        private void HeroAttackEnemy(int damageScale)
        {
            Enemy.Health_Max -= MyActualHero.Damage * damageScale;
            ProgressBar_Enemy.Value = Enemy.Health_Max;
        }
        private void EnemyAttackHero()
        {
            MyActualHero.Health -= Enemy.Damage;
            ProgressBar_Hero.Value = MyActualHero.Health;
        }
        private void HeroAttack1Enemy(int damageScale)
        {
            Enemy.Health_Max -= MyActualHero.Damage * damageScale;
            ProgressBar_Enemy.Value = Enemy.Health_Max;
        }
        private void HeroAttack2Enemy(int damageScale)
        {
            Enemy.Health_Max -= MyActualHero.Damage * damageScale;
            ProgressBar_Enemy.Value = Enemy.Health_Max;
        }
        private void CheckHeathStatus()
        {
            if(MyActualHero.Health <= 0)
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

    }
}
