using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 大话设计模式.外观模式
{
  public  class Projector
    {
      public void OpenProjector() 
      {
          Console.WriteLine("打开投影仪");
      }
      public void CloseProjector() 
      {
          Console.WriteLine("关闭投影仪");
      }
      public void SetWideScreen() 
      {
          Console.WriteLine("投影仪的状态现在是宽频模式");
      }
      public void SetStandardScreen() 
      {
          Console.WriteLine("投影仪的状态现在是标准模式");
      }

    }

  public class Amplifier 
  {
      public void OpenAmplifier() 
      {
          Console.WriteLine("打开功放机");
      }
      public void CloseAmplifier() 
      {
          Console.WriteLine("关闭功放机");
      }
  }

  public class Screen 
  {
      public void OpenScreen() 
      {
          Console.WriteLine("打开屏幕");
      }
      public void CloseScreen() 
      {
          Console.WriteLine("关闭屏幕");
      }
  }

  public class DVDPlayer 
  {
      public void OpenDVDPlayer() 
      {
          Console.WriteLine("打卡DDV播放器");
      }
      public void CloseDVDPlayer() 
      {
          Console.WriteLine("关闭DDV播放器");
      }
  }


  public class Light 
  {
      public void OpenLight() 
      {
          Console.WriteLine("打开灯光");
      }
      public void CloseLight() 
      {
          Console.WriteLine("关闭灯光");
      }
  }
  /// <summary>
  /// 定义一个外观类 
  /// </summary>
  public class MovieFacade 
  {
      /// <summary> 
      /// 在外观类中必须保存有子系统中各个对象 
      /// </summary> 
      private Projector projector;
      private Amplifier amplifier;
      private Screen screen;
      private DVDPlayer dvdPlayer;
      private Light light;
      public MovieFacade() 
      {
          this.projector = new Projector();
          this.amplifier = new Amplifier();
          this.dvdPlayer = new DVDPlayer();
          this.screen = new Screen();
          this.light = new Light();
      }

      public void OpenMovie() 
      {
          //打开投影仪
          projector.OpenProjector();
          //在打开功放
          amplifier.OpenAmplifier();
          //打开屏幕
          screen.OpenScreen();
          //打开ddv
          dvdPlayer.OpenDVDPlayer();
          //打开灯光
          light.OpenLight();
      }

      public void CloseMovie() 
      {
          projector.CloseProjector();

          amplifier.CloseAmplifier();

          screen.CloseScreen();

          dvdPlayer.CloseDVDPlayer();

          light.CloseLight();
      }
  }
}
