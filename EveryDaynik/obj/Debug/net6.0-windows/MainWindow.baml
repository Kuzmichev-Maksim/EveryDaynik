   M S B A M L   `   `   `  ????F  BEveryDaynik, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:EveryDaynikEveryDaynik  5          EveryDaynik.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      +localclr-namespace:EveryDaynik     5        ? Title$  
MainWindow??5      $	??450??6   $	??800??6!   .??5	      ?  ? RowDefinitions 5   
   ?? 5      $
??0.3* ?6   ?? 5      $??1* ?6   ?? 5      $
??0.3* ?6    ? ColumnDefinitions 5   
   ?? 5      $
??1.3* ?6   ?? 5      $??1* ?6   .+?5   
   (  "System.Windows.Controls.DatePicker  -   5          Name$ 	Calendare??5      $??2??6(   $??50(?6<   ???	#FF292929
???   ?6t   ?? 5   
   -   5        $??2??5      $??Удалить??6   $??40(?60   ???	#FFD90000
???????6h   ?? 5   
   -   5         ??Name$ 	ListNotes??5      $??1??6%   62   ? 5   
   $??1??6   $??1??6    5      ?? 5      $
??1.3* ?6#    5      ?? 5       ?? 5!      ?? 5"      ?? 5#      .+?5&      ?? $??40(?6   $??Center=?6&   $??Center=?6A   $??Название:??6^   ?? 5'      -   5         ??Name$ NameNote??5'      $??1??6(   $??20(?65   $??40??6C   ???	#FFD9D9D96O   ?? 5(      $??40(?6   $??Center=?6&   $??Center=?6A   $??2??6^   $??Описание:??6k   ?? 5)      -   5        $ DescNote??5)      $??4??6(   $??20(?65   $??40??6C   ???	#FFD9D9D96O   5*      ? 5,   
   $??1??6   $??2??6    5-      ?? 5.      ?? 5/      .+?52      ?? -   5        $??Создать??52      $??35(?6'   65   ?? 53      -   5        $??Сохранить??53      $??1??6)   $??35(?69   6G   54      56      57      