   M S B A M L   `   `   `  ����E  ATTLChanger, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:TTLChanger
TTLChanger  5   	       TTLChanger.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:TTLChanger     5   	   -   5          �Name$  	AppWindow��5	   	    � Title$ TTL Changer��5   	    � WindowStartupLocation$ CenterScreen=�5
   	   $	��270��5   	   $
��480 ��5   	    � WindowStyle$
 None=�5   	    � AllowsTransparency .   � 
ResizeMode$ NoResize=�5   	    J� SnapsToDevicePixels . &   System.Windows.Media.TextOptions   TextFormattingMode$ Display=�5   	    � DataContext 5          TTLChanger.WindowViewModel  5   
   .��5      �    BgDarkGrayBrush#��[  6   	 � ColumnDefinitions	 5   
   �� 5      $	��200 �6   �� 5      $��* �6   .+�5   
   ��   BgGrayBrush#��[ 6     DropShadowRight
 J� Effect#
 [ 68   �� 5!   
   $��Center=�6   $��Center=�60   $��0 0 0 20q�6M   .+�5"      ��   Segoe UI#��[ 5#      $	��120(�5$      $��Center=�5%      $��Center=�5&      $	��0 0q�5'      $��0q�5(        OrangeToRed#��[ 5)      ��5"      �� *
CurrentTTL+5)      �� 5*      #��[ 5+      $��18(�5,      $��Center=�5-      $��Center=�5.        OrangeBrush#��[ 5/      $��0q�50      $��0q�51      ��5*      �� *
TTLLabel+51      52      � 54   
   $��1��6    � RowDefinitions 55      �� 56      $��30 �6    �� 57      $��84 �6    �� 58      $��* �6    .+�5<      � $��0��6   	 5=      �� 5>      $��* �6'   �� 5?      $��46 �6'   �� 5@      $��46 �6'   .+�5D      �� -   5         ��Name$ 	DragPanel��5D      #��[  60   6^   �� 5G      $��1��6     	NavButton#��[ 6)   $	��—��6p   $��0 1 0 0q�6|   ��6L   �� *MinimizeCommand+5H      �� 5K      $��2��6   #��[ 6)   $	��╳��6m   ��6L   �� *CloseCommand+5L      5N      �� 5Q      $��1��6   $��30��6&   $	��160��62     DropShadowDown#
 [ 5R      #��[ 5S      $��Center=�5T      $��0 0 0 -8q�5U      .+�5V      � $��30��6   	 5W      �� 5X      $	��100 �6+   �� 5Y      $��* �6+   .+�5]      �� -   5         ��Name$ 
TTLTextBox��5]      $��0��62     MainTextBox#��[ 6B   ��6g   �� *TextBoxValue+ �� UpdateSourceTrigger$ PropertyChanged=��� 5`      $��1��6    	 	SetButton#��[	 6-   ��6P   �� *SetTTL+5b      5c      �� 5f      $��2��6   .+�5h      �� .+�5i      ��  
 DefaultCheckBox#��[
 6   $��Create a desktop shortcut��5j      5k      �� 5m      .+�5n      ��   AdditionalButton#��[ 6   #
 [ 5p      $��Set system TTL value��5q      ��5o      �� *SetSystemTTL+5q      5r      �� 5t      .+�5u      �� #��[ 6   #
 [ 5w      $��Create a desktop shortcut��5x      ��5v      �� *CreateShortcut+5x      5y      5}      5      5�      5�      