   M S B A M L   `   `   `  ����I  ETestAssignment, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:TestAssignmentTestAssignment  5   	       TestAssignment.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:TestAssignment     5   	     � Title$  Top 10 currencies��5   	   $	��450��5	   	   $	��500��5
   	   .��5      �  � RowDefinitions 5   
   �� 5      $
��0.1* �6   �� 5      $��1* �6   .+�5   
   �� $
��Next��6   $
��Left=�5      $��Center=�5      $��20��5      $��40��5      $��10,0,0,0q�5      ��5      �� *switchWindowCommand+�� 5   
   $��1��6   ��6    �� *
Currencies+ �� View 5      �� 5      .P�5      �� $
��Rank��6%    �� DisplayMemberBinding 5   %   �� *Rank+�� 5      $
��Name��6%    5   %   �� *Name+�� 5      $��Symbol��6%    5   %   �� *Symbol+�� 5       $��Price��6%    5!   %   �� *
PriceUsd+5"      5$      5%      5&      