   M S B A M L   `   `   `  ????B  >WpfApp3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WpfApp3WpfApp3  5   	       WpfApp3.MainWindow   5   	   _ [MaterialDesignThemes.Wpf, Version=4.8.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:WpfApp3     5   	   -   5          ? Title$  
MainWindow??5
   	   $	??600??6   $	??850??6-   .??5      ?  ? RowDefinitions 5   
   ?? 5      $
??109* ?6   ?? 5      $
??145* ?6   ?? 5      $	??72* ?6   ?? 5      $
??109* ?6    ? ColumnDefinitions 5   
   ?? 5      ?? 5      ?? 5      ?? 5      ?? 5      ?? 5      $??2* ?6   .+?5   
   ?? -   5         ??Name$ PauseButton??5         MaterialDesignIconButton#??[  5       ? ToolTip$ Pause / Play??5      
???????$??3??5!   x   $??33,31,33,30q?6?   $??3??6?   {?6   ?? *DataContext.ControlsEnabled+ ?? RelativeSource ?? *FindAncestor+ ?? AncestorType
 Window.??5"      '  !MaterialDesignThemes.Wpf.PackIcon  
???????   Kind$
 Play=?5$      5%      ?? 5&   
   -   5        $ PreviousTButton??5&      #??[  5'      $ Play previous??5(      
???????$??2??5*   x   $??33,31,33,30q?6?   $??3??6?   {?6   ?? *DataContext.ControlsEnabled+ ?? *FindAncestor+
 Window.??5+        
???????$ PreviousTitle=?5-      5.      ?? 5/   
   -   5        $ NextTButton??5/      #??[  50      $ 	Play next??51      
???????$??4??53   x   $??33,31,33,30q?6?   $??3??6?   {?6   ?? *DataContext.ControlsEnabled+ ?? *FindAncestor+
 Window.??54        
???????$ 	NextTitle=?56      57      ?? 58   
   -   5        $ RestartButton??58      #??[  59      $ Replay??5:      
???????$??1??5<   x   $??33,31,34,30q?6?   $??3??6?   {?6   ?? *DataContext.ControlsEnabled+ ?? *FindAncestor+
 Window.??5=        
???????$ Restart=?5?      5@      ?? 5A   
   -   5        $ ShuffleButton??5A      #??[  5B      $ Shuffle??5C      
???????$??33,31,33,30q?5E   x   $??3??6?   {?6   ?? *DataContext.ControlsEnabled+ ?? *FindAncestor+
 Window.??5F        $ Shuffle=?5G      5H      ?? 5I   
   -   5        $ OpenFileButton??5I       # MaterialDesignRaisedLightButton#??[ 5J      $4 .Resource name: MaterialDesignRaisedLightButton??5K      $??Выбрать папку??5L      $??3??5M   x   $??	0,38,0,39q?6?   $??11(?6?   {?6   ?? *DataContext.ControlsEnabled+ ?? *FindAncestor+
 Window6?   ?? 5N   
   -   5         ??Name$ VolumeSlider??5N      	 ? Value$	 0Q?5O      
 ? Minimum$
 0Q?5P         MaterialDesignDiscreteSlider#??[ 5R       ?? TickPlacement$ BottomRight=?5T      $??5??6   $??60,37,57,37q?6/   $??3??6D    ? Maximum 5Q      ?? *DiscreteHorizontal.Maximum+ ?? TickFrequency 5S      ?? *" DiscreteHorizontal.TickFrequency+5T   Q   ?? 5V   
   -	   5         ??Name$
 LBox??5V      $??1??6K   $??6??6X   $??0,0,0,1q?6l   6}   ?? 5W   
   -
   5         ??Name$
 FBox??5W      $
??Wrap=?6"   $
??0:00??66   $??0,1,57,8q?6B   $??2??6T    J? RenderTransformOrigin$ 0.533,-0.705&?6a   ?? 5X   
   -   5        $
 SBox??5X      $
??Wrap=?6"   $??-0:00??66   $??57,1,0,8q?6C   $??2??6U   $??5??6b    ?? TextAlignment$ Right=?6r   r? 5Y   
   -   5         r?Name$ track??5Y      $??4??6&   $??	114,1,0,6q?66   $??2??6?   ?? 5Z   
   -   5        $ 
TimeSlider??5Z      $
 0Q?5[      $ 50Q?5\      $	 0Q?5]      $??36??6   $	??Top=?6#   $??2??6;   $??6??6H   $!??15,36,15                 ,0q?6\   5^      5_      5a      