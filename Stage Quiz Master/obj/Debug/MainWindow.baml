   M S B A M L   `   `   `  ����Q  MStage Quiz Master, Version=0.1.627.1031, Culture=neutral, PublicKeyToken=nullK*clr-namespace:Stage_Quiz_Master.PropertiesStage_Quiz_Master.Properties  5   	   T PMahApps.Metro, Version=1.1.2.0, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4fV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls 5   	   "    Stage_Quiz_Master.MainWindow   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   A
Properties*clr-namespace:Stage_Quiz_Master.Properties     5   	   PControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro     5   	   -   5        (  "MahApps.Metro.Controls.MetroWindow   Name$  	metroMain��5       � Title$ Stage Quiz Portal��5   	    � 
ResizeMode$ NoResize=�6$    � WindowState$ 	Maximized=�6:    � WindowStartupLocation$ CenterScreen=�6R    � WindowStyle$
 None=�6w    � Topmost .     UseNoneWindowStyle .    ShowTitleBar .  	   IgnoreTaskbarOnMaximize	 . !
   ShowSystemMenuOnRightClick
 .     ShowMinButton .     ShowMaxRestoreButton .     ShowCloseButton .  
�������$	��460��6�  $	��812��6�  .��5      ]� $��Stretch=�6   ��. $��Stretch=�6C   .+�5	   
   � $	��Top=�6   $��Stretch=�6$   $
��Auto��6B   $	��Top=�6O   $��30��6g   ���	#FF252525.+�5
      o� $
��Left=�6   $��30��6.   $��Center=�6;   $��	0,0,738,0q�6V   .@�5      m� $��30��6   $��30��6'   |�.  $��0q�6\   ��6E   Z� ��5      �� 5      $��Resources/shutdown.png��6     J� OpacityMask 5      �� 5   "    �� ImageSource$ Resources/shutdown.png��6-    �� Opacity$
 0.75Q�6R   5      .@�5      m� -   5         m�Name$ btnMinimize��5      $��Minimize to Tray��65   $��12(�6O   6]   m� 5      -   5        $ btnShutDown��5      $
��Exit��64    m� InputGestureText$ Alt+F4��6B   $��12(�6\   6�   5      5      �� 5      -   5         ��Name$ 
tbDateTime��5      $
��Auto��6,   |�.   �� TextAlignment$ Center=�6L   $
��Wrap=�6c   $��	Date/Time��6w   $��Stretch=�6�   $��Stretch=�6�   $��14(�6�   $��	30,5,60,0q�6�   
�������$
��Thin"�6�   o� 5      $��Right=�6   $��30��6/   $��Center=�6<   $��0,0,0,0q�6W   .@�5      m� -   5        $ 
miSettings��5      $��30��60   $��30��6;   |�.  $��0q�6p   ��6Y   Z� ��5      �� 5!      $��Resources/settings.png��6     5"      �� 5#   "   $ Resources/settings.png��6-   $
 0.75Q�6R   5%      .@�5(      m� -   5        $ btnProperties��5(      $��Properties..��67   $ Ctrl+P��6M   $��12(�6g   m� 5)      -   5        $ btnAbout��5)      $��About..��62   $��12(�6C   5*      5+      o� 5,      $��Right=�6   $��30��6/   $��Center=�6<   $��0,0,30,0q�6W   .@�5-      m� -   5        $ miTools��5-      $��30��6-   $��30��68   |�.  $��0q�6m   ��6V   Z� ��5/      �� 51      $��Resources/tools.png��6    $��
-6,-6,0,-6q�6=   $��26��6Q   $��26��6\    52      �� 53   "   $ Resources/tools.png��6-   $
 0.75Q�6O   55      .@�58      m� $��Questionaire Manager��6   $��12(�6=   .@�59      m� -	   5        $ btnCreateNewQuestionaire��59   #   $��Create New..��6E   $ Ctrl+N��6[   6u   m� 5:      -
   5        $ btnLoadQuestionaire��5:   #   $��Open Existing..��6@   $ Ctrl+O��6Y   5<      m� 5=      -   5        $ btnCalculator��5=      $��
Calculator��66   $��12(�6J   6X   �� 5>      m� 5?      -   5        $ btnPlay��5?      $��	Play Quiz��60   $ Ctrl+P��6C   6]   5@      5A      5B       � 5C   
   -   5          �Name$ 	mainFrame��5C      $��Stretch=�6$   $��Stretch=�6B     � NavigationUIVisibility$ Hidden=�6^   ��5D      �� 5E      $ Resources/wall.png��6   5G      5I      5K      