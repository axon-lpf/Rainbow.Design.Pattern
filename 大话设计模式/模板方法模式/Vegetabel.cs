using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 大话设计模式.模板方法模式
{
  public abstract  class Vegetabel
    {
      public void CookVegetabel() 
      {
          Console.WriteLine("炒菜的一般做法");
          this.pourOil();
          this.HeatOil();
          this.pourVegetable();
          this.stir_fry();
          this.Out_Guo();
      }
      public void pourOil() 
      {
          Console.WriteLine("第一步倒油");
      }
      public void HeatOil() 
      {
          Console.WriteLine("第二步烧热油");
      }
      /// <summary>
      /// 这一步具体看要到什么 菜咯
      /// </summary>
      public abstract void pourVegetable();

      public void stir_fry() 
      {
          Console.WriteLine("第三步翻炒");
      }
      public void Out_Guo()
      {
          Console.WriteLine("最后一步出锅");
      }
    }

    /// <summary>
    /// 菠菜的做法
    /// </summary>
  public class Spinach : Vegetabel
  {
      public override void pourVegetable()
      {
          Console.WriteLine("倒菠菜进锅中");
      }
  }
    /// <summary>
    /// 大白菜的做法
    /// </summary>
  public class ChineseCabbage : Vegetabel 
  {

      public override void pourVegetable()
      {
          Console.WriteLine("倒大白菜进锅中");
      }
  }

}
