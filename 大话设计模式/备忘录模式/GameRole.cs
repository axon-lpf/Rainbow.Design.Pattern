using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 大话设计模式.备忘录模式
{
  public  class GameRole
    {
        private int vitality;

        public int Vitality
        {
            get { return vitality; }
            set { vitality = value; }
        }

        private int attack;

        public int Attack
        {
            get { return attack; }
            set { attack = value; }
        }

        private int defense;

        public int Defense
        {
            get { return defense; }
            set { defense = value; }
        }

        public GameRole() 
        {
            //初始化属性数据
            this.attack = 1000;
            this.vitality = 1000;
            this.defense = 1000;
        }
      /// <summary>
      /// 存档
      /// </summary>
      /// <returns></returns>
        public GameRoleStateMemento SaveGameState() 
        {
            return (new GameRoleStateMemento(vitality,attack,defense));
        }

      /// <summary>
      /// 恢复存档
      /// </summary>
      /// <param name="game"></param>
        public void RecoveryState(GameRoleStateMemento game) 
        {
            this.attack = game.Attack;
            this.defense = game.Defense;
            this.vitality = game.Vitality;
        }
      /// <summary>
      /// z战斗
      /// </summary>
        public void Fight() 
        {
            this.attack = 100;
            this.vitality = 100;
            this.defense = 100;
        }
    }

   /// <summary>
   /// 备份者
   /// </summary>
  public class GameRoleStateMemento 
  {
      public GameRoleStateMemento(int vit,int att,int def) 
      {
          this.vitality = vit;
          this.attack = att;
          this.defense = def;
      }
      private int vitality;

      public int Vitality
      {
          get { return vitality; }
          set { vitality = value; }
      }

      private int attack;

      public int Attack
      {
          get { return attack; }
          set { attack = value; }
      }

      private int defense;

      public int Defense
      {
          get { return defense; }
          set { defense = value; }
      }
  }

  /// <summary>
  /// 备份管理者
  /// </summary>
  public class MementoManager 
  {
      private GameRoleStateMemento memento;

      public GameRoleStateMemento Memento
      {
          get { return memento; }
          set { memento = value; }
      }
  }
}
