using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 大话设计模式.代理模式
{
  public  interface GiveGift
    {
        void GiveDolls();
        void GiveFlowers();
        void GiveChocolate();
    }
  public class GirlMM 
  {
      public string Name { get; set; }
  }

  public class Pursuit : GiveGift 
  {
      GirlMM MM;
      public Pursuit( GirlMM mm) 
      {
          this.MM = mm;
      }

      public void GiveDolls()
      {
          Console.WriteLine(this.MM.Name+"送你洋娃娃");
      }

      public void GiveFlowers()
      {
          Console.WriteLine(this.MM.Name + "送你鲜花");
      }

      public void GiveChocolate()
      {
          Console.WriteLine(this.MM.Name + "送你巧克力");
      }
  }

  public class Proxy : GiveGift 
  {
      Pursuit pur;
      public Proxy(Pursuit pur) 
      {
          this.pur =pur ;
      }

      public void GiveDolls()
      {
          pur.GiveDolls();  
      }

      public void GiveFlowers()
      {
          pur.GiveFlowers();
      }

      public void GiveChocolate()
      {
          pur.GiveChocolate();
      }
  }
}
